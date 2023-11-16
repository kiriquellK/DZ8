namespace Lesson8
{
    internal class Bus
    {
        private double _speed;

        private double _maxSpeed;

        private int _maxNumberOfPassengers;

        private List<string> _passengersSurnames = new List<string>();

        private bool _hasEmpty;

        private Dictionary<int, string> _busSeats = new Dictionary<int, string>();

        public double MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            private set
            {
                if (value >= 0)
                {
                    _maxSpeed = value;
                }
                else
                {
                    Console.WriteLine("Значение максимальной скорости введено некорректно");
                }
            }
        }

        public double Speed
        {
            get
            {
                return _speed;
            }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Невозможно двигаться медленнее 0 км/ч");
                    _speed = 0;
                }
                else if (value > _maxSpeed)
                {
                    Console.WriteLine("Невозможно превысить лимит скорости");
                    _speed = _maxSpeed;
                }
                else
                {
                    _speed = value;
                }
            }
        }

        public int MaxNumberOfPassengers
        {
            get
            {
                return _maxNumberOfPassengers;
            }
            private set
            {
                if (value > 0)
                {
                    _maxNumberOfPassengers = value;
                }
                else
                {
                    Console.WriteLine("Количество возможных пассажиров должно быть больше 0");
                }
            }
        }

        public List<string> PassengersSurnames
        {
            get
            {
                return _passengersSurnames;
            }
            set
            {
                _passengersSurnames = value;
            }
        }

        public Dictionary<int, string> BusSeats
        {
            get
            {
                return _busSeats;
            }
        }

        public Bus(double maxSpeed, int maxNumberOfPassengers)
        {
            MaxSpeed = maxSpeed;
            MaxNumberOfPassengers = maxNumberOfPassengers;
            _hasEmpty = true;
        }

        public void LoadingPassengers(string newSurname)
        {
            if (!String.IsNullOrWhiteSpace(newSurname))
            {
                if (_hasEmpty)
                {
                    for (int i = 1; i < _maxNumberOfPassengers + 1; i++)
                    {
                        if (!_busSeats.ContainsKey(i))
                        {
                            _busSeats.Add(i, newSurname);
                            break;
                        }
                    }
                    _hasEmpty = _busSeats.Count < _maxNumberOfPassengers;
                    _passengersSurnames.Add(newSurname);
                }
                else
                {
                    Console.WriteLine($"Извините, {newSurname}, все места заняты.");
                }
            }
            else
            {
                Console.WriteLine($"Фамилия должна быть определена");
            }
        }

        public void LoadingPassengers(List<string> newSurnames)
        {
            foreach (string surname in newSurnames)
            {
                this.LoadingPassengers(surname);
            }
        }

        public void UnloadingPassengers(string unloadedSurname)
        {
            if (!String.IsNullOrWhiteSpace(unloadedSurname))
            {
                if (_busSeats.ContainsValue(unloadedSurname))
                {
                    foreach (KeyValuePair<int, string> seat in _busSeats)
                    {
                        if (seat.Value == unloadedSurname)
                        {
                            _busSeats.Remove(seat.Key);
                            _hasEmpty = true;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Пассажира с такой фамилией нет в автобусе");
                }
            }
            else
            {
                Console.WriteLine($"Фамилия должна быть не пустой");
            }
        }
        public void UnloadingPassengers(List<string> newSurnames)
        {
            foreach (string surname in newSurnames)
            {
                this.UnloadingPassengers(surname);
            }
        }

        public void IncreaseSpeed(double speedDifference)
        {
            Speed = _speed + speedDifference;
        }

        public void ReduceSpeed(double speedDifference)
        {
            Speed = _speed - speedDifference;
        }
    }
}
