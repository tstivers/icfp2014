using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaMan.Compiler
{
    public abstract class Symbol : ASTNode
    {
    }

    public class Identifier : Symbol, IExpression
    {
        public string Name { get; set; }

        public Identifier(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public IEnumerable<Instruction> Evaluate()
        {
            return new List<Instruction> { new LD(new Constant(0), this) };
        }
    }

    public class Constant : Symbol, IExpression
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

        public IEnumerable<Instruction> Evaluate()
        {
            return new List<Instruction> {new LDC(this)};
        }
    }
}
