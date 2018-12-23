using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Interaction;
using Tobii.Interaction.Framework;

public struct Trials
{
    public Boolean congruence;
    public List<PointF> polygon1, polygon2;
    public Boolean response;
    public long elapsed_time;
};

namespace DiscrimProject
{
    public partial class MainForm : Form
    {
        SpeechSynthesizer synth;

        static public Host tobii4C = new Host();

        static public Boolean showGaze = false;

        static public List<Trials> allTrials;

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            //Change form title
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            this.Text = "Tobii Discrimination Research Project (v" + version.ToString() + ")";

            //Initialize speech synth
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();

            //Check for Tobii eye-tracker
            tobii4C = new Host();
            calibrationButton.Enabled = false;
            var userPresenceStateObserver = tobii4C.States.CreateUserPresenceObserver();
            userPresenceStateObserver.WhenChanged(userPresenceState =>
            {
                if (userPresenceState.IsValid)
                    switch (userPresenceState.Value)
                    {
                        case UserPresence.Present:
                            AllowEyeTrack(true);
                            break;

                        default:
                            Console.WriteLine("User is not present");
                            break;
                    }
            });

            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        //Launch eye-tracker calibration
        private void CalibrationButton_Click(object sender, EventArgs e)
        {
            // 3 points
            tobii4C.Context.LaunchConfigurationTool(ConfigurationTool.RetailCalibration, (data) => { });
            //6 points
            //tobii4C.Context.LaunchConfigurationTool(ConfigurationTool.Recalibrate, (data) => { }); 
        }

        //Launch one expe check
        private void LaunchExpeButton_Click(object sender, EventArgs e)
        {
            allTrials = new List<Trials>();

            TrialForm trials = new TrialForm();
            trials.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tobii4C.Dispose();
        }

        //Allow calibration button
        private void AllowEyeTrack(Boolean b)
        {
            Invoke(new Action(() =>
            {
                calibrationButton.Enabled = b;
            }));

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            showGaze = showEyesBox.Checked;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (allTrials == null) return;
            if (allTrials.Count == 0) return;
            nbTrials.Text = allTrials.Count + " essais réalisés";
            //On parcours la liste
            int good = 0;
            long meanTime = 0;
            long meanTimeG = 0;
            long meanTimeB = 0;
            foreach (Trials trial in allTrials)
            {
                if (trial.congruence == trial.response)
                {
                    good = good + 1;
                    meanTimeG = meanTimeG + trial.elapsed_time;
                }
                else meanTimeB = meanTimeB + trial.elapsed_time;
                meanTime = meanTime + trial.elapsed_time;
            }
            //Score
            score.Text = "Score : " + good + " / " + allTrials.Count;
            // Mean answers times
            meanTimeLabel.Text = "" + meanTime / allTrials.Count ;
            if (good != 0) meanSY_TimeLabel.Text = "" + meanTimeG / good ;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Save datas to CSV file
        // https://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp
        private void saveCSV_button_Click(object sender, EventArgs e)
        {
            // if nothing to save, return
            if (allTrials == null) return;
            if (allTrials.Count == 0) return;
            // get subject ID
            if (string.IsNullOrWhiteSpace(ID_textBox.Text)) return;
            var id = ID_textBox.Text;
            // construct the cvs
            var csv = new StringBuilder();
            csv.AppendLine("ID,congruence,response,delay");
            // loop in trials
            foreach (Trials trial in allTrials)
            {
                var first = trial.congruence.ToString();
                var second = trial.response.ToString();
                var third = trial.elapsed_time.ToString();
                var newLine = string.Format("{0},{1},{2},{3}", id, first, second, third);
                csv.AppendLine(newLine);
            }
            // get path
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                File.WriteAllText(folderPath + "\\data.csv", csv.ToString());
            }
            else return;
            Console.WriteLine(folderPath+"\\data.csv saved");
        }

        // Limit ID textbox input to numbers
        // https://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
        private void ID_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BrowseTrials_button_Click(object sender, EventArgs e)
        {
            // if nothing to save, return
            if (allTrials == null) return;
            if (allTrials.Count == 0) return;
            // open trials browser
            BrowseTrialsForm trialsBrowser = new BrowseTrialsForm();
            trialsBrowser.Show();
        }
    }

    
}

