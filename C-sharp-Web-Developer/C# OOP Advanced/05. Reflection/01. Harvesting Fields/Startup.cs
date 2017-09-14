using System;
using System.Reflection;
using System.Text;
using _01HarestingFields;

namespace _01.Harvesting_Fields
{
    public class Startup
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var sb = new StringBuilder();
            while (!command.Equals("HARVEST"))
            {
                switch (command)
                {
                    case "private":
                        sb.Append(GetPrivateFields());
                        break;
                    case "protected":
                        sb.Append(GetProtectedFields());
                        break;
                    case "public":
                        sb.Append(GetPublicFields());
                        break;
                    case "all":
                        sb.Append(GetAllFields());
                        break;
                }

                command = Console.ReadLine();
            }

            Console.Write(sb);
        }

        private static string GetPrivateFields()
        {
            var sb = new StringBuilder();
            var privateFields = typeof(HarvestingFields).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var privateField in privateFields)
            {
                var protection = "private";
                var typeName = privateField.FieldType.Name;
                if (privateField.IsPrivate)
                {
                    sb.AppendLine($"{protection} {typeName} {privateField.Name}");
                }
            }
            return sb.ToString();
        }

        private static string GetProtectedFields()
        {
            var sb = new StringBuilder();
            var protectedFields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var protectedField in protectedFields)
            {
                var protection = GetAccessModifier(protectedField);
                var typeName = protectedField.FieldType.Name;
                if (protectedField.IsFamily)
                {
                    sb.AppendLine($"{protection} {typeName} {protectedField.Name}");
                }
            }
            return sb.ToString();
        }

        private static string GetPublicFields()
        {
            var sb = new StringBuilder();
            var publicFields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var publicField in publicFields)
            {
                var protection = GetAccessModifier(publicField);
                var typeName = publicField.FieldType.Name;
                sb.AppendLine($"{protection} {typeName} {publicField.Name}");
            }
            return sb.ToString();
        }

        private static string GetAllFields()
        {
            var sb = new StringBuilder();
            var AllFields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in AllFields)
            {
                var protection = GetAccessModifier(field);
                var typeName = field.FieldType.Name;
                sb.AppendLine($"{protection} {typeName} {field.Name}");
            }
            return sb.ToString();
        }

        private static string GetAccessModifier(FieldInfo privateField)
        {
            if (privateField.IsPrivate)
            {
                return AccessModifier.Private.ToString().ToLower();
            }
            if (privateField.IsFamily)
            {
                return AccessModifier.Protected.ToString().ToLower();
            }
            return AccessModifier.Public.ToString().ToLower();
        }
    }
}