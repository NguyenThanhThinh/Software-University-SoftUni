using System.Collections.Generic;

public class ModifiedDictionary : Dictionary<string, Soldier>
{
    public void HandleSoldierDeath(object sender, SoldierDeathEventArgs args)
    {
        this.Remove(args.Name);
    }
}