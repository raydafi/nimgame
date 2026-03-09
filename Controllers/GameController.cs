using System;
using System.Collections.Generic;
using System.Text;
using jeu.Models;

namespace jeu.Controllers
{
    public class GameController
    {
        public bool IsGameOver { get; private set; }
        public Player Winner { get; private set; }
        public int MatchesLeft { get; private set; }
        public bool IsPlayerOneTurn { get; private set; }
        public bool IsPlayingAgainstAI { get; private set; }
        public bool IsHardDifficulty { get; private set; }

        private DatabaseManager dbManager;
        private Player player1;
        private Player player2;

        public GameController(DatabaseManager db, Player p1, Player p2, bool againstAI, bool hardMode)
        {
            dbManager = db;
            player1 = p1;
            player2 = p2;
            IsPlayingAgainstAI = againstAI;
            IsHardDifficulty = hardMode;

            MatchesLeft = 21;
            Random rand = new Random();
            IsPlayerOneTurn = rand.Next(2) == 0;
        }

        public void RemoveMatches(int count)
        {
            // 1. Vérification de la validité du coup
            if (count < 1 || count > 3 || count > MatchesLeft)
                throw new ArgumentException("Invalid number of matches to remove.");

            // 2. On retire les allumettes
            MatchesLeft -= count;

            // 3. On vérifie si la partie est terminée avant de changer de tour
            if (MatchesLeft == 0)
            {
                // Dans le jeu des allumettes classique, celui qui prend la dernière a perdu.
                // Puisqu'on n'a pas encore changé de tour, IsPlayerOneTurn nous indique qui vient de jouer le coup fatal.
                Player loser = IsPlayerOneTurn ? player1 : player2;
                Player winner = IsPlayerOneTurn ? player2 : player1; // Si joueur 2 est null (IA), on gérera ça dans EndGame

                EndGame(winner, loser);
            }
            else
            {
                // La partie continue, on passe au tour suivant
                IsPlayerOneTurn = !IsPlayerOneTurn;
            }
        }

        public int CalculateAITurn()
        {
            // Sécurité : On détermine le maximum d'allumettes qu'on a le droit de prendre (3 ou moins s'il en reste moins de 3)
            int maxPossible = Math.Min(3, MatchesLeft);

            if (IsHardDifficulty)
            {
                // MODE DIFFICILE : La stratégie mathématique (Modulo)
                int idealMove = (MatchesLeft - 1) % 4;

                if (idealMove == 0)
                {
                    // L'IA est piégée, elle prend juste 1 allumette en espérant que le joueur fasse une erreur au tour suivant
                    return 1;
                }
                else
                {
                    // L'IA joue le coup parfait
                    return idealMove;
                }
            }
            else
            {
                // MODE FACILE : Choix aléatoire
                Random rand = new Random();

                // Le deuxième paramètre de Next() est exclusif, donc on fait + 1
                return rand.Next(1, maxPossible + 1);
            }
        }

        // Méthode pour obtenir le nom du joueur actuel
        public string GetCurrentPlayerName()
        {
            if (IsPlayerOneTurn)
            {
                return player1.Name;
            }
            else
            {
                // Si on joue contre l'IA, on renvoie "L'ordinateur", sinon on renvoie le nom du joueur 2
                return IsPlayingAgainstAI ? "L'ordinateur" : player2.Name;
            }
        }

        private void EndGame(Player winner, Player loser)
        {
            IsGameOver = true;
            Winner = winner;
            // 1. Mise à jour du gagnant (si ce n'est pas l'IA)
            if (winner != null)
            {
                winner.Wins++;
                dbManager.UpdatePlayerStats(winner);
            }

            // 2. Mise à jour du perdant (si ce n'est pas l'IA)
            if (loser != null)
            {
                loser.Losses++;
                dbManager.UpdatePlayerStats(loser);
            }

            // 3. Sauvegarde de la partie dans l'historique
            string gameType = IsPlayingAgainstAI ? "Joueur vs IA" : "Joueur vs Joueur";
            string result = winner != null ? winner.Name + " a gagné" : "L'IA a gagné";

            // Il faudra créer cette méthode dans ton DatabaseManager !
            dbManager.SaveGameHistory(player1, player2, gameType, result);
        }

        // Méthode pour réinitialiser la partie avec les mêmes joueurs
        public void RestartGame()
        {
            MatchesLeft = 21; // On remet le paquet d'allumettes
            Random rand = new Random();
            IsPlayerOneTurn = rand.Next(2) == 0;
            IsGameOver = false; // Le jeu n'est plus terminé
            Winner = null; // On efface le gagnant précédent
        }
    }
}
