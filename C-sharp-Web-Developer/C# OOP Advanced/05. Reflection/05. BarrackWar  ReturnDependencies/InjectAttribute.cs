using System;

namespace _05.BarrackWar__ReturnDependencies
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}