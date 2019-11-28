﻿namespace IF.Tools.CodeGenerator
{
    partial class ApiListGeneratorForm
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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.checkedListBoxVsFiles = new System.Windows.Forms.CheckedListBox();
            this.labelControllerName = new System.Windows.Forms.Label();
            this.textBoxControllerName = new System.Windows.Forms.TextBox();
            this.labelRepositoryName = new System.Windows.Forms.Label();
            this.textBoxRepositoryName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(682, 369);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // checkedListBoxVsFiles
            // 
            this.checkedListBoxVsFiles.FormattingEnabled = true;
            this.checkedListBoxVsFiles.Location = new System.Drawing.Point(26, 33);
            this.checkedListBoxVsFiles.Name = "checkedListBoxVsFiles";
            this.checkedListBoxVsFiles.Size = new System.Drawing.Size(225, 199);
            this.checkedListBoxVsFiles.TabIndex = 1;
            // 
            // labelControllerName
            // 
            this.labelControllerName.AutoSize = true;
            this.labelControllerName.Location = new System.Drawing.Point(285, 36);
            this.labelControllerName.Name = "labelControllerName";
            this.labelControllerName.Size = new System.Drawing.Size(82, 13);
            this.labelControllerName.TabIndex = 18;
            this.labelControllerName.Text = "Controller Name";
            // 
            // textBoxControllerName
            // 
            this.textBoxControllerName.Location = new System.Drawing.Point(376, 33);
            this.textBoxControllerName.Name = "textBoxControllerName";
            this.textBoxControllerName.Size = new System.Drawing.Size(195, 20);
            this.textBoxControllerName.TabIndex = 17;
            // 
            // labelRepositoryName
            // 
            this.labelRepositoryName.AutoSize = true;
            this.labelRepositoryName.Location = new System.Drawing.Point(285, 85);
            this.labelRepositoryName.Name = "labelRepositoryName";
            this.labelRepositoryName.Size = new System.Drawing.Size(88, 13);
            this.labelRepositoryName.TabIndex = 20;
            this.labelRepositoryName.Text = "Repository Name";
            // 
            // textBoxRepositoryName
            // 
            this.textBoxRepositoryName.Location = new System.Drawing.Point(376, 82);
            this.textBoxRepositoryName.Name = "textBoxRepositoryName";
            this.textBoxRepositoryName.Size = new System.Drawing.Size(195, 20);
            this.textBoxRepositoryName.TabIndex = 19;
            // 
            // ApiListGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelRepositoryName);
            this.Controls.Add(this.textBoxRepositoryName);
            this.Controls.Add(this.labelControllerName);
            this.Controls.Add(this.textBoxControllerName);
            this.Controls.Add(this.checkedListBoxVsFiles);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "ApiListGeneratorForm";
            this.Text = "ListGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.CheckedListBox checkedListBoxVsFiles;
        private System.Windows.Forms.Label labelControllerName;
        private System.Windows.Forms.TextBox textBoxControllerName;
        private System.Windows.Forms.Label labelRepositoryName;
        private System.Windows.Forms.TextBox textBoxRepositoryName;
    }
}