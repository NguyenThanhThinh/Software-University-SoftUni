using System;
using System.Linq;

namespace _09.Pet_Clinics
{
    public class Clinic
    {
        private Pet[] rooms;
        private string name;
        private int magicNum;
        private bool leftSide;
        private int middleIndex;
        private bool settled;

        public Clinic(Pet[] rooms, string name)
        {
            this.Rooms = rooms;
            this.Name = name;
            this.MagicNum = 0;
            this.leftSide = true;
            this.middleIndex = this.Rooms.Length / 2;
            this.settled = true;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Pet[] Rooms
        {
            get { return rooms; }
            set
            {
                if (value.Length % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                rooms = value;
            }
        }

        private int MagicNum
        {
            get { return magicNum; }
            set
            {
                if (value == this.Rooms.Length / 2)
                {
                    magicNum = 0;
                }
                magicNum = value;
            }
        }

        public bool Add(Pet pet)
        {
            if (!HasEmptyRooms())
            {
                return false;
            }

            if (this.MagicNum == 0)
            {
                if (this.Rooms[this.middleIndex] is null)
                {
                    this.Rooms[this.middleIndex] = pet;
                }
                this.MagicNum++;
            }
            else
            {
                while (this.settled)
                {
                    if (this.leftSide && this.Rooms[this.middleIndex - this.MagicNum] is null)
                    {
                        this.Rooms[this.middleIndex - this.MagicNum] = pet;
                        this.leftSide = false;
                        this.settled = false;
                    }
                    else if (this.Rooms[this.middleIndex + this.MagicNum] is null)
                    {
                        this.Rooms[this.middleIndex + this.MagicNum] = pet;
                        this.MagicNum++;
                        this.leftSide = true;
                        this.settled = false;

                        if (this.MagicNum - this.middleIndex < 0)
                        {
                            this.MagicNum = this.middleIndex;
                        }
                    }
                }
                this.settled = true;
            }

            return true;
        }

        public bool HasEmptyRooms()
        {
            if (this.Rooms.Any(r => r is null))
            {
                return true;
            }
            return false;
        }

        public bool Release()
        {
            for (int i = middleIndex; i < this.Rooms.Length; i++)
            {
                if (!(this.Rooms[middleIndex] is null))
                {
                    this.Rooms[middleIndex] = null;
                    return true;
                }
            }

            for (int i = 0; i < middleIndex; i++)
            {
                if (!(this.Rooms[middleIndex] is null))
                {
                    this.Rooms[middleIndex] = null;
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                if (this.Rooms[i] is null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(this.Rooms[i].ToString());
                }
            }
        }

        public void Print(int room)
        {
            if (this.Rooms[room - 1] is null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(this.Rooms[room - 1].ToString());
            }
        }
    }
}