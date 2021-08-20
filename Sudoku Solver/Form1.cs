using System;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPress += (_1, kea) =>
            {
                if (ActiveControl is SudokuButton button)
                {
                    if (int.TryParse(kea.KeyChar.ToString(), out int number))
                    {
                        button.Text = number == 0 ? string.Empty : number.ToString();
                        button.Value = number;
                    }
                }
            };
            btnSolve.Click += (_1, _2) =>
            {
                btnSolve.Enabled = false;
                sudokuArea.Enabled = false;

                Solver solver = new Solver();

                solver.Solve(sudokuArea).ContinueWith(_ =>
                {
                    Invoke(new Action(() =>
                    {
                        btnSolve.Enabled = true;
                        sudokuArea.Enabled = true;
                    }));
                });
            };
        }
    }
}
