using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Thread gazeThread, trialsThread;
        int trialState = 0;

        Trials currentTrial;
        Stopwatch stopwatch = new Stopwatch();

        SpeechRecognitionEngine _recognizer;
        FixationDataStream fixationDataStream;
        GazePointDataStream pointDataStream;
        double eyeX = 100;
        double eyeY = 100;

        PromptBuilder fixCenterMsg, falseRecog;
        SpeechSynthesizer synth;

        List<PointF> polygon1, polygon2;
        Boolean polyEquals;
        Random rnd = new Random(1234);

        // Init form
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
            GrammarBuilder gb = new GrammarBuilder(reponses, 1, 1);
            //gb.Append(reponses);
            Grammar g = new Grammar(gb);
            //Recog
            _recognizer = new SpeechRecognitionEngine();
            _recognizer.RequestRecognizerUpdate();
            _recognizer.LoadGrammar(g);
            //Event handler
            _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            _recognizer.SpeechRecognitionRejected += _recognizer_SpeechNotRecognized;
            //Default input
            _recognizer.SetInputToDefaultAudioDevice();
            //asynchronous
            //_recognizer.RecognizeAsync(RecognizeMode.Multiple);
            //_recognizer.RecognizeAsync(RecognizeMode.Single);

            //Init synthe
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            fixCenterMsg = new PromptBuilder();
            fixCenterMsg.StartSentence();
            fixCenterMsg.AppendText("Fixez bien la croix au centre de l'écran.");
            fixCenterMsg.EndSentence();
            falseRecog = new PromptBuilder();
            falseRecog.StartSentence();
            falseRecog.AppendText("Je n'ai pas compris.");
            falseRecog.EndSentence();
        }

        // When form is shown, init gaze monitoring
        private void TrialForm_Shown(object sender, EventArgs e)
        {
            //Init tobbi gaze
            fixationDataStream = MainForm.tobii4C.Streams.CreateFixationDataStream();
            fixationDataStream.Begin((x, y, timestamp) => { eyeX = x; eyeY = y; });
            fixationDataStream.End((x, y, timestamp) => { eyeX = x; eyeY = y; });

            //Refresh gaze drawing
            if (MainForm.showGaze)
            {
                // Init tobii point gaze and get data's
                pointDataStream = MainForm.tobii4C.Streams.CreateGazePointDataStream();
                pointDataStream.GazePoint((x, y, ts) => { eyeX = x; eyeY = y; });
                // Init gaze pointer refresh thread
                gazeThread = new Thread(new ThreadStart(GazeRefreshThread))
                {
                    IsBackground = true
                };
                gazeThread.Start();
            }
        }

        // Show gaze pointer refresh thread
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

        // A word hasn't been recognized
        private void _recognizer_SpeechNotRecognized(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            stopwatch.Stop();
            synth.SpeakAsync(fixCenterMsg);
            //_recognizer.Recognize();
        }

        // A word has been recognized
        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //Console.WriteLine(e.Result.Text + " " + e.Result.Confidence);
            if (e.Result.Confidence >= 0.7)
            {
                // Get trial time and answer
                if (stopwatch.IsRunning) stopwatch.Stop();
                currentTrial.elapsed_time = stopwatch.ElapsedMilliseconds;
                currentTrial.answer = (e.Result.Text == "Oui");
                //Save trial in trials list
                MainForm.allTrials.Add(currentTrial);
                //initiate new trial
                trialState = 0;
                Invoke(new Action(() =>
                {
                    this.Refresh();
                }));
            }
            else
            {
                stopwatch.Stop();
                synth.SpeakAsync(falseRecog);
                //_recognizer.Recognize();
            }
        }

        // Running trials thread, stops with ESC key
        private void TrialsRunningThread ()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                currentTrial = new Trials();
                GeneratePolygon();
                trialState = 1;
                Thread.Sleep(1000);
                Invoke(new Action(() =>
                {
                    this.Refresh();
                }));
                stopwatch.Restart();
                while (trialState == 1)
                    _recognizer.Recognize();
            }
        }

        // KeyPress event
        private void TrialForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                StopTrials();
            else if (e.KeyChar == (char)Keys.Space && trialState == 0)
            {
                if (true) //if (gazeCentered())
                {
                    trialsThread = new Thread(new ThreadStart(TrialsRunningThread))
                    {
                        IsBackground = true
                    };
                    trialsThread.Start();
                }
                else
                    synth.SpeakAsync(fixCenterMsg);
            }
        }

        // Check if gaze in centered (cross fixation)
        private Boolean GazeCentered ()
        {
            if (eyeX > this.Width / 2 - 20 && eyeX < this.Width / 2 + 20)
                if (eyeY > this.Height / 2 - 20 && eyeY < this.Height / 2 + 20)
                    return true;
            return false;
        }

        private void StopTrials()
        {
            trialsThread.Abort();
            trialState = 0;
            if (gazeThread != null) gazeThread.Abort();
            if (_recognizer != null) _recognizer.Dispose();
            Cursor.Show();
            //host.Dispose();
            this.Close();
        }

        // Generate (and record) new polygon's trials
        private void GeneratePolygon()
        {
            double alpha = 2 * Math.PI / 5;
            polygon1 = new List<PointF>();
            polygon2 = new List<PointF>();

            polyEquals = Convert.ToBoolean(rnd.Next() % 2);

            PointF center1 = new PointF(2*this.Width / 6, this.Height / 2);
            PointF center2 = new PointF(4*this.Width / 6, this.Height / 2);
            //POLYGON LEFT
            for (int i = 0; i < 5; i++)
            {
                double r = rnd.Next(this.Width / 6-100, this.Width / 6-20);
                PointF p = new PointF((float)(r * Math.Cos(alpha * i)), (float)(r * Math.Sin(alpha * i)));
                polygon1.Add(PointF.Add(p, new System.Drawing.Size((int)center1.X, (int)center1.Y)));
                if (polyEquals) polygon2.Add(PointF.Add(p, new System.Drawing.Size((int)center2.X, (int)center2.Y)));
            }
            //POLYGON RIGHT
            if (!polyEquals)
            {
                for (int i = 0; i < 5; i++)
                {
                    double r = rnd.Next(this.Width / 6 - 100, this.Width / 6 - 20);
                    PointF p = new PointF((float)(r * Math.Cos(alpha * i)), (float)(r * Math.Sin(alpha * i)));
                    polygon2.Add(PointF.Add(p, new System.Drawing.Size((int)center2.X, (int)center2.Y)));
                }
            }

            //Save the trial
            currentTrial.equals = polyEquals;
            currentTrial.polygon1 = polygon1;
            currentTrial.polygon2 = polygon2;
        }

        // Form paint function
        private void TrialForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            //Pens
            Pen myPen2 = new Pen(System.Drawing.Color.Gray, 2);
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
                //graphicsObj.DrawLine(myPen2, this.Width /2, 50, this.Width / 2, this.Height-50);
                //Draw polygon 1
                graphicsObj.DrawPolygon(myPen, polygon1.ToArray());
                //Draw polygon 2
                graphicsObj.DrawPolygon(myPen, polygon2.ToArray());
            }

            //Draw gaze
            if (MainForm.showGaze)
            {
                if (GazeCentered()) myPen.Color = System.Drawing.Color.Red;
                else myPen.Color = System.Drawing.Color.Gray;
                myPen.Width = 1;
                g.DrawEllipse(myPen, (int)eyeX - 50, (int)eyeY - 50, 100, 100);
            }
        }

        // Just draw a fixation cross in the middle of the screen
        private void DrawCross (System.Drawing.Graphics graphicsObj, Pen myPen, PointF center)
        {
            graphicsObj.DrawLine(myPen, center.X - 10, center.Y, center.X + 10, center.Y);
            graphicsObj.DrawLine(myPen, center.X, center.Y - 10, center.X, center.Y + 10);
        }

        
    }
}
