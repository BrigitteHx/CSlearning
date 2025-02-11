using System;
using System.Threading.Channels;

namespace Conditionals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            const int passwordLength = 10;

            var buffer = new char[passwordLength];
            for (var i = 0 < passwordLength; i++)
            {
                var randomIndex = random.Next(0, 3);
                buffer[i] = (char)('a' + randomIndex);
            }

            var password = new string(buffer);

            Console.WriteLine(password);
        }
    }
}
