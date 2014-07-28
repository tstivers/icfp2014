using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using LambdaMan.Compiler;
using System;
using System.IO;
using System.Windows.Forms;

namespace VisualGcc
{
    public static class Bleh
    {
        public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;

            if (propertyInfo == null ||
                !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
                @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new VisualGccForm.SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
            }
        }
    }

    public partial class VisualGccForm : Form
    {
        public VisualGccForm()
        {
            InitializeComponent();
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            var compiler = new GccCompiler();

            Task.Run(() => compiler.Compile(InputTextBox.Text, lineNumbersCheckBox.Checked, includeCommentsCheckbox.Checked, breakOnExceptionCheckbox.Checked))
                .ContinueWith(a => OutputTextBox.SetPropertyThreadSafe(() => OutputTextBox.Text, a.Result));            
        }

        public delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);

     

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
