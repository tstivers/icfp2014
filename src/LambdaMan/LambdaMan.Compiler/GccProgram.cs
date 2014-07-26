using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using IronMeta.AST;

namespace LambdaMan.Compiler
{
    public abstract class ASTNode
    {
        public virtual ASTNode Parent { get; set; }

        public virtual Dictionary<string, ASTNode> Symbols
        {
            get { return Parent.Symbols; }
        }

        public Function FindFunction(string name)
        {
            ASTNode node = null;
            ASTNode scope = this;

            do
            {
                if (!scope.Symbols.TryGetValue(name, out node))
                    scope = scope.Parent;

            } while (node == null && scope != null);
                
            if (node == null || !(node is Function))
                throw new Exception("Unableo to find function: " + name);

            return node as Function;        
        }

        public Tuple<int, int> FindLocalVariable(string name)
        {
            return null;
        }

        public virtual int Address { get; set; }

        public virtual void Compile(ref int address)
        {
            Address = address;
            address++;
        }

        public virtual void Link()
        {
        }

        public virtual void BuildSymbolTable(ASTNode parent)
        {
            Parent = parent;
        }

        public virtual void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            if (includeLineNumbers)
                b.AppendFormat("[{0,5}] ", Address);
        }
    }

    public class SimpleInstruction : Instruction
    {
        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            b.AppendLine(GetType().Name);
        }
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
            return Name;
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
        public Constant Constant { get; set; }

        public LDC(Constant constant)
        {
            Constant = constant;
        }

        public override string ToString()
        {
            return String.Format("LDC {0}", Constant);
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

        public override string ToString()
        {
            return String.Format("LD {0} {1}", Frame, Index);
        }

        public override void Link()
        {
            base.Link();
            if (Index is Identifier)
            {
                ASTNode node = null;
                if (!Symbols.TryGetValue(Index.ToString(), out node) || !(node is Function))
                    throw new Exception("Unable to find symbol: " + Index);

                var f = node as Function;


                Index = new Constant(f.Parameters.FindIndex(x => x.Name == Index.ToString()));
            }
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            b.AppendFormat("LD {0} {1}", Frame, Index);
            b.AppendLine();
        }
    }

    public class ADD : SimpleInstruction
    {
        public override string ToString()
        {
            return "ADD";
        }
    }

    public class SUB : SimpleInstruction
    {
        public override string ToString()
        {
            return "SUB";
        }
    }

    public class MUL : SimpleInstruction
    {
        public override string ToString()
        {
            return "MUL";
        }
    }

    public class DIV : SimpleInstruction
    {
        public override string ToString()
        {
            return "DIV";
        }
    }

    public class CEQ : SimpleInstruction
    {
        public override string ToString()
        {
            return "CEQ";
        }
    }

    public class CGT : SimpleInstruction
    {
        public override string ToString()
        {
            return "CGT";
        }
    }

    public class CGTE : SimpleInstruction
    {
        public override string ToString()
        {
            return "CGTE";
        }
    }

    public class ATOM : SimpleInstruction
    {
        public override string ToString()
        {
            return "ATOM";
        }
    }

    public class CONS : SimpleInstruction
    {
        public override string ToString()
        {
            return "CONS";
        }
    }

    public class CAR : SimpleInstruction
    {
        public override string ToString()
        {
            return "CAR";
        }
    }

    public class CDR : SimpleInstruction
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

    public class JOIN : SimpleInstruction
    {
        public override string ToString()
        {
            return "JOIN";
        }
    }

    public class LDF : Instruction
    {
        public Symbol FunctionAddress { get; set; }

        public LDF(Symbol functionAddress)
        {
            FunctionAddress = functionAddress;
        }

        public override string ToString()
        {
            return String.Format("LDF {0}", FunctionAddress);
        }

        public override void Link()
        {
            base.Link();
            if (FunctionAddress is Identifier)
            {                
                FunctionAddress = new Constant(FindFunction(FunctionAddress.ToString()).Address);
            }
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            b.AppendFormat("LDF {0}", FunctionAddress);
            b.AppendLine();
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

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            base.Emit(b, includeLineNumbers, includeComments);
            b.AppendFormat("AP {0}", NumArguments.Value);
            b.AppendLine();
        }
    }

    public class RTN : SimpleInstruction
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

    public class STOP : SimpleInstruction
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

    public class DBUG : SimpleInstruction
    {
        public override string ToString()
        {
            return "DBUG";
        }
    }

    public class BRK : SimpleInstruction
    {
        public override string ToString()
        {
            return "BRK";
        }
    }

    public class Function : ASTNode
    {
        private readonly Dictionary<string, ASTNode> _symbols = new Dictionary<string, ASTNode>();

        public override Dictionary<string, ASTNode> Symbols
        {
            get { return _symbols; }
        }

        public override int Address
        {
            get { return _instructions[0].Address; }
        }

        public string Name { get; set; }

        private readonly List<ASTNode> _instructions;
        public List<Identifier> Parameters { get; private set; }

        public Function(string name, IEnumerable<ASTNode> instructions, IEnumerable<Identifier> parameters)
        {
            Name = name;
            _instructions = instructions.ToList();
            Parameters = parameters.ToList();
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            base.BuildSymbolTable(parent);
            parent.Symbols[Name] = this;

            foreach (var p in Parameters)
                Symbols[p.Name] = this;

            foreach (var instruction in _instructions)
                instruction.BuildSymbolTable(this);
        }

        public override void Compile(ref int address)
        {

            if (!(_instructions.Last() is RTN))
                _instructions.Add(new RTN());

            foreach (var instruction in _instructions)
            {
                instruction.Compile(ref address);                
            }
        }

        public override void Link()
        {
            foreach (var instruction in _instructions)
                instruction.Link();
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            foreach (var instruction in _instructions)
            {
                instruction.Emit(b, includeLineNumbers, includeComments);                
            }
        }
    }

    public class FunctionCall : ASTNode
    {
        public string Name { get; private set; }

        public List<Constant> Parameters { get; private set; }
        public List<Instruction> Instructions { get; private set; }

        public FunctionCall(string name, IEnumerable<Constant> parameters)
        {
            Name = name;
            Parameters = parameters.ToList();
            Instructions = new List<Instruction>();
        }

        public override void Compile(ref int address)
        {
            ASTNode node = null;

            var f = FindFunction(Name);

            if (Parameters.Count() != f.Parameters.Count())
                throw new Exception("Argument count mismatch: " + Name);

            Instructions.Add(new LDF(new Identifier(f.Name)));

            foreach (var p in Parameters)
            {
                Instructions.Add(new LDC(p));
            }

            Instructions.Add(new AP(new Constant(Parameters.Count())));

            foreach (var i in Instructions)
            {
                i.BuildSymbolTable(this);
                i.Compile(ref address);                
            }
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            foreach (var instruction in Instructions)
            {
                instruction.Emit(b, includeLineNumbers, includeComments);                
            }
        }

        public override void Link()
        {
            base.Link();
            foreach(var i in Instructions)
                i.Link();
        }
    }

    public class GccProgram : ASTNode
    {
        private readonly Dictionary<string, ASTNode> _symbols = new Dictionary<string, ASTNode>();

        public override Dictionary<string, ASTNode> Symbols
        {
            get { return _symbols; }
        }

        private readonly IEnumerable<ASTNode> _instructions;

        public GccProgram(IEnumerable<ASTNode> instructions)
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

        public override void BuildSymbolTable(ASTNode parent)
        {
            base.BuildSymbolTable(parent);

            foreach (var instruction in _instructions)
            {
                instruction.BuildSymbolTable(this);
            }
        }

        public override void Compile(ref int address)
        {            
            foreach (var instruction in _instructions)
            {                
                instruction.Compile(ref address);                
            }
        }

        public override void Link()
        {
            base.Link();

            foreach (var instruction in _instructions)
                instruction.Link();
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers, bool includeComments)
        {
            foreach (var instruction in _instructions)
            {
                instruction.Emit(b, includeLineNumbers, includeComments);                
            }
        }
    }
}