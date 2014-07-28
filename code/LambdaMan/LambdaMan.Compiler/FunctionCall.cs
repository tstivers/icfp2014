using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaMan.Compiler
{
    public class FunctionCall : ASTNode
    {
        public string Name { get; private set; }

        public List<ASTNode> Parameters { get; private set; }        

        public FunctionCall(string name, IEnumerable<ASTNode> parameters)
        {
            Name = name;
            Parameters = parameters.ToList();            
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {            
            var f = parent.FindSymbolByName(Name) as Function;
            var instructions = new List<Instruction>();

            if (Parameters.Count() != f.ParameterCount)
                throw new Exception("Argument count mismatch: " + Name);

            foreach (var p in Parameters)
                instructions.AddRange(p.Compile(parent));

            for (var i = Parameters.Count; i < f.Locals.Count; i++)
                instructions.Add(new LDC(new Constant(0)));

            instructions.Add(new LDF(new Identifier(f.Name, parent), parent));
            instructions.Add(new AP(new Constant(f.Locals.Count)));
            instructions.Last().Comment = "call function " + Name;

            return instructions;
        }
    }

    public class TFunctionCall : FunctionCall
    {        
        public TFunctionCall(string name, IEnumerable<ASTNode> parameters)
            : base(name, parameters)
        {
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            var f = parent.FindSymbolByName(Name) as Function;
            var instructions = new List<Instruction>();

            if (Parameters.Count() != f.ParameterCount)
                throw new Exception("Argument count mismatch: " + Name);

            foreach (var p in Parameters)
                instructions.AddRange(p.Compile(parent));

            for (var i = Parameters.Count; i < f.Locals.Count; i++)
                instructions.Add(new LDC(new Constant(0)));

            instructions.Add(new LDF(new Identifier(f.Name, parent), parent));
            instructions.Add(new TAP(new Constant(f.Locals.Count)));
            instructions.Last().Comment = "tcall function " + Name;

            return instructions;
        }
    }
}