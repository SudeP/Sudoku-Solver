
namespace Sudoku_Solver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSolve = new System.Windows.Forms.Button();
            this.sudokuArea = new Sudoku_Solver.SudokuPanel();
            this.btnFillNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(93, 12);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            // 
            // sudokuArea
            // 
            this.sudokuArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sudokuArea.Location = new System.Drawing.Point(0, 41);
            this.sudokuArea.MinimumSize = new System.Drawing.Size(400, 400);
            this.sudokuArea.Name = "sudokuArea";
            this.sudokuArea.Size = new System.Drawing.Size(400, 400);
            this.sudokuArea.TabIndex = 0;
            // 
            // btnFillNumber
            // 
            this.btnFillNumber.Location = new System.Drawing.Point(12, 12);
            this.btnFillNumber.Name = "btnFillNumber";
            this.btnFillNumber.Size = new System.Drawing.Size(75, 23);
            this.btnFillNumber.TabIndex = 2;
            this.btnFillNumber.Text = "Fill Number";
            this.btnFillNumber.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 441);
            this.Controls.Add(this.btnFillNumber);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.sudokuArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(415, 480);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private SudokuPanel sudokuArea;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnFillNumber;
    }
}

