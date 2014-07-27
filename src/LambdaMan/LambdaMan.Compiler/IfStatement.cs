using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaMan.Compiler
{
    public class IfStatement : ASTNode, IPostCompileNeeded
    {
        protected ASTNode Condition { get; set; }
        protected List<ASTNode> TrueNodes { get; set; }
        protected List<ASTNode> FalseNodes { get; set; }

        protected readonly string TrueLabel;
        protected readonly string FalseLabel;
        protected bool IsTailOptimised = false;

        public IfStatement(ASTNode condition, IEnumerable<ASTNode> trueNodes, IEnumerable<ASTNode> falseNodes, bool isTailOptimised = false)
        {
            Condition = condition;

            TrueNodes = trueNodes.ToList();
            FalseNodes = falseNodes.ToList();

            IsTailOptimised = isTailOptimised;

            SetParents(TrueNodes);
            SetParents(FalseNodes);

            TrueLabel = String.Format("__if_true_{0}", TempCount);
            FalseLabel = String.Format("__if_false_{0}", TempCount++);
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var instructions = new List<Instruction>();
            instructions.AddRange(Condition.Compile(parent));
            
            if (!IsTailOptimised)
                instructions.Add(new SEL(new Identifier(TrueLabel), new Identifier(FalseLabel), parent)
                {
                    Comment = "if " + TrueLabel + " else " + FalseLabel
                });
            else
            {
                instructions.Add(new TSEL(new Identifier(TrueLabel), new Identifier(FalseLabel), parent)
                {
                    Comment = "if " + TrueLabel + " else " + FalseLabel
                });
            }

            return instructions;
        }

        protected IEnumerable<Instruction> CreateBlock(List<ASTNode> nodes, string label, ASTNode parent)
        {
            var instructions = new List<Instruction>();

            if (!IsTailOptimised)
            {
                if (!nodes.Any() || !(nodes.Last() is JOIN))
                    nodes.Add(new JOIN());
            }
            else
            {
                if (!nodes.Any())
                    nodes.Add(new BRK());
            }

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
            instructions.AddRange(CreateBlock(TrueNodes, TrueLabel, parent));
            instructions.AddRange(CreateBlock(FalseNodes, FalseLabel, parent));
            return instructions;
        }
    } 
}
