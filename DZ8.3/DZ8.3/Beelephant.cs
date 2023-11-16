namespace Classes
{
    internal class Beelephant
    {
        private int _beeNumber;

        private int _elephantNumber;

        public int BeeNumber
        {
            get
            {
                return _beeNumber;
            }
            private set
            {
                if (value > 100)
                {
                    Console.WriteLine("Невозможно стать больше 100. Число пчелы 100.");
                    _beeNumber = 100;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно стать меньше 0. Число пчелы 0.");
                    _beeNumber = 0;
                }
                else
                {
                    _beeNumber = value;
                }
            }
        }

        public int ElephantNumber
        {
            get
            {
                return _elephantNumber;
            }
            private set
            {
                if (value > 100)
                {
                    Console.WriteLine("Невозможно стать больше 100. Число слона 100.");
                    _elephantNumber = 100;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно стать меньше 0. Число слона 0.");
                    _elephantNumber = 0;
                }
                else
                {
                    _elephantNumber = value;
                }
            }
        }

        public Beelephant(int beeNumber, int elephantNumber)
        {
            ElephantNumber = elephantNumber;
            BeeNumber = beeNumber;
        }

        public bool Fly()
        {
            return !(_beeNumber < _elephantNumber);
        }

        public string Trumpet()
        {
            string elephantSound = "tu - tu - doo - doo";
            string beeSound = "wzzzz";
            if (!(_beeNumber > _elephantNumber))
            {
                return elephantSound;
            }
            else
            {
                return beeSound;
            }
        }

        public void Eat(string meal, int value)
        {
            if (value > 0 & value < 101)
            {
                switch (meal)
                {
                    case "nectar":
                        BeeNumber += value;
                        ElephantNumber -= value;
                        break;
                    case "grass":
                        BeeNumber -= value;
                        ElephantNumber += value;
                        break;
                    default:
                        Console.WriteLine($"{meal} - не съедобно");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Заданное количество еды невозможно съесть");
            }
        }
    }
}
