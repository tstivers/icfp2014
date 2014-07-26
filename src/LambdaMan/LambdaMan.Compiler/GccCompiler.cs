using System;
using System.Text;

namespace LambdaMan.Compiler
{
    public class GccCompiler
    {
        public string Compile(string input, bool includeLineNumbers = false)
        {
            var parser = new Parser();

            try
            {
                var parseResult = parser.GetMatch(input, parser.GccProgram);

                if (parseResult.Success)
                {
                    var b = new StringBuilder();
                    int address = 0;
                    parseResult.Result.BuildSymbolTable(null);
                    parseResult.Result.Compile(ref address);
                    parseResult.Result.Link();

                    parseResult.Result.Emit(b, includeLineNumbers);
                    return b.ToString();
                }
                
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
