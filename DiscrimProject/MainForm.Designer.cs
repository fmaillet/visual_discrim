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
            this.nbTrials = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.meanTimeLabel = new System.Windows.Forms.Label();
            this.meanSY_TimeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveCSV_button = new System.Windows.Forms.Button();
            this.ID_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.browseTrials_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calibrationButton
            // 
            this.calibrationButton.Location = new System.Drawing.Point(26, 21);
            this.calibrationButton.Name = "calibrationButton";
            this.calibrationButton.Size = new System.Drawing.Size(133, 35);
            this.calibrationButton.TabIndex = 0;
            this.calibrationButton.Text = "Calibration Tobii4C";
            this.calibrationButton.UseVisualStyleBackColor = true;
            this.calibrationButton.Click += new System.EventHandler(this.CalibrationButton_Click);
            // 
            // launchExpeButton
            // 
            this.launchExpeButton.Location = new System.Drawing.Point(348, 21);
            this.launchExpeButton.Name = "launchExpeButton";
            this.launchExpeButton.Size = new System.Drawing.Size(133, 53);
            this.launchExpeButton.TabIndex = 1;
            this.launchExpeButton.Text = "Lancer expé";
            this.launchExpeButton.UseVisualStyleBackColor = true;
            this.launchExpeButton.Click += new System.EventHandler(this.LaunchExpeButton_Click);
            // 
            // showEyesBox
            // 
            this.showEyesBox.AutoSize = true;
            this.showEyesBox.Location = new System.Drawing.Point(197, 22);
            this.showEyesBox.Name = "showEyesBox";
            this.showEyesBox.Size = new System.Drawing.Size(79, 17);
            this.showEyesBox.TabIndex = 2;
            this.showEyesBox.Text = "Show gaze";
            this.showEyesBox.UseVisualStyleBackColor = true;
            this.showEyesBox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // nbTrials
            // 
            this.nbTrials.AutoSize = true;
            this.nbTrials.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbTrials.Location = new System.Drawing.Point(23, 130);
            this.nbTrials.Name = "nbTrials";
            this.nbTrials.Size = new System.Drawing.Size(130, 16);
            this.nbTrials.TabIndex = 3;
            this.nbTrials.Text = " 0 essais réalisés";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(23, 180);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(31, 16);
            this.score.TabIndex = 4;
            this.score.Text = "-- %";
            // 
            // meanTimeLabel
            // 
            this.meanTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.meanTimeLabel.AutoSize = true;
            this.meanTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meanTimeLabel.Location = new System.Drawing.Point(185, 78);
            this.meanTimeLabel.Name = "meanTimeLabel";
            this.meanTimeLabel.Size = new System.Drawing.Size(58, 16);
            this.meanTimeLabel.TabIndex = 5;
            this.meanTimeLabel.Text = "(all time)";
            // 
            // meanSY_TimeLabel
            // 
            this.meanSY_TimeLabel.AutoSize = true;
            this.meanSY_TimeLabel.Location = new System.Drawing.Point(53, 21);
            this.meanSY_TimeLabel.Name = "meanSY_TimeLabel";
            this.meanSY_TimeLabel.Size = new System.Drawing.Size(59, 13);
            this.meanSY_TimeLabel.TabIndex = 6;
            this.meanSY_TimeLabel.Text = "(good time)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.meanSY_TimeLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.meanTimeLabel, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(238, 180);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(248, 100);
            this.tableLayoutPanel1.TabIndex = 7;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sames";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Differents";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "1200";
            // 
            // saveCSV_button
            // 
            this.saveCSV_button.Location = new System.Drawing.Point(618, 22);
            this.saveCSV_button.Name = "saveCSV_button";
            this.saveCSV_button.Size = new System.Drawing.Size(133, 34);
            this.saveCSV_button.TabIndex = 8;
            this.saveCSV_button.Text = "Sauvegarder datas";
            this.saveCSV_button.UseVisualStyleBackColor = true;
            this.saveCSV_button.Click += new System.EventHandler(this.saveCSV_button_Click);
            // 
            // ID_textBox
            // 
            this.ID_textBox.Location = new System.Drawing.Point(225, 54);
            this.ID_textBox.Name = "ID_textBox";
            this.ID_textBox.Size = new System.Drawing.Size(76, 20);
            this.ID_textBox.TabIndex = 9;
            this.ID_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_textBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Id :";
            // 
            // browseTrials_button
            // 
            this.browseTrials_button.Location = new System.Drawing.Point(26, 229);
            this.browseTrials_button.Name = "browseTrials_button";
            this.browseTrials_button.Size = new System.Drawing.Size(133, 51);
            this.browseTrials_button.TabIndex = 11;
            this.browseTrials_button.Text = "Voir les essais";
            this.browseTrials_button.UseVisualStyleBackColor = true;
            this.browseTrials_button.Click += new System.EventHandler(this.BrowseTrials_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.browseTrials_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ID_textBox);
            this.Controls.Add(this.saveCSV_button);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.score);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nbTrials);
            this.Controls.Add(this.showEyesBox);
            this.Controls.Add(this.launchExpeButton);
            this.Controls.Add(this.calibrationButton);
            this.Name = "MainForm";
            this.Text = "Tobii Discrimination Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calibrationButton;
        private System.Windows.Forms.Button launchExpeButton;
        private System.Windows.Forms.CheckBox showEyesBox;
        private System.Windows.Forms.Label nbTrials;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label meanTimeLabel;
        private System.Windows.Forms.Label meanSY_TimeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveCSV_button;
        private System.Windows.Forms.TextBox ID_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button browseTrials_button;
    }
}

