using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Interaction;

namespace DiscrimProject
{
    public partial class TrialForm : Form
    {
        //Thread pour les essais
        Thread gazeThread;
        int trialState = 0;

        SpeechRecognitionEngine _recognizer;
        FixationDataStream fixationDataStream;
        GazePointDataStream pointDataStream;
        double eyeX = 100;
        double eyeY = 100;

        PromptBuilder fixCenterMsg, falseRecog;
        SpeechSynthesizer synth;

        public TrialForm()
        {
            InitializeComponent();
            //passer en full view
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            //Initialize recognizer
            //Grammaire
            Choices reponses = new Choices();
            reponses.Add(new string[] { "oui", "non" });
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(reponses);
            Grammar g = new Grammar(gb);
            //Recog
            _recognizer = new SpeechRecognitionEngine();
            _recognizer.LoadGrammar(g);
            //Event handler
            _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            //Default input
            _recognizer.SetInputToDefaultAudioDevice();
            //asynchronous
            //_recognizer.RecognizeAsync(RecognizeMode.Multiple);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            //Init synthe
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            fixCenterMsg = new PromptBuilder();
            fixCenterMsg.StartSentence();
            fixCenterMsg.AppendText("Fixez bien la croix au centre de l'écran.");
            fixCenterMsg.EndSentence();
        }

        void GazeRefreshThread ()
        {
            while (Thread.CurrentThread.IsAlive)
                {
                    Invoke(new Action(() =>
                {
                    this.Refresh();
                }));
                Thread.Sleep(100);
            }
        }

        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= 0.7 && trialState == 1)
            {
                if (e.Result.Text == "non")
                {
                    
                }
                else
                {
                    
                }
                trialState = 0;
                this.Refresh();
            }
            /*else
                synth.SpeakAsync(falseRecog);*/
        }

        private void TrialForm_Load(object sender, EventArgs e)
        {

        }

        private void TrialForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                StopTrials();
            else if (e.KeyChar == (char)Keys.Space && trialState == 0)
            {
                if (true) //if (gazeCentered())
                {
                    trialState = 1;
                    this.Refresh();
                }
                else
                    synth.SpeakAsync(fixCenterMsg);
            }
        }

        private Boolean gazeCentered ()
        {
            if (eyeX > this.Width / 2 - 20 && eyeX < this.Width / 2 + 20)
                if (eyeY > this.Height / 2 - 20 && eyeY < this.Height / 2 + 20)
                    return true;
            return false;
        }

        private void StopTrials()
        {
            
            gazeThread.Abort();
            //if (_recognizer != null) _recognizer.Dispose();
            Cursor.Show();
            //host.Dispose();
            this.Close();
        }

        private void TrialForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            //Pen
            Pen myPen = new Pen(System.Drawing.Color.Black, 2);

            if (trialState == 0)
            {
                
                //Draw cross
                graphicsObj.DrawLine(myPen, (this.Width / 2) , (this.Height /2)-10 , (this.Width / 2) , (this.Height/2) + 10);
                graphicsObj.DrawLine(myPen, (this.Width / 2)-10, (this.Height / 2) , (this.Width / 2)+10, (this.Height / 2) );
            }
            else if (trialState == 1)
            {
                //Draw vertical line
                graphicsObj.DrawLine(myPen, this.Width /2, 50, this.Width / 2, this.Height-50);
                //Draw polygon 1
                PointF point1 = new PointF(150.0F+350, 250.0F);
                PointF point2 = new PointF(200.0F+350, 225.0F);
                PointF point3 = new PointF(300.0F+350, 205.0F);
                PointF point4 = new PointF(350.0F+350, 250.0F);
                PointF point5 = new PointF(400.0F+350, 300.0F);
                PointF point6 = new PointF(450.0F+350, 400.0F);
                PointF point7 = new PointF(350.0F+350, 450.0F);
                PointF[] curvePoints =
                {
                     point1,
                     point2,
                     point3,
                     point4,
                     point5,
                     point6,
                     point7
                };
                graphicsObj.DrawPolygon(myPen, curvePoints);
                //Draw polygon 2
                point1 = new PointF(150.0F+ this.Width / 2, 250.0F);
                point2 = new PointF(200.0F+ this.Width / 2, 225.0F);
                point3 = new PointF(300.0F+ this.Width / 2, 205.0F);
                point4 = new PointF(350.0F+ this.Width / 2, 250.0F);
                point5 = new PointF(400.0F+ this.Width / 2, 300.0F);
                point6 = new PointF(450.0F+ this.Width / 2, 400.0F);
                point7 = new PointF(350.0F+ this.Width / 2, 450.0F);
                PointF[] curvePoints2 =
                {
                     point1,
                     point2,
                     point3,
                     point4,
                     point5,
                     point6,
                     point7
                };
                graphicsObj.DrawPolygon(myPen, curvePoints2);
            }

            //Draw gaze
            if (gazeCentered()) myPen.Color = System.Drawing.Color.Red;
            else myPen.Color = System.Drawing.Color.Gray;
            myPen.Width = 1;
            g.DrawEllipse(myPen, (int)eyeX - 50, (int)eyeY - 50, 100, 100);

        }

        private void TrialForm_Shown(object sender, EventArgs e)
        {
            //Init tobbi gaze
            pointDataStream = MainForm.tobii4C.Streams.CreateGazePointDataStream();
            /*fixationDataStream = MainForm.tobii4C.Streams.CreateFixationDataStream();
            fixationDataStream.Begin((x, y, timestamp) => { eyeX = x; eyeY = y; });*/
            pointDataStream.GazePoint((x, y, ts) => { eyeX = x; eyeY = y; });
            //Refresh gaze drawing
            gazeThread = new Thread(new ThreadStart(GazeRefreshThread));
            gazeThread.IsBackground = true;
            gazeThread.Start();
        }
    }
}
