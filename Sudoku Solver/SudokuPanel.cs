using System.Drawing;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public class SudokuPanel : Panel
    {
        public const int minimumWidth = 400;
        public const int minimumHeight = 400;
        public const int buttonMinimumSizeWidth = 25;
        public const int buttonMinimumSizeHeight = 25;
        public const int buttonMinimumOffset = 5;
        public const int buttonBonusOffsetCount = 3;
        public const int buttonCountX = 9;
        public const int buttonCountY = 9;
        public override Size MinimumSize
        {
            get => new Size(minimumWidth, minimumHeight);
        }
        public SudokuButton[,] Buttons;
        public CubeChild[] Cubes;
        public StickChild[] Sticks;
        public SudokuPanel()
        {
            Buttons = new SudokuButton[buttonCountX, buttonCountY];
            Cubes = new CubeChild[9];
            Sticks = new StickChild[18];

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Buttons[x, y] = new SudokuButton()
                    {
                        Parent = this
                    };
                }
            }

            for (int x = 0; x < 9; x++)
            {
                StickChild stickChild = new StickChild();
                for (int y = 0; y < 9; y++)
                {
                    stickChild.Cells[y] = Buttons[x, y];
                }
                Sticks[x] = stickChild;
            }

            for (int y = 0; y < 9; y++)
            {
                StickChild stickChild = new StickChild();
                for (int x = 0; x < 9; x++)
                {
                    stickChild.Cells[y] = Buttons[x, y];
                }
                Sticks[y + 9] = stickChild;
            }

            int cubeX = 0, cubeY = 0;
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    CubeChild cubeChild = new CubeChild();
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            int m = cubeX + x;
                            int n = cubeY + y;

                            cubeChild.Cells[m, n] = Buttons[m, n];
                        }
                    }
                    int index = ((a + 1) * (b + 1)) - 1;
                    Cubes[index] = cubeChild;
                    cubeY += 3;
                }
                cubeX += 3;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Size.Width < minimumWidth || Size.Height < minimumHeight)
            {
                Size = MinimumSize;
            }

            int buttonBonusOffset = buttonMinimumOffset * buttonBonusOffsetCount;

            int Calculate(int size, int countX, int minimumSize)
            {
                int remainingAreaForButtons = size - ((buttonMinimumOffset * (countX + 1)) + buttonBonusOffset);

                int buttonPerArea = remainingAreaForButtons / countX;

                if (buttonPerArea < minimumSize)
                {
                    buttonPerArea = minimumSize;
                }

                return buttonPerArea;
            }

            int sizeWidth = Calculate(Size.Width, buttonCountX, buttonMinimumSizeWidth);

            int sizeHeight = Calculate(Size.Height, buttonCountY, buttonMinimumSizeHeight);


            int locationX = 0;
            for (int x = 0; x < buttonCountX; x++)
            {
                int addBonusOffsetX = x > 0 && x % buttonBonusOffsetCount == 0 ? buttonMinimumOffset : 0;
                locationX += (x > 0 ? sizeWidth : 0) + buttonMinimumOffset + addBonusOffsetX;

                int locationY = 0;
                for (int y = 0; y < buttonCountY; y++)
                {
                    int addBonusOffsetY = y > 0 && y % buttonBonusOffsetCount == 0 ? buttonMinimumOffset : 0;
                    locationY += (y > 0 ? sizeHeight : 0) + buttonMinimumOffset + addBonusOffsetY;

                    Buttons[x, y].Size = new Size(sizeWidth, sizeHeight);
                    Buttons[x, y].Location = new Point(locationX, locationY);
                }
            }

            base.OnPaint(e);
        }
    }
}
