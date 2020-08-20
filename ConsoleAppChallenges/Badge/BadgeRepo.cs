using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace Badge
{
    public class BadgeRepo
    {
        private Dictionary<int, Badge> _BadgeDictionary = new Dictionary<int, Badge>();
        private List<string> _doorname = new List<string>();
        public void AddNewBadges(Badge badges)
        {
            //for (int i = _BadgeDictionary.Count; i < _BadgeDictionary.Count - 1; i++)
            //{
            //    _BadgeDictionary.Add(i, badges);
            //}

            //if (_BadgeDictionary.Count >= 0)
            //{
            //    int num = _BadgeDictionary.Count + 1;
            //    _BadgeDictionary.Add(num, badges);
            //    _doorname.Add(badges.DoorName.ToString());

            //}
            _BadgeDictionary.Add(badges.BadgeID, badges);


            //_BadgeDictionary.Add();
            Console.WriteLine(badges);
            Console.WriteLine(_BadgeDictionary.Count);

        }

        public Badge GetById(int id)
        {
            foreach (Badge item in _BadgeDictionary.Values)
            {
                if (item.BadgeID == id)
                {
                    return item;
                }
            }
            return null;
        }

        //public Badges GetDoors(int id,string doornames)
        //{
        //    Badges content = GetById(id);
        //    foreach (Badges item in _BadgeDictionary.Values)
        //    {
        //        if(id == item.BadgeID)
        //        {
        //            _BadgeDictionary[id] = content.ToString();
        //        }
        //    }
        //}


        public bool AddDoorsToBadge(int id, string name)
        {
            Badge content = GetById(id);
            
            if(content.DoorName != null)
            {
                return false;
            }


            foreach (Badge badge in _BadgeDictionary.Values)
            {
                if(badge.DoorName != null)
                {
                    _doorname.Add(name);
                    return true;
                }
            }
            return false;
        }


        // i think i need to make the doornames an array so i can delete a specific item in the array
        public bool RemoveDoorsFromBadge(string doorname)
        {
            //Badge content = GetById(id);

            //if (content == null)
            //{
            //    return false;
            //}

            int initialCount = _BadgeDictionary.Count;
            _doorname.Remove(doorname);

            //update the content.DoorNames to remove those characters
            //content.DoorNames.

            //_BadgeDictionary.Remove(id);
            foreach (Badge badge in _BadgeDictionary.Values)
            {
                if (badge.DoorName != null)
                {
                    _doorname.Remove(doorname);
                    return true;
                }
            }

            if (initialCount > _BadgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateBadges(int ID, Badge badges)
        {
            Badge content = GetById(ID);


            if (_BadgeDictionary.ContainsKey(content.BadgeID))
            {
                for (int i = 0; i < _BadgeDictionary.Count; i++)
                {
                    var testing = _BadgeDictionary.ElementAt(i).Key;
                    var testingOne = _BadgeDictionary.ElementAt(i).Value;

                    int index = _BadgeDictionary.ElementAt(i).Key;

                    _BadgeDictionary[index] = badges;
                    return true;
                }
            }
            return false;
        }

        public Dictionary<int, Badge> GetBadges()
        {

            return _BadgeDictionary;

        }

        public List<string> GetDoors()
        {
            return _doorname;
        }


        public Dictionary<int, Badge> GetSingle()
        {
            if (_BadgeDictionary.Count > 0)
            {
                return _BadgeDictionary;
            }
            return null;
        }

    }
}
