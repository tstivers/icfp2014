using System;
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public class IndexExpression : ASTNode
    {
        public string Name { get; set; }
        public ASTNode Index { get; set; }

        private readonly string _tempVar;

        public IndexExpression(string name, ASTNode index)
        {
            Name = name;
            Index = index;
            _tempVar = String.Format("__temp_{0}", TempCount++);
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            var f = parent as Function;

            if (f == null)
                throw new Exception("Cannot index outside of functions!");

            f.Locals.Add(_tempVar);
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            // load count into tempvar
            // load cons
            // while (_tempVar > 0)
            // car
            return EmptyInstructionList;
        }
    }
}
