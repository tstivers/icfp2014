﻿namespace VisualGcc
{
    partial class VisualGccForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PropertiesSplitter = new System.Windows.Forms.SplitContainer();
            this.CodeSplitter = new System.Windows.Forms.SplitContainer();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lineNumbersCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesSplitter)).BeginInit();
            this.PropertiesSplitter.Panel1.SuspendLayout();
            this.PropertiesSplitter.Panel2.SuspendLayout();
            this.PropertiesSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeSplitter)).BeginInit();
            this.CodeSplitter.Panel1.SuspendLayout();
            this.CodeSplitter.Panel2.SuspendLayout();
            this.CodeSplitter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertiesSplitter
            // 
            this.PropertiesSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertiesSplitter.Location = new System.Drawing.Point(0, 0);
            this.PropertiesSplitter.Name = "PropertiesSplitter";
            this.PropertiesSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // PropertiesSplitter.Panel1
            // 
            this.PropertiesSplitter.Panel1.Controls.Add(this.CodeSplitter);
            // 
            // PropertiesSplitter.Panel2
            // 
            this.PropertiesSplitter.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.PropertiesSplitter.Size = new System.Drawing.Size(1272, 1040);
            this.PropertiesSplitter.SplitterDistance = 779;
            this.PropertiesSplitter.TabIndex = 0;
            // 
            // CodeSplitter
            // 
            this.CodeSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeSplitter.Location = new System.Drawing.Point(0, 0);
            this.CodeSplitter.Name = "CodeSplitter";
            // 
            // CodeSplitter.Panel1
            // 
            this.CodeSplitter.Panel1.Controls.Add(this.InputTextBox);
            // 
            // CodeSplitter.Panel2
            // 
            this.CodeSplitter.Panel2.Controls.Add(this.OutputTextBox);
            this.CodeSplitter.Size = new System.Drawing.Size(1272, 779);
            this.CodeSplitter.SplitterDistance = 579;
            this.CodeSplitter.TabIndex = 0;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(0, 0);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(579, 779);
            this.InputTextBox.TabIndex = 0;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTextBox.Location = new System.Drawing.Point(0, 0);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(689, 779);
            this.OutputTextBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lineNumbersCheckBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1272, 257);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lineNumbersCheckBox
            // 
            this.lineNumbersCheckBox.AutoSize = true;
            this.lineNumbersCheckBox.Location = new System.Drawing.Point(3, 3);
            this.lineNumbersCheckBox.Name = "lineNumbersCheckBox";
            this.lineNumbersCheckBox.Size = new System.Drawing.Size(129, 17);
            this.lineNumbersCheckBox.TabIndex = 0;
            this.lineNumbersCheckBox.Text = "Include Line Numbers";
            this.lineNumbersCheckBox.UseVisualStyleBackColor = true;
            this.lineNumbersCheckBox.CheckedChanged += new System.EventHandler(this.lineNumbersCheckBox_CheckedChanged);
            // 
            // VisualGccForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 1040);
            this.Controls.Add(this.PropertiesSplitter);
            this.Name = "VisualGccForm";
            this.Text = "VisualGcc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisualGccForm_FormClosing);
            this.Load += new System.EventHandler(this.VisualGccForm_Load);
            this.PropertiesSplitter.Panel1.ResumeLayout(false);
            this.PropertiesSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesSplitter)).EndInit();
            this.PropertiesSplitter.ResumeLayout(false);
            this.CodeSplitter.Panel1.ResumeLayout(false);
            this.CodeSplitter.Panel1.PerformLayout();
            this.CodeSplitter.Panel2.ResumeLayout(false);
            this.CodeSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeSplitter)).EndInit();
            this.CodeSplitter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer PropertiesSplitter;
        private System.Windows.Forms.SplitContainer CodeSplitter;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox lineNumbersCheckBox;
    }
}

