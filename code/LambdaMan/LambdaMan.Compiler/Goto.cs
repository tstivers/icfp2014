using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public class Goto : ASTNode
    {
        public string Name { get; set; }

        public Goto(string name)
        {
            Name = name;
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();
            instructions.Add(new LDC(new Constant(1)));
            instructions.Add(new TSEL(new Identifier(Name, parent), new Constant(0), parent)
            {
                Comment = "goto " + Name
            });

            return instructions;
        }
    }
}
