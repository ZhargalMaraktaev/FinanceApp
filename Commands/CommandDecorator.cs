using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class CommandDecorator : ICommand
    {
        private ICommand command;

        public CommandDecorator(ICommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            command.Execute();
            watch.Stop();
            Console.WriteLine($"Command executed in {watch.ElapsedMilliseconds} ms");
        }
    }

}
