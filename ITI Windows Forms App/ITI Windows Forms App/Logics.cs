using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI_Windows_Forms_App
{
    internal class Logics
    {
        public static int RollDice(PictureBox pictureBox)
        {
            int dice;
            Random random = new Random();
            dice = random.Next(1, 7);
            pictureBox.Image = Image.FromFile(@"E:\Projects\My\ITI Windows Forms App\ITI Windows Forms App\Resources\" + dice + ".png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            return dice;
        }

        public static int Move(ref int x, ref int y, int p, int dice, PictureBox px, Label label)
        {

            if ((dice + p) > 100)
            {
                label.Text = "cannot move";
                label.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                for (int i = 0; i < dice; i++)
                {

                    if (p == 10)
                    {
                        x = 37;
                        y = 480;
                    }
                    else if (p == 20)
                    {
                        x = 37;
                        y = 413;
                    }
                    else if (p == 30)
                    {
                        x = 37;
                        y = 360;
                    }
                    else if (p == 40)
                    {
                        x = 37;
                        y = 300;
                    }
                    else if (p == 50)
                    {
                        x = 37;
                        y = 235;
                    }
                    else if (p == 60)
                    {
                        x = 37;
                        y = 185;
                    }
                    else if (p == 70)
                    {
                        x = 37;
                        y = 120;
                    }
                    else if (p == 80)
                    {
                        x = 37;
                        y = 75;
                    }
                    else if (p == 90)
                    {
                        x = 37;
                        y = 15;
                    }
                    else
                    {
                        x += 70;
                    }

                    //label.Text = p.ToString();
                    px.Location = new Point(x, y);
                    p++;
                    //position[p] = 1;

                }


            }

            return p;
        }


        public static int Snake(ref int x, ref int y, int p, PictureBox pictureBox)
        {
            if (p == 25)
            {
                x = 317;
                y = 518;
                p = 5;

            }
            else if (p == 34)
            {
                x = 37;
                y = 518;
                p = 1;
            }
            else if (p == 47)
            {
                x = 597;
                y = 480;
                p = 19;
            }
            else if (p == 65)
            {
                x = 107;
                y = 235;
                p = 52;
            }
            else if (p == 87)
            {
                x = 457;
                y = 235;
                p = 57;
            }
            else if (p == 91)
            {
                x = 37;
                y = 185;
                p = 61;
            }
            else if (p == 99)
            {
                x = 597;
                y = 185;
                p = 69;
            }
            
            
            pictureBox.Location = new Point(x, y);

            return p;
        }

        public static int Ladder(ref int x, ref int y, int p, PictureBox pictureBox)
        {
            if (p == 3)
            {
                x = 37;
                y = 235;
                p = 51;
            }
            else if (p == 6)
            {
                x = 457;
                y = 413;
                p = 27;
            }
            else if (p == 20)
            {
                x = 667;
                y = 185;
                p = 70;
            }
            else if (p == 36)
            {
                x = 317;
                y = 235;
                p = 55;
            }
            else if (p == 63)
            {
                x = 317;
                y = 15;
                p = 95;
            }
            else if (p == 68)
            {
                x = 527;
                y = 15;
                p = 98;
            }

            pictureBox.Location = new Point(x, y);

            return p;
        }
    }
}
