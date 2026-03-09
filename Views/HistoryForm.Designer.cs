namespace jeu.Views
{
    partial class HistoryForm
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
            label1 = new Label();
            label2 = new Label();
            dgvRankings = new DataGridView();
            dgvHistory = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRankings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(189, 75);
            label1.Name = "label1";
            label1.Size = new Size(343, 32);
            label1.TabIndex = 0;
            label1.Text = "Classement des joueurs";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1032, 75);
            label2.Name = "label2";
            label2.Size = new Size(254, 32);
            label2.TabIndex = 1;
            label2.Text = "Dernières parties";
            // 
            // dgvRankings
            // 
            dgvRankings.AllowUserToAddRows = false;
            dgvRankings.BackgroundColor = SystemColors.Control;
            dgvRankings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRankings.Location = new Point(12, 119);
            dgvRankings.Name = "dgvRankings";
            dgvRankings.RowHeadersWidth = 72;
            dgvRankings.Size = new Size(713, 813);
            dgvRankings.TabIndex = 2;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.BackgroundColor = SystemColors.Control;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(799, 119);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 72;
            dgvHistory.Size = new Size(713, 813);
            dgvHistory.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(1211, 983);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(301, 69);
            btnClose.TabIndex = 4;
            btnClose.Text = "Retour au menu";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 1064);
            Controls.Add(btnClose);
            Controls.Add(dgvHistory);
            Controls.Add(dgvRankings);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HistoryForm";
            Text = "HistoryForm";
            ((System.ComponentModel.ISupportInitialize)dgvRankings).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgvRankings;
        private DataGridView dgvHistory;
        private Button btnClose;
    }
}