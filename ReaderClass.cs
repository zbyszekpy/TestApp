using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TestApp
{
    class GenricReaderClass
    {
        IReader realReader;

        public GenricReaderClass(bool realMode)
        {
            realReader = realMode ? (IReader)new FileReader() : new FakeReader();
        }

        string path = @"C:\fake.txt";
        public Task<IEnumerable<string>> ReadAsync()
        {
                try
                {
                    return realReader.ReadAsync(path);
                }
                catch (Exception e)
                {
                    return null;
                }
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