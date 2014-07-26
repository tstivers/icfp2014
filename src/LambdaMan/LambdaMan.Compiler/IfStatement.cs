using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaMan.Compiler
{
    public class IfStatement : ASTNode, IPostCompileNeeded
    {
        ASTNode Condition { get; set; }
        List<ASTNode> TrueNodes { get; set; }

        private readonly string _trueLabel;
        private readonly string _falseLabel;

        public IfStatement(ASTNode condition, IEnumerable<ASTNode> trueNodes)
        {
            Condition = condition;
            TrueNodes = trueNodes.ToList();
            _trueLabel = String.Format("__if_true_{0}", TempCount);
            _falseLabel = String.Format("__if_false_{0}", TempCount++);
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            var f = parent as Function;
            Parent = parent;

            if (f == null)
                throw new Exception("Cannot create if statement outside of functions!");
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

        public IEnumerable<Instruction> PostCompile(ASTNode parent)
        {
            var instructions = new List<Instruction>();

            if (!(TrueNodes.Last() is JOIN))
                TrueNodes.Add(new JOIN());

            foreach (var node in TrueNodes)
                instructions.AddRange(node.Compile(parent));

            parent.Symbols.Add(_trueLabel, instructions.First());
            instructions.First().Comment = ":" + _trueLabel;

            foreach (var node in TrueNodes.Where(x => x is IPostCompileNeeded).Cast<IPostCompileNeeded>())
                instructions.AddRange(node.PostCompile(parent));

            var j = new JOIN()
            {
                Comment = ":" + _falseLabel
            };

            parent.Symbols.Add(_falseLabel, j);

            instructions.Add(j);

            return instructions;
        }
    }
}
