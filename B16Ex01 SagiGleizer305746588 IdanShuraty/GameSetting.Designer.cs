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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.textBoxPlaye2Name = new System.Windows.Forms.TextBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player1:";
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
            // GameSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxPlaye2Name);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayer);
            this.Name = "GameSetting";
            this.Text = "GameSetting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.TextBox textBoxPlaye2Name;
    }
}