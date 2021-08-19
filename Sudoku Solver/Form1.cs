using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += (_1, _2) =>
            {
                Panel area = new Panel()
                {
                    Parent = this,
                    BorderStyle = BorderStyle.None,
                    Location = new Point(0, 0),
                    Size = new Size(340, 340)
                };

                int buttonSize = 25,
                buttonOffset = 10;

                for (int a = 0; a < 9; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        int addBonusOffsetX = a % 3 == 0 ? buttonOffset : 0;
                        int addBonusOffsetY = b % 3 == 0 ? buttonOffset : 0;

                        Button btn = new Button()
                        {
                            Parent = area,
                            Size = new Size(buttonSize, buttonSize),
                            Location = new Point(addBonusOffsetX + buttonOffset + (buttonSize * a), addBonusOffsetY + buttonOffset + (buttonSize * b))
                        };

                        btn.Click += (curr, _3) =>
                        {
                            string input = Interaction.InputBox("", "", "0");

                            if (int.TryParse(input, out _))
                            {
                                ((Button)curr).Text = input;
                            }
                        };
                    }
                }
            };
        }
    }
}
