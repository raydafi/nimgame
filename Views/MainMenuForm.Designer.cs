namespace jeu.Views
{
    partial class MainMenuForm
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
            lblTitle = new Label();
            rbPvP = new RadioButton();
            rbPvE = new RadioButton();
            txtPlayer1 = new TextBox();
            txtPlayer2 = new TextBox();
            chkHardMode = new CheckBox();
            btnPlay = new Button();
            btnHistory = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Broadway", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(166, 182);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1197, 127);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Jeu des allumettes";
            // 
            // rbPvP
            // 
            rbPvP.AutoSize = true;
            rbPvP.Checked = true;
            rbPvP.Font = new Font("Arial Rounded MT Bold", 14.1428576F);
            rbPvP.Location = new Point(73, 493);
            rbPvP.Name = "rbPvP";
            rbPvP.Size = new Size(390, 42);
            rbPvP.TabIndex = 1;
            rbPvP.TabStop = true;
            rbPvP.Text = "Joueur contre Joueur";
            rbPvP.UseVisualStyleBackColor = true;
            // 
            // rbPvE
            // 
            rbPvE.AutoSize = true;
            rbPvE.Font = new Font("Arial Rounded MT Bold", 14.1428576F);
            rbPvE.Location = new Point(73, 546);
            rbPvE.Name = "rbPvE";
            rbPvE.Size = new Size(450, 42);
            rbPvE.TabIndex = 2;
            rbPvE.Text = "Jouer contre l'Ordinateur";
            rbPvE.UseVisualStyleBackColor = true;
            // 
            // txtPlayer1
            // 
            txtPlayer1.Font = new Font("Arial", 12F);
            txtPlayer1.Location = new Point(1201, 497);
            txtPlayer1.Name = "txtPlayer1";
            txtPlayer1.Size = new Size(249, 40);
            txtPlayer1.TabIndex = 3;
            txtPlayer1.Text = "Joueur 1";
            // 
            // txtPlayer2
            // 
            txtPlayer2.Font = new Font("Arial", 12F);
            txtPlayer2.Location = new Point(1201, 568);
            txtPlayer2.Name = "txtPlayer2";
            txtPlayer2.Size = new Size(249, 40);
            txtPlayer2.TabIndex = 4;
            txtPlayer2.Text = "Joueur 2";
            // 
            // chkHardMode
            // 
            chkHardMode.AutoSize = true;
            chkHardMode.Cursor = Cursors.SizeNESW;
            chkHardMode.Font = new Font("Arial Rounded MT Bold", 14.1428576F);
            chkHardMode.Location = new Point(119, 602);
            chkHardMode.Name = "chkHardMode";
            chkHardMode.Size = new Size(258, 42);
            chkHardMode.TabIndex = 5;
            chkHardMode.Text = "Mode difficile";
            chkHardMode.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPlay.Location = new Point(502, 801);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(514, 55);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "Lancer la partie !";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHistory.Location = new Point(502, 887);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(514, 55);
            btnHistory.TabIndex = 7;
            btnHistory.Text = "Historique des parties";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.1428576F);
            label1.Location = new Point(1009, 493);
            label1.Name = "label1";
            label1.Size = new Size(176, 38);
            label1.TabIndex = 8;
            label1.Text = "Joueur 1 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 14.1428576F);
            label2.Location = new Point(1009, 564);
            label2.Name = "label2";
            label2.Size = new Size(176, 38);
            label2.TabIndex = 9;
            label2.Text = "Joueur 2 :";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1548, 1128);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnHistory);
            Controls.Add(btnPlay);
            Controls.Add(chkHardMode);
            Controls.Add(txtPlayer2);
            Controls.Add(txtPlayer1);
            Controls.Add(rbPvE);
            Controls.Add(rbPvP);
            Controls.Add(lblTitle);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private RadioButton rbPvP;
        private RadioButton rbPvE;
        private TextBox txtPlayer1;
        private TextBox txtPlayer2;
        private CheckBox chkHardMode;
        private Button btnPlay;
        private Button btnHistory;
        private Label label1;
        private Label label2;
    }
}