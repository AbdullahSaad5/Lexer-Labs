namespace Lab5Task1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.tfToken = new System.Windows.Forms.RichTextBox();
            this.symbolTable = new System.Windows.Forms.RichTextBox();
            this.tfInput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(371, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Generate Lexemes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tfToken
            // 
            this.tfToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tfToken.Location = new System.Drawing.Point(12, 229);
            this.tfToken.Name = "tfToken";
            this.tfToken.Size = new System.Drawing.Size(406, 168);
            this.tfToken.TabIndex = 10;
            this.tfToken.Text = "";
            // 
            // symbolTable
            // 
            this.symbolTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbolTable.Location = new System.Drawing.Point(448, 229);
            this.symbolTable.Name = "symbolTable";
            this.symbolTable.Size = new System.Drawing.Size(406, 168);
            this.symbolTable.TabIndex = 9;
            this.symbolTable.Text = "";
            // 
            // tfInput
            // 
            this.tfInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tfInput.Location = new System.Drawing.Point(12, 12);
            this.tfInput.Name = "tfInput";
            this.tfInput.Size = new System.Drawing.Size(842, 211);
            this.tfInput.TabIndex = 8;
            this.tfInput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tfToken);
            this.Controls.Add(this.symbolTable);
            this.Controls.Add(this.tfInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox tfToken;
        private System.Windows.Forms.RichTextBox symbolTable;
        private System.Windows.Forms.RichTextBox tfInput;
    }
}

