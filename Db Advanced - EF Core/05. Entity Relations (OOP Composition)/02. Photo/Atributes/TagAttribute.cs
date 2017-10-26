namespace _02.Photo.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class TagAttribute : ValidationAttribute
    {
        private readonly string tagValue;

        //public TagAttribute(string tagValue)
        //{
        //    this.tagValue = tagValue;
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(this.tagValue);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format("Unknown property: {0}", this.tagValue)
                );
            }
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);

            return null;
        }
    }
}
