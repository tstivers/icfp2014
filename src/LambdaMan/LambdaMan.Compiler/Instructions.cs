using System;
using System.Text;

namespace LambdaMan.Compiler
{
    public abstract class Instruction : ASTNode
    {
    }

    public abstract class SimpleInstruction : Instruction
    {
        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            b.AppendLine(GetType().Name);
        }
    }

    public abstract class NumArgumentsInstruction : Instruction
    {
        public Constant NumArguments { get; set; }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            b.AppendFormat("{0} {1}", GetType().Name, NumArguments.Value);
            b.AppendLine();
        }
    }

    public abstract class SELInstruction : Instruction
    {
        public Symbol TrueAddress { get; set; }
        public Symbol FalseAddress { get; set; }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            if (TrueAddress is Identifier)
                TrueAddress = new Constant(FindFunction((TrueAddress as Identifier).ToString()).Address);
            if (FalseAddress is Identifier)
                FalseAddress = new Constant(FindFunction((FalseAddress as Identifier).ToString()).Address);
            b.AppendFormat("{0} {1} {2}", GetType().Name, TrueAddress, FalseAddress);
            b.AppendLine();
        }
    }


    public class LDC : Instruction
    {
        public Constant Constant { get; set; }

        public LDC(Constant constant)
        {
            Constant = constant;
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            b.AppendFormat("LDC {0}", Constant);
            b.AppendLine();
        }
    }

    public class LD : Instruction
    {
        public Constant Frame { get; set; }
        public Symbol Index { get; set; }

        public LD(Constant frame, Symbol index)
        {
            Frame = frame;
            Index = index;
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            if (Index is Identifier)
                Index = new Constant(FindLocalVariable(Index.ToString()));

            b.AppendFormat("LD {0} {1}", Frame, Index);
            b.AppendLine();
        }
    }

    public class ST : Instruction
    {
        public Constant Frame { get; set; }
        public Symbol Index { get; set; }

        public ST(Constant frame, Symbol index)
        {
            Frame = frame;
            Index = index;
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            if (Index is Identifier)
                Index = new Constant(FindLocalVariable(Index.ToString()));

            b.AppendFormat("ST {0} {1}", Frame, Index);
            b.AppendLine();
        }
    }

    public class LDF : Instruction
    {
        public Symbol FunctionAddress { get; set; }

        public LDF(Symbol functionAddress)
        {
            FunctionAddress = functionAddress;
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            if (FunctionAddress is Identifier)
                FunctionAddress = new Constant(FindFunction(FunctionAddress.ToString()).Address);
            b.AppendFormat("LDF {0}", FunctionAddress);
            b.AppendLine();
        }
    }

    public class SEL : SELInstruction
    {
        public SEL(Symbol trueAddress, Symbol falseAddress)
        {
            TrueAddress = trueAddress;
            FalseAddress = falseAddress;
        }
    }

    public class TSEL : SELInstruction
    {
        public TSEL(Symbol trueAddress, Symbol falseAddress)
        {
            TrueAddress = trueAddress;
            FalseAddress = falseAddress;
        }
    }

    public class AP : NumArgumentsInstruction
    {
        public AP(Constant numArguments)
        {
            NumArguments = numArguments;
        }      
    }

    public class DUM : NumArgumentsInstruction
    {
        public DUM(Constant numArguments)
        {
            NumArguments = numArguments;
        }

    }

    public class RAP : NumArgumentsInstruction
    {
        public RAP(Constant numArguments)
        {
            NumArguments = numArguments;
        }
    }

    public class TAP : NumArgumentsInstruction
    {
        public TAP(Constant numArguments)
        {
            NumArguments = numArguments;
        }
    }

    public class TRAP : NumArgumentsInstruction
    {
        public TRAP(Constant numArguments)
        {
            NumArguments = numArguments;
        }
    }

    public class ADD : SimpleInstruction
    {
    }

    public class SUB : SimpleInstruction
    {
    }

    public class MUL : SimpleInstruction
    {
    }

    public class DIV : SimpleInstruction
    {
    }

    public class CEQ : SimpleInstruction
    {
    }

    public class CGT : SimpleInstruction
    {
    }

    public class CGTE : SimpleInstruction
    {
    }

    public class ATOM : SimpleInstruction
    {
    }

    public class CONS : SimpleInstruction
    {
    }

    public class CAR : SimpleInstruction
    {
    }

    public class CDR : SimpleInstruction
    {
    }

    public class JOIN : SimpleInstruction
    {
    }

    public class RTN : SimpleInstruction
    {
    }

    public class STOP : SimpleInstruction
    {
    }

    public class DBUG : SimpleInstruction
    {
    }

    public class BRK : SimpleInstruction
    {
    }

}
