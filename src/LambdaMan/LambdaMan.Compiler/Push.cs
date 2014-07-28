using System.Collections.Generic;
using System.Linq;

namespace LambdaMan.Compiler
{
    public class Push : ASTNode
    {
        public List<ASTNode> Parameters { get; private set; }

        public Push(IEnumerable<ASTNode> parameters)
        {
            Parameters = parameters.ToList();
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();

            foreach (var p in Parameters)
                instructions.AddRange(p.Compile(parent));

            return instructions;
        }
    }
}