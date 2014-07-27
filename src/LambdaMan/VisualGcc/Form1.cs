using LambdaMan.Compiler;
using System;
using System.IO;
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

            OutputTextBox.Text = compiler.Compile(InputTextBox.Text, lineNumbersCheckBox.Checked, includeCommentsCheckbox.Checked, breakOnExceptionCheckbox.Checked);
        }

        private void lineNumbersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InputTextBox_TextChanged(sender, e);
        }

        private void VisualGccForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
        }

        private void VisualGccForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("contents.txt"))
                InputTextBox.Text = File.ReadAllText("contents.txt");
        }

        private void includeCommentsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            InputTextBox_TextChanged(sender, e);
        }

        private void breakOnExceptionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            InputTextBox_TextChanged(sender, e);
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                InputTextBox.SelectAll();
        }

        private void OutputTextBox_Enter(object sender, EventArgs e)
        {
            Clipboard.SetText(OutputTextBox.Text);
        }
    }
}
