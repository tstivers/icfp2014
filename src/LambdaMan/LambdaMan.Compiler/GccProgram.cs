using System;
using System.Collections.Generic;
using System.Text;

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

            if (!(node is Function))
                throw new Exception("Unable to find function: " + name);

            return node as Function;
        }

        public int FindLocalVariable(string name)
        {
            ASTNode node = null;

            if (!Symbols.TryGetValue(name, out node) || !(node is Function))
                throw new Exception("Unable to find local variable: " + name);

            return (node as Function).Parameters.FindIndex(x => x.Name == name);
        }

        public virtual int Address { get; set; }

        public virtual void Compile()
        {
        }

        public virtual void Link(ref int address)
        {
            if (Address != 0)
                throw new Exception("Node was double-linked!");

            Address = address;
            address++;
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

    public interface IExpression
    {
        IEnumerable<Instruction> Evaluate();
    }

    public class GccProgram : ASTNode
    {
        private readonly Dictionary<string, ASTNode> _symbols = new Dictionary<string, ASTNode>();

        public override Dictionary<string, ASTNode> Symbols
        {
            get { return _symbols; }
        }

        private readonly IEnumerable<ASTNode> _nodes;

        public GccProgram(IEnumerable<ASTNode> nodes)
        {
            _nodes = nodes;
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            foreach (var node in _nodes)
                node.BuildSymbolTable(this);
        }

        public override void Compile()
        {
            foreach (var node in _nodes)
                node.Compile();
        }

        public override void Link(ref int address)
        {
            foreach (var node in _nodes)
                node.Link(ref address);
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers, bool includeComments)
        {
            foreach (var instruction in _nodes)
                instruction.Emit(b, includeLineNumbers, includeComments);
        }
    }
}