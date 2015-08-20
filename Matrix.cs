using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agar
{
    class Matrix
    {
        private int i;          // Ha az i csak a nevnek kell akkor szedd ki !!!
        private Random rnd = new Random();
        
        
        public Gombok collgomb;
        public int pozicio;
        public List<Gombok> GombList = new List<Gombok>();


        public Matrix()
        {
            i = 0;
            collgomb = new Gombok();
            Gombok gomb = new Gombok();
            GombList.Add(gomb);
            GombList.ElementAt(0).setSize(20);
            GombList.ElementAt(0).setX(400);
            GombList.ElementAt(0).setY(300);
            i++;
        }

        public void Add(int i)
        {

            Gombok gomb = new Gombok();
            gomb.setSize(rnd.Next(4, GombList.ElementAt(0).getSize() + GombList.ElementAt(0).getSize() / 3));
            gomb.setX(rnd.Next(1, gomb.xMax - gomb.getSize() + 1));
            gomb.setY(rnd.Next(1, gomb.yMax - gomb.getSize() + 1));
            this.i++;
            GombList.Add(gomb);

        }

        public void Remove(int gomb)
        {
            GombList.RemoveAt(gomb);
        }

        public void moveDIR(Gombok gombA, int dir)
        {
            switch (dir)
            {
                case 0:
                    gombA.moveUP();
                    break;
                case 1:
                    gombA.moveUP();
                    gombA.moveRIGHT();
                    break;
                case 2:
                    gombA.moveRIGHT();
                    break;
                case 3:
                    gombA.moveRIGHT();
                    gombA.moveDOWN();
                    break;
                case 4:
                    gombA.moveDOWN();
                    break;
                case 5:
                    gombA.moveDOWN();
                    gombA.moveLEFT();
                    break;
                case 6:
                    gombA.moveLEFT();
                    break;
                case 7:
                    gombA.moveLEFT();
                    gombA.moveUP();
                    break;
            }

        }

        public bool eat()
        {

            Gombok gombi = new Gombok();
            gombi = GombList.ElementAt(0);
            foreach (var gombj in GombList)
            {
                if (gombj != gombi)
                {
                    Gombok gomby = new Gombok();
                    gomby = gombj;
                    collgomb = gomby;
                    pozicio = GombList.IndexOf(gomby);
                    if (gomby.getX() >= gombi.getX() && gomby.getX() + gomby.getSize() <= gombi.getX() + gombi.getSize())
                    {

                        if (gomby.getY() >= gombi.getY() && gomby.getY() + gomby.getSize() <= gombi.getY() + gombi.getSize())
                        {
                            if (gombi.getSize() < gomby.getSize())
                            {
                                return false;
                            }
                            return true;
                        }

                    }

                }
            }
            return false;
        }



    }
}
