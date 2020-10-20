using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TestApp
{
    class GenricReaderClass
    {
        string path = @"C:\fake.txt";
        IReader realReader;

        public GenricReaderClass(bool realMode)
        {
            realReader = realMode ? (IReader)new FileReader() : new FakeReader();
        }

        Task<IEnumerable<string>> ReadAsync()
        {
            return realReader.ReadAsync(path);
        }

    }

    // END CODE TO REVIEW

    public interface IReader
    {
        Task<IEnumerable<string>> ReadAsync(string param);
    }

    internal class FileReader : IReader
    {
        public async Task<IEnumerable<string>> ReadAsync(string param)
        {
            return await File.ReadAllLinesAsync(param);
        }
    }

    internal class FakeReader : IReader
    {
        public async Task<IEnumerable<string>> ReadAsync(string param)
        {
            return await File.ReadAllLinesAsync(param);
        }
    }
}