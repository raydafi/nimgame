using System;
using System.Windows.Forms;
using jeu.Models;

namespace jeu.Views
{
    public partial class HistoryForm : Form
    {
        private DatabaseManager dbManager;

        public HistoryForm()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();

            // On configure l'apparence de nos tableaux
            SetupDataGrids();

            // On demande à la base de données de nous fournir les infos
            LoadData();
        }

        private void SetupDataGrids()
        {
            // Colonnes pour le classement (dgvRankings)
            dgvRankings.Columns.Add("Name", "Joueur");
            dgvRankings.Columns.Add("Wins", "Victoires");
            dgvRankings.Columns.Add("Losses", "Défaites");

            // Pour que les colonnes prennent toute la largeur :
            dgvRankings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Colonnes pour l'historique (dgvHistory)
            dgvHistory.Columns.Add("GameType", "Mode de jeu");
            dgvHistory.Columns.Add("Result", "Résultat");

            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            // On nettoie les tableaux avant de les remplir
            dgvRankings.Rows.Clear();
            dgvHistory.Rows.Clear();

            // 1. Remplissage du classement
            List<Player> joueurs = dbManager.GetPlayerRankings();
            foreach (Player joueur in joueurs)
            {
                dgvRankings.Rows.Add(joueur.Name, joueur.Wins, joueur.Losses);
            }

            // 2. Remplissage de l'historique
            List<string[]> parties = dbManager.GetGameHistory();
            foreach (string[] partie in parties)
            {
                dgvHistory.Rows.Add(partie[0], partie[1]); // partie[0] = Mode, partie[1] = Résultat
            }
        }

        // Double-clique sur ton bouton btnClose dans le designer pour générer ceci :
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme la fenêtre d'historique (le menu principal réapparaîtra si on l'a bien configuré)
        }
    }
}