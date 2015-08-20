using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;


namespace Agar
{
    public partial class Agar : Form
    {
        private List<Keys> pressedKeys = new List<Keys>();
        private Random rnd = new Random();
        private Matrix matrix1 = new Matrix();
        private Image<Bgr, Byte> img = new Image<Bgr, Byte>(800, 600, new Bgr(255, 255, 255));          
        private int i, f;
        private int oldX, oldY;

        public Agar()
        {
            InitializeComponent();
            Kep.Image = img;
            oldX = matrix1.GombList.ElementAt(0).getX();
            oldY = matrix1.GombList.ElementAt(0).getY();
            i = 0;
            f = 0;
            Image_move();
            Kep.Image = img;

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
        
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (pressedKeys.Count == 0) pressedKeys.Add(e.KeyCode);
            if (e.KeyCode != pressedKeys.ElementAt(pressedKeys.Count - 1)) pressedKeys.Add(e.KeyCode);
            //  if (pressedKeys.Count > 1 ) MessageBox.Show("Menne de nem megy");
           // matrix1.GombList.ElementAt(0).speed = matrix1.GombList.ElementAt(0).getSize() / 2 + 2 - (matrix1.GombList.ElementAt(0).getSize() / 4);
            movePressedKeys();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
            //printPressedKeys();

        }

        private void setImage()
        {
            if (matrix1.GombList.Count < 5)
            {
                f = 0;
                while (matrix1.GombList.Count < 10)
                {
                    f++;
                    matrix1.Add(matrix1.GombList.Count + 1);
                    if (f > 10) break;
                }
            }


            foreach (var gomb in matrix1.GombList)
            {
                for (int a = gomb.getY(); a < gomb.getY() + gomb.getSize(); a++)
                {
                    for (int b = gomb.getX(); b < gomb.getX() + gomb.getSize(); b++)
                    {
                        if (gomb == matrix1.GombList.ElementAt(0))
                        {
                            if (a <= gomb.yMax - 1 && b <= gomb.xMax - 1)
                            {

                                img[a, b] = new Bgr(0, 0, 155);

                            }
                            else
                            {
                                if (a > gomb.yMax)
                                {

                                    img[a - gomb.yMax, b] = new Bgr(0, 0, 155);

                                }

                                if (b > gomb.xMax)
                                {

                                    img[a, b - gomb.xMax] = new Bgr(0, 0, 155);

                                }
                            }
                        }
                        else
                        {
                            img[a, b] = new Bgr(0, 0, 0);
                        }
                    }
                }
            }


             Kep.Image = img;
        }

        private void Image_move()
        {

            // Eltunteti az elmozdult kocka maradvanyait 
            if (oldX != matrix1.GombList.ElementAt(0).getX() || oldY != matrix1.GombList.ElementAt(0).getY())
            {
                for (int i = oldY; i < oldY + matrix1.GombList.ElementAt(0).getSize(); i++)
                {
                    for (int j = oldX; j < oldX + matrix1.GombList.ElementAt(0).getSize(); j++)
                    {
                        if (i >= matrix1.GombList.ElementAt(0).yMax  || j >= matrix1.GombList.ElementAt(0).xMax)
                        {
                            if (i >= matrix1.GombList.ElementAt(0).yMax - 1)
                            {

                                img[i - matrix1.GombList.ElementAt(0).yMax + 1, j] = new Bgr(255, 255, 255);

                            }

                            if (j >= matrix1.GombList.ElementAt(0).xMax)
                            {

                                img[i, j - matrix1.GombList.ElementAt(0).xMax + 1] = new Bgr(255, 255, 255);

                            }

                        }
                        else
                        {

                            img[i, j] = new Bgr(255, 255, 255);

                        }
                    }
                }

            }
            oldX = matrix1.GombList.ElementAt(0).getX();
            oldY = matrix1.GombList.ElementAt(0).getY();

            //Megeszi a kockat
            if (matrix1.eat())
            {
                for (int a = matrix1.collgomb.getY(); a < matrix1.collgomb.getY() + matrix1.collgomb.getSize(); a++)
                {
                    for (int b = matrix1.collgomb.getX(); b < matrix1.collgomb.getX() + matrix1.collgomb.getSize(); b++)
                    {

                        img[a, b] = new Bgr(255, 255, 255);

                    }
                }
                matrix1.GombList.ElementAt(0).setSize(matrix1.GombList.ElementAt(0).getSize() + matrix1.collgomb.getSize() / 4);
                matrix1.GombList.Remove(matrix1.GombList.ElementAt(matrix1.pozicio));
            }
            setImage();
        }
        
        private void movePressedKeys()
        {
            foreach (var key in pressedKeys)
            {
                if (key == Keys.W)
                {
                    for (int h = 0; h < matrix1.GombList.ElementAt(0).speed; h++) 
                    {

                        matrix1.moveDIR(matrix1.GombList.ElementAt(0), 0);

                    } 
                    //textBox3.Text = matrix1.GombList.ElementAt(0).getY().ToString();
                }
                if (key == Keys.A)
                {
                    for (int h = 0; h < matrix1.GombList.ElementAt(0).speed; h++)
                    {
                        matrix1.moveDIR(matrix1.GombList.ElementAt(0), 6);
                    }
                    //textBox2.Text = matrix1.GombList.ElementAt(0).getX().ToString();
                }
                if (key == Keys.S)
                {
                    for (int h = 0; h < matrix1.GombList.ElementAt(0).speed; h++)
                    {
                        matrix1.moveDIR(matrix1.GombList.ElementAt(0), 4);
                    }
                    
                    //textBox3.Text = matrix1.GombList.ElementAt(0).getY().ToString();
                }
                if (key == Keys.D)
                {
                    for (int h = 0; h < matrix1.GombList.ElementAt(0).speed; h++)
                    {
                        matrix1.moveDIR(matrix1.GombList.ElementAt(0), 2);
                    }
                    
                    // textBox2.Text = matrix1.GombList.ElementAt(0).getX().ToString();
                }
                Image_move();
            }
        }

        private void Kep_Click(object sender, EventArgs e)
        {

        }
    }
}
