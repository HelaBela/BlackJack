using System;

namespace BlackJack
{
    public class ConsoleOperations : IConsoleOperations
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}