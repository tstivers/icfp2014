using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public abstract class Symbol : ASTNode
    {
    }

    public class Identifier : Symbol
    {
        public string Name { get; set; }

        public Identifier(string name, ASTNode parent = null)
        {
            Name = name;
            Parent = parent;
        }

        public override string ToString()
        {
            return Name;
        }

        public override IEnumerable<ASTNode> Compile(ASTNode parent)
        {
            return new List<Instruction> { new LD(new Constant(0), this, parent) };
        }
    }

    public class Constant : Symbol
    {
        public int Value { get; set; }

        public Constant(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override IEnumerable<ASTNode> Compile(ASTNode parent)
        {
            return new List<Instruction> { new LDC(this) };
        }
    }
}
