namespace F_Delegation
{
    
            namespace F_Delegation
    {








        public class Car
        {
            int speed = 0;

            public event Action <int> TooFastDriving;

            //public delegate void TooFast(int currentSpeed);

            //private TooFast tooFast;
            public void Start()
            {
                speed = 10;
            }
            public void Accelerate()
            {
                speed += 10;
                if (speed > 80)
                    if(TooFastDriving != null)
                        TooFastDriving(speed);

            }
            public void Stop()
            {
                speed = 0;
            }

            //public void RegisisterOnTooFast(TooFastDriving tooFast)
            //{
            //    this.TooFastDriving += tooFast;//могу добавить еще 1 вывод из метода HandleOnToFast. Используя -= могу убрать 1 вывод
            //}
        }
        class Program
        {
            
            static Car car;
            static void Main(string[] args)
            {
                car = new Car();
                car.TooFastDriving += HandleOnTooFast;
                car.TooFastDriving += HandleOnTooFast;
                car.TooFastDriving += HandleOnTooFast;

                //car.RegisisterOnTooFast(HandleOnTooFast);
                car.Start();
                for (int i = 0; i < 10; i++)
                {
                    car.Accelerate();
                }
                Console.ReadLine();

            }

            private static void HandleOnTooFast(int speed)
            {
                Console.WriteLine($"Wow, current speed = {speed}");
                car.Stop();
            }
        }
        

    }
}
    
