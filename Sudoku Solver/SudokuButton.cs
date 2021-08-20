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
            base.OnClick(e);
        }
        public SudokuButton()
        {
            Possibility = new bool[9];
            Value = 0;
        }
    }
}