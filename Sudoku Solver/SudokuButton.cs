using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public class SudokuButton : Button
    {
        public bool[] Possibility { get; set; }
        public int Value { get; set; }
        protected override void OnClick(EventArgs e)
        {
            //string input = Interaction.InputBox(string.Empty, string.Empty, "0");

            //if (int.TryParse(input, out int val))
            //{
            //    Text = val is 0 ? string.Empty : input;

            //    Value = val;
            //}

            base.OnClick(e);
        }
        public SudokuButton()
        {
            Possibility = new bool[9];
            Value = 0;
        }
    }
}