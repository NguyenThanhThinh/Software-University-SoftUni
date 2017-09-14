using System;
using System.Collections.Generic;

public interface IManager
{
    string AddHero(IList<String> arguments);
    string AddItemToHero(IList<String> arguments);
    string Inspect(IList<String> arguments);
    string Quit();
}