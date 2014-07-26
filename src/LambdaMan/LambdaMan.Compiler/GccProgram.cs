using System.Collections.Generic;
using System.Text;

namespace LambdaMan.Compiler
{
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

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();

            foreach (var node in _nodes)
                instructions.AddRange(node.Compile(this));

            return instructions;
        }

        public override void Link(ref int address)
        {
            foreach (var node in _nodes)
                node.Link(ref address);
        }     
    }
}