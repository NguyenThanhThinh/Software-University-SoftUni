using System.Collections.Generic;

namespace _04.Telephony
{
    public interface ICallable
    {
        List<string> PhoneNumber { get; }
        void Call();
    }
}