using System;
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public class Assignment : ASTNode
    {
        public string Name { get; set; }
        public ASTNode Node { get; set; }

        public Assignment(string name, ASTNode node)
        {
            Name = name;
            Node = node;
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            Node.BuildSymbolTable(parent);
        }             

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();
            instructions.AddRange(Node.Compile(parent));
            instructions.Add(new ST(new Constant(0), new Identifier(Name, this), parent));

            return instructions;
        }
    }
}
