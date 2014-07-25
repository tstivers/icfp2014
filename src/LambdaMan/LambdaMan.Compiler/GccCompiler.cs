using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaMan.Compiler
{
    public class GccCompiler
    {
        public string Compile(string input)
        {
            var parser = new Parser();

            try
            {
                var parseResult = parser.GetMatch(input, parser.GccProgram);

                if (parseResult.Success)
                    return parseResult.Result.ToString();
                return parseResult.Error;                
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return String.Empty;
        }
    }
}
