using System;

namespace _04.BarrackWars_Commands_Strike_Back.Core.Commands
{
    public class Fight : Command
    {
        public Fight()
        {
        }

        public override string Execute()
        {
            //Console.WriteLine(Engine.sb);
            Environment.Exit(0);
            return string.Empty;
        }
    }
}