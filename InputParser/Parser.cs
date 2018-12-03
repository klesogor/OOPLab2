using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InputParser
{
    public class Parser: IParser
    {
        private readonly ICommandFactory _factory;
        private static readonly Regex _regex = new Regex(@"^(\w+)(?:\:(\w+))?( .+)?$");//I do so like regular expressions

        public Parser(ICommandFactory factory)
        {
            _factory = factory;
        }

        public ICommand Parse(string input)
        {
            var match = _regex.Split(input);
            match = match.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (match.Length < 1) throw new Exception("No command provided!");
            var command = match[0];
            var realArgs = new List<string>();
            foreach (string arg in match.Skip(1))
            {
                realArgs.AddRange(ParseArgs(arg));
            }
            return _factory.Create(command,realArgs.ToArray());
        }

        private string[] ParseArgs(string input)
        {
            var splitted = input.Split(' ');
            return splitted.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }
    }
}
