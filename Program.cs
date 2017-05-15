using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace NatureSimulationGen2
{
    class Program
    {
        public class World
        {
            public int X; //shirina mira
            public int Y; //visota mira

            public World(int x, int y)
            {
                X = x;
                Y = y;
            }

            public object[,] CreateWorld(int x, int y)
            {
                object[,] world = new object[x, y];
                return world;
            }
        }


        public class Duck
        {
            public int X;
            public int Y;
            public int Speed;
            public Duck(int x, int y, int s)
            {
                X = x - 1;
                Y = y - 1;
                Speed = s;
            }

            public void DoStep(int x, int y, int s)
            {
                Random dirrand = new Random(((int)DateTime.Now.Ticks));
                int direction = dirrand.Next(1, 9);

                while (direction == 1 || direction == 3 || direction == 5 || direction == 7)
                {
                    direction = dirrand.Next(1, 9);
                }

                if (direction == 6)
                {
                    int newCoordX = X + s;

                    if (newCoordX >= 8)                    //Мир сделать классом, здесь указать размер массива по X
                    {
                        X = x;
                    }

                    else
                    {
                        X = X + s;
                    }
                }

                else if (direction == 4)
                {
                    int newCoordX = X - s;

                    if (newCoordX <= 0)
                    {
                        X = x;
                    }

                    else
                    {
                        X = X - s;
                    }
                }

                else if (direction == 8)
                {
                    int newCoordY = Y - s;

                    if (newCoordY <= 0)
                    {
                        Y = y;
                    }

                    else
                    {
                        Y = Y - s;
                    }
                }

                else if (direction == 2)
                {
                    int newCoordY = Y + s;

                    if (newCoordY >= 9)             //Сделать тут длину массива world по Y
                    {
                        Y = y;
                    }

                    else
                    {
                        Y = Y + s;
                    }
                }
                Console.WriteLine("Направление движения " + direction);
            }
        }

        static void Main()
        {
            Duck duck1 = new Duck(3, 3, 1);              //Зарандомить появление утки

            List<Duck> ducks = new List<Duck>();
            ducks.Add(duck1);

            //int x = 8; //Размер мира по координате x - зарандомить
            //int y = 9; //Размер мира по координате y

            var world = Objects();

            //World world = new World(8, 8);

            CreateWorld(world.X, world.Y);

            for (int y1 = 0; y1 < y; y1++)
            {
                for (int x1 = 0; x1 < x; x1++)
                {
                    world[x1, y1] = "0";
                    Console.Write(world[x1, y1]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Добавим утку в мир");

            foreach (var duck in ducks)
            {
                world[duck.X, duck.Y] = ">";
            }

            for (int y1 = 0; y1 < y; y1++)
            {
                for (int x1 = 0; x1 < x; x1++)
                {
                    Console.Write(world[x1, y1]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("End of Turn");

            Console.ReadLine();

            for (int y1 = 0; y1 < y; y1++)
            {
                for (int x1 = 0; x1 < x; x1++)
                {
                    world[x1, y1] = "0";
                }
            }

            duck1.DoStep(duck1.X, duck1.Y, duck1.Speed);

            foreach (var duck in ducks)
            {
                world[duck.X, duck.Y] = ">";
            }

            for (int y1 = 0; y1 < y; y1++)
            {
                for (int x1 = 0; x1 < x; x1++)
                {
                    Console.Write(world[x1, y1]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("End of Turn");
            Console.ReadLine();

        }

        public static object[,] Objects(int x, int y)
        {
            object[,] world = new object[x, y];
            return world;
        }
    }
}