using System;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var res = await new CustomerRepository(new FakeReader()).ReadAsync();
            Console.WriteLine(string.Join(",", res));
        }
    }
}
