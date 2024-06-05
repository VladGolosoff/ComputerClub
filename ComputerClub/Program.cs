namespace ComputerClub
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class ComputerClub
    {
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();
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


