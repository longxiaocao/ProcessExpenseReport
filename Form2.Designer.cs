namespace ProcessExpenseReport
{
    partial class Form2
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
            btnSelectFolder = new Button();
            btnProcessFiles = new Button();
            txtFolderPath = new TextBox();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(12, 12);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(94, 29);
            btnSelectFolder.TabIndex = 0;
            btnSelectFolder.Text = "选择文件夹";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnProcessFiles
            // 
            btnProcessFiles.Location = new Point(12, 47);
            btnProcessFiles.Name = "btnProcessFiles";
            btnProcessFiles.Size = new Size(94, 29);
            btnProcessFiles.TabIndex = 1;
            btnProcessFiles.Text = "开始处理";
            btnProcessFiles.UseVisualStyleBackColor = true;
            btnProcessFiles.Click += btnProcessFiles_Click;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(112, 14);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(621, 27);
            txtFolderPath.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(112, 47);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(621, 29);
            progressBar1.TabIndex = 3;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 89);
            Controls.Add(progressBar1);
            Controls.Add(txtFolderPath);
            Controls.Add(btnProcessFiles);
            Controls.Add(btnSelectFolder);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFolder;
        private Button btnProcessFiles;
        private TextBox txtFolderPath;
        private ProgressBar progressBar1;
    }
}