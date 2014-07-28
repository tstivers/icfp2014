using System;
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
            get { return _firstInstruction.Address; }
        }

        public string Name { get; set; }

        private readonly List<ASTNode> _nodes;
        private Instruction _firstInstruction;

        public List<string> Locals { get; private set; }
        public int ParameterCount { get; private set; }

        public Function(string name, IEnumerable<ASTNode> nodes, IEnumerable<Identifier> parameters)
        {
            Name = name;
            _nodes = nodes.ToList();
            SetParents(_nodes);
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

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();

            foreach (var node in _nodes)
                instructions.AddRange(node.Compile(this));
            
            if (!(instructions.Any()) || !(instructions.Last() is RTN))
                instructions.Add(new RTN());

            _firstInstruction = instructions.First();
            _firstInstruction.Comment = String.Format("function {0}({1})", Name, String.Join(", ", Locals.Take(ParameterCount)));
            instructions.Last().Comment = String.Format("end function {0}", Name);

            foreach (var node in _nodes.Where(x => x is IPostCompileNeeded).Cast<IPostCompileNeeded>())
                instructions.AddRange(node.PostCompile(this));

            return instructions;
        }
    }
}