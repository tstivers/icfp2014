using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaMan.Compiler
{
    public class FunctionCall : ASTNode, IExpression
    {
        public string Name { get; private set; }

        public List<IExpression> Parameters { get; private set; }
        public List<Instruction> Instructions { get; private set; }

        public FunctionCall(string name, IEnumerable<IExpression> parameters)
        {
            Name = name;
            Parameters = parameters.ToList();
            Instructions = new List<Instruction>();
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            base.BuildSymbolTable(parent);
            foreach (var p in Parameters)
                ((ASTNode)p).BuildSymbolTable(parent);
        }

        public override void Compile()
        {
            var f = FindFunction(Name);

            if (Parameters.Count() != f.Parameters.Count())
                throw new Exception("Argument count mismatch: " + Name);

            foreach (var p in Parameters)
            {
                ((ASTNode)p).Compile();
                Instructions.AddRange(p.Evaluate());
            }

            Instructions.Add(new LDF(new Identifier(f.Name)));
            Instructions.Add(new AP(new Constant(Parameters.Count())));

            foreach (var i in Instructions)
            {
                i.BuildSymbolTable(this);
                i.Compile();
            }
        }

        public override void Link(ref int address)
        {
            foreach (var i in Instructions)
            {
                i.Link(ref address);
            }
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            foreach (var instruction in Instructions)
            {
                instruction.Emit(b, includeLineNumbers, includeComments);
            }
        }

        public IEnumerable<Instruction> Evaluate()
        {
            return Instructions;
        }
    }
}