namespace DiscrimProject
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.calibrationButton = new System.Windows.Forms.Button();
            this.launchExpeButton = new System.Windows.Forms.Button();
            this.showEyesBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // calibrationButton
            // 
            this.calibrationButton.Location = new System.Drawing.Point(538, 56);
            this.calibrationButton.Name = "calibrationButton";
            this.calibrationButton.Size = new System.Drawing.Size(133, 35);
            this.calibrationButton.TabIndex = 0;
            this.calibrationButton.Text = "Calibration Tobii4C";
            this.calibrationButton.UseVisualStyleBackColor = true;
            this.calibrationButton.Click += new System.EventHandler(this.calibrationButton_Click);
            // 
            // launchExpeButton
            // 
            this.launchExpeButton.Location = new System.Drawing.Point(538, 133);
            this.launchExpeButton.Name = "launchExpeButton";
            this.launchExpeButton.Size = new System.Drawing.Size(133, 35);
            this.launchExpeButton.TabIndex = 1;
            this.launchExpeButton.Text = "Lancer expé";
            this.launchExpeButton.UseVisualStyleBackColor = true;
            this.launchExpeButton.Click += new System.EventHandler(this.launchExpeButton_Click);
            // 
            // showEyesBox
            // 
            this.showEyesBox.AutoSize = true;
            this.showEyesBox.Location = new System.Drawing.Point(323, 150);
            this.showEyesBox.Name = "showEyesBox";
            this.showEyesBox.Size = new System.Drawing.Size(79, 17);
            this.showEyesBox.TabIndex = 2;
            this.showEyesBox.Text = "Show gaze";
            this.showEyesBox.UseVisualStyleBackColor = true;
            this.showEyesBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showEyesBox);
            this.Controls.Add(this.launchExpeButton);
            this.Controls.Add(this.calibrationButton);
            this.Name = "MainForm";
            this.Text = "Tobii Discrimination Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calibrationButton;
        private System.Windows.Forms.Button launchExpeButton;
        private System.Windows.Forms.CheckBox showEyesBox;
    }
}

