using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4096
{
    public partial class GamePanelTetris : UserControl
    {
        public GamePanelTetris()
        {
            InitializeComponent();
        }

        public class SHAPES
        {
            public class Block:Panel
            {

            }
            public class Line : Shape
            {
                public Line()
                {
                    this.ShapeID = 0;
                }
            }
            public class Square : Shape
            {
                public Square()
                {
                    this.ShapeID = 0;
                }
            }
            public class L : Shape
            {
                public L()
                {
                    this.ShapeID = 0;
                }
            }
            public class BackwardsL : Shape
            {
                public BackwardsL()
                {
                    this.ShapeID = 0;
                }
            }
            public class T : Shape
            {
                public T()
                {
                    this.ShapeID = 0;
                }
            }






            public class Shape
            {
                public static int Bottom;
                public int ShapeID;
                public Point Location;
                public List<Panel> ShapeItems;
                public Shape()
                {
                    ShapeItems = new List<Panel>();
                    Bottom = 550;
                }
                public void MoveDown()
                {

                }
                public void MoveRight()
                {
                    bool Move = true;
                    foreach (var item in ShapeItems)
                    {
                        if (item.Location.X == 550)
                        {
                            Move = false;
                        }
                    }
                    if (Move)
                    {
                        foreach (var item in ShapeItems)
                        {
                            item.Bounds = new Rectangle(item.Location.X + 50, item.Location.Y, 50, 50);
                        }
                    }
                }
                public void MoveLeft()
                {
                    bool Move = true;
                    foreach (var item in ShapeItems)
                    {
                        if(item.Location.X==0)
                        {
                            Move = false;
                        }
                    }
                    if (Move)
                    {
                        foreach (var item in ShapeItems)
                        {
                            item.Bounds = new Rectangle(item.Location.X - 50, item.Location.Y, 50, 50);
                        }
                    }
                }
                private Panel Item()
                {
                    Panel I = new Panel();
                    I.Width = 50;
                    I.Height = 50;
                    return I;
                }
                private void colorItems(Color ItemColor)
                {
                    foreach (Panel item in ShapeItems)
                    {
                        item.BackColor = ItemColor;
                    }
                }
            }
        }
    }
}
