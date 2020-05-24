using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Don_t
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rd = new Random();

        int X = 0;      int Y = 0;      int color = 0; 
        int score;      int dx;     int dy;     int t = 0;

        public int[,] table = new int[5, 13];
        bullet bb = new bullet();


        int highscore = 0;


        class bullet
        {
            public int bullet_x = 388; 
            public int bullet_y = 593;
            public int vx = 50;
            public int bullets = 2;
            
        }
        public void delete()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 11; j > 0; j--)
                {
                    if (table[i, j] == 6)
                    {
                        
                        for (int k = j; k > 0; k--)
                        {
                            
                            table[i, k] = table[i, k - 1];
                        }
                    }
                }
            
        }
        int checkk = 0;
        public void mark(int a, int b)
        {
            
            table[a, b] = 6;
            score += 10;
            
        }
        public void check2(int a, int b)
        {
            if (table[a, b] == color  )
            {
                check(a, b);
            }
            else
            {
  
                return;

            }


        }
        
        public void check(int a, int b)
        {

            mark(a, b);
            
            if (a == 0)
            {
                if (b == 0)
                {
                    check2(0, 1);
                    check2(1, 0);
                }

                else if (b == 11)
                {
                    check2(0, 10);
                    check2(1, 11);
                }
                else
                {
                    check2(1, b);
                    check2(0, b - 1);
                    check2(0, b + 1);
                }

            }
            
            else if (a == 1 || a == 2 || a == 3)
            {
                if (b == 0)
                {
                    check2(a, b + 1);
                    check2(a - 1, b);
                    check2(a + 1, b);
                }
                else if (b == 11)
                {
                    check2(a, b - 1);
                    check2(a + 1, b);
                    check2(a - 1, b);
                }
                else
                {
                    check2(a + 1, b);
                    check2(a - 1, b);
                    check2(a, b + 1);
                    check2(a, b - 1);
                }


            }
            
            else if (a == 4)
            {
                if (b == 0)
                {
                    check2(4, 1);

                    check2(3, 0);
                }

                else if (b == 11)
                {
                    check2(4, 10);

                    check2(3, 11);
                }
                else
                {
                    check2(3, b);
                    check2(4, b - 1);
                    check2(4, b + 1);
                }


            }


        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
        }
        
       
        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
           
            
            
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.Black, 410, 568, 35, 50);
            g.FillRectangle(Brushes.Black, 405, 583, 10, 20);
            
            g.FillEllipse(Brushes.Black, bb.bullet_x - 5, bb.bullet_y - 5, 10, 10);
            
            
        }
        

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Text = e.X.ToString();
            label7.Text = e.Y.ToString();

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            bb.bullet_x -= bb.vx;
            
            if(bb.bullet_x < 10)
            {
                for(int i = 0; i < 5; i ++)
                {
                   
                    table[i, 9] = 0;
                    for(int j = 9; j >0; j --)
                    {
                        table[i, j] = table[i, j - 1];
                    }
                    table[i, 10] = 0;
                    for (int j = 10; j > 0; j--)
                    {
                        table[i, j] = table[i, j - 1];
                    }
                }
                bb.bullets -= 1;
                timer1.Stop();
                label3.Text = (bb.bullets).ToString();
            }
            Refresh();
        }
        

       
        private void button3_Click(object sender, EventArgs e)
        {
            if (kk == 1)
            {
                bb.bullet_x = 388;
                if (bb.bullets > 0)
                {

                    bb.vx = 50;
                }
                if (bb.bullets == 0)
                {
                    bb.vx = 0;

                }
                timer1.Start();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label3.Text = (bb.bullets).ToString();
            
           
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }
   
        
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < 5; i++)

            {

                if (table[i, 11] == 1)
                {

                    e.Graphics.FillRectangle(Brushes.Red, i * 50, 0, 50, 50);
                }

                if (table[i, 11] == 2)
                {
                    e.Graphics.FillRectangle(Brushes.Green, i * 50, 0, 50, 50);
                }

                if (table[i, 11] == 3)
                {
                    e.Graphics.FillRectangle(Brushes.Yellow, i * 50, 0, 50, 50);
                }

                if (table[i, 11] == 4)
                {
                    e.Graphics.FillRectangle(Brushes.Wheat, i * 50, 0, 50, 50);
                }
                if (table[i, 11] == 5)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, i * 50, 0, 50, 50);
                }
                
            }
            

            


        }
        int m = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            t++;
            if (t == 2 )
            {


                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (table[i, j] == 0)
                        {
                            table[i, j] = table[i, j + 1];
                            table[i, j + 1] = 0;
                        }

                    }
                    table[i, 11] = rd.Next(1, 6);
                }

                timer2.Stop();
                t = 0;
                if (table[0, 0] != 0 || table[1, 0] != 0 || table[2, 0] != 0 || table[3, 0] != 0 || table[4, 0] != 0)
                {
                    bb.bullets = 0;
                    label4.Text = "Latest Score : " + score.ToString(); label3.Text = (bb.bullets).ToString();
                    m = 1; w = 0;
                    textBox1.Text = "GAME OVER\r\n";
                    
                    textBox1.Text += score.ToString();
                    button2.Visible = false;
                    

                    if (score > highscore)
                    {
                        highscore = score;
                        label9.Text = "Highest Score : " + highscore.ToString();

                    }
                }

            }

            pictureBox1.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap bt = new Bitmap("ddd.jpg");
            g.DrawImage(bt, 0, 0, pictureBox1.Width, pictureBox1.Height);
            e.Graphics.DrawLine(Pens.Black, 0, 20, 250, 20);
            e.Graphics.DrawLine(Pens.Black, 0, 21, 250, 21);
            
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 12; j++)
                {
                   

                    if (table[i, j] == 1)
                    {

                        e.Graphics.FillRectangle(Brushes.Red, i * 50, 40 * j, 50, 40);
                    }

                    if (table[i, j] == 2)
                    {
                        e.Graphics.FillRectangle(Brushes.Green, i * 50, 40 * j, 50, 40);
                    }

                    if (table[i, j] == 3)
                    {
                        e.Graphics.FillRectangle(Brushes.Yellow, i * 50, 40 * j, 50, 40);
                    }

                    if (table[i, j] == 4)
                    {
                        e.Graphics.FillRectangle(Brushes.Wheat, i * 50, 40 * j, 50, 40);
                    }
                    if (table[i, j] == 5)
                    {
                        e.Graphics.FillRectangle(Brushes.Blue, i * 50, 40 * j, 50, 40);
                    }

                }
            if (m == 1)
            {
                e.Graphics.DrawLine(Pens.Red, 0, 20, 250, 20);
                e.Graphics.DrawLine(Pens.Red, 0, 21, 250, 21);
            }



        }

        int kk = 0;
        private void Button1_Click(object sender, EventArgs e)
        {
            //timer2.Start();
            color = 0;
            w = 1; kk = 1;
            m = 0; p = 0;
            textBox1.Text = "".ToString();
            
            bb.bullets = 2;
            label3.Text = (bb.bullets).ToString();
            score = 0;
            timer3.Start();
            for(int i = 0; i < 5; i ++)
            {
                table[i, 11] = rd.Next(1, 6);
                for(int j = 0; j < 11; j ++)
                {
                    table[i, j] = 0;
                }
            }
            button2.Visible = true;

            
            timer2.Stop();
            pictureBox1.Refresh();
            
        }
        int p = 0; int w = 0; 
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (w == 1)
            {
                if (table[0, 0] == 0 && table[1, 0] == 0 && table[2, 0] == 0 && table[3, 0] == 0 && table[4, 0] == 0)
                {
                    timer2.Start();
                    X = e.X;
                    Y = e.Y;

                    for (int i = 0; i < 5; i++)
                    {
                        if (X > i * 50 && X < i * 50 + 49)
                        {
                            dx = i;
                        }
                    }
                    for (int j = 0; j < 12; j++)
                    {
                        if (Y > j * 40 && Y < j * 40 + 39)
                        {
                            dy = j;
                        }
                    }
                    color = table[dx, dy];

                    if (table[dx, dy] != 0)

                    {
                        //timer2.Start();
                        check(dx, dy);
                        delete();
                        delete();
                        delete();
                        delete();
                        delete();
                        delete();
                        delete();
                        delete();
                        delete();
                        delete();
                        delete();

                        textBox1.Text = score.ToString();

                        if (score >= 1000 && p == 0)

                        {
                            p = 1;
                            if (p == 1)
                            {
                                bb.bullets += 2;
                                label3.Text = (bb.bullets).ToString();
                            }

                        }
                        if (score >= 2000 && p == 1)

                        {
                            p = 2;
                            if (p == 2)
                            {
                                bb.bullets += 3;
                                label3.Text = (bb.bullets).ToString();


                            }
                            

                        }
                        if (score >= 3000 && p == 2)

                        {
                            p = 3;
                            if (p == 3)
                            {
                                bb.bullets += 5;
                                label3.Text = (bb.bullets).ToString();


                            }

                        }




                    }



                }
            }

            pictureBox1.Refresh();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
       
        
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            
            for(int i = 0; i<11;i++)
            {
                table[1, i] = 0;
                table[0, i] = 0;
                table[4, i] = 0;
                table[2, i] = 0;
                table[3, i] = 0;
            }
         
            
        }
        
        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            
            if (color == 1)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.Red, 0, 0, 250, 40);
            }
            if (color == 2)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.Green, 0, 0, 250, 40);
            }
            if (color == 3)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.Yellow, 0, 0, 250, 40);
            }
            if (color == 4)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.Wheat, 0, 0, 250, 40);
                
            }
            if (color == 5)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.Blue, 0, 0, 250, 40);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
