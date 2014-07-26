using System;
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public class Assignment : ASTNode, IExpression
    {
        public string Name { get; set; }
        public IExpression Expression { get; set; }

        public Assignment(string name, IExpression expression)
        {
            Name = name;
            Expression = expression;
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            ((ASTNode)Expression).BuildSymbolTable(parent);
        }

        public override void Compile()
        {
            ((ASTNode)Expression).Compile();
        }

        public override void Link(ref int address)
        {
            ((ASTNode)Expression).Link(ref address);
        }

        public IEnumerable<Instruction> Evaluate()
        {
            var instructions = new List<Instruction>();
            instructions.AddRange(Expression.Evaluate());
            instructions.Add(new ST(new Constant(0), new Identifier(Name)));

            return instructions;
        }
    }
}
