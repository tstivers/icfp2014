using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaMan.Compiler
{
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

        public override void Compile()
        {
            if (!(_instructions.Last() is RTN))
                _instructions.Add(new RTN());

            foreach (var instruction in _instructions)
                instruction.Compile();
        }

        public override void Link(ref int address)
        {
            foreach (var instruction in _instructions)
                instruction.Link(ref address);
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            foreach (var instruction in _instructions)
            {
                instruction.Emit(b, includeLineNumbers, includeComments);
            }
        }
    }
}