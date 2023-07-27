using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace VelocityDrift
{
    public class Present : VelocityDrift.InterferenceField, ICollectible
    {
        private bool _isCollected;
        private int _value;
        private string _audioPath;

        public Present(PictureBox pictureBox, string ImagePath, int x, int y, int lane) 
        {
            _audioPath = ImagePath;
            _value = 5;
            string coinImageName = "present";
            LoadImage(coinImageName, ImagePath, pictureBox, x, y, lane);

            LifeTime();
        }
        public bool isCollected
        {
            get { return _isCollected; }
            set { _isCollected = value; }
        }
        public int value
        {
            get { return _value; }
        }
        public void Collect()
        {
            _isCollected = true;
            pictureBox.Visible = false;
            playSound(_audioPath);

        }
        private void playSound(string audioPath)
        {
            string soundFilePath = Path.Combine(audioPath, "PresentSound.wav");
            SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
            soundPlayer.Play(); 
        }
        //To summarize, the LifeTime method introduces a delay of 3
        //seconds using the Task.Delay method and then hides a
        //pictureBox control by setting its Visible property to false.
        //This can be useful in scenarios where you want to show an
        //element for a specific duration and then automatically hide it.
        private async void LifeTime()
        {
            await Task.Delay(3000); //within 3 seconds
            pictureBox.Visible = false; // Hide the PictureBox
        }
    }
}
