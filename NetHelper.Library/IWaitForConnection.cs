using System;
using System.Threading.Tasks;

namespace NetHelper.Library
{
    public interface IConnectionAwaiter
    {
        TimeSpan Frequency { get; set; }
        int? NumAttempts { get; set; }
        void WaitForConnection();
        Task WaitForConnectionAsync();
    }
}