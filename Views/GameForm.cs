using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using jeu.Controllers;


namespace jeu.Views
{
    public partial class GameForm : Form
    {
        private GameController controller;

        // Le constructeur reçoit le contrôleur créé dans le menu principal
        public GameForm(GameController gameController)
        {
            InitializeComponent();
            controller = gameController;

            // On s'abonne à l'événement "Paint" du Panel pour qu'il se dessine tout seul
            pnlBoard.Paint += new PaintEventHandler(PnlBoard_Paint);

            UpdateUI(); // On met à jour l'affichage au démarrage
        }

        // --- LA MÉTHODE DE DESSIN (Le cadeau du début !) ---
        private void DessinerAllumettes(Graphics g, int nombreAllumettes, Panel panelJeu)
        {
            // --- ÉTAPE 0 : Le fond texturé (Tapis de jeu en feutre) ---
            // On utilise un motif de tissage (Weave) avec deux nuances de vert
            using (HatchBrush tapisBrush = new HatchBrush(HatchStyle.Weave, Color.ForestGreen, Color.DarkGreen))
            {
                // On remplit tout le panel avec cette texture
                g.FillRectangle(tapisBrush, panelJeu.ClientRectangle);
            }
            // 1. Activation de l'Anti-aliasing pour des contours parfaits
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (nombreAllumettes <= 0) return;

            int largeurAllumette = 12;
            int hauteurAllumette = 120;
            int espacement = 25;
            int largeurTotale = (nombreAllumettes * largeurAllumette) + ((nombreAllumettes - 1) * espacement);
            int startX = (panelJeu.Width - largeurTotale) / 2;
            int startY = (panelJeu.Height - hauteurAllumette) / 2;

            for (int i = 0; i < nombreAllumettes; i++)
            {
                int x = startX + i * (largeurAllumette + espacement);

                // --- ÉTAPE 1 : L'Ombre portée ---
                // On dessine l'ombre légèrement décalée vers la droite et le bas (x+4, y+4) avec du noir semi-transparent (Alpha 100)
                using (Brush shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                {
                    g.FillRectangle(shadowBrush, x + 4, startY + 4, largeurAllumette, hauteurAllumette);
                    g.FillEllipse(shadowBrush, x - 3 + 4, startY - 10 + 4, largeurAllumette + 6, 24);
                }

                // --- ÉTAPE 2 : Le bâton en bois (Effet cylindre 3D) ---
                Rectangle woodRect = new Rectangle(x, startY, largeurAllumette, hauteurAllumette);
                using (LinearGradientBrush woodBrush = new LinearGradientBrush(woodRect, Color.Black, Color.White, LinearGradientMode.Horizontal))
                {
                    // On crée un mélange de couleurs personnalisées (Foncé -> Clair -> Foncé)
                    ColorBlend woodBlend = new ColorBlend();
                    woodBlend.Positions = new float[] { 0.0f, 0.3f, 0.7f, 1.0f };
                    woodBlend.Colors = new Color[] { Color.SaddleBrown, Color.Bisque, Color.NavajoWhite, Color.SaddleBrown };
                    woodBrush.InterpolationColors = woodBlend;

                    g.FillRectangle(woodBrush, woodRect);
                }

                // --- ÉTAPE 3 : La tête de l'allumette (Effet sphère rouge) ---
                Rectangle headRect = new Rectangle(x - 3, startY - 10, largeurAllumette + 6, 24);
                using (LinearGradientBrush headBrush = new LinearGradientBrush(headRect, Color.Black, Color.White, LinearGradientMode.Horizontal))
                {
                    // Mélange de couleurs (Bordeaux -> Rouge clair -> Bordeaux)
                    ColorBlend headBlend = new ColorBlend();
                    headBlend.Positions = new float[] { 0.0f, 0.3f, 0.7f, 1.0f };
                    headBlend.Colors = new Color[] { Color.DarkRed, Color.LightCoral, Color.Red, Color.Maroon };
                    headBrush.InterpolationColors = headBlend;

                    g.FillEllipse(headBrush, headRect);
                }

                // --- ÉTAPE 4 : Le reflet de lumière sur la tête ---
                // Une petite touche finale pour simuler la brillance du soufre
                using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(150, 255, 200, 200)))
                {
                    g.FillEllipse(highlightBrush, x + 2, startY - 6, largeurAllumette - 4, 8);
                }
            }
        }

        // L'événement déclenché à chaque fois que le panel doit être redessiné
        private void PnlBoard_Paint(object sender, PaintEventArgs e)
        {
            DessinerAllumettes(e.Graphics, controller.MatchesLeft, pnlBoard);
        }

        // --- LOGIQUE D'AFFICHAGE ---
        // N'oublie pas d'ajouter ceci tout en haut de ton fichier avec les autres "using" :
        // using System.Threading.Tasks;

        // Ajoute le mot "async" ici !
        private async void UpdateUI()
        {
            // 1. On force le panel à se redessiner
            pnlBoard.Invalidate();

            // --- NOUVEAU : Mise à jour du compteur d'allumettes ---
            lblMatchesLeft.Text = "Allumettes restantes : " + controller.MatchesLeft;

            if (controller.IsGameOver)
            {
                string nomGagnant = controller.Winner != null ? controller.Winner.Name : "L'ordinateur";

                // On pose la question avec des boutons Oui / Non
                DialogResult choix = MessageBox.Show(
                    $"La partie est terminée ! {nomGagnant} a gagné !\n\nVoulez-vous recommencer une partie avec les mêmes paramètres ?",
                    "Fin de partie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (choix == DialogResult.Yes)
                {
                    // Le joueur veut rejouer : on réinitialise le contrôleur
                    controller.RestartGame();

                    // On efface le message de l'IA au cas où
                    lblAIMessage.Text = "";

                    // On relance l'affichage pour le nouveau premier tour
                    UpdateUI();
                }
                else
                {
                    // Le joueur a cliqué sur Non : on ferme le jeu et on retourne au menu
                    this.Close();
                }

                return; // On arrête l'exécution de la méthode ici dans tous les cas
            }

            lblStatus.Text = "C'est au tour de : " + controller.GetCurrentPlayerName();

            if (!controller.IsPlayerOneTurn && controller.IsPlayingAgainstAI && controller.MatchesLeft > 0)
            {
                // On désactive les boutons pendant que l'IA réfléchit
                EnableButtons(false);

                int iaChoice = controller.CalculateAITurn();

                // --- NOUVEAU : On affiche le message sur le Label au lieu du MessageBox ---
                lblAIMessage.Text = "L'IA décide de retirer " + iaChoice + " allumette(s).";

                // On fait une pause de 1.5 seconde (1500 millisecondes) pour que le joueur puisse lire
                await Task.Delay(1500);

                // On efface le message pour le prochain tour
                lblAIMessage.Text = "";

                controller.RemoveMatches(iaChoice);
                UpdateUI();
            }
            else
            {
                // C'est à un humain de jouer : on vérifie quels boutons activer
                btnTake1.Enabled = controller.MatchesLeft >= 1;
                btnTake2.Enabled = controller.MatchesLeft >= 2;
                btnTake3.Enabled = controller.MatchesLeft >= 3;
            }
        }

        private void EnableButtons(bool enabled)
        {
            btnTake1.Enabled = enabled;
            btnTake2.Enabled = enabled;
            btnTake3.Enabled = enabled;
        }

        // --- LES ÉVÉNEMENTS DES BOUTONS (Double-clique sur les boutons dans le designer pour les générer) ---
        private void btnTake1_Click(object sender, EventArgs e)
        {
            JouerCoup(1);
        }

        private void btnTake2_Click(object sender, EventArgs e)
        {
            JouerCoup(2);
        }

        private void btnTake3_Click(object sender, EventArgs e)
        {
            JouerCoup(3);
        }

        private void JouerCoup(int nb)
        {
            controller.RemoveMatches(nb);
            UpdateUI();
        }
    }
}