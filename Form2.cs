using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VelocityDrift
{
    public partial class Form2 : Form
    {

        /*--------------------------------------------------------------------*/
        /* Declare global constants:                                          */
        /*--------------------------------------------------------------------*/
        private const int NUM_COLLECTIBLES = 2;
        private const int NUM_ENEMY_CARS = 5;
        private const int NUM_LANES = 3;
        private const int NUM_OBJECTS = 2;
        private const int NUM_OBJECT_TYPES = 2;

        private const int OBJECT_TYPE_ENEMY_CAR = 1;
        private const int OBJECT_TYPE_COLLECTIBLE = 2;

        private const int OBJECT_TYPE_COLLECTIBLE_COIN = 1;
        private const int OBJECT_TYPE_COLLECTIBLE_PRESENT = 2;

        /*--------------------------------------------------------------------*/
        /* Declare class variables used throughout the class:                 */
        /*--------------------------------------------------------------------*/
        private EnemyCar _enemyCar;
        private int _startingSpeed = 2;
        private int _currentSpeed = 2;
        private int elapsedSeconds = 0;
        private int lanePlayerStart = 2;
        private int yPlayerStart = 345;
        private int numBlockers = 0;
        private InterferenceField _interferenceField;
        private Lane lane1;
        private Lane lane2;
        private Lane lane3;
        private int _score = 0;
        //In C#, the backslash character (/) is an escape character used to indicate
        //special characters or sequences. When you want to include
        //a backslash itself as part of a string literal, you need to escape it by using another backslash.
        private string ImagePath = "C:\\Users\\NAJWA ASHYIELA\\OneDrive\\Documents\\COS20007\\CustomProject\\";
        private PictureBox pictureBox;
        private List<InterferenceField> _interferenceFieldObjects = new List<InterferenceField>();
        private List<PictureBox> _roadLines;
        private PlayerCar _playerCar;
        private Road _road;

        /*--------------------------------------------------------------------*/
        /* Declare a random number generator:                                 */
        /*--------------------------------------------------------------------*/
        private Random random;

        public Form2()
        {
            /*----------------------------------------------------------------*/
            /* Initialise the program:                                        */
            /*----------------------------------------------------------------*/
            InitializeComponent();

            /*----------------------------------------------------------------*/
            /* Create a random number generator object:                       */
            /*----------------------------------------------------------------*/
            random = new Random();
        }

        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Form 2 load event callback function:                               */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private void Form2_Load(object sender, EventArgs e)
        {
            /*----------------------------------------------------------------*/
            /* Create the interferenceField:                                  */
            /*----------------------------------------------------------------*/
            _interferenceField = new InterferenceField();

            /*----------------------------------------------------------------*/
            /* Create the road:                                               */
            /*----------------------------------------------------------------*/
            _road = new Road(_roadLines);

            /*----------------------------------------------------------------*/
            /* Add the white lines pictures to the road lines list:           */
            /*----------------------------------------------------------------*/
            _roadLines = new List<PictureBox>();
            AddRoadLine();

            /*----------------------------------------------------------------*/
            /* Create the lane:                                               */
            /*----------------------------------------------------------------*/
            lane1 = new Lane();
            lane2 = new Lane();
            lane3 = new Lane();

            /*----------------------------------------------------------------*/
            /* Set the middle lane unavailable and not started:               */
            /*----------------------------------------------------------------*/
            lane2.available = false;
            lane2.started = false;

            /*----------------------------------------------------------------*/
            /* Calculate the centre x-coordinate of each lane:                */
            /*----------------------------------------------------------------*/
            int laneWidth = (this.Width - (RoadBoundaryLeft.Width + RoadSpacerLeft.Width) - (RoadBoundaryRight.Width + RoadSpacerRight.Width) - (roadLine4.Width * 2)) / 3;
            lane1.x = ((RoadBoundaryLeft.Width + RoadSpacerLeft.Width) + laneWidth / 2) - ( 50 / 2);
            lane2.x = lane1.x + roadLine4.Width + laneWidth;
            lane3.x = lane2.x + roadLine4.Width + laneWidth;

            /*----------------------------------------------------------------*/
            /* Create the player car and place it in the middle lane to start:*/
            /*----------------------------------------------------------------*/
            pictureBox = new PictureBox();
            this.Controls.Add(pictureBox);
            _playerCar = new PlayerCar(pictureBox, ImagePath, GetLaneXCoordinate(lanePlayerStart), yPlayerStart, lanePlayerStart, UpdateScore);
            _playerCar.pictureBox.BringToFront();
        }

        
        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Launch a new object:                                               */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private void launchObject()
        {
            /*----------------------------------------------------------------*/
            /* Declare local variables:                                       */
            /*----------------------------------------------------------------*/
            int lane;
            int objectType;

            /*----------------------------------------------------------------*/
            /* Get a random lane and check if it is available:                */
            /*----------------------------------------------------------------*/
            lane = random.Next(1, NUM_LANES + 1);
            //Debug.WriteLine(string.Format("Got random lane {0}", lane));

            if (IsLaneAvailable(lane))
            {
                Debug.WriteLine(string.Format("lane {0} is available", lane));
                /*------------------------------------------------------------*/
                /* Launch a new object according to random object type:       */
                /*------------------------------------------------------------*/
                objectType = random.Next(1, NUM_OBJECT_TYPES + 1);
                switch (objectType)
                {
                    case OBJECT_TYPE_ENEMY_CAR:
                        if (numBlockers < 2)
                        {
                            launchNewEnemyCar(lane);
                            numBlockers++;
                            SetLaneAvailability(lane, false);
                        }
                        else
                            Debug.WriteLine(string.Format("Enemy car is blocked in lane {0}", lane));
                        break;
                    case OBJECT_TYPE_COLLECTIBLE:
                        if (numBlockers < 2)
                        {
                            launchNewCollectible(lane);
                            numBlockers++;
                            SetLaneAvailability(lane, false);
                        }
                        break;
                }
                /*------------------------------------------------------------*/
                /* Make sure the player car is always top most:               */
                /*------------------------------------------------------------*/
                _playerCar.pictureBox.BringToFront();
            }
        }

        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Launch a new enemy car:                                            */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private void launchNewEnemyCar(int lane)
        {
            /*----------------------------------------------------------------*/
            /* Declare local variables:                                       */
            /*----------------------------------------------------------------*/
            int car;
            int speedDivisor = 2;

            /*----------------------------------------------------------------*/
            /* Get a random enemy car picture number:                         */
            /*----------------------------------------------------------------*/
            car = random.Next(1, NUM_ENEMY_CARS + 1);
            /*----------------------------------------------------------------*/
            /* Create an enemy car and add it to the list of interference     */
            /* field objects:                                                 */
            /*----------------------------------------------------------------*/
            pictureBox = new PictureBox();
            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();
            _enemyCar = new EnemyCar(pictureBox, ImagePath, GetLaneXCoordinate(lane), -_playerCar.pictureBox.Height, car, lane);

            _interferenceFieldObjects.Add(_enemyCar);

            /*----------------------------------------------------------------*/
            /* Set the enemy car velocity to a random fraction of the road    */
            /* speed:                                                         */
            /*----------------------------------------------------------------*/
            _enemyCar.YVelocity = _startingSpeed / speedDivisor;
        }

        private void launchNewCollectible(int lane)
        {
            PictureBox pictureBox = new PictureBox();
            this.Controls.Add(pictureBox);

            int collectible = random.Next(1, NUM_COLLECTIBLES + 1);
            InterferenceField newCollectible = null;

            switch (collectible)
            {
                case OBJECT_TYPE_COLLECTIBLE_COIN:
                    Coin coin = new Coin(pictureBox, ImagePath, GetLaneXCoordinate(lane), -_playerCar.pictureBox.Height, lane);
                    newCollectible = coin;
                    break;
                case OBJECT_TYPE_COLLECTIBLE_PRESENT:
                    Present present = new Present(pictureBox, ImagePath, GetLaneXCoordinate(lane), -_playerCar.pictureBox.Height, lane);
                    newCollectible = present;
                    break;
            }

            if (newCollectible != null)
            {
                _interferenceFieldObjects.Add(newCollectible);
                newCollectible.YVelocity = _startingSpeed;
            }
        }

        private void hasPlayerCarCollided()
        {
            /*----------------------------------------------------------------*/
            /* Declare local variables:                                       */
            /*----------------------------------------------------------------*/
            float h;                               /* Hypotenuse              */
            int x;
            int y;

            /*----------------------------------------------------------------*/
            /* Iterate through each interference field object in play:        */
            /*----------------------------------------------------------------*/
            foreach (InterferenceField interferenceObject in _interferenceFieldObjects)
            {
                /*------------------------------------------------------------*/
                /* Get the distance between the two objects:                  */
                /*------------------------------------------------------------*/
                x = _playerCar.X - interferenceObject.X;
                y = _playerCar.Y - interferenceObject.Y;
                h = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                /*------------------------------------------------------------*/
                /* Check for a collision if the distance between the two      */
                /* objects is less than the sum of their interference field   */
                /* radii:                                                     */
                /*------------------------------------------------------------*/
                if (h < _playerCar.Height / 2 + interferenceObject.Height / 2 &&
                        _playerCar.lane == interferenceObject.lane)
                {
                    /*--------------------------------------------------------*/
                    /* Oops! Bang! Determine the outcome based on the type of */
                    /* object. Check if a game ending object:                 */
                    /*--------------------------------------------------------*/
                    if (interferenceObject is EnemyCar enemyCar)
                    {
                        GameOver();
                    }
                    /*--------------------------------------------------------*/
                    /* Phew! Must be a collectible:                           */
                    /*--------------------------------------------------------*/
                    // else if (interferenceObject is ICollectible collectible)
                    //{
                    /*----------------------------------------------------*/
                    /* Give the points to the player:                     */
                    /*----------------------------------------------------*/
                    if (interferenceObject is Coin coin)
                    {
                        if (!coin.isCollected) //if not collected yet
                        {
                            coin.Collect();
                            int points = coin.value;
                            _score += points; // Add the points to the score
                            Score.Text = string.Format("Score: {0}", _score); // Update the score display
                        }
                    }
                    /*----------------------------------------------------*/
                    if (interferenceObject is Present present)
                    {
                        if (!present.isCollected) //if not collected yet
                        {
                            present.Collect();
                            int points = present.value;
                            _score += points; // Add the points to the score
                            Score.Text = string.Format("Score: {0}", _score); // Update the score display
                        }
                    }
                }
            }
        }

        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Update the score:                                                  */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private void UpdateScore(int score)
        {
            _score += score; // Update the score //_score = _score + score
            Score.Text = string.Format("Score: {0}", _score); // Update the score display
        }

        public int score
        {
            get { return _score; }
        }

        public int ElapsedSeconds
        {
            get { return elapsedSeconds; }
        }
        //public int ElapsedSeconds => elapsedSeconds; getter


        /* private int GenerateRandom(int lowLimit, int highLimit, int selectedValue)
         {
             while (true)
             {
                 int randomValue = random.Next(lowLimit, highLimit);

                 if (selectedValue == -1)
                 {
                     return randomValue;
                 }
                 else if (selectedValue != randomValue)
                 {
                     return randomValue;
                 }
             }
         }*/
        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Timer tick event callback function:                                */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*----------------------------------------------------------------*/
            /* Move whe road lines down to make it appear that the            */
            /* player car is moving up:                                       */
            /*----------------------------------------------------------------*/
            MoveRoad(_currentSpeed);

            /*----------------------------------------------------------------*/
            /* Iterate through each interference field object in play:        */
            /*----------------------------------------------------------------*/

            foreach (InterferenceField interferenceObject in _interferenceFieldObjects)
            {
                /*------------------------------------------------------------*/
                /* Check if this is an enemy car:                             */
                /*------------------------------------------------------------*/
                if (interferenceObject is EnemyCar enemyCar)
                {
                    /*--------------------------------------------------------*/
                    /* Calculate the enemy car velocity                       */
                    /*--------------------------------------------------------*/
                    enemyCar.UpdatePosition();
                }
                else if (interferenceObject is Coin coin)
                {
                    coin.UpdatePosition();
                }
                else if (interferenceObject is Present present)
                {
                    present.UpdatePosition();
                }
                /*------------------------------------------------------------*/
                /* Check if the middle lane is available on game start:       */
                /* Only allow 2 objects in 2 random lanes                     */
                /*------------------------------------------------------------*/
                if (interferenceObject.Y >= this.Height / 2 && !lane2.started)
                {
                      SetLaneAvailability(2, true);
                      lane2.started = true;
                }
                /*------------------------------------------------------------*/
                /* Check if the object has moved below half the form height   */
                /* in which case the lane can be made available for the next  */
                /* object:                                                    */
                /*------------------------------------------------------------*/
                int height = random.Next(1, 4);
                int factor = 1;
                if(height == 3)
                {
                    factor = 2;
                }
                if (interferenceObject.Y >= factor * this.Height / height && !interferenceObject.clear)
                {
                    SetLaneAvailability(interferenceObject.lane, true);
                    interferenceObject.clear = true;
                    if (numBlockers > 0)
                    {
                        numBlockers--;
                    }
                }
                /*------------------------------------------------------------*/
                /* Check if the object has moved below the bottom of the form */
                /* window and needs to be disposed of:                        */
                /*------------------------------------------------------------*/
                if (interferenceObject.Y >= this.Height)
                {
                    /*--------------------------------------------------------*/
                    /* Dispose of the object according to object type:        */
                    /*--------------------------------------------------------*/
                    if (interferenceObject is EnemyCar EnemyCar)
                    {
                        this.Controls.Remove(EnemyCar.pictureBox);
                        EnemyCar.pictureBox.Dispose();
                    }
                    if (interferenceObject is Coin Coin)
                    {
                        this.Controls.Remove(Coin.pictureBox);
                        Coin.pictureBox.Dispose();
                    }
                    if (interferenceObject is Present present)
                    {
                        this.Controls.Remove(present.pictureBox);
                        present.pictureBox.Dispose();
                    }
                    /*--------------------------------------------------------*/
                    /* Remove the interference field object from the list:    */
                    /*--------------------------------------------------------*/
                    _interferenceFieldObjects.Remove(interferenceObject);
                    break;
                }
            }
            /*----------------------------------------------------------------*/
            /* Launch any new objects if any lanes are available:             */
            /*----------------------------------------------------------------*/
            launchObject();

            /*----------------------------------------------------------------*/
            /* Check for a collision between the player car and any other     */
            /* object:                                                        */
            /*----------------------------------------------------------------*/
             hasPlayerCarCollided();
        }

        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Check for a collision between the player car and any other         */
        /* interference field object:                                         */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        
        private void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            elapsedSeconds++;
            Vehicle vehicle;

            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60; // giving the remainder of seconds

            Timer.Text = $"Timer: {minutes:00}:{seconds:00}";
            if (minutes == 1 && seconds >= 30 && seconds < 60)
            {
                vehicle = _enemyCar;
                vehicle.ActivatePowerUp();
            }
           if (minutes == 2 && seconds >= 30 && seconds <= 40) // Check if 2.5 minutes to 2.666 minutes have elapsed
            {
                vehicle = _playerCar;
                vehicle.ActivatePowerUp();
                //UpdateScore(_playerCar.GetScore());
            }
            if (minutes >= 3)
            {
                timer2.Stop();
                timer1.Stop();
            }
        }
        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Get the x coordinate for the given lane:                           */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private int GetLaneXCoordinate(int lane)
        {
            int x;
            switch (lane)
            {
                case 1:
                    x = lane1.x;
                    break;
                case 2:
                    x = lane2.x;
                    break;
                case 3:
                    x = lane3.x;
                    break;
                default:
                    x = 0;
                    Debug.WriteLine("GetLaneXCoordinate out of range!");
                    break;
            }
            return x;
        }
        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Check if the given lane is available:                              */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
         private bool IsLaneAvailable(int lane)
         {
             bool available;
             switch (lane)
             {
                 case 1:
                     available = lane1.available;
                     break;
                 case 2:
                     available = lane2.available;
                     break;
                 case 3:
                     available = lane3.available;
                     break;
                 default:
                     available = false;
                     Debug.WriteLine("IsLaneAvailable out of range!");
                     break;
             }
             return available;
         }

        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Set the given lane available or unavailable:                       */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private void SetLaneAvailability(int lane, bool available)
        {
            switch (lane)
            {
                case 1:
                    lane1.available = available;
                    break;
                case 2:
                    lane2.available = available;
                    break;
                case 3:
                    lane3.available = available;
                    break;
                default:
                    Debug.WriteLine("SetLaneAvailability out of range!");
                    break;
            }
        }

        private void AddRoadLine()
        {
            for (int i = 1; i <= 8; i++)
            {
                PictureBox roadLine = Controls.Find("roadLine" + i, true).FirstOrDefault() as PictureBox; //search for the Controls property with the type PictureBox
                if (roadLine != null)
                {
                    _roadLines.Add(roadLine);
                }
            }
        }

        public void Form2_KeyDown(object sender, KeyEventArgs e)
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

        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Move the player car one lane to the left if not fully left:        */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        public void GoLeft()
        {
            if (_playerCar.lane > 1)
            {
                _playerCar.lane--;
                _playerCar.X = GetLaneXCoordinate(_playerCar.lane);
                _playerCar.UpdatePosition();
            }
        }

        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* Move the player car one lane to the right if not fully right:      */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        public void GoRight()
        {
            if (_playerCar.lane < NUM_LANES)
            {
                _playerCar.lane++;
                _playerCar.X = GetLaneXCoordinate(_playerCar.lane);
                _playerCar.UpdatePosition();
            }
        }
        /*--------------------------------------------------------------------*/
        /*                                                                    */
        /* GameOver!!!                                                        */
        /*                                                                    */
        /*--------------------------------------------------------------------*/
        private void GameOver()
        {

            timer1.Stop(); // stop the timer
            timer2.Stop(); //stop the elapsed time
            Form4 f4 = new Form4(_score, elapsedSeconds);
            f4.Show();
            this.Hide();
            /*if (_score >= 30)
            {
                MessageBox.Show("You win");
            }
            else
                MessageBox.Show("You lose");*/
        }
    }
}
