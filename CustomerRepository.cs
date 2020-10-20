using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp
{
    public class CustomerRepository
    {
        private const string Path = @"C:\fake.txt";
        private readonly IReader _reader;

        public CustomerRepository(IReader reader)
        {
            _reader = reader;
        }

        public async Task<IEnumerable<string>> ReadAsync()
        {
            Console.WriteLine($"++ReadAsync");
            var list = await ReadInternalAsync();

            Console.WriteLine($"--ReadAsync: Records count: {list.Count()}");

            return list;
        }

        private Task<IEnumerable<string>> ReadInternalAsync()
        {
            try
            {
                return _reader.ReadAsync(Path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }

    // END CODE TO REVIEW

    public interface IReader
    {
        Task<IEnumerable<string>> ReadAsync(string param);
    }
}