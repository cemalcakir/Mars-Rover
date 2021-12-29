// See https://aka.ms/new-console-template for more information

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            while (true)
            {
                int[] WidthAndHeight = GetPlateauCoordinates();
                Plateau CurrentPlateau = new Plateau(WidthAndHeight);

                AddRoversAndInputs(CurrentPlateau);

            }
        }

        static void AddRoversAndInputs(Plateau currentPlateau)
        {
            while (true)
            {
                Console.WriteLine("Enter Rover Coordinates and Direction (X Y Direction):");
                Console.WriteLine("Enter 'F' to exit and list all existing rovers");

                string input = Console.ReadLine();

                if (input == null)
                {
                    continue;
                }

                if (input.ToLower() == "f")
                {
                    Console.WriteLine("All rovers in the current Plateau:");
                    currentPlateau.ListRovers();
                    break;
                }

                string[] RoverInfo = input.ToLower().Split(' ');
                try
                {
                    AddSingleRoverAndInput(currentPlateau, RoverInfo);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


            }
        }

        static void AddSingleRoverAndInput(Plateau currentPlateau, string[] roverInfo)
        {
            Rover CurrentRover = AddSingleRover(currentPlateau, roverInfo);
            List<char> MovementInput = GetMovementInputs();
            CurrentRover.Move(MovementInput);
        }

        static Rover AddSingleRover(Plateau currentPlateau, string[] roverInfo)
        {
            int LocationX = int.Parse(roverInfo[0]);
            int LocationY = int.Parse(roverInfo[1]);
            char Direction = char.Parse(roverInfo[2]);

            if (LocationX > currentPlateau.BorderX)
            {
                throw new Exception("You cannot place a Rover out of bounds for existing Plateau");
            }

            if (LocationY > currentPlateau.BorderY)
            {
                throw new Exception("You cannot place a Rover out of bounds for existing Plateau");
            }

            if (!"nswe".Contains(Direction.ToString().ToLower()))
            {
                throw new Exception("You can only specify N(North) S(South) E(East) W(West)");
            }

            Rover rover = new Rover(LocationX, LocationY, Direction, currentPlateau);

            currentPlateau.AddRover(rover);
            return rover;
        }

        static List<char> GetMovementInputs()
        {
            Console.WriteLine("Enter movement inputs for the Rover (Valid inputs are L-R-M)");
            string input = Console.ReadLine();

            List<char> output = new List<char>();

            foreach (char c in input.ToLower())
            {
                if (!"lrm".Contains(c.ToString().ToLower()))
                {
                    throw new Exception("You can only specify L-R-M for Rover movement input");
                }
                output.Add(c);
            }
            return output;
        }

        static int[] GetPlateauCoordinates()
        {
            while (true)
            {
                Console.WriteLine("Enter Plateau Width and Height (Number Number):");
                string[] WidthAndHeightStr = Console.ReadLine().Split(' ');

                try
                {
                    int[] WidthAndHeight = { int.Parse(WidthAndHeightStr[0]), int.Parse(WidthAndHeightStr[1]) };
                    return WidthAndHeight;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Plase enter the input as specified (Number Number) ");
                }

            }
        }
    }
}
