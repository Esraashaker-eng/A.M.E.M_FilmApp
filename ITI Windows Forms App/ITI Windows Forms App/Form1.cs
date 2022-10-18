using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI_Windows_Forms_App
{
    public partial class Form1 : Form
    {
        bool blue = false;
        bool green = false;

        int flag = 0; // using this flag to switch between the 2 players, when 0 means the blue player turn;

        int BlueX = 37; 
        int BlueY = 518;
        int BluePosition = 0;

        int GreenX = 37;
        int GreenY = 518;
        int GreenPosition = 0;

        int diceValue; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LabelsHide();

            if (flag == 0)
            {
                button2.Enabled = false;
            }

            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox3.Image = Image.FromFile(@"E:\Projects\My\ITI Windows Forms App\ITI Windows Forms App\Resources\roll-the-dice-top-image.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            diceValue = Logics.RollDice(pictureBox3);
            label2.Text = diceValue.ToString();

            // should get in this con to start playing;
            if (label2.Text == "6" && blue == false)
            {
                pictureBox4.Visible = true;
                pictureBox1.Visible = false;

                //set the flag to start play;
                blue = true;

                //move the peace in the box num 1 on the board;
                pictureBox4.Location = new Point(BlueX, BlueY);

                label4.Text = BlueX.ToString();
                label6.Text = BlueY.ToString();
                label8.Text = BluePosition.ToString();

                BluePosition++;
            }

            // if he start play so the next step is to roll again and move on the board;
            if (blue == true)
            {
                //the move func takes the exists x, y, position and the dice value and get new movement to the player peace;
                BluePosition = Logics.Move(ref BlueX, ref BlueY, BluePosition, diceValue, pictureBox4, label9);

                label4.Text = BlueX.ToString();
                label6.Text = BlueY.ToString();
                label8.Text = BluePosition.ToString();
            }

            
            // check if the position reached the last box on the board to say that the player has won;
            if (BluePosition == 100)
            {
                MessageBox.Show("Win");
                button1.Enabled = false;
            }

            // snake func checks the snake bites on the board and re-move the player to the right place if his piece stands on it;
            BluePosition = Logics.Snake(ref BlueX, ref BlueY, BluePosition, pictureBox4);

            // ladder func checks the ladders on the board and give moves to the player whose piece stands on ladder;
            BluePosition = Logics.Ladder(ref BlueX, ref BlueY, BluePosition, pictureBox4);
            label8.Text = BluePosition.ToString();

            // this is one of the game rules .. that any player get 6 on rolling dice must play once more;
            //and this con is to stop the other (green) player from playing until the blue player play again;
            if (diceValue == 6)
            {
                flag = 0;
            }
            else
            {
                flag = 1;
                button1.Enabled = false;
                button2.Enabled = true;
            }

        }




        // all what i've said in the btn1 repeated here with some changes in the conditions of switching players; 
        private void button2_Click(object sender, EventArgs e)
        {
            diceValue = Logics.RollDice(pictureBox3);
            label2.Text = diceValue.ToString();

            if (green == true)
            {
                GreenPosition = Logics.Move(ref GreenX, ref GreenY, GreenPosition, diceValue, pictureBox5, label9);

                label4.Text = GreenX.ToString();
                label6.Text = GreenY.ToString();
                label10.Text = GreenPosition.ToString();
            }

            if (label2.Text == "6" && green == false)
            {
                pictureBox5.Visible = true;
                pictureBox2.Visible = false;

                green = true;

                pictureBox5.Location = new Point(GreenX, GreenY);

                label4.Text = GreenX.ToString();
                label6.Text = GreenY.ToString();
                label10.Text = GreenPosition.ToString();

                GreenPosition++;
            }

            if (GreenPosition == 100)
            {
                MessageBox.Show("Win");
                button2.Enabled = false;
            }

            GreenPosition = Logics.Snake(ref GreenX, ref GreenY, GreenPosition, pictureBox5);
            GreenPosition = Logics.Ladder(ref GreenX, ref GreenY, GreenPosition, pictureBox5);
            label10.Text = GreenPosition.ToString();


            if (diceValue == 6)
            {
                flag = 1;
            }
            else
            {
                flag = 0;
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }


        // hiding the labels which used in debuging;  
        public void LabelsHide()
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

    }
}
