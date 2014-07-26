
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
  public class OperatorExpression : ASTNode
    {
        public ASTNode LValue { get; set; }
        public ASTNode RValue { get; set; }
        public string Operator { get; set; }

        public OperatorExpression(ASTNode lvalue, string op, ASTNode rvalue)
        {
            LValue = lvalue;
            Operator = op;
            RValue = rvalue;
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            Parent = parent;
            LValue.BuildSymbolTable(parent);
            RValue.BuildSymbolTable(parent);
        }

        public override IEnumerable<ASTNode> Compile(ASTNode parent)
        {
            Parent = parent;
            var instructions = new List<ASTNode>();

            Instruction opIns = null;
            var swap = false;

            switch (Operator)
            {
                case "==":
                    opIns = new CEQ();
                    break;
                case "<":
                    swap = true;
                    opIns = new CGT();
                    break;
                case "<=":
                    swap = true;
                    opIns = new CGTE();
                    break;
                case ">":
                    opIns = new CGT();
                    break;
                case ">=":
                    opIns = new CGTE();
                    break;
                case "+":
                    opIns = new ADD();
                    break;
                case "-":
                    opIns = new SUB();
                    break;
                case "/":
                    opIns = new DIV();
                    break;
                case "*":
                    opIns = new MUL();
                    break;
            }

            if (!swap)
            {

                instructions.AddRange(LValue.Compile(this));
                instructions.AddRange(RValue.Compile(this));
            }
            else
            {
                instructions.AddRange(RValue.Compile(this));
                instructions.AddRange(LValue.Compile(this));
            }

            instructions.Add(opIns);

            return instructions;
        }
    }
}
