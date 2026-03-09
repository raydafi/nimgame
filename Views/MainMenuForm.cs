using System;
using System.Windows.Forms;
using jeu.Controllers;
using jeu.Models;

namespace jeu.Views
{
    public partial class MainMenuForm : Form
    {
        // On prépare notre gestionnaire de base de données
        private DatabaseManager dbManager;

        public MainMenuForm()
        {
            InitializeComponent(); // Cette ligne magique charge tout ce que tu as fait dans le designer !
            dbManager = new DatabaseManager();

            // On abonne les RadioButtons à l'événement qui modifie l'interface
            rbPvP.CheckedChanged += ModeDeJeu_CheckedChanged;
            rbPvE.CheckedChanged += ModeDeJeu_CheckedChanged;
        }

        // Méthode pour adapter l'interface selon le mode choisi
        private void ModeDeJeu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPvE.Checked)
            {
                // Mode contre l'ordinateur : On désactive le Joueur 2 et on affiche la difficulté
                txtPlayer2.Enabled = false;
                txtPlayer2.Text = "Ordinateur";
                chkHardMode.Visible = true;
            }
            else
            {
                // Mode Joueur vs Joueur : On réactive le Joueur 2 et on cache la difficulté
                txtPlayer2.Enabled = true;
                txtPlayer2.Text = "Joueur 2";
                chkHardMode.Visible = false;
            }
        }

        // Double-clique sur ton bouton btnPlay dans le designer pour générer ça :
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // 1. On récupère ou on crée les joueurs depuis la base de données
            // (Logique à peaufiner selon ton DatabaseManager)
            // Pour le Joueur 1
            Player p1 = dbManager.GetPlayerByName(txtPlayer1.Text);
            if (p1 == null)
            {
                p1 = new Player(txtPlayer1.Text);
                dbManager.AddPlayer(p1); // On l'ajoute à la BDD
                p1 = dbManager.GetPlayerByName(txtPlayer1.Text); // On le récupère pour avoir son nouvel ID !
            }

            // Pour le Joueur 2 (si on ne joue pas contre l'IA)
            Player p2 = null;
            if (!rbPvE.Checked)
            {
                p2 = dbManager.GetPlayerByName(txtPlayer2.Text);
                if (p2 == null)
                {
                    p2 = new Player(txtPlayer2.Text);
                    dbManager.AddPlayer(p2);
                    p2 = dbManager.GetPlayerByName(txtPlayer2.Text);
                }
            }

            // 2. On configure le contrôleur
            bool againstAI = rbPvE.Checked;
            bool isHard = chkHardMode.Checked;
            GameController controller = new GameController(dbManager, p1, p2, againstAI, isHard);

            // 3. On ouvre la fenêtre du jeu
            GameForm gameForm = new GameForm(controller);
            gameForm.FormClosed += (s, args) => this.Show();
            gameForm.Show();
            this.Hide(); // On cache le menu

            MessageBox.Show("Le jeu va se lancer !", "Test"); // Temporaire
        }

        // Double-clique sur ton bouton btnHistory dans le designer pour générer ça :
        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.FormClosed += (s, args) => this.Show(); // Le menu réapparaît quand on quitte l'historique
            historyForm.Show();
            this.Hide(); // On cache le menu        }
        }
    }
}