using OpenQA.Selenium.Firefox;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class Form1 : Form
    {
        FirefoxDriver driver;
        public Form1()
        {
            InitializeComponent();
            FormClosing += (_1, _2) =>
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
                }
            };
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
                btnFillNumber.Enabled = false;
                btnSolve.Enabled = false;
                sudokuArea.Enabled = false;

                Solver solver = new Solver();

                solver.Solve(sudokuArea).ContinueWith(_ =>
                {
                    Invoke(new Action(() =>
                    {
                        btnFillNumber.Enabled = true;
                        btnSolve.Enabled = true;
                        sudokuArea.Enabled = true;
                    }));
                });
            };
            btnFillNumber.Click += (_1, _2) =>
            {
                btnFillNumber.Enabled = false;
                btnSolve.Enabled = false;
                sudokuArea.Enabled = false;

                Task.Factory.StartNew(() =>
                {
                    FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService();
                    firefoxDriverService.HideCommandPromptWindow = true;
                    FirefoxOptions firefoxOptions = new FirefoxOptions();

                    driver = new FirefoxDriver(firefoxDriverService, firefoxOptions)
                    {
                        Url = "https://sudoku.com/medium"
                    };

                    driver.Manage().Window.Minimize();

                    object obj;

                    while (true)
                    {
                        obj = driver.ExecuteScript($@"return window.game.scene.keys.Game.gameFieldReady");
                        if (obj != null)
                        {
                            break;
                        }
                        else Wait(500);
                    }

                    if (true.ToString() == obj.ToString())
                    {
                        for (int i = 0; i < 81; i++)
                        {
                            object val = driver.ExecuteScript($@"return window.game.scene.keys.Game.getCellById({i}).dataValue");
                            if (int.TryParse(val.ToString(), out int number) && number != 0)
                            {
                                Invoke(new Action(() =>
                                {
                                    sudokuArea.Buttons[i % 9, i / 9].Value = number;
                                    sudokuArea.Buttons[i % 9, i / 9].Text = number.ToString();
                                    Application.DoEvents();
                                }));
                            }
                        }
                    }
                    driver.Quit();
                    driver = null;
                }).ContinueWith(_ =>
                {
                    Invoke(new Action(() =>
                    {
                        btnFillNumber.Enabled = true;
                        btnSolve.Enabled = true;
                        sudokuArea.Enabled = true;
                    }));
                });
            };
        }
        private void Wait(int milliSecond)
        {
            var date = DateTime.Now.AddMilliseconds(milliSecond);
            while (true)
            {
                if (date < DateTime.Now)
                {
                    break;
                }
                else Application.DoEvents();
            }
        }
    }
}
