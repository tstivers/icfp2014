//
// IronMeta Parser Parser; Generated 2014-07-26 15:33:46Z UTC
//

using System;
using System.Collections.Generic;
using System.Linq;
using IronMeta.Matcher;

#pragma warning disable 0219
#pragma warning disable 1591

namespace LambdaMan.Compiler
{

    using _Parser_Inputs = IEnumerable<char>;
    using _Parser_Results = IEnumerable<ASTNode>;
    using _Parser_Item = IronMeta.Matcher.MatchItem<char, ASTNode>;
    using _Parser_Args = IEnumerable<IronMeta.Matcher.MatchItem<char, ASTNode>>;
    using _Parser_Memo = Memo<char, ASTNode>;
    using _Parser_Rule = System.Action<Memo<char, ASTNode>, int, IEnumerable<IronMeta.Matcher.MatchItem<char, ASTNode>>>;
    using _Parser_Base = IronMeta.Matcher.Matcher<char, ASTNode>;

    public partial class Parser : IronMeta.Matcher.CharMatcher<ASTNode>
    {
        public Parser()
            : base()
        {
            _setTerminals();
        }

        public Parser(bool handle_left_recursion)
            : base(handle_left_recursion)
        {
            _setTerminals();
        }

        void _setTerminals()
        {
            this.Terminals = new HashSet<string>()
            {
                "ADD",
                "AP",
                "ATOM",
                "BRA",
                "BRK",
                "CAR",
                "CDR",
                "CEQ",
                "CGT",
                "CGTE",
                "Comment",
                "CONS",
                "Constant",
                "DBUG",
                "DIV",
                "DUM",
                "EOL",
                "Ident",
                "IdentBegin",
                "IdentBody",
                "Identifier",
                "Instruction",
                "JOIN",
                "KET",
                "LD",
                "LDC",
                "LDF",
                "MUL",
                "Operator",
                "PLUS",
                "RAP",
                "RTN",
                "SEL",
                "SEMI",
                "SP",
                "STOP",
                "SUB",
                "Symbol",
                "TAP",
                "TRAP",
                "TSEL",
                "WS",
                "WT",
            };
        }


        public void SEMI(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // AND 0
            int _start_i0 = _index;

            // LITERAL ';'
            _ParseLiteralChar(_memo, ref _index, ';');

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label0; }

            // CALLORVAR SP
            _Parser_Item _r2;

            _r2 = _MemoCall(_memo, "SP", _index, SP, null);

            if (_r2 != null) _index = _r2.NextIndex;

        label0: // AND
            var _r0_2 = _memo.Results.Pop();
            var _r0_1 = _memo.Results.Pop();

            if (_r0_1 != null && _r0_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i0, _index, _memo.InputEnumerable, _r0_1.Results.Concat(_r0_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i0;
            }

        }


        public void SP(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // STAR 0
            int _start_i0 = _index;
            var _res0 = Enumerable.Empty<ASTNode>();
        label0:

            // OR 1
            int _start_i1 = _index;

            // CALLORVAR WS
            _Parser_Item _r2;

            _r2 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR Comment
            _Parser_Item _r3;

            _r3 = _MemoCall(_memo, "Comment", _index, Comment, null);

            if (_r3 != null) _index = _r3.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // STAR 0
            var _r0 = _memo.Results.Pop();
            if (_r0 != null)
            {
                _res0 = _res0.Concat(_r0.Results);
                goto label0;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i0, _index, _memo.InputEnumerable, _res0.Where(_NON_NULL), true));
            }

        }


        public void WS(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // LITERAL ' '
            _ParseLiteralChar(_memo, ref _index, ' ');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i2; } else goto label2;

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // LITERAL '\r'
            _ParseLiteralChar(_memo, ref _index, '\r');

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL '\t'
            _ParseLiteralChar(_memo, ref _index, '\t');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void BRA(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL '{'
            _ParseLiteralChar(_memo, ref _index, '{');

        }


        public void KET(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL '}'
            _ParseLiteralChar(_memo, ref _index, '}');

        }


        public void EOL(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // AND 0
            int _start_i0 = _index;

            // AND 1
            int _start_i1 = _index;

            // STAR 2
            int _start_i2 = _index;
            var _res2 = Enumerable.Empty<ASTNode>();
        label2:

            // CALLORVAR WT
            _Parser_Item _r3;

            _r3 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // STAR 2
            var _r2 = _memo.Results.Pop();
            if (_r2 != null)
            {
                _res2 = _res2.Concat(_r2.Results);
                goto label2;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _res2.Where(_NON_NULL), true));
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // OR 4
            int _start_i4 = _index;

            // OR 5
            int _start_i5 = _index;

            // LITERAL ';'
            _ParseLiteralChar(_memo, ref _index, ';');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i5; } else goto label5;

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i4; } else goto label4;

            // LITERAL '\r'
            _ParseLiteralChar(_memo, ref _index, '\r');

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label0; }

            // STAR 9
            int _start_i9 = _index;
            var _res9 = Enumerable.Empty<ASTNode>();
        label9:

            // CALLORVAR WT
            _Parser_Item _r10;

            _r10 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r10 != null) _index = _r10.NextIndex;

            // STAR 9
            var _r9 = _memo.Results.Pop();
            if (_r9 != null)
            {
                _res9 = _res9.Concat(_r9.Results);
                goto label9;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i9, _index, _memo.InputEnumerable, _res9.Where(_NON_NULL), true));
            }

        label0: // AND
            var _r0_2 = _memo.Results.Pop();
            var _r0_1 = _memo.Results.Pop();

            if (_r0_1 != null && _r0_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i0, _index, _memo.InputEnumerable, _r0_1.Results.Concat(_r0_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i0;
            }

        }


        public void WT(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL ' '
            _ParseLiteralChar(_memo, ref _index, ' ');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL '\t'
            _ParseLiteralChar(_memo, ref _index, '\t');

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void PLUS(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL '+'
            _ParseLiteralChar(_memo, ref _index, '+');

        }


        public void Comment(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "//"
            _ParseLiteralString(_memo, ref _index, "//");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // STAR 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // AND 5
            int _start_i5 = _index;

            // NOT 6
            int _start_i6 = _index;

            // OR 7
            int _start_i7 = _index;

            // AND 8
            int _start_i8 = _index;

            // LITERAL '\r'
            _ParseLiteralChar(_memo, ref _index, '\r');

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label8; }

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _Parser_Item(_index, _memo.InputEnumerable)); }

        label8: // AND
            var _r8_2 = _memo.Results.Pop();
            var _r8_1 = _memo.Results.Pop();

            if (_r8_1 != null && _r8_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i8, _index, _memo.InputEnumerable, _r8_1.Results.Concat(_r8_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i8;
            }

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i7; } else goto label7;

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

        label7: // OR
            int _dummy_i7 = _index; // no-op for label

            // NOT 6
            var _r6 = _memo.Results.Pop();
            _memo.Results.Push( _r6 == null ? new _Parser_Item(_start_i6, _memo.InputEnumerable) : null);
            _index = _start_i6;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label5; }

            // ANY
            _ParseAny(_memo, ref _index);

        label5: // AND
            var _r5_2 = _memo.Results.Pop();
            var _r5_1 = _memo.Results.Pop();

            if (_r5_1 != null && _r5_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i5, _index, _memo.InputEnumerable, _r5_1.Results.Concat(_r5_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i5;
            }

            // STAR 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // OR 14
            int _start_i14 = _index;

            // AND 15
            int _start_i15 = _index;

            // LITERAL '\r'
            _ParseLiteralChar(_memo, ref _index, '\r');

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label15; }

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _Parser_Item(_index, _memo.InputEnumerable)); }

        label15: // AND
            var _r15_2 = _memo.Results.Pop();
            var _r15_1 = _memo.Results.Pop();

            if (_r15_1 != null && _r15_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i15, _index, _memo.InputEnumerable, _r15_1.Results.Concat(_r15_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i15;
            }

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i14; } else goto label14;

            // LITERAL '\n'
            _ParseLiteralChar(_memo, ref _index, '\n');

        label14: // OR
            int _dummy_i14 = _index; // no-op for label

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // AND 20
            int _start_i20 = _index;

            // AND 21
            int _start_i21 = _index;

            // LITERAL "/*"
            _ParseLiteralString(_memo, ref _index, "/*");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label21; }

            // STAR 23
            int _start_i23 = _index;
            var _res23 = Enumerable.Empty<ASTNode>();
        label23:

            // AND 24
            int _start_i24 = _index;

            // NOT 25
            int _start_i25 = _index;

            // LITERAL "*/"
            _ParseLiteralString(_memo, ref _index, "*/");

            // NOT 25
            var _r25 = _memo.Results.Pop();
            _memo.Results.Push( _r25 == null ? new _Parser_Item(_start_i25, _memo.InputEnumerable) : null);
            _index = _start_i25;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label24; }

            // ANY
            _ParseAny(_memo, ref _index);

        label24: // AND
            var _r24_2 = _memo.Results.Pop();
            var _r24_1 = _memo.Results.Pop();

            if (_r24_1 != null && _r24_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i24, _index, _memo.InputEnumerable, _r24_1.Results.Concat(_r24_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i24;
            }

            // STAR 23
            var _r23 = _memo.Results.Pop();
            if (_r23 != null)
            {
                _res23 = _res23.Concat(_r23.Results);
                goto label23;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i23, _index, _memo.InputEnumerable, _res23.Where(_NON_NULL), true));
            }

        label21: // AND
            var _r21_2 = _memo.Results.Pop();
            var _r21_1 = _memo.Results.Pop();

            if (_r21_1 != null && _r21_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i21, _index, _memo.InputEnumerable, _r21_1.Results.Concat(_r21_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i21;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label20; }

            // LITERAL "*/"
            _ParseLiteralString(_memo, ref _index, "*/");

        label20: // AND
            var _r20_2 = _memo.Results.Pop();
            var _r20_1 = _memo.Results.Pop();

            if (_r20_1 != null && _r20_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i20, _index, _memo.InputEnumerable, _r20_1.Results.Concat(_r20_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i20;
            }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void GccProgram(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item nodes = null;

            // PLUS 2
            int _start_i2 = _index;
            var _res2 = Enumerable.Empty<ASTNode>();
        label2:

            // CALLORVAR Node
            _Parser_Item _r3;

            _r3 = _MemoCall(_memo, "Node", _index, Node, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // PLUS 2
            var _r2 = _memo.Results.Pop();
            if (_r2 != null)
            {
                _res2 = _res2.Concat(_r2.Results);
                goto label2;
            }
            else
            {
                if (_index > _start_i2)
                    _memo.Results.Push(new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _res2.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

            // BIND nodes
            nodes = _memo.Results.Peek();

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new GccProgram(nodes.Results); }, _r0), true) );
            }

        }


        public void Node(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // AND 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // CALLORVAR Instruction
            _Parser_Item _r3;

            _r3 = _MemoCall(_memo, "Instruction", _index, Instruction, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i2; } else goto label2;

            // CALLORVAR Function
            _Parser_Item _r4;

            _r4 = _MemoCall(_memo, "Function", _index, Function, null);

            if (_r4 != null) _index = _r4.NextIndex;

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR FunctionCall
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "FunctionCall", _index, FunctionCall, null);

            if (_r5 != null) _index = _r5.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label0; }

            // PLUS 6
            int _start_i6 = _index;
            var _res6 = Enumerable.Empty<ASTNode>();
        label6:

            // CALLORVAR EOL
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "EOL", _index, EOL, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // PLUS 6
            var _r6 = _memo.Results.Pop();
            if (_r6 != null)
            {
                _res6 = _res6.Concat(_r6.Results);
                goto label6;
            }
            else
            {
                if (_index > _start_i6)
                    _memo.Results.Push(new _Parser_Item(_start_i6, _index, _memo.InputEnumerable, _res6.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label0: // AND
            var _r0_2 = _memo.Results.Pop();
            var _r0_1 = _memo.Results.Pop();

            if (_r0_1 != null && _r0_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i0, _index, _memo.InputEnumerable, _r0_1.Results.Concat(_r0_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i0;
            }

        }


        public void Constant(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item n = null;

            // PLUS 2
            int _start_i2 = _index;
            var _res2 = Enumerable.Empty<ASTNode>();
        label2:

            // INPUT CLASS
            _ParseInputClass(_memo, ref _index, '\u0030', '\u0031', '\u0032', '\u0033', '\u0034', '\u0035', '\u0036', '\u0037', '\u0038', '\u0039');

            // PLUS 2
            var _r2 = _memo.Results.Pop();
            if (_r2 != null)
            {
                _res2 = _res2.Concat(_r2.Results);
                goto label2;
            }
            else
            {
                if (_index > _start_i2)
                    _memo.Results.Push(new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _res2.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

            // BIND n
            n = _memo.Results.Peek();

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new Constant(int.Parse(Input(n))); }, _r0), true) );
            }

        }


        public void Identifier(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item id = null;

            // CALLORVAR Ident
            _Parser_Item _r2;

            _r2 = _MemoCall(_memo, "Ident", _index, Ident, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // BIND id
            id = _memo.Results.Peek();

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return id; }, _r0), true) );
            }

        }


        public void Ident(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item id = null;

            // AND 2
            int _start_i2 = _index;

            // CALLORVAR IdentBegin
            _Parser_Item _r3;

            _r3 = _MemoCall(_memo, "IdentBegin", _index, IdentBegin, null);

            if (_r3 != null) _index = _r3.NextIndex;

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // STAR 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR IdentBody
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "IdentBody", _index, IdentBody, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // STAR 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // BIND id
            id = _memo.Results.Peek();

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new Identifier(Input(id)); }, _r0), true) );
            }

        }


        public void IdentBegin(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL '_'
            _ParseLiteralChar(_memo, ref _index, '_');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // COND 2
            int _start_i2 = _index;

            // ANY
            _ParseAny(_memo, ref _index);

            // COND
            Func<_Parser_Item, bool> lambda2 = (_IM_Result) => { return System.Char.IsLetter(_IM_Result); };
            if (_memo.Results.Peek() == null || !lambda2(_memo.Results.Peek())) { _memo.Results.Pop(); _memo.Results.Push(null); _index = _start_i2; }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void IdentBody(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // LITERAL '_'
            _ParseLiteralChar(_memo, ref _index, '_');

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // COND 2
            int _start_i2 = _index;

            // ANY
            _ParseAny(_memo, ref _index);

            // COND
            Func<_Parser_Item, bool> lambda2 = (_IM_Result) => { return System.Char.IsLetterOrDigit(_IM_Result); };
            if (_memo.Results.Peek() == null || !lambda2(_memo.Results.Peek())) { _memo.Results.Pop(); _memo.Results.Push(null); _index = _start_i2; }

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Symbol(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // CALLORVAR Constant
            _Parser_Item _r1;

            _r1 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r1 != null) _index = _r1.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR Identifier
            _Parser_Item _r2;

            _r2 = _MemoCall(_memo, "Identifier", _index, Identifier, null);

            if (_r2 != null) _index = _r2.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void LDC(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item c = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "LDC"
            _ParseLiteralString(_memo, ref _index, "LDC");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR WT
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Constant
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND c
            c = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new LDC((Constant)((ASTNode)c)); }, _r0), true) );
            }

        }


        public void LD(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item n = null;
            _Parser_Item i = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // LITERAL "LD"
            _ParseLiteralString(_memo, ref _index, "LD");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // PLUS 6
            int _start_i6 = _index;
            var _res6 = Enumerable.Empty<ASTNode>();
        label6:

            // CALLORVAR WT
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // PLUS 6
            var _r6 = _memo.Results.Pop();
            if (_r6 != null)
            {
                _res6 = _res6.Concat(_r6.Results);
                goto label6;
            }
            else
            {
                if (_index > _start_i6)
                    _memo.Results.Push(new _Parser_Item(_start_i6, _index, _memo.InputEnumerable, _res6.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // CALLORVAR Constant
            _Parser_Item _r9;

            _r9 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // BIND n
            n = _memo.Results.Peek();

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 10
            int _start_i10 = _index;
            var _res10 = Enumerable.Empty<ASTNode>();
        label10:

            // CALLORVAR WT
            _Parser_Item _r11;

            _r11 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r11 != null) _index = _r11.NextIndex;

            // PLUS 10
            var _r10 = _memo.Results.Pop();
            if (_r10 != null)
            {
                _res10 = _res10.Concat(_r10.Results);
                goto label10;
            }
            else
            {
                if (_index > _start_i10)
                    _memo.Results.Push(new _Parser_Item(_start_i10, _index, _memo.InputEnumerable, _res10.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Symbol
            _Parser_Item _r13;

            _r13 = _MemoCall(_memo, "Symbol", _index, Symbol, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // BIND i
            i = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new LD((Constant)((ASTNode)n), (Symbol)((ASTNode)i)); }, _r0), true) );
            }

        }


        public void ADD(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "ADD"
            _ParseLiteralString(_memo, ref _index, "ADD");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new ADD(); }, _r0), true) );
            }

        }


        public void SUB(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "SUB"
            _ParseLiteralString(_memo, ref _index, "SUB");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new SUB(); }, _r0), true) );
            }

        }


        public void MUL(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "MUL"
            _ParseLiteralString(_memo, ref _index, "MUL");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new MUL(); }, _r0), true) );
            }

        }


        public void DIV(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "DIV"
            _ParseLiteralString(_memo, ref _index, "DIV");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new DIV(); }, _r0), true) );
            }

        }


        public void CEQ(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "CEQ"
            _ParseLiteralString(_memo, ref _index, "CEQ");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new CEQ(); }, _r0), true) );
            }

        }


        public void CGT(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "CGT"
            _ParseLiteralString(_memo, ref _index, "CGT");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new CGT(); }, _r0), true) );
            }

        }


        public void CGTE(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "CGTE"
            _ParseLiteralString(_memo, ref _index, "CGTE");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new CGTE(); }, _r0), true) );
            }

        }


        public void ATOM(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "ATOM"
            _ParseLiteralString(_memo, ref _index, "ATOM");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new ATOM(); }, _r0), true) );
            }

        }


        public void CONS(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "CONS"
            _ParseLiteralString(_memo, ref _index, "CONS");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new CONS(); }, _r0), true) );
            }

        }


        public void CAR(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "CAR"
            _ParseLiteralString(_memo, ref _index, "CAR");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new CAR(); }, _r0), true) );
            }

        }


        public void CDR(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "CDR"
            _ParseLiteralString(_memo, ref _index, "CDR");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new CDR(); }, _r0), true) );
            }

        }


        public void SEL(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item trueAddress = null;
            _Parser_Item falseAddress = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // LITERAL "SEL"
            _ParseLiteralString(_memo, ref _index, "SEL");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // PLUS 6
            int _start_i6 = _index;
            var _res6 = Enumerable.Empty<ASTNode>();
        label6:

            // CALLORVAR WT
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // PLUS 6
            var _r6 = _memo.Results.Pop();
            if (_r6 != null)
            {
                _res6 = _res6.Concat(_r6.Results);
                goto label6;
            }
            else
            {
                if (_index > _start_i6)
                    _memo.Results.Push(new _Parser_Item(_start_i6, _index, _memo.InputEnumerable, _res6.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // CALLORVAR Symbol
            _Parser_Item _r9;

            _r9 = _MemoCall(_memo, "Symbol", _index, Symbol, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // BIND trueAddress
            trueAddress = _memo.Results.Peek();

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 10
            int _start_i10 = _index;
            var _res10 = Enumerable.Empty<ASTNode>();
        label10:

            // CALLORVAR WT
            _Parser_Item _r11;

            _r11 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r11 != null) _index = _r11.NextIndex;

            // PLUS 10
            var _r10 = _memo.Results.Pop();
            if (_r10 != null)
            {
                _res10 = _res10.Concat(_r10.Results);
                goto label10;
            }
            else
            {
                if (_index > _start_i10)
                    _memo.Results.Push(new _Parser_Item(_start_i10, _index, _memo.InputEnumerable, _res10.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Symbol
            _Parser_Item _r13;

            _r13 = _MemoCall(_memo, "Symbol", _index, Symbol, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // BIND falseAddress
            falseAddress = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new SEL((Symbol)((ASTNode)trueAddress), (Symbol)((ASTNode)falseAddress)); }, _r0), true) );
            }

        }


        public void JOIN(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "JOIN"
            _ParseLiteralString(_memo, ref _index, "JOIN");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new JOIN(); }, _r0), true) );
            }

        }


        public void LDF(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item address = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "LDF"
            _ParseLiteralString(_memo, ref _index, "LDF");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR WT
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Symbol
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Symbol", _index, Symbol, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND address
            address = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new LDF((Symbol)((ASTNode)address)); }, _r0), true) );
            }

        }


        public void AP(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "AP"
            _ParseLiteralString(_memo, ref _index, "AP");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR WT
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Constant
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND n
            n = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new AP((Constant)((ASTNode)n)); }, _r0), true) );
            }

        }


        public void RTN(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "RTN"
            _ParseLiteralString(_memo, ref _index, "RTN");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new RTN(); }, _r0), true) );
            }

        }


        public void DUM(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "DUM"
            _ParseLiteralString(_memo, ref _index, "DUM");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR WT
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Constant
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND n
            n = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new DUM((Constant)((ASTNode)n)); }, _r0), true) );
            }

        }


        public void RAP(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "RAP"
            _ParseLiteralString(_memo, ref _index, "RAP");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR WT
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Constant
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND n
            n = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new RAP((Constant)((ASTNode)n)); }, _r0), true) );
            }

        }


        public void STOP(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "STOP"
            _ParseLiteralString(_memo, ref _index, "STOP");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new STOP(); }, _r0), true) );
            }

        }


        public void TSEL(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item trueAddress = null;
            _Parser_Item falseAddress = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // LITERAL "TSEL"
            _ParseLiteralString(_memo, ref _index, "TSEL");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // PLUS 6
            int _start_i6 = _index;
            var _res6 = Enumerable.Empty<ASTNode>();
        label6:

            // CALLORVAR WT
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // PLUS 6
            var _r6 = _memo.Results.Pop();
            if (_r6 != null)
            {
                _res6 = _res6.Concat(_r6.Results);
                goto label6;
            }
            else
            {
                if (_index > _start_i6)
                    _memo.Results.Push(new _Parser_Item(_start_i6, _index, _memo.InputEnumerable, _res6.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // CALLORVAR Symbol
            _Parser_Item _r9;

            _r9 = _MemoCall(_memo, "Symbol", _index, Symbol, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // BIND trueAddress
            trueAddress = _memo.Results.Peek();

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 10
            int _start_i10 = _index;
            var _res10 = Enumerable.Empty<ASTNode>();
        label10:

            // CALLORVAR WT
            _Parser_Item _r11;

            _r11 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r11 != null) _index = _r11.NextIndex;

            // PLUS 10
            var _r10 = _memo.Results.Pop();
            if (_r10 != null)
            {
                _res10 = _res10.Concat(_r10.Results);
                goto label10;
            }
            else
            {
                if (_index > _start_i10)
                    _memo.Results.Push(new _Parser_Item(_start_i10, _index, _memo.InputEnumerable, _res10.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Symbol
            _Parser_Item _r13;

            _r13 = _MemoCall(_memo, "Symbol", _index, Symbol, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // BIND falseAddress
            falseAddress = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new TSEL((Symbol)((ASTNode)trueAddress), (Symbol)((ASTNode)falseAddress)); }, _r0), true) );
            }

        }


        public void TAP(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "TAP"
            _ParseLiteralString(_memo, ref _index, "TAP");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR WT
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Constant
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND n
            n = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new TAP((Constant)((ASTNode)n)); }, _r0), true) );
            }

        }


        public void TRAP(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item n = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // LITERAL "TRAP"
            _ParseLiteralString(_memo, ref _index, "TRAP");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // PLUS 4
            int _start_i4 = _index;
            var _res4 = Enumerable.Empty<ASTNode>();
        label4:

            // CALLORVAR WT
            _Parser_Item _r5;

            _r5 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r5 != null) _index = _r5.NextIndex;

            // PLUS 4
            var _r4 = _memo.Results.Pop();
            if (_r4 != null)
            {
                _res4 = _res4.Concat(_r4.Results);
                goto label4;
            }
            else
            {
                if (_index > _start_i4)
                    _memo.Results.Push(new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _res4.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR Constant
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Constant", _index, Constant, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND n
            n = _memo.Results.Peek();

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new TRAP((Constant)((ASTNode)n)); }, _r0), true) );
            }

        }


        public void DBUG(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "DBUG"
            _ParseLiteralString(_memo, ref _index, "DBUG");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new DBUG(); }, _r0), true) );
            }

        }


        public void BRK(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // LITERAL "BRK"
            _ParseLiteralString(_memo, ref _index, "BRK");

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new BRK(); }, _r0), true) );
            }

        }


        public void Operator(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // OR 2
            int _start_i2 = _index;

            // OR 3
            int _start_i3 = _index;

            // OR 4
            int _start_i4 = _index;

            // OR 5
            int _start_i5 = _index;

            // OR 6
            int _start_i6 = _index;

            // OR 7
            int _start_i7 = _index;

            // LITERAL "=="
            _ParseLiteralString(_memo, ref _index, "==");

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i7; } else goto label7;

            // LITERAL "+"
            _ParseLiteralString(_memo, ref _index, "+");

        label7: // OR
            int _dummy_i7 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i6; } else goto label6;

            // LITERAL "-"
            _ParseLiteralString(_memo, ref _index, "-");

        label6: // OR
            int _dummy_i6 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i5; } else goto label5;

            // LITERAL "/"
            _ParseLiteralString(_memo, ref _index, "/");

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i4; } else goto label4;

            // LITERAL "*"
            _ParseLiteralString(_memo, ref _index, "*");

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i3; } else goto label3;

            // LITERAL "<"
            _ParseLiteralString(_memo, ref _index, "<");

        label3: // OR
            int _dummy_i3 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i2; } else goto label2;

            // LITERAL "<="
            _ParseLiteralString(_memo, ref _index, "<=");

        label2: // OR
            int _dummy_i2 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // LITERAL ">"
            _ParseLiteralString(_memo, ref _index, ">");

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // LITERAL ">="
            _ParseLiteralString(_memo, ref _index, ">=");

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Expression(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // OR 0
            int _start_i0 = _index;

            // OR 1
            int _start_i1 = _index;

            // CALLORVAR OperatorExpression
            _Parser_Item _r2;

            _r2 = _MemoCall(_memo, "OperatorExpression", _index, OperatorExpression, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i1; } else goto label1;

            // CALLORVAR FunctionCall
            _Parser_Item _r3;

            _r3 = _MemoCall(_memo, "FunctionCall", _index, FunctionCall, null);

            if (_r3 != null) _index = _r3.NextIndex;

        label1: // OR
            int _dummy_i1 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i0; } else goto label0;

            // CALLORVAR Symbol
            _Parser_Item _r4;

            _r4 = _MemoCall(_memo, "Symbol", _index, Symbol, null);

            if (_r4 != null) _index = _r4.NextIndex;

        label0: // OR
            int _dummy_i0 = _index; // no-op for label

        }


        public void Instruction(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            // AND 0
            int _start_i0 = _index;

            // STAR 1
            int _start_i1 = _index;
            var _res1 = Enumerable.Empty<ASTNode>();
        label1:

            // CALLORVAR WT
            _Parser_Item _r2;

            _r2 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r2 != null) _index = _r2.NextIndex;

            // STAR 1
            var _r1 = _memo.Results.Pop();
            if (_r1 != null)
            {
                _res1 = _res1.Concat(_r1.Results);
                goto label1;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _res1.Where(_NON_NULL), true));
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label0; }

            // OR 3
            int _start_i3 = _index;

            // OR 4
            int _start_i4 = _index;

            // OR 5
            int _start_i5 = _index;

            // OR 6
            int _start_i6 = _index;

            // OR 7
            int _start_i7 = _index;

            // OR 8
            int _start_i8 = _index;

            // OR 9
            int _start_i9 = _index;

            // OR 10
            int _start_i10 = _index;

            // OR 11
            int _start_i11 = _index;

            // OR 12
            int _start_i12 = _index;

            // OR 13
            int _start_i13 = _index;

            // OR 14
            int _start_i14 = _index;

            // OR 15
            int _start_i15 = _index;

            // OR 16
            int _start_i16 = _index;

            // OR 17
            int _start_i17 = _index;

            // OR 18
            int _start_i18 = _index;

            // OR 19
            int _start_i19 = _index;

            // OR 20
            int _start_i20 = _index;

            // OR 21
            int _start_i21 = _index;

            // OR 22
            int _start_i22 = _index;

            // OR 23
            int _start_i23 = _index;

            // OR 24
            int _start_i24 = _index;

            // OR 25
            int _start_i25 = _index;

            // OR 26
            int _start_i26 = _index;

            // OR 27
            int _start_i27 = _index;

            // CALLORVAR LDC
            _Parser_Item _r28;

            _r28 = _MemoCall(_memo, "LDC", _index, LDC, null);

            if (_r28 != null) _index = _r28.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i27; } else goto label27;

            // CALLORVAR LD
            _Parser_Item _r29;

            _r29 = _MemoCall(_memo, "LD", _index, LD, null);

            if (_r29 != null) _index = _r29.NextIndex;

        label27: // OR
            int _dummy_i27 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i26; } else goto label26;

            // CALLORVAR ADD
            _Parser_Item _r30;

            _r30 = _MemoCall(_memo, "ADD", _index, ADD, null);

            if (_r30 != null) _index = _r30.NextIndex;

        label26: // OR
            int _dummy_i26 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i25; } else goto label25;

            // CALLORVAR SUB
            _Parser_Item _r31;

            _r31 = _MemoCall(_memo, "SUB", _index, SUB, null);

            if (_r31 != null) _index = _r31.NextIndex;

        label25: // OR
            int _dummy_i25 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i24; } else goto label24;

            // CALLORVAR MUL
            _Parser_Item _r32;

            _r32 = _MemoCall(_memo, "MUL", _index, MUL, null);

            if (_r32 != null) _index = _r32.NextIndex;

        label24: // OR
            int _dummy_i24 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i23; } else goto label23;

            // CALLORVAR DIV
            _Parser_Item _r33;

            _r33 = _MemoCall(_memo, "DIV", _index, DIV, null);

            if (_r33 != null) _index = _r33.NextIndex;

        label23: // OR
            int _dummy_i23 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i22; } else goto label22;

            // CALLORVAR CEQ
            _Parser_Item _r34;

            _r34 = _MemoCall(_memo, "CEQ", _index, CEQ, null);

            if (_r34 != null) _index = _r34.NextIndex;

        label22: // OR
            int _dummy_i22 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i21; } else goto label21;

            // CALLORVAR CGT
            _Parser_Item _r35;

            _r35 = _MemoCall(_memo, "CGT", _index, CGT, null);

            if (_r35 != null) _index = _r35.NextIndex;

        label21: // OR
            int _dummy_i21 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i20; } else goto label20;

            // CALLORVAR CGTE
            _Parser_Item _r36;

            _r36 = _MemoCall(_memo, "CGTE", _index, CGTE, null);

            if (_r36 != null) _index = _r36.NextIndex;

        label20: // OR
            int _dummy_i20 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i19; } else goto label19;

            // CALLORVAR ATOM
            _Parser_Item _r37;

            _r37 = _MemoCall(_memo, "ATOM", _index, ATOM, null);

            if (_r37 != null) _index = _r37.NextIndex;

        label19: // OR
            int _dummy_i19 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i18; } else goto label18;

            // CALLORVAR CONS
            _Parser_Item _r38;

            _r38 = _MemoCall(_memo, "CONS", _index, CONS, null);

            if (_r38 != null) _index = _r38.NextIndex;

        label18: // OR
            int _dummy_i18 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i17; } else goto label17;

            // CALLORVAR CAR
            _Parser_Item _r39;

            _r39 = _MemoCall(_memo, "CAR", _index, CAR, null);

            if (_r39 != null) _index = _r39.NextIndex;

        label17: // OR
            int _dummy_i17 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i16; } else goto label16;

            // CALLORVAR CDR
            _Parser_Item _r40;

            _r40 = _MemoCall(_memo, "CDR", _index, CDR, null);

            if (_r40 != null) _index = _r40.NextIndex;

        label16: // OR
            int _dummy_i16 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i15; } else goto label15;

            // CALLORVAR SEL
            _Parser_Item _r41;

            _r41 = _MemoCall(_memo, "SEL", _index, SEL, null);

            if (_r41 != null) _index = _r41.NextIndex;

        label15: // OR
            int _dummy_i15 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i14; } else goto label14;

            // CALLORVAR JOIN
            _Parser_Item _r42;

            _r42 = _MemoCall(_memo, "JOIN", _index, JOIN, null);

            if (_r42 != null) _index = _r42.NextIndex;

        label14: // OR
            int _dummy_i14 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i13; } else goto label13;

            // CALLORVAR LDF
            _Parser_Item _r43;

            _r43 = _MemoCall(_memo, "LDF", _index, LDF, null);

            if (_r43 != null) _index = _r43.NextIndex;

        label13: // OR
            int _dummy_i13 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i12; } else goto label12;

            // CALLORVAR AP
            _Parser_Item _r44;

            _r44 = _MemoCall(_memo, "AP", _index, AP, null);

            if (_r44 != null) _index = _r44.NextIndex;

        label12: // OR
            int _dummy_i12 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i11; } else goto label11;

            // CALLORVAR RTN
            _Parser_Item _r45;

            _r45 = _MemoCall(_memo, "RTN", _index, RTN, null);

            if (_r45 != null) _index = _r45.NextIndex;

        label11: // OR
            int _dummy_i11 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i10; } else goto label10;

            // CALLORVAR DUM
            _Parser_Item _r46;

            _r46 = _MemoCall(_memo, "DUM", _index, DUM, null);

            if (_r46 != null) _index = _r46.NextIndex;

        label10: // OR
            int _dummy_i10 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i9; } else goto label9;

            // CALLORVAR RAP
            _Parser_Item _r47;

            _r47 = _MemoCall(_memo, "RAP", _index, RAP, null);

            if (_r47 != null) _index = _r47.NextIndex;

        label9: // OR
            int _dummy_i9 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i8; } else goto label8;

            // CALLORVAR STOP
            _Parser_Item _r48;

            _r48 = _MemoCall(_memo, "STOP", _index, STOP, null);

            if (_r48 != null) _index = _r48.NextIndex;

        label8: // OR
            int _dummy_i8 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i7; } else goto label7;

            // CALLORVAR TSEL
            _Parser_Item _r49;

            _r49 = _MemoCall(_memo, "TSEL", _index, TSEL, null);

            if (_r49 != null) _index = _r49.NextIndex;

        label7: // OR
            int _dummy_i7 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i6; } else goto label6;

            // CALLORVAR TAP
            _Parser_Item _r50;

            _r50 = _MemoCall(_memo, "TAP", _index, TAP, null);

            if (_r50 != null) _index = _r50.NextIndex;

        label6: // OR
            int _dummy_i6 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i5; } else goto label5;

            // CALLORVAR TRAP
            _Parser_Item _r51;

            _r51 = _MemoCall(_memo, "TRAP", _index, TRAP, null);

            if (_r51 != null) _index = _r51.NextIndex;

        label5: // OR
            int _dummy_i5 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i4; } else goto label4;

            // CALLORVAR DBUG
            _Parser_Item _r52;

            _r52 = _MemoCall(_memo, "DBUG", _index, DBUG, null);

            if (_r52 != null) _index = _r52.NextIndex;

        label4: // OR
            int _dummy_i4 = _index; // no-op for label

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i3; } else goto label3;

            // CALLORVAR BRK
            _Parser_Item _r53;

            _r53 = _MemoCall(_memo, "BRK", _index, BRK, null);

            if (_r53 != null) _index = _r53.NextIndex;

        label3: // OR
            int _dummy_i3 = _index; // no-op for label

        label0: // AND
            var _r0_2 = _memo.Results.Pop();
            var _r0_1 = _memo.Results.Pop();

            if (_r0_1 != null && _r0_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i0, _index, _memo.InputEnumerable, _r0_1.Results.Concat(_r0_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i0;
            }

        }


        public void Function(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item name = null;
            _Parser_Item parameters = null;
            _Parser_Item nodes = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // AND 7
            int _start_i7 = _index;

            // AND 8
            int _start_i8 = _index;

            // AND 9
            int _start_i9 = _index;

            // AND 10
            int _start_i10 = _index;

            // AND 11
            int _start_i11 = _index;

            // AND 12
            int _start_i12 = _index;

            // AND 13
            int _start_i13 = _index;

            // LITERAL "function"
            _ParseLiteralString(_memo, ref _index, "function");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label13; }

            // PLUS 15
            int _start_i15 = _index;
            var _res15 = Enumerable.Empty<ASTNode>();
        label15:

            // CALLORVAR WT
            _Parser_Item _r16;

            _r16 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r16 != null) _index = _r16.NextIndex;

            // PLUS 15
            var _r15 = _memo.Results.Pop();
            if (_r15 != null)
            {
                _res15 = _res15.Concat(_r15.Results);
                goto label15;
            }
            else
            {
                if (_index > _start_i15)
                    _memo.Results.Push(new _Parser_Item(_start_i15, _index, _memo.InputEnumerable, _res15.Where(_NON_NULL), true));
                else
                    _memo.Results.Push(null);
            }

        label13: // AND
            var _r13_2 = _memo.Results.Pop();
            var _r13_1 = _memo.Results.Pop();

            if (_r13_1 != null && _r13_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i13, _index, _memo.InputEnumerable, _r13_1.Results.Concat(_r13_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i13;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label12; }

            // CALLORVAR Ident
            _Parser_Item _r18;

            _r18 = _MemoCall(_memo, "Ident", _index, Ident, null);

            if (_r18 != null) _index = _r18.NextIndex;

            // BIND name
            name = _memo.Results.Peek();

        label12: // AND
            var _r12_2 = _memo.Results.Pop();
            var _r12_1 = _memo.Results.Pop();

            if (_r12_1 != null && _r12_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i12, _index, _memo.InputEnumerable, _r12_1.Results.Concat(_r12_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i12;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label11; }

            // STAR 19
            int _start_i19 = _index;
            var _res19 = Enumerable.Empty<ASTNode>();
        label19:

            // CALLORVAR WT
            _Parser_Item _r20;

            _r20 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r20 != null) _index = _r20.NextIndex;

            // STAR 19
            var _r19 = _memo.Results.Pop();
            if (_r19 != null)
            {
                _res19 = _res19.Concat(_r19.Results);
                goto label19;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i19, _index, _memo.InputEnumerable, _res19.Where(_NON_NULL), true));
            }

        label11: // AND
            var _r11_2 = _memo.Results.Pop();
            var _r11_1 = _memo.Results.Pop();

            if (_r11_1 != null && _r11_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i11, _index, _memo.InputEnumerable, _r11_1.Results.Concat(_r11_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i11;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label10; }

            // LITERAL "("
            _ParseLiteralString(_memo, ref _index, "(");

        label10: // AND
            var _r10_2 = _memo.Results.Pop();
            var _r10_1 = _memo.Results.Pop();

            if (_r10_1 != null && _r10_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i10, _index, _memo.InputEnumerable, _r10_1.Results.Concat(_r10_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i10;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label9; }

            // STAR 23
            int _start_i23 = _index;
            var _res23 = Enumerable.Empty<ASTNode>();
        label23:

            // AND 24
            int _start_i24 = _index;

            // AND 25
            int _start_i25 = _index;

            // STAR 26
            int _start_i26 = _index;
            var _res26 = Enumerable.Empty<ASTNode>();
        label26:

            // CALLORVAR WT
            _Parser_Item _r27;

            _r27 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r27 != null) _index = _r27.NextIndex;

            // STAR 26
            var _r26 = _memo.Results.Pop();
            if (_r26 != null)
            {
                _res26 = _res26.Concat(_r26.Results);
                goto label26;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i26, _index, _memo.InputEnumerable, _res26.Where(_NON_NULL), true));
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label25; }

            // CALLORVAR Ident
            _Parser_Item _r28;

            _r28 = _MemoCall(_memo, "Ident", _index, Ident, null);

            if (_r28 != null) _index = _r28.NextIndex;

        label25: // AND
            var _r25_2 = _memo.Results.Pop();
            var _r25_1 = _memo.Results.Pop();

            if (_r25_1 != null && _r25_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i25, _index, _memo.InputEnumerable, _r25_1.Results.Concat(_r25_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i25;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label24; }

            // LITERAL ','
            _ParseLiteralChar(_memo, ref _index, ',');

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _Parser_Item(_index, _memo.InputEnumerable)); }

        label24: // AND
            var _r24_2 = _memo.Results.Pop();
            var _r24_1 = _memo.Results.Pop();

            if (_r24_1 != null && _r24_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i24, _index, _memo.InputEnumerable, _r24_1.Results.Concat(_r24_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i24;
            }

            // STAR 23
            var _r23 = _memo.Results.Pop();
            if (_r23 != null)
            {
                _res23 = _res23.Concat(_r23.Results);
                goto label23;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i23, _index, _memo.InputEnumerable, _res23.Where(_NON_NULL), true));
            }

            // BIND parameters
            parameters = _memo.Results.Peek();

        label9: // AND
            var _r9_2 = _memo.Results.Pop();
            var _r9_1 = _memo.Results.Pop();

            if (_r9_1 != null && _r9_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i9, _index, _memo.InputEnumerable, _r9_1.Results.Concat(_r9_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i9;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label8; }

            // STAR 31
            int _start_i31 = _index;
            var _res31 = Enumerable.Empty<ASTNode>();
        label31:

            // CALLORVAR WT
            _Parser_Item _r32;

            _r32 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r32 != null) _index = _r32.NextIndex;

            // STAR 31
            var _r31 = _memo.Results.Pop();
            if (_r31 != null)
            {
                _res31 = _res31.Concat(_r31.Results);
                goto label31;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i31, _index, _memo.InputEnumerable, _res31.Where(_NON_NULL), true));
            }

        label8: // AND
            var _r8_2 = _memo.Results.Pop();
            var _r8_1 = _memo.Results.Pop();

            if (_r8_1 != null && _r8_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i8, _index, _memo.InputEnumerable, _r8_1.Results.Concat(_r8_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i8;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label7; }

            // LITERAL ")"
            _ParseLiteralString(_memo, ref _index, ")");

        label7: // AND
            var _r7_2 = _memo.Results.Pop();
            var _r7_1 = _memo.Results.Pop();

            if (_r7_1 != null && _r7_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i7, _index, _memo.InputEnumerable, _r7_1.Results.Concat(_r7_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i7;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label6; }

            // STAR 34
            int _start_i34 = _index;
            var _res34 = Enumerable.Empty<ASTNode>();
        label34:

            // OR 35
            int _start_i35 = _index;

            // CALLORVAR WT
            _Parser_Item _r36;

            _r36 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r36 != null) _index = _r36.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i35; } else goto label35;

            // CALLORVAR EOL
            _Parser_Item _r37;

            _r37 = _MemoCall(_memo, "EOL", _index, EOL, null);

            if (_r37 != null) _index = _r37.NextIndex;

        label35: // OR
            int _dummy_i35 = _index; // no-op for label

            // STAR 34
            var _r34 = _memo.Results.Pop();
            if (_r34 != null)
            {
                _res34 = _res34.Concat(_r34.Results);
                goto label34;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i34, _index, _memo.InputEnumerable, _res34.Where(_NON_NULL), true));
            }

        label6: // AND
            var _r6_2 = _memo.Results.Pop();
            var _r6_1 = _memo.Results.Pop();

            if (_r6_1 != null && _r6_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i6, _index, _memo.InputEnumerable, _r6_1.Results.Concat(_r6_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i6;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label5; }

            // CALLORVAR BRA
            _Parser_Item _r38;

            _r38 = _MemoCall(_memo, "BRA", _index, BRA, null);

            if (_r38 != null) _index = _r38.NextIndex;

        label5: // AND
            var _r5_2 = _memo.Results.Pop();
            var _r5_1 = _memo.Results.Pop();

            if (_r5_1 != null && _r5_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i5, _index, _memo.InputEnumerable, _r5_1.Results.Concat(_r5_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i5;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // STAR 39
            int _start_i39 = _index;
            var _res39 = Enumerable.Empty<ASTNode>();
        label39:

            // OR 40
            int _start_i40 = _index;

            // CALLORVAR WT
            _Parser_Item _r41;

            _r41 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r41 != null) _index = _r41.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i40; } else goto label40;

            // CALLORVAR EOL
            _Parser_Item _r42;

            _r42 = _MemoCall(_memo, "EOL", _index, EOL, null);

            if (_r42 != null) _index = _r42.NextIndex;

        label40: // OR
            int _dummy_i40 = _index; // no-op for label

            // STAR 39
            var _r39 = _memo.Results.Pop();
            if (_r39 != null)
            {
                _res39 = _res39.Concat(_r39.Results);
                goto label39;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i39, _index, _memo.InputEnumerable, _res39.Where(_NON_NULL), true));
            }

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // STAR 44
            int _start_i44 = _index;
            var _res44 = Enumerable.Empty<ASTNode>();
        label44:

            // CALLORVAR Node
            _Parser_Item _r45;

            _r45 = _MemoCall(_memo, "Node", _index, Node, null);

            if (_r45 != null) _index = _r45.NextIndex;

            // STAR 44
            var _r44 = _memo.Results.Pop();
            if (_r44 != null)
            {
                _res44 = _res44.Concat(_r44.Results);
                goto label44;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i44, _index, _memo.InputEnumerable, _res44.Where(_NON_NULL), true));
            }

            // BIND nodes
            nodes = _memo.Results.Peek();

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // STAR 46
            int _start_i46 = _index;
            var _res46 = Enumerable.Empty<ASTNode>();
        label46:

            // OR 47
            int _start_i47 = _index;

            // CALLORVAR WT
            _Parser_Item _r48;

            _r48 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r48 != null) _index = _r48.NextIndex;

            // OR shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _index = _start_i47; } else goto label47;

            // CALLORVAR EOL
            _Parser_Item _r49;

            _r49 = _MemoCall(_memo, "EOL", _index, EOL, null);

            if (_r49 != null) _index = _r49.NextIndex;

        label47: // OR
            int _dummy_i47 = _index; // no-op for label

            // STAR 46
            var _r46 = _memo.Results.Pop();
            if (_r46 != null)
            {
                _res46 = _res46.Concat(_r46.Results);
                goto label46;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i46, _index, _memo.InputEnumerable, _res46.Where(_NON_NULL), true));
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // CALLORVAR KET
            _Parser_Item _r50;

            _r50 = _MemoCall(_memo, "KET", _index, KET, null);

            if (_r50 != null) _index = _r50.NextIndex;

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new Function(Input(name), nodes.Results, parameters.Results.Cast<Identifier>()); }, _r0), true) );
            }

        }


        public void FunctionCall(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item name = null;
            _Parser_Item parameters = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // CALLORVAR Ident
            _Parser_Item _r7;

            _r7 = _MemoCall(_memo, "Ident", _index, Ident, null);

            if (_r7 != null) _index = _r7.NextIndex;

            // BIND name
            name = _memo.Results.Peek();

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label5; }

            // STAR 8
            int _start_i8 = _index;
            var _res8 = Enumerable.Empty<ASTNode>();
        label8:

            // CALLORVAR WT
            _Parser_Item _r9;

            _r9 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r9 != null) _index = _r9.NextIndex;

            // STAR 8
            var _r8 = _memo.Results.Pop();
            if (_r8 != null)
            {
                _res8 = _res8.Concat(_r8.Results);
                goto label8;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i8, _index, _memo.InputEnumerable, _res8.Where(_NON_NULL), true));
            }

        label5: // AND
            var _r5_2 = _memo.Results.Pop();
            var _r5_1 = _memo.Results.Pop();

            if (_r5_1 != null && _r5_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i5, _index, _memo.InputEnumerable, _r5_1.Results.Concat(_r5_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i5;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // LITERAL "("
            _ParseLiteralString(_memo, ref _index, "(");

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // STAR 12
            int _start_i12 = _index;
            var _res12 = Enumerable.Empty<ASTNode>();
        label12:

            // AND 13
            int _start_i13 = _index;

            // AND 14
            int _start_i14 = _index;

            // STAR 15
            int _start_i15 = _index;
            var _res15 = Enumerable.Empty<ASTNode>();
        label15:

            // CALLORVAR WT
            _Parser_Item _r16;

            _r16 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r16 != null) _index = _r16.NextIndex;

            // STAR 15
            var _r15 = _memo.Results.Pop();
            if (_r15 != null)
            {
                _res15 = _res15.Concat(_r15.Results);
                goto label15;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i15, _index, _memo.InputEnumerable, _res15.Where(_NON_NULL), true));
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label14; }

            // CALLORVAR Expression
            _Parser_Item _r17;

            _r17 = _MemoCall(_memo, "Expression", _index, Expression, null);

            if (_r17 != null) _index = _r17.NextIndex;

        label14: // AND
            var _r14_2 = _memo.Results.Pop();
            var _r14_1 = _memo.Results.Pop();

            if (_r14_1 != null && _r14_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i14, _index, _memo.InputEnumerable, _r14_1.Results.Concat(_r14_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i14;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label13; }

            // LITERAL ','
            _ParseLiteralChar(_memo, ref _index, ',');

            // QUES
            if (_memo.Results.Peek() == null) { _memo.Results.Pop(); _memo.Results.Push(new _Parser_Item(_index, _memo.InputEnumerable)); }

        label13: // AND
            var _r13_2 = _memo.Results.Pop();
            var _r13_1 = _memo.Results.Pop();

            if (_r13_1 != null && _r13_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i13, _index, _memo.InputEnumerable, _r13_1.Results.Concat(_r13_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i13;
            }

            // STAR 12
            var _r12 = _memo.Results.Pop();
            if (_r12 != null)
            {
                _res12 = _res12.Concat(_r12.Results);
                goto label12;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i12, _index, _memo.InputEnumerable, _res12.Where(_NON_NULL), true));
            }

            // BIND parameters
            parameters = _memo.Results.Peek();

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // STAR 20
            int _start_i20 = _index;
            var _res20 = Enumerable.Empty<ASTNode>();
        label20:

            // CALLORVAR WT
            _Parser_Item _r21;

            _r21 = _MemoCall(_memo, "WT", _index, WT, null);

            if (_r21 != null) _index = _r21.NextIndex;

            // STAR 20
            var _r20 = _memo.Results.Pop();
            if (_r20 != null)
            {
                _res20 = _res20.Concat(_r20.Results);
                goto label20;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i20, _index, _memo.InputEnumerable, _res20.Where(_NON_NULL), true));
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // LITERAL ")"
            _ParseLiteralString(_memo, ref _index, ")");

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new FunctionCall(Input(name), parameters.Results.Cast<IExpression>()); }, _r0), true) );
            }

        }


        public void OperatorExpression(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item l = null;
            _Parser_Item op = null;
            _Parser_Item r = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // STAR 7
            int _start_i7 = _index;
            var _res7 = Enumerable.Empty<ASTNode>();
        label7:

            // CALLORVAR WS
            _Parser_Item _r8;

            _r8 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r8 != null) _index = _r8.NextIndex;

            // STAR 7
            var _r7 = _memo.Results.Pop();
            if (_r7 != null)
            {
                _res7 = _res7.Concat(_r7.Results);
                goto label7;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i7, _index, _memo.InputEnumerable, _res7.Where(_NON_NULL), true));
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label6; }

            // CALLORVAR Expression
            _Parser_Item _r10;

            _r10 = _MemoCall(_memo, "Expression", _index, Expression, null);

            if (_r10 != null) _index = _r10.NextIndex;

            // BIND l
            l = _memo.Results.Peek();

        label6: // AND
            var _r6_2 = _memo.Results.Pop();
            var _r6_1 = _memo.Results.Pop();

            if (_r6_1 != null && _r6_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i6, _index, _memo.InputEnumerable, _r6_1.Results.Concat(_r6_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i6;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label5; }

            // STAR 11
            int _start_i11 = _index;
            var _res11 = Enumerable.Empty<ASTNode>();
        label11:

            // CALLORVAR WS
            _Parser_Item _r12;

            _r12 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r12 != null) _index = _r12.NextIndex;

            // STAR 11
            var _r11 = _memo.Results.Pop();
            if (_r11 != null)
            {
                _res11 = _res11.Concat(_r11.Results);
                goto label11;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i11, _index, _memo.InputEnumerable, _res11.Where(_NON_NULL), true));
            }

        label5: // AND
            var _r5_2 = _memo.Results.Pop();
            var _r5_1 = _memo.Results.Pop();

            if (_r5_1 != null && _r5_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i5, _index, _memo.InputEnumerable, _r5_1.Results.Concat(_r5_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i5;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // CALLORVAR Operator
            _Parser_Item _r14;

            _r14 = _MemoCall(_memo, "Operator", _index, Operator, null);

            if (_r14 != null) _index = _r14.NextIndex;

            // BIND op
            op = _memo.Results.Peek();

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // STAR 15
            int _start_i15 = _index;
            var _res15 = Enumerable.Empty<ASTNode>();
        label15:

            // CALLORVAR WS
            _Parser_Item _r16;

            _r16 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r16 != null) _index = _r16.NextIndex;

            // STAR 15
            var _r15 = _memo.Results.Pop();
            if (_r15 != null)
            {
                _res15 = _res15.Concat(_r15.Results);
                goto label15;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i15, _index, _memo.InputEnumerable, _res15.Where(_NON_NULL), true));
            }

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // CALLORVAR Expression
            _Parser_Item _r18;

            _r18 = _MemoCall(_memo, "Expression", _index, Expression, null);

            if (_r18 != null) _index = _r18.NextIndex;

            // BIND r
            r = _memo.Results.Peek();

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // STAR 19
            int _start_i19 = _index;
            var _res19 = Enumerable.Empty<ASTNode>();
        label19:

            // CALLORVAR WS
            _Parser_Item _r20;

            _r20 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r20 != null) _index = _r20.NextIndex;

            // STAR 19
            var _r19 = _memo.Results.Pop();
            if (_r19 != null)
            {
                _res19 = _res19.Concat(_r19.Results);
                goto label19;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i19, _index, _memo.InputEnumerable, _res19.Where(_NON_NULL), true));
            }

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new OperatorExpression((IExpression)((ASTNode)l), Input(op), (IExpression)((ASTNode)r)); }, _r0), true) );
            }

        }


        public void ParensExpression(_Parser_Memo _memo, int _index, _Parser_Args _args)
        {

            _Parser_Item l = null;
            _Parser_Item op = null;
            _Parser_Item r = null;

            // AND 1
            int _start_i1 = _index;

            // AND 2
            int _start_i2 = _index;

            // AND 3
            int _start_i3 = _index;

            // AND 4
            int _start_i4 = _index;

            // AND 5
            int _start_i5 = _index;

            // AND 6
            int _start_i6 = _index;

            // AND 7
            int _start_i7 = _index;

            // AND 8
            int _start_i8 = _index;

            // LITERAL "("
            _ParseLiteralString(_memo, ref _index, "(");

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label8; }

            // STAR 10
            int _start_i10 = _index;
            var _res10 = Enumerable.Empty<ASTNode>();
        label10:

            // CALLORVAR WS
            _Parser_Item _r11;

            _r11 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r11 != null) _index = _r11.NextIndex;

            // STAR 10
            var _r10 = _memo.Results.Pop();
            if (_r10 != null)
            {
                _res10 = _res10.Concat(_r10.Results);
                goto label10;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i10, _index, _memo.InputEnumerable, _res10.Where(_NON_NULL), true));
            }

        label8: // AND
            var _r8_2 = _memo.Results.Pop();
            var _r8_1 = _memo.Results.Pop();

            if (_r8_1 != null && _r8_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i8, _index, _memo.InputEnumerable, _r8_1.Results.Concat(_r8_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i8;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label7; }

            // CALLORVAR Expression
            _Parser_Item _r13;

            _r13 = _MemoCall(_memo, "Expression", _index, Expression, null);

            if (_r13 != null) _index = _r13.NextIndex;

            // BIND l
            l = _memo.Results.Peek();

        label7: // AND
            var _r7_2 = _memo.Results.Pop();
            var _r7_1 = _memo.Results.Pop();

            if (_r7_1 != null && _r7_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i7, _index, _memo.InputEnumerable, _r7_1.Results.Concat(_r7_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i7;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label6; }

            // STAR 14
            int _start_i14 = _index;
            var _res14 = Enumerable.Empty<ASTNode>();
        label14:

            // CALLORVAR WS
            _Parser_Item _r15;

            _r15 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r15 != null) _index = _r15.NextIndex;

            // STAR 14
            var _r14 = _memo.Results.Pop();
            if (_r14 != null)
            {
                _res14 = _res14.Concat(_r14.Results);
                goto label14;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i14, _index, _memo.InputEnumerable, _res14.Where(_NON_NULL), true));
            }

        label6: // AND
            var _r6_2 = _memo.Results.Pop();
            var _r6_1 = _memo.Results.Pop();

            if (_r6_1 != null && _r6_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i6, _index, _memo.InputEnumerable, _r6_1.Results.Concat(_r6_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i6;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label5; }

            // CALLORVAR Operator
            _Parser_Item _r17;

            _r17 = _MemoCall(_memo, "Operator", _index, Operator, null);

            if (_r17 != null) _index = _r17.NextIndex;

            // BIND op
            op = _memo.Results.Peek();

        label5: // AND
            var _r5_2 = _memo.Results.Pop();
            var _r5_1 = _memo.Results.Pop();

            if (_r5_1 != null && _r5_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i5, _index, _memo.InputEnumerable, _r5_1.Results.Concat(_r5_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i5;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label4; }

            // STAR 18
            int _start_i18 = _index;
            var _res18 = Enumerable.Empty<ASTNode>();
        label18:

            // CALLORVAR WS
            _Parser_Item _r19;

            _r19 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r19 != null) _index = _r19.NextIndex;

            // STAR 18
            var _r18 = _memo.Results.Pop();
            if (_r18 != null)
            {
                _res18 = _res18.Concat(_r18.Results);
                goto label18;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i18, _index, _memo.InputEnumerable, _res18.Where(_NON_NULL), true));
            }

        label4: // AND
            var _r4_2 = _memo.Results.Pop();
            var _r4_1 = _memo.Results.Pop();

            if (_r4_1 != null && _r4_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i4, _index, _memo.InputEnumerable, _r4_1.Results.Concat(_r4_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i4;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label3; }

            // CALLORVAR Expression
            _Parser_Item _r21;

            _r21 = _MemoCall(_memo, "Expression", _index, Expression, null);

            if (_r21 != null) _index = _r21.NextIndex;

            // BIND r
            r = _memo.Results.Peek();

        label3: // AND
            var _r3_2 = _memo.Results.Pop();
            var _r3_1 = _memo.Results.Pop();

            if (_r3_1 != null && _r3_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i3, _index, _memo.InputEnumerable, _r3_1.Results.Concat(_r3_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i3;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label2; }

            // STAR 22
            int _start_i22 = _index;
            var _res22 = Enumerable.Empty<ASTNode>();
        label22:

            // CALLORVAR WS
            _Parser_Item _r23;

            _r23 = _MemoCall(_memo, "WS", _index, WS, null);

            if (_r23 != null) _index = _r23.NextIndex;

            // STAR 22
            var _r22 = _memo.Results.Pop();
            if (_r22 != null)
            {
                _res22 = _res22.Concat(_r22.Results);
                goto label22;
            }
            else
            {
                _memo.Results.Push(new _Parser_Item(_start_i22, _index, _memo.InputEnumerable, _res22.Where(_NON_NULL), true));
            }

        label2: // AND
            var _r2_2 = _memo.Results.Pop();
            var _r2_1 = _memo.Results.Pop();

            if (_r2_1 != null && _r2_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i2, _index, _memo.InputEnumerable, _r2_1.Results.Concat(_r2_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i2;
            }

            // AND shortcut
            if (_memo.Results.Peek() == null) { _memo.Results.Push(null); goto label1; }

            // LITERAL ")"
            _ParseLiteralString(_memo, ref _index, ")");

        label1: // AND
            var _r1_2 = _memo.Results.Pop();
            var _r1_1 = _memo.Results.Pop();

            if (_r1_1 != null && _r1_2 != null)
            {
                _memo.Results.Push( new _Parser_Item(_start_i1, _index, _memo.InputEnumerable, _r1_1.Results.Concat(_r1_2.Results).Where(_NON_NULL), true) );
            }
            else
            {
                _memo.Results.Push(null);
                _index = _start_i1;
            }

            // ACT
            var _r0 = _memo.Results.Peek();
            if (_r0 != null)
            {
                _memo.Results.Pop();
                _memo.Results.Push( new _Parser_Item(_r0.StartIndex, _r0.NextIndex, _memo.InputEnumerable, _Thunk(_IM_Result => { return new OperatorExpression((IExpression)((ASTNode)l), Input(op), (IExpression)((ASTNode)r)); }, _r0), true) );
            }

        }

    } // class Parser

} // namespace LambdaMan.Compiler

