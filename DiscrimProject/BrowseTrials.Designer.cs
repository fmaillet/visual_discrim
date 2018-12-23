namespace DiscrimProject
{
    partial class BrowseTrialsForm
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
            this.n_label = new System.Windows.Forms.Label();
            this.congruence_label = new System.Windows.Forms.Label();
            this.answer_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // n_label
            // 
            this.n_label.AutoSize = true;
            this.n_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n_label.Location = new System.Drawing.Point(13, 13);
            this.n_label.Name = "n_label";
            this.n_label.Size = new System.Drawing.Size(19, 20);
            this.n_label.TabIndex = 0;
            this.n_label.Text = "n";
            // 
            // congruence_label
            // 
            this.congruence_label.AutoSize = true;
            this.congruence_label.Location = new System.Drawing.Point(14, 58);
            this.congruence_label.Name = "congruence_label";
            this.congruence_label.Size = new System.Drawing.Size(64, 13);
            this.congruence_label.TabIndex = 1;
            this.congruence_label.Text = "congruence";
            // 
            // answer_label
            // 
            this.answer_label.AutoSize = true;
            this.answer_label.Location = new System.Drawing.Point(17, 85);
            this.answer_label.Name = "answer_label";
            this.answer_label.Size = new System.Drawing.Size(41, 13);
            this.answer_label.TabIndex = 2;
            this.answer_label.Text = "answer";
            // 
            // BrowseTrialsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.answer_label);
            this.Controls.Add(this.congruence_label);
            this.Controls.Add(this.n_label);
            this.Name = "BrowseTrialsForm";
            this.Text = "Browse Trials";
            this.Load += new System.EventHandler(this.BrowseTrialsForm_Load);
            this.Shown += new System.EventHandler(this.BrowseTrialsForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BrowseTrialsForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BrowseTrialsForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BrowseTrialsForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_label;
        private System.Windows.Forms.Label congruence_label;
        private System.Windows.Forms.Label answer_label;
    }
}