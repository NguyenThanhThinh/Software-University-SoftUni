using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.IOInterface.Contracts
{
    public abstract class Command : IExecutable
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
