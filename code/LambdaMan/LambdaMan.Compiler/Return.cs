using System.Collections.Generic;
using System.Linq;

namespace LambdaMan.Compiler
{
    public class Return : ASTNode
    {
        public List<ASTNode> Parameters { get; private set; }

        public Return(IEnumerable<ASTNode> parameters)
        {
            Parameters = parameters.ToList();
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();

            foreach (var p in Parameters)
                instructions.AddRange(p.Compile(parent));

            instructions.Add(new RTN());
            return instructions;
        }
    }
}