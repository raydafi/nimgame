using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace jeu.Models
{
    public class DatabaseManager
    {
        private string connectionString = "Server=mysql-raydafi.alwaysdata.net;Database=raydafi_allumettes;Uid=raydafi;Pwd=Gisby@Play;";

        public void AddPlayer(Player newPlayer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO players (name, wins, losses) VALUES (@nom, @victoires, @defaites)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nom", newPlayer.Name);
                        cmd.Parameters.AddWithValue("@victoires", newPlayer.Wins);
                        cmd.Parameters.AddWithValue("@defaites", newPlayer.Losses);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur de base de données : " + ex.Message);
                }
            }
        }

        public List<Player> GetPlayerRankings()
        {
            List<Player> playersList = new List<Player>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // On sélectionne les joueurs et on les trie par victoires (du plus grand au plus petit)
                    string query = "SELECT name, wins, losses FROM players ORDER BY wins DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // On crée un joueur avec les données lues et on l'ajoute à la liste
                                Player p = new Player(reader["name"].ToString())
                                {
                                    Wins = Convert.ToInt32(reader["wins"]),
                                    Losses = Convert.ToInt32(reader["losses"])
                                };
                                playersList.Add(p);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur de base de données : " + ex.Message);
                }
            }

            return playersList;
        }

        public List<string[]> GetGameHistory()
        {
            List<string[]> historyList = new List<string[]>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // On récupère le mode et le résultat des 15 dernières parties
                    string query = "SELECT game_type, result FROM history ORDER BY id DESC LIMIT 15";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string[] row = new string[]
                                {
                            reader["game_type"].ToString(),
                            reader["result"].ToString()
                                };
                                historyList.Add(row);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur de base de données : " + ex.Message);
                }
            }

            return historyList;
        }
        public Player GetPlayerByName(string name)
        {
            Player player = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM players WHERE name = @nom";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nom", name);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                player = new Player
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["name"].ToString(),
                                    Wins = Convert.ToInt32(reader["wins"]),
                                    Losses = Convert.ToInt32(reader["losses"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur de base de données : " + ex.Message);
                }
            }
            return player;
        }

        public void UpdatePlayerStats(Player player)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // On utilise UPDATE pour modifier un enregistrement existant basé sur son ID
                    string query = "UPDATE players SET wins = @victoires, losses = @defaites WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Toujours des paramètres pour bloquer les injections SQL !
                        cmd.Parameters.AddWithValue("@victoires", player.Wins);
                        cmd.Parameters.AddWithValue("@defaites", player.Losses);
                        cmd.Parameters.AddWithValue("@id", player.Id);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la mise à jour des stats : " + ex.Message);
                }
            }
        }

        public void SaveGameHistory(Player p1, Player p2, string gameType, string result)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO history (player1_id, player2_id, game_type, result) VALUES (@p1, @p2, @type, @result)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@p1", p1.Id);

                        // Si p2 est null (c'est l'IA), on insère DBNull.Value dans la colonne
                        cmd.Parameters.AddWithValue("@p2", p2 != null ? (object)p2.Id : DBNull.Value);

                        cmd.Parameters.AddWithValue("@type", gameType);
                        cmd.Parameters.AddWithValue("@result", result);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la sauvegarde de l'historique : " + ex.Message);
                }
            }
        }
    }
}
