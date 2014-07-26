﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaMan.Compiler
{
    public class Declaration : ASTNode
    {
        public List<string> Names { get; set; }

        public Declaration(IEnumerable<ASTNode> identifiers)
        {
            Names = identifiers.Cast<Identifier>().Select(x => x.Name).ToList();
        }

        public override void BuildSymbolTable(ASTNode parent)
        {
            base.BuildSymbolTable(parent);

            if (!(parent is Function))
                throw new Exception("Cannot declare variables outside a function!");

            var f = parent as Function;

            Names.ForEach(x =>
            {
                f.Parameters.Add(x);
                f.Symbols.Add(x, f);
                f.VariableCount++;
            });
        }

        public override void Link(ref int address)
        {
            // do nothing
        }

        public override void Emit(StringBuilder b, bool includeLineNumbers = false, bool includeComments = false)
        {
            // do nothing
        }
    }
}