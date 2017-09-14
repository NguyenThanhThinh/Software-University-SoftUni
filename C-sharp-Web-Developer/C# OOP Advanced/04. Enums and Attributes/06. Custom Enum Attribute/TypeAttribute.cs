using System;

namespace _06.Custom_Enum_Attribute
{
    [AttributeUsage(AttributeTargets.All)]
    public class TypeAttribute : Attribute
    {
        private string type;
        private string category;
        public string description;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}