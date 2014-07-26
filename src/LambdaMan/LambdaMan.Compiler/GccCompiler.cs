using System;
using System.Linq;
using System.Text;

namespace LambdaMan.Compiler
{
    public class GccCompiler
    {
        public string Compile(string input, bool includeLineNumbers = false, bool includeComments = false, bool breakOnExceptions = false)
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
                    var instructions = parseResult.Result.Compile(null);
                    
                    foreach(var i in instructions)
                        i.Link(ref address);

                    foreach (var i in instructions)
                        b.AppendLine(i.Emit(includeLineNumbers, includeComments));
                    
                    return b.ToString();
                }
                
                return parseResult.Error;
            }
            catch (Exception e)
            {
                if (!breakOnExceptions)
                    return e.Message;

                throw;
            }            
        }
    }
}
