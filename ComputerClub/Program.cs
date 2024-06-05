namespace ComputerClub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClub club = new ComputerClub(5);
            club.Work();
        }
    }

    class ComputerClub
    {
        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();

        public ComputerClub(int computersCount)
        {
            Random random = new Random();

            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(random.Next(5,15)));
            }
            
            CreateNewClients(20, random);
        }

        public void CreateNewClients(int count, Random random)
        {
            for (int i = 0; i < count; i++)
            {
                _clients.Enqueue(new Client(random.Next(100,300), random));
            }
        }

        public void Work()
        {
            while (_clients.Count > 0)
            {
                Client newClient = _clients.Dequeue();
                Console.WriteLine($"Баланс компьютерного клуба: {_money} руб. Ждем нового клиента.");
                Console.WriteLine($"У вас новый клиент, и он хочет купить {newClient.DesiredMinutes} минут");
                ShowAllComputerState();

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowAllComputerState()
        {
            Console.WriteLine("\nСписок всех компьютеров:");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                _computers[i].ShowState();
            }
        }
    }

    class Computer
    {
        private Client _client;
        private int _minutesRemaining;

        public bool IsTaken
        {
            get { return _minutesRemaining > 0; }
        }
        
        public int PricePerMinute { get; private set; }

        public void BecomeTaken(Client client)
        {
            _client = client;
            _minutesRemaining = _client.DesiredMinutes;
        }

        public void BecomeEmpty()
        {
            _client = null;
        }

        public void SpendOneMinute()
        {
            _minutesRemaining--;
        }

        public void ShowState()
        {
            if(IsTaken)
                Console.WriteLine($"Компьютер занят, осталось минут: {_minutesRemaining}");
            else
                Console.WriteLine($"Компьютер свободен, цена за минуту: {PricePerMinute}");
        }
        
        public Computer(int pricePerMinute)
        {
            PricePerMinute = pricePerMinute;
        }
    }


    class Client
        {
            private int _money;
            public int DesiredMinutes { get; private set; }

            public Client(int money, Random random)
            {
                _money = money;
                DesiredMinutes = random.Next(10, 30);
            }
        }
    }


