using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaMan.Compiler
{
    public class IfStatement : ASTNode, IPostCompileNeeded
    {
        ASTNode Condition { get; set; }
        List<ASTNode> TrueNodes { get; set; }
        List<ASTNode> FalseNodes { get; set; }

        private readonly string _trueLabel;
        private readonly string _falseLabel;

        public IfStatement(ASTNode condition, IEnumerable<ASTNode> trueNodes, IEnumerable<ASTNode> falseNodes)
        {
            Condition = condition;
            
            TrueNodes = trueNodes.ToList();
            FalseNodes = falseNodes.ToList();
            
            SetParents(TrueNodes);
            SetParents(FalseNodes);

            _trueLabel = String.Format("__if_true_{0}", TempCount);
            _falseLabel = String.Format("__if_false_{0}", TempCount++);
        }       

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {            
            var instructions = new List<Instruction>();
            instructions.AddRange(Condition.Compile(parent));
            instructions.Add(new SEL(new Identifier(_trueLabel), new Identifier(_falseLabel), parent)
            {
                Comment = "if " + _trueLabel + " else " + _falseLabel
            });           

            return instructions;
        }

        protected static IEnumerable<Instruction> CreateBlock(List<ASTNode> nodes, string label, ASTNode parent)
        {
            var instructions = new List<Instruction>();

            if (!nodes.Any() || !(nodes.Last() is JOIN))
                nodes.Add(new JOIN());

            foreach (var node in nodes)
                instructions.AddRange(node.Compile(parent));

            parent.Symbols.Add(label, instructions.First());
            instructions.First().Comment = ":" + label;

            foreach (var node in nodes.Where(x => x is IPostCompileNeeded).Cast<IPostCompileNeeded>())
                instructions.AddRange(node.PostCompile(parent));

            return instructions;
        }

        public IEnumerable<Instruction> PostCompile(ASTNode parent)
        {
            var instructions = new List<Instruction>();
            instructions.AddRange(CreateBlock(TrueNodes, _trueLabel, parent));
            instructions.AddRange(CreateBlock(FalseNodes, _falseLabel, parent));
            return instructions;
        }
    }
}
