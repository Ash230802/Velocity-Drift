using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VelocityDrift
{
    public partial class Form2 : Form
    {
        private Road _road;
        private List<PictureBox> _roadLines;
        private int InitialX = 365;
        private int InitialY = 345;
        private int _currentSpeed = 0;
        private PlayerCar _playerCar;
        private int elapsedSeconds = 0;
        private EnemyCar _enemyCar;
        private Dictionary<InterferenceField, PictureBox> _objectPictureBoxes;
        private PictureBox pictureBox;
        private int _movementDistance = 110;
        private string ImagePath = "C:\\Users\\NAJWA ASHYIELA\\OneDrive\\Documents\\COS20007\\CustomProject\\";
        public Form2()
        {
            InitializeComponent();
            _roadLines = new List<PictureBox>();
            _road = new Road(_roadLines);
            _playerCar = new PlayerCar(ImagePath, InitialX, InitialY);
            _enemyCar = new EnemyCar();
            pictureBox = new PictureBox();
            _objectPictureBoxes = new Dictionary<InterferenceField, PictureBox>();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            AddRoadLine();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveRoad(_currentSpeed);
            label1.Text = $"Velocity: {_road.YVelocity}";
            label2.Text = $"Distance left: {_road.YDisplacement}";
            foreach (KeyValuePair<InterferenceField, PictureBox> pair in _objectPictureBoxes)
            {
                InterferenceField interferenceField = pair.Key;
                PictureBox pictureBox = pair.Value;

                GenerateRandomPosition(interferenceField, pictureBox);
            }
        }
        private void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            elapsedSeconds++;

            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60; // giving the remainder of seconds

            label3.Text = $"{minutes:00}:{seconds:00}";
            if (minutes >= 3)
            {
                timer2.Stop();
                timer1.Stop();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw the player car image on the form
            if (_playerCar != null)
            {
                pictureBox13.Image = _playerCar.Image; // Set the image of the PictureBox control
                pictureBox13.Size = new Size(_playerCar.Image.Width, _playerCar.Image.Height); //default size
                pictureBox13.Location = new Point((int)_playerCar.X, (int)_playerCar.Y);
            }
        }

        private void AddRoadLine()
        {
            for (int i = 1; i <= 8; i++)
            {
                PictureBox roadLine = Controls.Find("pictureBox" + i, true).FirstOrDefault() as PictureBox; //search for the Controls property with the type PictureBox
                if (roadLine != null)
                {
                    _roadLines.Add(roadLine);
                }
            }
        }

        private void GenerateRandomPosition<T>(T interferenceField, PictureBox pictureBox) where T : InterferenceField
        {
            Random random = new Random();
            int laneWidth = this.Width / 3; // 3 lanes

            if (pictureBox.Top > this.Height)
            {
                int laneIndex = random.Next(0, 3);
                int laneX = laneIndex * laneWidth + laneWidth / 2;
                int y = 0;
                interferenceField.X = laneX; // Set the X property of the interference field
                interferenceField.Y = y;
                pictureBox.Location = new Point(laneX, y);
            }
            else
            {
                interferenceField.Y += _currentSpeed;
                pictureBox.Top += _currentSpeed;
            }
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                _currentSpeed = _road.VelocityIncrement(_currentSpeed);
            }
            if (e.KeyCode == Keys.Down)
            {
                _currentSpeed = _road.VelocityDecrement(_currentSpeed);
            }
            if (e.KeyCode == Keys.Right)
            {
               GoRight();
            }
            if (e.KeyCode == Keys.Left)
            {
               GoLeft();
            }
        }
        public void MoveRoad(int roadSpeed)
        {
            foreach (PictureBox roadLine in _roadLines)
            {
                if (roadLine.Top >= this.Height)
                {
                    roadLine.Top = -roadLine.Height;
                }
                else
                {
                    roadLine.Top += roadSpeed;
                }
            }
        }
        public void GoLeft()
        {
            if (_playerCar.X + _playerCar.Image.Width > 0 + pictureBox9.Width + pictureBox11.Width + (_playerCar.Image.Width * 2))
            {
                _playerCar.X -= _movementDistance;
                int newLeft = (int)Math.Round(_playerCar.X);
                _playerCar.X = newLeft;
            }
        }

        public void GoRight()
        {
            if (_playerCar.X < this.Width - pictureBox10.Width - pictureBox12.Width - (_playerCar.Image.Width * 2))
            {
                _playerCar.X += _movementDistance;
                int newLeft = (int)Math.Round(_playerCar.X);
                _playerCar.X = newLeft;
            }
        }
    }
}
