using System;
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public abstract class Instruction : ASTNode
    {
        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            return new List<Instruction> { this };
        }

        public abstract string Emit(bool includeLineNumbers = false, bool includeComments = false);

        protected string EmitFormat(string opcode, string arg1, string arg2, bool includeLineNumbers = false, bool includeComments = false)
        {
            return String.Format("{0}{1,-5}{2,-5}{3,-5}{4}",
                includeLineNumbers ? String.Format("[{0,4}] ", Address) : String.Empty,
                opcode,
                arg1,
                arg2,
                includeComments && Comment != null ? String.Format("  ; {0}", Comment) : String.Empty);

        }
    }

    public abstract class SimpleInstruction : Instruction
    {
        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            return EmitFormat(GetType().Name, String.Empty, String.Empty, includeLineNumbers, includeComments);
        }
    }

    public abstract class NumArgumentsInstruction : Instruction
    {
        public Constant NumArguments { get; set; }

        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            return EmitFormat(GetType().Name, NumArguments.ToString(), String.Empty, includeLineNumbers, includeComments);
        }
    }

    public abstract class SELInstruction : Instruction
    {
        public Symbol TrueAddress { get; set; }
        public Symbol FalseAddress { get; set; }

        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            if (TrueAddress is Identifier)
                TrueAddress = new Constant(FindSymbolByName((TrueAddress as Identifier).ToString()).Address);
            if (FalseAddress is Identifier)
                FalseAddress = new Constant(FindSymbolByName((FalseAddress as Identifier).ToString()).Address);
            return EmitFormat(GetType().Name, TrueAddress.ToString(), FalseAddress.ToString(), includeLineNumbers,
                includeComments);
        }
    }

    public class LDC : Instruction
    {
        public Constant Constant { get; set; }

        public LDC(Constant constant)
        {
            Constant = constant;
        }

        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            return EmitFormat(GetType().Name, Constant.ToString(), String.Empty, includeLineNumbers, includeComments);
        }
    }

    public class LD : Instruction
    {
        public Constant Frame { get; set; }
        public Symbol Index { get; set; }

        public LD(Constant frame, Symbol index, ASTNode parent = null)
        {
            Frame = frame;
            Index = index;
            Parent = parent;
        }

        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            if (Index is Identifier)
                Index = new Constant(FindLocal(Index.ToString()));

            return EmitFormat(GetType().Name, Frame.ToString(), Index.ToString(), includeLineNumbers, includeComments);
        }
    }

    public class ST : Instruction
    {
        public Constant Frame { get; set; }
        public Symbol Index { get; set; }

        public ST(Constant frame, Symbol index, ASTNode parent = null)
        {
            Frame = frame;
            Index = index;
            Parent = parent;
        }

        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            if (Index is Identifier)
                Index = new Constant(FindLocal(Index.ToString()));

            return EmitFormat(GetType().Name, Frame.ToString(), Index.ToString(), includeLineNumbers, includeComments);
        }
    }

    public class LDF : Instruction
    {
        public Symbol FunctionAddress { get; set; }

        public LDF(Symbol functionAddress, ASTNode parent = null)
        {
            FunctionAddress = functionAddress;
            Parent = parent;
        }

        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            if (FunctionAddress is Identifier)
                FunctionAddress = new Constant(FindSymbolByName(FunctionAddress.ToString()).Address);

            return EmitFormat(GetType().Name, FunctionAddress.ToString(), String.Empty, includeLineNumbers, includeComments);
        }
    }

    public class SEL : SELInstruction
    {
        public SEL(Symbol trueAddress, Symbol falseAddress, ASTNode parent = null)
        {
            TrueAddress = trueAddress;
            FalseAddress = falseAddress;
            Parent = parent;
        }
    }

    public class TSEL : SELInstruction
    {
        public TSEL(Symbol trueAddress, Symbol falseAddress, ASTNode parent = null)
        {
            TrueAddress = trueAddress;
            FalseAddress = falseAddress;
            Parent = parent;
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
