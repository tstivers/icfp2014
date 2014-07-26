using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaMan.Compiler
{
    public abstract class ASTNode
    {
        public ASTNode Parent { get; set; }

        public string Comment { get; set; }

        protected static readonly IEnumerable<Instruction> EmptyNodeList = new List<Instruction>();

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

        public int FindLocal(string name)
        {
            ASTNode node = null;

            if (!Symbols.TryGetValue(name, out node) || !(node is Function))
                throw new Exception("Unable to find local variable: " + name);

            return (node as Function).Locals.IndexOf(name);
        }

        public virtual int Address { get; set; }

        public abstract IEnumerable<Instruction> Compile(ASTNode parent);      

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
    }
}