using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Badge
{
    public class BadgesUI
    {
        private bool _IsOpen = true;
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void start()
        {
            SeedContent();
            Menu();
        }

        private void Menu()
        {
            while (_IsOpen)
            {
                string input = getBadgeSelection();
                openBadgeItem(input);
            }
        }

        private string getBadgeSelection()
        {
            Console.Clear();
            Console.WriteLine
                (
                "Hello Security Admin, What would you like to do?\n" +
                "1 - Add a badge\n" +
                "2 - Edit a Badge\n" +
                "3 - List all Badges\n"
                );
            string input = Console.ReadLine();
            return input;
        }

        private void openBadgeItem(string input)
        {
            Console.Clear();
            switch (input)
            {
                case "1":
                    //Add a badge
                    AddNewBadge();
                    break;
                case "2":
                    // edit a badge
                    updateBadge();
                    break;
                case "3":
                    //list all badges
                    DisplayAllBadges();
                    break;
                default:
                    Console.WriteLine("Please select a valid option!");
                    break;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayAllBadges()
        {
            Dictionary<int, Badge> listBadges = _badgeRepo.GetBadges();
            foreach (Badge item in listBadges.Values)
            {
                DisplayBadges(item);
            }
            

        }

        private void DisplayBadges(Badge badges)
        {
            List<string> doornames = new List<string>();
            Dictionary<int, Badge> testing = _badgeRepo.GetBadges();

            Console.WriteLine($"{"Badge Num: ",-5} {"Badge Name"}");
            //badges.ToString();
            Thread.Sleep(75);
            Console.WriteLine($"{badges.BadgeID,-11}  {badges.BadgeName}");
            foreach (Badge item in testing.Values)
            {
                List<string> doors = item.DoorName;
                foreach (var test in doors)
                {
                    Console.WriteLine($"Access Doors: {test}");
                }
            }
        }




        private void AddNewBadge()
        {
            List<string> doornames = new List<string>();
            var testing = _badgeRepo.GetBadges();
            Console.WriteLine("What is the number on the badge: ");
            string badgeid = Console.ReadLine();
            int badgeId = int.Parse(badgeid);

            if (testing.ContainsKey(badgeId))
            {
                Console.WriteLine("key exists pick a new one");
                Console.ReadKey();
                Console.Clear();
                AddNewBadge();
            } 

            //nest in a while loop
            Console.WriteLine("list a door that it needs access to: ");
            string AccessDoors = Console.ReadLine();
            doornames.Add(AccessDoors);

            Console.WriteLine("Give the badge a name");
            string badgename = Console.ReadLine();

            Badge newItem = new Badge(badgeId, doornames, badgename);

            _badgeRepo.AddNewBadges(newItem);
        }

        //private void UpdateItem()
        //{
        //    Badges badge = _badgeRepo.UpdateBadges();
        //    updateBadge(badge);
        //}

        private void DisplayBadgeItem(Badge badge)
        {
            Console.WriteLine($"{badge.BadgeID} has access to doors {badge.DoorName}");
        }

        private void updateBadge()
        {
            Console.WriteLine("Which Badge id would you like to update?: ");
            string input = Console.ReadLine();
            int badgeID = int.Parse(input);

            Dictionary<int, Badge> listBadges = _badgeRepo.GetBadges();


            foreach (Badge item in listBadges.Values)
            {
                List<string> doors = item.DoorName;
                foreach (var test in doors)
                {
                    Console.WriteLine($"{item.BadgeID} has access to doors:  {test}");
                }
            }


            Console.WriteLine(
                "What would you like to do:\n" +
                "1. Remove a Door\n" +
                "2. Add a Door\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    //remove a door
                    RemoveDoor();
                    break;
                case "2":
                    //add a door
                    AddDoor();
                    break;
                default:
                    Console.WriteLine("Plase select a valid option");
                    break;
            }
            Console.Clear();
            foreach (Badge item in listBadges.Values)
            {
                List<string> doors = item.DoorName;
                foreach (var test in doors)
                {
                    Console.WriteLine($"{item.BadgeID} has access to doors {test}");
                }
            }

        }

        private void AddDoor()
        {
            Dictionary<int, Badge> sure = _badgeRepo.GetBadges();
            Console.WriteLine("What door would you like to add");
            string input = Console.ReadLine();
            //doornames.Add(input);
            //foreach (Badge item in sure.Values)
            //{
            //    _badgeRepo.AddDoorsToBadge(item.BadgeID, input);
            //}

            foreach (Badge item in sure.Values)
            {
                List<string> doors = item.DoorName;
                doors.Add(input);
            }
        }

        private void RemoveDoor()
        {
            Dictionary<int, Badge> listBadges = _badgeRepo.GetBadges();
            Console.WriteLine("Which door would you like to remove?: ");
            string userInput = Console.ReadLine();
            foreach (Badge item in listBadges.Values)
            {
                List<string> doors = item.DoorName;
                doors.Remove(userInput);
            }
        }

        private void SeedContent()
        {
            //Badges itemOne = new Badges(1, "A1, D4, F4", "Dev Badge");
            //Badges itemTwo = new Badges(2, "A2, B3, G5", "Intern Badge");
            //Badges itemThree = new Badges(3, "All Doors", "Security Badge");

            //_badgeRepo.AddNewBadges(itemOne);
            //_badgeRepo.AddNewBadges(itemTwo);
            //_badgeRepo.AddNewBadges(itemThree);
        }
    }
}
