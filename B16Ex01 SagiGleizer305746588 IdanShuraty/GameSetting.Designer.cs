namespace B16Ex01_SagiGleizer305746588_IdanShuraty
{
    partial class GameSetting
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
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.textBoxPlaye2Name = new System.Windows.Forms.TextBox();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Location = new System.Drawing.Point(12, 20);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(44, 13);
            this.labelPlayer.TabIndex = 0;
            this.labelPlayer.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(40, 42);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(45, 13);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player1:";
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(12, 114);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.labelBoardSize.TabIndex = 2;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(43, 69);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Player2:";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(113, 42);
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayer1Name.TabIndex = 4;
            // 
            // textBoxPlaye2Name
            // 
            this.textBoxPlaye2Name.Enabled = false;
            this.textBoxPlaye2Name.Location = new System.Drawing.Point(113, 69);
            this.textBoxPlaye2Name.Name = "textBoxPlaye2Name";
            this.textBoxPlaye2Name.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlaye2Name.TabIndex = 5;
            this.textBoxPlaye2Name.Text = "[Computer]";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(90, 138);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownRows.TabIndex = 6;
            this.numericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(33, 140);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(37, 13);
            this.labelRows.TabIndex = 7;
            this.labelRows.Text = "Rows:";
            this.labelRows.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(133, 140);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(30, 13);
            this.labelCols.TabIndex = 9;
            this.labelCols.Text = "Cols:";
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(176, 138);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownCols.TabIndex = 8;
            this.numericUpDownCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(15, 180);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(198, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // GameSetting
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 215);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.textBoxPlaye2Name);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayer);
            this.Enabled = false;
            this.Name = "GameSetting";
            this.Text = "Game Setting";
            this.Load += new System.EventHandler(this.GameSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.TextBox textBoxPlaye2Name;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Button buttonStart;
    }
}