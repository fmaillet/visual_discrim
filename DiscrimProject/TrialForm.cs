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

        List<PointF> polygon1, polygon2;
        Boolean polyEquals;

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
            //_recognizer.RecognizeAsync(RecognizeMode.Multiple);

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
                    generatePolygon();
                    trialState = 1;
                    this.Refresh();
                    _recognizer.Recognize();
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
            
            if (gazeThread != null) gazeThread.Abort();
            //if (_recognizer != null) _recognizer.Dispose();
            Cursor.Show();
            //host.Dispose();
            this.Close();
        }

        private void generatePolygon()
        {
            Random rnd = new Random();
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
            
        }

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
                if (gazeCentered()) myPen.Color = System.Drawing.Color.Red;
                else myPen.Color = System.Drawing.Color.Gray;
                myPen.Width = 1;
                g.DrawEllipse(myPen, (int)eyeX - 50, (int)eyeY - 50, 100, 100);
            }
        }

        private void drawCross (System.Drawing.Graphics graphicsObj, Pen myPen, PointF center)
        {
            graphicsObj.DrawLine(myPen, center.X - 10, center.Y, center.X + 10, center.Y);
            graphicsObj.DrawLine(myPen, center.X, center.Y - 10, center.X, center.Y + 10);
        }

        private void TrialForm_Shown(object sender, EventArgs e)
        {
            //Init tobbi gaze
            pointDataStream = MainForm.tobii4C.Streams.CreateGazePointDataStream();
            /*fixationDataStream = MainForm.tobii4C.Streams.CreateFixationDataStream();
            fixationDataStream.Begin((x, y, timestamp) => { eyeX = x; eyeY = y; });*/
            pointDataStream.GazePoint((x, y, ts) => { eyeX = x; eyeY = y; });
            //Refresh gaze drawing
            if (MainForm.showGaze)
            {
                gazeThread = new Thread(new ThreadStart(GazeRefreshThread));
                gazeThread.IsBackground = true;
                gazeThread.Start();
            }
        }
    }
}
