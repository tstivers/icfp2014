using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaMan.Compiler
{
    public class PostfixOp : ASTNode
    {
        public ASTNode LValue { get; set; }        
        public string Operator { get; set; }

        public PostfixOp(ASTNode lvalue, string op)
        {
            LValue = lvalue;
            Operator = op;            
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            Parent = parent;
            LValue.BuildSymbolTable(parent);            
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            Parent = parent;
            var instructions = new List<Instruction>();

            Instruction opIns = null;            

            switch (Operator)
            {
                case "<<":
                    opIns = new CAR();
                    break;
                case ">>":                    
                    opIns = new CDR();
                    break;
                case "^":                    
                    opIns = new ATOM();
                    break;
            }

            instructions.AddRange(LValue.Compile(parent));
            instructions.Add(opIns);

            return instructions;
        }
    }
}
