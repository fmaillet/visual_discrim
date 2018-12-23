using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscrimProject
{
    public partial class BrowseTrialsForm : Form
    {
        int trialListIdx;
        Trials trial;

        public BrowseTrialsForm()
        {
            InitializeComponent();
            //passer en full view
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void BrowseTrialsForm_Load(object sender, EventArgs e)
        {

        }

        private void BrowseTrialsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) UpdateTrial(trialListIdx - 1);
            if (e.KeyCode == Keys.Right) UpdateTrial(trialListIdx + 1);
        }

        private void BrowseTrialsForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) this.Close();
        }

        private void UpdateTrial (int n)
        {
            if (n < 0 | n > MainForm.allTrials.Count-1) return;
            trialListIdx = n;
            trial = MainForm.allTrials.ElementAt(trialListIdx);
            n_label.Text = (trialListIdx + 1).ToString() + "/" + MainForm.allTrials.Count.ToString();
            congruence_label.Text = "Congruence: " + trial.congruence.ToString();
            answer_label.Text = "Response  : " + trial.response.ToString();
            this.Refresh();
        }

        private void BrowseTrialsForm_Shown(object sender, EventArgs e)
        {
            UpdateTrial(0);
        }

        private void BrowseTrialsForm_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Black, 2);

            graphicsObj.DrawPolygon(myPen, trial.polygon1.ToArray());
            graphicsObj.DrawPolygon(myPen, trial.polygon2.ToArray());
        }
    }
}
