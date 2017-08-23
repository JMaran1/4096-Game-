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
    public partial class GamePanel : UserControl
    {
        private int _Score;
        public int GetScore { get { return _Score; } }
        public GamePanel()
        {
            InitializeComponent();
            AddNew();
            Color();
            _Score = 0;
            WhichWay = new NextMove(this.Controls);
            timer1.Enabled = true;
        }
        NextMove WhichWay;
        public bool Combine(char Direction, out int Score,out bool Lose, out bool WIN)
        {
            int S = 0;
            bool R = WhichWay.Move(Direction,out S,out WIN);
            _Score += S;
            Score = _Score;
            if (R)
            {
                AddNew();
                Color();
                WhichWay = new NextMove(this.Controls);
                Lose = WhichWay.LOSE;
                return R;
            }
            Lose = WhichWay.LOSE;
            return R;
        }
        private void Color()
        {
            foreach (Label item in this.Controls)
            {
                if (item.Text == "2")
                {
                    item.BackColor = System.Drawing.Color.Yellow;
                }
                if (item.Text == "4")
                {
                    item.BackColor = System.Drawing.Color.LightSteelBlue;
                }
                if (item.Text == "8")
                {
                    item.BackColor = System.Drawing.Color.MediumAquamarine;
                }
                if (item.Text == "16")
                {
                    item.BackColor = System.Drawing.Color.IndianRed;
                }
                if (item.Text == "32")
                {
                    item.BackColor = System.Drawing.Color.HotPink;
                }
                if (item.Text == "64")
                {
                    item.BackColor = System.Drawing.Color.Orange;
                }
                if (item.Text == "128")
                {
                    item.BackColor = System.Drawing.Color.Orchid;
                }
                if (item.Text == "256")
                {
                    item.BackColor = System.Drawing.Color.Fuchsia;
                }
                if (item.Text == "512")
                {
                    item.BackColor = System.Drawing.Color.Fuchsia;
                }
                if (item.Text == "1024")
                {
                    item.BackColor = System.Drawing.Color.Fuchsia;
                }
                if (item.Text == "2048")
                {
                    item.BackColor = System.Drawing.Color.LightBlue;
                }
                if (item.Text == "4096")
                {
                    item.BackColor = System.Drawing.Color.LightCoral;
                }
                if (item.Text == "8192")
                {
                    item.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                }
                if (item.Text == "16384")
                {
                    item.BackColor = System.Drawing.Color.MediumBlue;
                }
                if (item.Text == "32768")
                {
                    item.BackColor = System.Drawing.Color.LightSalmon;
                }
                if (item.Text == "65536")
                {
                    item.BackColor = System.Drawing.Color.LightSeaGreen;
                }
            }
        }
        private void AddNew()
        {
            List<Label> Items = new List<Label>();
            foreach (Label item in this.Controls)
            {
                if(item.Text=="0")
                {
                    Items.Add(item);
                }
            }
            Random R = new Random();
            int A = R.Next(5);
            if(A<4)
            {
                A = 2;
            }
            else
            {
                A = 4;
            }
            if (Items.Count != 0)
            {
                Items[R.Next(Items.Count-1)].Text = A.ToString();
            }
        }
        private static bool ComboTiles(List<Label> Tiles,out int ReturnScore)
        {
            bool Moved = false;
            int AddScore = 0;
            List<int> Items = new List<int>();
            for (int i = 0; i < Tiles.Count;i++)
            {
                int A = int.Parse(Tiles[i].Text);
                if (A != 0)
                {
                    Items.Add(A);
                    if (i>0&&Items.Count-1<i)
                    {
                        Moved = true;
                    }
                }
                Tiles[i].Text = "0";
            }
            for (int i = 0; i < Items.Count-1; i++)
            {
                if(Items[i]==Items[i+1])
                {
                    Items[i] = Items[i] * 2;
                    Items[i + 1] = 0;
                    AddScore += Items[i];
                    Moved = true;
                }
            }
            for (int i = 0; i < Items.Count; i++)
            {
                if(Items[i]==0)
                {
                    Items.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < Items.Count; i++)
            {
                    Tiles[i].Text=Items[i].ToString();
            }
            ReturnScore = AddScore;
            return Moved;
        }

        int Ar = 100;
        bool Up = false;
        private void ColorFade(object sender, EventArgs e)
        {
            if (Up)
            {
                Ar++;
                if (Ar == 256)
                {
                    Up = false;
                }
            }
            if (!Up)
            {
                Ar--;
                if (Ar == 0)
                {
                    Up = true;
                }
            };
            foreach (Label item in this.Controls)
            {
                if (item.Text == "0")
                {
                    item.BackColor = System.Drawing.Color.FromArgb(Ar, System.Drawing.Color.White);
                }
            };

        }
    }
    public class NextMove
    {
        public bool LOSE = false;

        private List<List<int>> Up = new List<List<int>>();
        private bool _Up = false;
        private int _Up_ = 0;
        private bool WinUp = false;

        private List<List<int>> Down = new List<List<int>>();
        private bool _Down = false;
        private bool WinDown = false;
        private int _Down_ = 0;

        private List<List<int>> Left = new List<List<int>>();
        private bool _Left = false;
        private bool WinLeft = false;
        private int _Left_ = 0;

        private List<List<int>> Right = new List<List<int>>();
        private bool _Right = false;
        private bool WinRight = false;
        private int _Right_ = 0;

        Control.ControlCollection _Controls;

        public NextMove(Control.ControlCollection Controls)
        {
            LOSE = Combine(Controls);
            _Controls = Controls;
        }

        private bool Combine(Control.ControlCollection Controls)
        {
            bool LOSE = false;
            Up = new List<List<int>>();
            Down = new List<List<int>>();
            Left = new List<List<int>>();
            Right = new List<List<int>>();
            for (int i = 0; i < 4; i++)
            {
                List<int> A = new List<int>();
                A.Add(int.Parse(((Label)Controls["R" + (0).ToString() + "C" + i.ToString()]).Text));
                A.Add(int.Parse(((Label)Controls["R" + (1).ToString() + "C" + i.ToString()]).Text));
                A.Add(int.Parse(((Label)Controls["R" + (2).ToString() + "C" + i.ToString()]).Text));
                A.Add(int.Parse(((Label)Controls["R" + (3).ToString() + "C" + i.ToString()]).Text));
                int RSa = 0;
                if (ComboTiles(ref A, out RSa,out WinUp))
                {
                    if (!_Up)
                    {
                        _Up = true;
                    }
                }
                _Up_ += RSa;
                Up.Add(A);
           
                List<int> B = new List<int>();
                B.Add(int.Parse(((Label)Controls["R" + (3).ToString() + "C" + i.ToString()]).Text));
                B.Add(int.Parse(((Label)Controls["R" + (2).ToString() + "C" + i.ToString()]).Text));
                B.Add(int.Parse(((Label)Controls["R" + (1).ToString() + "C" + i.ToString()]).Text));
                B.Add(int.Parse(((Label)Controls["R" + (0).ToString() + "C" + i.ToString()]).Text));
                int RSb = 0;
                if(ComboTiles(ref B, out RSb, out WinDown))
                {
                    if (!_Down)
                    {
                        _Down = true;
                    }
                }
                _Down_ = RSb;
                Down.Add(B);

                List<int> C = new List<int>();
                C.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C0"]).Text));
                C.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C1"]).Text));
                C.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C2"]).Text));
                C.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C3"]).Text));
                int RSc = 0;
                if(ComboTiles(ref C, out RSc, out WinLeft))
                {
                    if(!_Left)
                    {
                        _Left = true;
                    }
                }
                _Left_ += RSc;
                Left.Add(C);

                List<int> D = new List<int>();
                D.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C3"]).Text));
                D.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C2"]).Text));
                D.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C1"]).Text));
                D.Add(int.Parse(((Label)Controls["R" + (i).ToString() + "C0"]).Text));
                int RSd = 0;
                if(ComboTiles(ref D, out RSd, out WinRight))
                {
                    if (!_Right)
                    {
                        _Right = true;
                    }
                }
                _Right_ += RSd;
                Right.Add(D);

            }
            if(!_Up&&!_Down&&!_Left&&!_Right)
            {
                LOSE = true;
            }
            return LOSE;
        }

        private static bool ComboTiles(ref List<int> Tiles, out int ReturnScore,out bool Win)
        {
            bool Moved = false;
            Win = false;
            int AddScore = 0;
            List<int> Items = new List<int>();
            for (int i = 0; i < Tiles.Count; i++)
            {
                int A = Tiles[i];
                if (A != 0)
                {
                    Items.Add(A);
                    if (i > 0 && Items.Count - 1 < i)
                    {
                        Moved = true;
                    }
                }
                Tiles[i] = 0;
            }
            for (int i = 0; i < Items.Count - 1; i++)
            {
                if (Items[i] == Items[i + 1])
                {
                    if(Items[i]==2048)
                    { Win = true; };
                    Items[i] = Items[i] * 2;
                    Items[i + 1] = 0;
                    AddScore += Items[i];
                    Moved = true;
                }
            }
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] == 0)
                {
                    Items.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < Items.Count; i++)
            {
                Tiles[i] = Items[i];
            }
            ReturnScore = AddScore;
            return Moved;
        }

        public bool Move(char Direction, out int Score, out bool WIN)
        {
            switch (Direction)
            {
                //r3-0 
                case 'U':
                    for (int i = 0; i < 4; i++)
                    {
                        ((Label)this._Controls["R" + (0).ToString() + "C" + i.ToString()]).Text = Up[i][0].ToString();
                        ((Label)this._Controls["R" + (1).ToString() + "C" + i.ToString()]).Text = Up[i][1].ToString();
                        ((Label)this._Controls["R" + (2).ToString() + "C" + i.ToString()]).Text = Up[i][2].ToString();
                        ((Label)this._Controls["R" + (3).ToString() + "C" + i.ToString()]).Text = Up[i][3].ToString();
                    }
                    Score = _Up_;
                    WIN = WinUp;
                    return _Up;
                //r0-3
                case 'D':
                    for (int i = 3; i > -1; i--)
                    {
                        ((Label)this._Controls["R" + (3).ToString() + "C" + i.ToString()]).Text = Down[i][0].ToString();
                        ((Label)this._Controls["R" + (2).ToString() + "C" + i.ToString()]).Text = Down[i][1].ToString();
                        ((Label)this._Controls["R" + (1).ToString() + "C" + i.ToString()]).Text = Down[i][2].ToString();
                        ((Label)this._Controls["R" + (0).ToString() + "C" + i.ToString()]).Text = Down[i][3].ToString();
                    }
                    Score = _Down_;
                    WIN = WinDown;
                    return _Down;
                //c3-0
                case 'L':
                    for (int i = 0; i < 4; i++)
                    {
                        ((Label)this._Controls["R" + (i).ToString() + "C0"]).Text = Left[i][0].ToString();
                        ((Label)this._Controls["R" + (i).ToString() + "C1"]).Text = Left[i][1].ToString();
                        ((Label)this._Controls["R" + (i).ToString() + "C2"]).Text = Left[i][2].ToString();
                        ((Label)this._Controls["R" + (i).ToString() + "C3"]).Text = Left[i][3].ToString();
                    }
                    Score = _Left_;
                    WIN = WinLeft;
                    return _Left;
                //c0-3
                case 'R':
                    for (int i = 0; i < 4; i++)
                    {
                        ((Label)this._Controls["R" + (i).ToString() + "C3"]).Text= Right[i][0].ToString();
                        ((Label)this._Controls["R" + (i).ToString() + "C2"]).Text= Right[i][1].ToString();
                        ((Label)this._Controls["R" + (i).ToString() + "C1"]).Text= Right[i][2].ToString();
                        ((Label)this._Controls["R" + (i).ToString() + "C0"]).Text= Right[i][3].ToString();
                    }
                    Score = _Right_;
                    WIN = WinRight;
                    return _Right;
            }
            Score = 0;
            throw new Exception("Out of Range");
        }
    }
}
