namespace _02.Photo
{
    public static class TagTransformer
    {
        private const string Pound = "#";
        private const int RequiredLeght = 20;

        public static string Transform(string tag)
        {
            string formattedTag = tag;

            formattedTag = formattedTag.Replace(" ", string.Empty);

            if (!formattedTag.StartsWith(Pound))
            {
                formattedTag = Pound + formattedTag;
            }

            if (formattedTag.Length > RequiredLeght)
            {
                formattedTag = formattedTag.Substring(0, RequiredLeght);
            }

            return formattedTag;
        }
    }
}