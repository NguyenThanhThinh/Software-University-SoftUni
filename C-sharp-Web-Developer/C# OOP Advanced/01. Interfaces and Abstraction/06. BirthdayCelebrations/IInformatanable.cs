namespace _06.BirthdayCelebrations
{
    public interface IInformatanable
    {
        string Name { get; set; }
        string Birthday { get; set; }
        void GetBirthdayIfMatch(string birthday);
    }
}