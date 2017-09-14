namespace _09.CollectionHierarchy
{
    public interface IAddableRemovableCollection : IAddableCollection
    {
        string Remove(int range);
    }
}