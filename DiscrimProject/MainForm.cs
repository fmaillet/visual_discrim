using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Interaction;
using Tobii.Interaction.Framework;

namespace DiscrimProject
{
    public partial class MainForm : Form
    {
        SpeechSynthesizer synth;
        SpeechRecognitionEngine _recognizer;
        PromptBuilder consignes, falseRecog;

        static private Host tobii4C = new Host();

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
                            allowEyeTrack(true);
                            break;

                        default:
                            Console.WriteLine("User is not present");
                            break;
                    }
            });
        }

        //Launch eye-tracker calibration
        private void calibrationButton_Click(object sender, EventArgs e)
        {
            // 3 points
            tobii4C.Context.LaunchConfigurationTool(ConfigurationTool.RetailCalibration, (data) => { });
            //6 points
            //tobii4C.Context.LaunchConfigurationTool(ConfigurationTool.Recalibrate, (data) => { }); 
        }

        //Launch one expe check
        private void launchExpeButton_Click(object sender, EventArgs e)
        {

        }

        //Allow calibration button
        private void allowEyeTrack(Boolean b)
        {
            Invoke(new Action(() =>
            {
                calibrationButton.Enabled = b;
            }));

        }
    }

    
}

