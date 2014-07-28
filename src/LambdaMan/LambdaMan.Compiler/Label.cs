using System;
using System.Collections.Generic;

namespace LambdaMan.Compiler
{
    public class Label : Instruction
    {
        public string Name { get; set; }

        public Label(string name)
        {
            Name = name;
        }

        public override void Link(ref int address)
        {
            Address = address;
            // don't increment address here, SUPER SNEAKY
        }

        public override IEnumerable<Instruction> Compile(ASTNode parent)
        {
            parent.Symbols.Add(Name, this);
            return new List<Instruction> { this };
        }

        // labels don't actually emit an instruction (sneaky)
        public override string Emit(bool includeLineNumbers = false, bool includeComments = false)
        {
            return String.Empty;
        }
    }
}
