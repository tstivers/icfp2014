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

    public class Identifier : Symbol
    {
        public string Name { get; set; }
        public Identifier(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return ":" + Name;
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
            return String.Format("LDC {0}", Constant);
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
            return String.Format("LD {0} {1}", Frame, Index);
        }
    }

    public class ADD : Instruction
    {
        public override string ToString()
        {
            return "ADD";
        }
    }

    public class SUB : Instruction
    {
        public override string ToString()
        {
            return "SUB";
        }
    }
    public class MUL : Instruction
    {
        public override string ToString()
        {
            return "MUL";
        }
    }
    public class DIV : Instruction
    {
        public override string ToString()
        {
            return "DIV";
        }
    }

    public class CEQ : Instruction
    {
        public override string ToString()
        {
            return "CEQ";
        }
    }

    public class CGT : Instruction
    {
        public override string ToString()
        {
            return "CGT";
        }
    }

    public class CGTE : Instruction
    {
        public override string ToString()
        {
            return "CGTE";
        }
    }

    public class ATOM : Instruction
    {
        public override string ToString()
        {
            return "ATOM";
        }
    }

    public class CONS : Instruction
    {
        public override string ToString()
        {
            return "CONS";
        }
    }

    public class CAR : Instruction
    {
        public override string ToString()
        {
            return "CAR";
        }
    }

    public class CDR : Instruction
    {
        public override string ToString()
        {
            return "CDR";
        }
    }

    public class SEL : Instruction
    {
        public Symbol TrueAddress { get; set; }
        public Symbol FalseAddress { get; set; }

        public SEL(Symbol trueAddress, Symbol falseAddress)
        {
            TrueAddress = trueAddress;
            FalseAddress = falseAddress;
        }

        public override string ToString()
        {
            return String.Format("SEL {0} {1}", TrueAddress, FalseAddress);
        }
    }

    public class JOIN : Instruction
    {
        public override string ToString()
        {
            return "JOIN";
        }
    }

    public class LDF : Instruction
    {
        public Symbol Address { get; set; }
        public LDF(Symbol address)
        {
            Address = address;
        }

        public override string ToString()
        {
            return String.Format("LDF {0}", Address);
        }
    }

    public class AP : Instruction
    {
        public Constant NumArguments { get; set; }

        public AP(Constant numArguments)
        {
            NumArguments = numArguments;
        }

        public override string ToString()
        {
            return String.Format("AP {0}", NumArguments);
        }
    }

    public class RTN : Instruction
    {
        public override string ToString()
        {
            return "RTN";
        }
    }

    public class DUM : Instruction
    {
        public Constant NumArguments { get; set; }

        public DUM(Constant numArguments)
        {
            NumArguments = numArguments;
        }

        public override string ToString()
        {
            return String.Format("DUM {0}", NumArguments);
        }
    }

    public class RAP : Instruction
    {
        public Constant NumArguments { get; set; }

        public RAP(Constant numArguments)
        {
            NumArguments = numArguments;
        }

        public override string ToString()
        {
            return String.Format("RAP {0}", NumArguments);
        }
    }

    public class STOP : Instruction
    {
        public override string ToString()
        {
            return "STOP";
        }
    }

    public class TSEL : Instruction
    {
        public Symbol TrueAddress { get; set; }
        public Symbol FalseAddress { get; set; }

        public TSEL(Symbol trueAddress, Symbol falseAddress)
        {
            TrueAddress = trueAddress;
            FalseAddress = falseAddress;
        }

        public override string ToString()
        {
            return String.Format("TSEL {0} {1}", TrueAddress, FalseAddress);
        }
    }

    public class TAP : Instruction
    {
        public Constant NumArguments { get; set; }

        public TAP(Constant numArguments)
        {
            NumArguments = numArguments;
        }

        public override string ToString()
        {
            return String.Format("TAP {0}", NumArguments);
        }
    }

    public class TRAP : Instruction
    {
        public Constant NumArguments { get; set; }

        public TRAP(Constant numArguments)
        {
            NumArguments = numArguments;
        }

        public override string ToString()
        {
            return String.Format("TRAP {0}", NumArguments);
        }
    }

    public class DBUG : Instruction
    {
        public override string ToString()
        {
            return "DBUG";
        }
    }

    public class BRK : Instruction
    {
        public override string ToString()
        {
            return "BRK";
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
