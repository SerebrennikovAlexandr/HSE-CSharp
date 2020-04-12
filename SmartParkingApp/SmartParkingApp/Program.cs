using System;

namespace ParkingApp
{
    class Program
    {
        static Random rand = new Random();
        // Array of all users
        static User[] users;


        // Parameters for testing
        const int numberOfUsers = 4;
        const int parkingManagerCapacity = 3;


        // Emulates skipping time in ParkingManager. Is needed for testing.
        static void IncreaseTime(ParkingManager parkingManager, double diff)
        {
            parkingManager.CurrentTime = parkingManager.CurrentTime.AddMinutes(diff);
        }

        static string CreateUserName()
        {
            string[] names = {"Bob", "Hans", "Alice", "Johan", "Ivan",
                "Stephan", "Sergey", "Mark", "Julia", "Ella",  "Anna",
                "Robert", "Kate", "Olga"};
            return names[rand.Next(names.Length)];
        }

        // Format is XXX, X - number
        static string CreateUserCarPlateNumber()
        {
            string res = "";
            for(int i = 0; i < 3; i++)
            {
                string t = ((char)rand.Next('0', '9' + 1)).ToString();
                res += t;
            }
            return res;
        }

        // Format is XXXXXXXXXXX, X - number
        static string CreateUserPhone()
        {
            string res = "";
            for (int i = 0; i < 11; i++)
            {
                string t = ((char)rand.Next('0', '9' + 1)).ToString();
                res += t;
            }
            return res;
        }

        public static int GetInt(string varname)
        {
            Console.Write("Enter integer positive number - " + varname + " = ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine("Invalid input. Repeat");
                Console.Write("Enter " + varname + ": ");
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Smart parking application\n");

            users = new User[numberOfUsers];

            // Create users
            Console.WriteLine($"We create {users.Length} users:");
            for (int i = 0; i < users.Length; i++)
            {
                users[i] = new User(CreateUserName(), CreateUserCarPlateNumber(), CreateUserPhone());
                Console.WriteLine($"User {i + 1}: " + users[i]);
            }
            Console.WriteLine("\n");

            // Create ParkingManager with capacity of 3 cars
            ParkingManager parkingManager = new ParkingManager(parkingManagerCapacity);

            // We test EnterParking method, 1 user won't have place to park his car
            Console.WriteLine("We want to test EnterParking method:");

            TestEnterParkingMethod(parkingManager);

            int activeUsersLeft = Math.Min(numberOfUsers, parkingManagerCapacity);

            // We test paying and leaving parking systems
            Console.WriteLine("Now we are testing paying and leaving parking systems.\n");
            Console.WriteLine(
                "For each user you'll have to input the number of minutes\n" +
                "he was abcent and the number of minutes passed between\n" +
                "paying and trying to leave the parking.\n");

            TestLeavingParkingSystem(parkingManager, activeUsersLeft);

            Console.WriteLine("Press any button to exit . . .");
            Console.ReadKey();
        }

        static void TestEnterParkingMethod(ParkingManager parkingManager)
        {
            ParkingSession session;
            for (int i = 0; i < users.Length; i++)
            {
                session = parkingManager.EnterParking(users[i].CarPlateNumber);
                if (session == null)
                {
                    Console.WriteLine($"There's no place for {users[i].Name} to park the Car {users[i].CarPlateNumber}.");
                }
                else
                {
                    Console.WriteLine($"{users[i].Name} parked the car {users[i].CarPlateNumber}. Related session:");
                    Console.WriteLine(session);
                    users[i].TicketNumber = session.TicketNumber;
                }
                Console.WriteLine();
            }
        }

        static void TestLeavingParkingSystem(ParkingManager parkingManager, int activeUsersLeft)
        {
            ParkingSession session;
            for (int i = 0; i < activeUsersLeft; i++)
            {
                Console.WriteLine("How many minutes have passed?");
                int passed = GetInt("minutes passed");
                // We skip some time
                IncreaseTime(parkingManager, passed);
                Console.WriteLine($"We skipped {passed} minutes.\n");
                Console.WriteLine($"{users[i].Name} wants to leave with car {users[i].CarPlateNumber}.");

                // We check, if the user should pay for parking
                if (parkingManager.TryLeaveParkingWithTicket((int)users[i].TicketNumber, out session))
                {
                    Console.WriteLine($"Exit for car {users[i].CarPlateNumber} is granted. Related session:");
                    Console.WriteLine(session);
                }
                else
                {
                    Console.WriteLine($"Exit for car {users[i].CarPlateNumber} is denied. Payment needed.");
                    decimal rate = parkingManager.GetRemainingCost((int)users[i].TicketNumber);
                    Console.WriteLine($"{users[i].Name} has to pay {rate} roubles.");
                    Console.WriteLine($"{users[i].Name} pays immidiately.\n");
                    parkingManager.PayForParking((int)users[i].TicketNumber, rate);

                    Console.WriteLine("How many minutes have passed?");
                    passed = GetInt("minutes passed");
                    // We skip some time
                    IncreaseTime(parkingManager, passed);
                    Console.WriteLine($"We skipped {passed} minutes.\n");

                    // We check, if the user should pay extra money for being late to leave
                    if (parkingManager.TryLeaveParkingWithTicket((int)users[i].TicketNumber, out session))
                    {
                        Console.WriteLine($"Exit for car {users[i].CarPlateNumber} is granted. Related session:");
                        Console.WriteLine(session);
                    }
                    else
                    {
                        Console.WriteLine($"Exit for car {users[i].CarPlateNumber} is denied. Payment needed.");
                        rate = parkingManager.GetRemainingCost((int)users[i].TicketNumber);
                        Console.WriteLine($"{users[i].Name} has to extra pay {rate} roubles.");
                        Console.WriteLine($"{users[i].Name} pays.\n");
                        parkingManager.PayForParking((int)users[i].TicketNumber, rate);

                        if (parkingManager.TryLeaveParkingWithTicket((int)users[i].TicketNumber, out session))
                        {
                            Console.WriteLine($"Exit for car {users[i].CarPlateNumber} is granted. Related session:");
                            Console.WriteLine(session);
                        }
                        else
                        {
                            Console.WriteLine("ERROR OF THE SYSTEM");
                        }
                    }
                }
            }
        }
    }
}
