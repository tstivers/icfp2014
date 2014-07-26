
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
  public class OperatorExpression : ASTNode, IExpression
    {
        public IExpression LValue { get; set; }
        public IExpression RValue { get; set; }
        public string Operator { get; set; }

        public OperatorExpression(IExpression lvalue, string op, IExpression rvalue)
        {
            LValue = lvalue;
            Operator = op;
            RValue = rvalue;
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            ((ASTNode)LValue).BuildSymbolTable(parent);
            ((ASTNode)RValue).BuildSymbolTable(parent);
        }

        public override void Compile()
        {
            ((ASTNode)LValue).Compile();
            ((ASTNode)RValue).Compile();
        }

        public override void Link(ref int address)
        {
            ((ASTNode)LValue).Link(ref address);
            ((ASTNode)RValue).Link(ref address);
        }

        public IEnumerable<Instruction> Evaluate()
        {
            var instructions = new List<Instruction>();

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

                instructions.AddRange(LValue.Evaluate());
                instructions.AddRange(RValue.Evaluate());
            }
            else
            {
                instructions.AddRange(RValue.Evaluate());
                instructions.AddRange(LValue.Evaluate());
            }

            instructions.Add(opIns);

            return instructions;
        }
    }
}
