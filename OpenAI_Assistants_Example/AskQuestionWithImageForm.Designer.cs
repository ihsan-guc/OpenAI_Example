namespace OpenAI_Assistants_Example
{
    partial class AskQuestionWithImageForm
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
            Chose_Image_Btn = new Button();
            Answer_Listbox = new ListBox();
            Get_Answer_Btn = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // Chose_Image_Btn
            // 
            Chose_Image_Btn.Location = new Point(9, 12);
            Chose_Image_Btn.Name = "Chose_Image_Btn";
            Chose_Image_Btn.Size = new Size(218, 23);
            Chose_Image_Btn.TabIndex = 3;
            Chose_Image_Btn.Text = "Chose Image";
            Chose_Image_Btn.UseVisualStyleBackColor = true;
            Chose_Image_Btn.Click += Chose_Image_Btn_Click;
            // 
            // Answer_Listbox
            // 
            Answer_Listbox.FormattingEnabled = true;
            Answer_Listbox.ItemHeight = 15;
            Answer_Listbox.Location = new Point(9, 41);
            Answer_Listbox.Name = "Answer_Listbox";
            Answer_Listbox.Size = new Size(106, 94);
            Answer_Listbox.TabIndex = 6;
            // 
            // Get_Answer_Btn
            // 
            Get_Answer_Btn.Location = new Point(121, 41);
            Get_Answer_Btn.Name = "Get_Answer_Btn";
            Get_Answer_Btn.Size = new Size(106, 23);
            Get_Answer_Btn.TabIndex = 5;
            Get_Answer_Btn.Text = "Get Answer";
            Get_Answer_Btn.UseVisualStyleBackColor = true;
            Get_Answer_Btn.Click += Get_Answer_Btn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // AskQuestionWithImageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 181);
            Controls.Add(Answer_Listbox);
            Controls.Add(Get_Answer_Btn);
            Controls.Add(Chose_Image_Btn);
            Margin = new Padding(2);
            Name = "AskQuestionWithImageForm";
            Text = "AskQuestionWithImageForm";
            ResumeLayout(false);
        }

        #endregion

        private Button Chose_Image_Btn;
        private ListBox Answer_Listbox;
        private Button Get_Answer_Btn;
        private OpenFileDialog openFileDialog1;
    }
}