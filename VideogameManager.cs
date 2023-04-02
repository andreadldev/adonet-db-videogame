using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    public class VideogameManager
    {
        public string connStr;

        public VideogameManager()
        {
            connStr = "Data Source=localhost;Initial Catalog=db-videogames-query; Integrated Security=True";
        }

        public void AddGame(Videogame videogame)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "INSERT INTO videogames (name, overview, release_date, software_house_id) " +
                                "VALUES ('@Name', '@Overview', '@ReleaseDate', '@SoftwareHouseId')";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", videogame.Name);
                    cmd.Parameters.AddWithValue("@Overview", videogame.Overview);
                    cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@SoftwareHouseId", videogame.SoftwareHouseId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public Videogame? SearchById(long id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE id = @Id";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var name = reader.GetString(1);
                        var overview = reader.GetString(2);
                        var releaseDate = reader.GetDateTime(3);
                        var softwareHouseId = reader.GetInt64(4);

                        Videogame videogame = new Videogame(id, name, overview, releaseDate, softwareHouseId);
                        Console.WriteLine($"ID: {reader.GetInt64(0)}\nNome: {reader.GetString(1)}\nDescrizione: {reader.GetString(2)}\nData di rilascio: {reader.GetDateTime(3)}");
                        return videogame;
                    }
                    Console.WriteLine("Nessun risultato trovato\n");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        public Videogame? SearchByName(string Name)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name = @Name";
                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", Name);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var name = reader.GetString(1);
                        var overview = reader.GetString(2);
                        var releaseDate = reader.GetDateTime(3);
                        var softwareHouseId = reader.GetInt64(4);

                        Videogame videogame = new Videogame(id, name, overview, releaseDate, softwareHouseId);
                        Console.WriteLine($"ID: {reader.GetInt64(0)}\nNome: {reader.GetString(1)}\nDescrizione: {reader.GetString(2)}\nData di rilascio: {reader.GetDateTime(3)}");
                        return videogame;
                    }
                    Console.WriteLine("Nessun risultato trovato\n");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }


        public bool DeleteGame(long id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    var query = "DELETE FROM videogames WHERE id = @Id";
                    var cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
    }
}
