using LambdaMan.Compiler;
using System;
using System.Windows.Forms;

namespace VisualGcc
{
    public partial class VisualGccForm : Form
    {
        public VisualGccForm()
        {
            InitializeComponent();
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            var compiler = new GccCompiler();

            OutputTextBox.Text = compiler.Compile(InputTextBox.Text, lineNumbersCheckBox.Checked);
        }

        private void lineNumbersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InputTextBox_TextChanged(sender, e);
        }
    }
}
