using System.Threading.Tasks;

namespace Sudoku_Solver
{
    public class Solver
    {
        private SudokuPanel panel;
        public Task Solve(SudokuPanel sudokuPanel)
        {
            panel = sudokuPanel;

            return Task.Factory.StartNew(Process);
        }
        private void Process()
        {

        }
    }
    public class StickChild
    {
        public SudokuButton[] Cells { get; set; }
        public StickChild()
        {
            Cells = new SudokuButton[9];
        }
    }
    public class CubeChild
    {
        public SudokuButton[,] Cells { get; set; }
        public CubeChild()
        {
            Cells = new SudokuButton[9, 9];
        }
    }
}
