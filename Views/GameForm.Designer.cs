namespace jeu.Views
{
    partial class GameForm
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
            pnlBoard = new Panel();
            lblStatus = new Label();
            btnTake1 = new Button();
            btnTake2 = new Button();
            btnTake3 = new Button();
            lblMatchesLeft = new Label();
            lblAIMessage = new Label();
            SuspendLayout();
            // 
            // pnlBoard
            // 
            pnlBoard.Location = new Point(12, 12);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.Size = new Size(1476, 529);
            pnlBoard.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial Rounded MT Bold", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(12, 562);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(300, 38);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "C'est au tour de...";
            // 
            // btnTake1
            // 
            btnTake1.Font = new Font("Arial", 12F);
            btnTake1.Location = new Point(12, 628);
            btnTake1.Name = "btnTake1";
            btnTake1.Size = new Size(200, 50);
            btnTake1.TabIndex = 2;
            btnTake1.Text = "Prendre 1";
            btnTake1.UseVisualStyleBackColor = true;
            btnTake1.Click += btnTake1_Click;
            // 
            // btnTake2
            // 
            btnTake2.Font = new Font("Arial", 12F);
            btnTake2.Location = new Point(218, 628);
            btnTake2.Name = "btnTake2";
            btnTake2.Size = new Size(200, 50);
            btnTake2.TabIndex = 3;
            btnTake2.Text = "Prendre 2";
            btnTake2.UseVisualStyleBackColor = true;
            btnTake2.Click += btnTake2_Click;
            // 
            // btnTake3
            // 
            btnTake3.Font = new Font("Arial", 12F);
            btnTake3.Location = new Point(424, 628);
            btnTake3.Name = "btnTake3";
            btnTake3.Size = new Size(200, 50);
            btnTake3.TabIndex = 4;
            btnTake3.Text = "Prendre 3";
            btnTake3.UseVisualStyleBackColor = true;
            btnTake3.Click += btnTake3_Click;
            // 
            // lblMatchesLeft
            // 
            lblMatchesLeft.AutoSize = true;
            lblMatchesLeft.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatchesLeft.Location = new Point(1165, 562);
            lblMatchesLeft.Name = "lblMatchesLeft";
            lblMatchesLeft.Size = new Size(323, 32);
            lblMatchesLeft.TabIndex = 5;
            lblMatchesLeft.Text = "Allumettes restantes : 21";
            // 
            // lblAIMessage
            // 
            lblAIMessage.AutoSize = true;
            lblAIMessage.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAIMessage.ForeColor = Color.Red;
            lblAIMessage.Location = new Point(12, 704);
            lblAIMessage.Name = "lblAIMessage";
            lblAIMessage.Size = new Size(0, 32);
            lblAIMessage.TabIndex = 6;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 1000);
            Controls.Add(lblAIMessage);
            Controls.Add(lblMatchesLeft);
            Controls.Add(btnTake3);
            Controls.Add(btnTake2);
            Controls.Add(btnTake1);
            Controls.Add(lblStatus);
            Controls.Add(pnlBoard);
            Name = "GameForm";
            Text = "GameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBoard;
        private Label lblStatus;
        private Button btnTake1;
        private Button btnTake2;
        private Button btnTake3;
        private Label lblMatchesLeft;
        private Label lblAIMessage;
    }
}