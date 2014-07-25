using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaMan.Compiler
{
    public class ASTNode
    {

    }

    public class Instruction : ASTNode
    {
    }

    public class Symbol : ASTNode
    {
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
    }

    public class LDC : Instruction
    {
        public Symbol Constant { get; set; }
        public LDC(Symbol constant)
        {
            Constant = constant;
        }

        public override string ToString()
        {
            return String.Format("LDC {0};", Constant);
        }
    }

    public class LD : Instruction
    {
        public Symbol Frame { get; set; }
        public Symbol Index { get; set; }

        public LD(Symbol frame, Symbol index)
        {
            Frame = frame;
            Index = index;
        }

        public override string ToString()
        {
            return String.Format("LD {0} {1};", Frame, Index);
        }
    }

    public class GccProgram : ASTNode
    {
        private IEnumerable<Instruction> _instructions;
        public GccProgram(IEnumerable<Instruction> instructions)
        {
            _instructions = instructions;
        }

        public override string ToString()
        {
            if (_instructions == null)
                return String.Empty;

            StringBuilder builder = new StringBuilder();

            foreach (var instruction in _instructions)
            {
                builder.AppendLine(instruction.ToString());                
            }

            return builder.ToString();
        }
    }
}
