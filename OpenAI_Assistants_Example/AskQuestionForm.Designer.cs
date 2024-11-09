namespace OpenAI_Assistants_Example
{
    partial class AskQuestionForm
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
            Ask_Question_Txt = new TextBox();
            Ask_Question_Btn = new Button();
            Get_Answer_Btn = new Button();
            Answer_Listbox = new ListBox();
            Clear_Btn = new Button();
            SuspendLayout();
            // 
            // Ask_Question_Txt
            // 
            Ask_Question_Txt.Location = new Point(12, 12);
            Ask_Question_Txt.Name = "Ask_Question_Txt";
            Ask_Question_Txt.Size = new Size(120, 23);
            Ask_Question_Txt.TabIndex = 0;
            // 
            // Ask_Question_Btn
            // 
            Ask_Question_Btn.Location = new Point(138, 11);
            Ask_Question_Btn.Name = "Ask_Question_Btn";
            Ask_Question_Btn.Size = new Size(106, 23);
            Ask_Question_Btn.TabIndex = 1;
            Ask_Question_Btn.Text = "Ask Question";
            Ask_Question_Btn.UseVisualStyleBackColor = true;
            Ask_Question_Btn.Click += Ask_Question_Btn_Click;
            // 
            // Get_Answer_Btn
            // 
            Get_Answer_Btn.Location = new Point(138, 50);
            Get_Answer_Btn.Name = "Get_Answer_Btn";
            Get_Answer_Btn.Size = new Size(106, 23);
            Get_Answer_Btn.TabIndex = 3;
            Get_Answer_Btn.Text = "Get Answer";
            Get_Answer_Btn.UseVisualStyleBackColor = true;
            Get_Answer_Btn.Click += Get_Answer_Btn_Click;
            // 
            // Answer_Listbox
            // 
            Answer_Listbox.FormattingEnabled = true;
            Answer_Listbox.ItemHeight = 15;
            Answer_Listbox.Location = new Point(12, 50);
            Answer_Listbox.Name = "Answer_Listbox";
            Answer_Listbox.Size = new Size(120, 94);
            Answer_Listbox.TabIndex = 4;
            // 
            // Clear_Btn
            // 
            Clear_Btn.Location = new Point(138, 79);
            Clear_Btn.Name = "Clear_Btn";
            Clear_Btn.Size = new Size(106, 23);
            Clear_Btn.TabIndex = 5;
            Clear_Btn.Text = "Clear List";
            Clear_Btn.UseVisualStyleBackColor = true;
            Clear_Btn.Click += Clear_Btn_Click;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 178);
            Controls.Add(Clear_Btn);
            Controls.Add(Answer_Listbox);
            Controls.Add(Get_Answer_Btn);
            Controls.Add(Ask_Question_Btn);
            Controls.Add(Ask_Question_Txt);
            Name = "Form";
            Text = "Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Ask_Question_Txt;
        private Button Ask_Question_Btn;
        private Button Get_Answer_Btn;
        private ListBox Answer_Listbox;
        private Button Clear_Btn;
    }
}