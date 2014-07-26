
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public class EqualsOperator : ASTNode, IExpression
    {
        public IExpression LValue { get; set; }
        public IExpression RValue { get; set; }

        public EqualsOperator(IExpression lvalue, IExpression rvalue)
        {
            LValue = lvalue;
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

            instructions.AddRange(LValue.Evaluate());
            instructions.AddRange(RValue.Evaluate());
            instructions.Add(new CEQ());

            return instructions;
        }
    }
}
