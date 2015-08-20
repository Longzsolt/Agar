using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agar
{
    class Gombok
    {
        private int x;
        private int y;
        private int size;
        public int xMax;
        public int yMax;
        public int speed;
        private Random rnd = new Random();



        public Gombok()
        {
            x = 1;
            y = 1;
            size = 2;
            speed = 2;
            xMax = 600;
            yMax = 600;
        }
        public void setX(int x)
        {
            this.x = x;
        }

        public int getX()
        {
            return x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int getY()
        {
            return y;
        }

        public void setSize(int size)
        {

            this.size = size;

        }

        public int getSize()
        {

            return size;

        }

        public void moveUP()
        {
            if (this.y <= 0) setY(yMax);
                y--;
        }

        public void moveDOWN()
        {

            if (this.y > this.yMax) setY(0);
                y++; 
        }

        public void moveLEFT()
        {
            if (this.x <= 0) setX(xMax);
                x--;
        }

        public void moveRIGHT()
        {

            if (this.x > this.xMax) setX(0);
                x++;
        }

    }
}
