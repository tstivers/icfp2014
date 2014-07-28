using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaMan.Compiler
{
    public class ConsOp : ASTNode
    {
        public List<ASTNode> Parameters { get; private set; }

        public ConsOp(IEnumerable<ASTNode> parameters)
        {
            Parameters = parameters.ToList();
            if (Parameters.Count < 2)
                throw new Exception("Need at least 2 parameters for a cons op");
        }

        // a, b, c, d
        // ld c
        // ld d
        // cons
        // ld b
        // cons
        // ld a
        // cons
        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();

            foreach(var p in Parameters)
                instructions.AddRange(p.Compile(parent));

            for (var i = 0; i < Parameters.Count - 1; i++)
                instructions.Add(new CONS());

            return instructions;
        }
    }
}
