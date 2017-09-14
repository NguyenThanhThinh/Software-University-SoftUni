using System.Collections.Generic;

namespace _04.Telephony
{
    public interface IBrowsable
    {
        List<string> Webs { get; }
        void Browse();
    }
}