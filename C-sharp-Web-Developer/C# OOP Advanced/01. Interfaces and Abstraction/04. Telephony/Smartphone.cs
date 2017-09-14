using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private List<string> phoneNumber;
        private List<string> webs;

        public Smartphone(List<string> phoneNumber, List<string> webs)
        {
            this.PhoneNumber = phoneNumber;
            this.Webs = webs;
        }

        public List<string> PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }


        public List<string> Webs
        {
            get { return webs; }
            set { webs = value; }
        }

        public void Browse()
        {
            for (int i = 0; i < this.Webs.Count; i++)
            {
                string pattern = @"^[^0-9]+$";
                if (!Regex.IsMatch(this.Webs[i], pattern))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {this.Webs[i]}!");
                }
            }
        }

        public void Call()
        {
            string pattern = @"^[^\D]+$";

            for (int i = 0; i < this.PhoneNumber.Count; i++)
            {
                if (!Regex.IsMatch(this.PhoneNumber[i], pattern))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    Console.WriteLine($"Calling... {this.PhoneNumber[i]}");
                }
            }
        }
    }
}