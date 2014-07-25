using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LambdaMan.Compiler;

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

            OutputTextBox.Text = compiler.Compile(InputTextBox.Text);
        }
    }
}
