using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            get { return _nodes[0].Address; }
        }

        public string Name { get; set; }

        private readonly List<ASTNode> _nodes;

        public List<string> Locals { get; private set; }
        public int ParameterCount { get; private set; }

        public Function(string name, IEnumerable<ASTNode> nodes, IEnumerable<Identifier> parameters)
        {
            Name = name;
            _nodes = nodes.ToList();
            Locals = parameters.Select(x => x.Name).ToList();
            ParameterCount = Locals.Count;
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            base.BuildSymbolTable(parent);
            parent.Symbols[Name] = this;

            foreach (var p in Locals)
                Symbols[p] = this;

            foreach (var node in _nodes)
                node.BuildSymbolTable(this);
        }

        public override IEnumerable<ASTNode> Compile(ASTNode parent)
        {
            var instructions = new List<ASTNode>();

            if (!(_nodes.Last() is RTN))
                _nodes.Add(new RTN());

            foreach (var node in _nodes)
                instructions.AddRange(node.Compile(this));

            return instructions;
        }
    }
}