using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace PosteCifa.Models
{
    public static class DB
    {
        public static User getUserByUsername(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from [User] where Username = @username", conn);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            User user = new User();
            while (sqlDataReader.Read())
            {
                user.Id = Convert.ToInt32(sqlDataReader["IdUser"]);
                user.Username = sqlDataReader["Username"].ToString();
                user.Password = sqlDataReader["Password"].ToString();
                user.Role = sqlDataReader["Role"].ToString();
            }

            conn.Close();
            return user;
        }

        public static void AddCliente(string name, string surname, DateTime birthDay, string cf)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Clienti] (Nome, Cognome, DataNascita, CF) VALUES(@name, @surname, @birthday, @cf)";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("birthday", birthDay);
                cmd.Parameters.AddWithValue("cf", cf);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static void AddAzienda(string name, string ragioneSociale, string partitaIva)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Azienda] (Nominativo, RagioneSociale, PartitaIva) VALUES(@name, @ragioneSociale, @partitaIva)";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("ragioneSociale", ragioneSociale);
                cmd.Parameters.AddWithValue("partitaIva", partitaIva);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static void AddSpedizioneCLienti(DateTime dataSpedizione,double weight,string city,string address,string destinatario,double price,DateTime dataConsegna,int idCliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [SpedizioneClienti] (DataSpedizione,Peso,CittaDestinataria,Indirizzo,NominativoDestinatario,Costo,DataConsegna,IdCliente)" +
                    " VALUES(@dataSpedizione,@weight,@city,@address,@destinatario,@price,@dataConsegna,@idCliente)";
                cmd.Parameters.AddWithValue("dataSpedizione", dataSpedizione);
                cmd.Parameters.AddWithValue("weight", weight);
                cmd.Parameters.AddWithValue("city", city);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("destinatario", destinatario);
                cmd.Parameters.AddWithValue("price", price);
                cmd.Parameters.AddWithValue("dataConsegna", dataConsegna);
                cmd.Parameters.AddWithValue("idCliente", idCliente);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch(Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

        public static void AddSpedizioneAzienda(DateTime dataSpedizione, double weight, string city, string address, string destinatario, double price, DateTime dataConsegna, int idAzienda)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [SpedizioneAzienda] (DataSpedizione,Peso,CittaDestinataria,Indirizzo,NominativoDestinatario,Costo,DataConsegna,IdAzienda)" +
                    " VALUES(@dataSpedizione,@weight,@city,@address,@destinatario,@price,@dataConsegna,@idAzienda)";
                cmd.Parameters.AddWithValue("dataSpedizione", dataSpedizione);
                cmd.Parameters.AddWithValue("weight", weight);
                cmd.Parameters.AddWithValue("city", city);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("destinatario", destinatario);
                cmd.Parameters.AddWithValue("price", price);
                cmd.Parameters.AddWithValue("dataConsegna", dataConsegna);
                cmd.Parameters.AddWithValue("idAzienda", idAzienda);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }
        public static void AddUpdateSClienti(string state, string place, string description, DateTime dateUpdate, int idS)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [AggiornamentoSClienti] (Stato, Luogo, Descrizione, DataAggiornamento,IdSClienti) VALUES(@state, @place, @description, @dateUpdate,@idS)";
                cmd.Parameters.AddWithValue("state", state);
                cmd.Parameters.AddWithValue("place", place);
                cmd.Parameters.AddWithValue("description", description);
                cmd.Parameters.AddWithValue("dateUpdate", dateUpdate);
                cmd.Parameters.AddWithValue("idS", idS);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }
        public static void AddUpdateSAzienda(string state, string place, string description, DateTime dateUpdate, int idS)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [AggiornamentoSAzienda] (Stato, Luogo, Descrizione, DataAggiornamento,IdSAzienda) VALUES(@state, @place, @description, @dateUpdate,@idS)";
                cmd.Parameters.AddWithValue("state", state);
                cmd.Parameters.AddWithValue("place", place);
                cmd.Parameters.AddWithValue("description", description);
                cmd.Parameters.AddWithValue("dateUpdate", dateUpdate);
                cmd.Parameters.AddWithValue("idS", idS);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }
        public static List<Cliente> getAllClienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Clienti", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Cliente> clienti = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente c = new Cliente();
                c.Id = Convert.ToInt32(sqlDataReader["IdCliente"]);
                c.Name = sqlDataReader["Nome"].ToString();
                c.Surname = sqlDataReader["Cognome"].ToString();
                c.BirthDay = Convert.ToDateTime(sqlDataReader["DataNascita"]);
                c.CF = sqlDataReader["CF"].ToString();
                clienti.Add(c);
            }

            conn.Close();
            return clienti;
        }
        public static List<Azienda> getAllAziende()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Azienda", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Azienda> aziende = new List<Azienda>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Azienda a = new Azienda();
                a.Id = Convert.ToInt32(sqlDataReader["IdAzienda"]);
                a.Nominativo = sqlDataReader["Nominativo"].ToString();
                a.RagioneSociale = sqlDataReader["RagioneSociale"].ToString();
                a.PartitaIVA = sqlDataReader["PartitaIva"].ToString();
                aziende.Add(a);
            }

            conn.Close();
            return aziende;
        }

        public static List<Spedizione> getAllSpedizioniFromClienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from SpedizioneClienti", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Spedizione> spedizioni = new List<Spedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Spedizione s = new Spedizione();
                s.Id = Convert.ToInt32(sqlDataReader["IdSpedizione"]);
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.Weight = Convert.ToDouble(sqlDataReader["Peso"]);
                s.Destination = sqlDataReader["CittaDestinataria"].ToString();
                s.Address = sqlDataReader["Indirizzo"].ToString();
                s.Destinatario = sqlDataReader["NominativoDestinatario"].ToString();
                s.Price = Convert.ToDouble(sqlDataReader["Costo"]);
                s.DataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                spedizioni.Add(s);
            }

            conn.Close();
            return spedizioni;
        }

        public static List<Spedizione> getAllSpedizioniFromAziende()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from SpedizioneAzienda", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Spedizione> spedizioni = new List<Spedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Spedizione s = new Spedizione();
                s.Id = Convert.ToInt32(sqlDataReader["IdSpedizione"]);
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.Weight = Convert.ToDouble(sqlDataReader["Peso"]);
                s.Destination = sqlDataReader["CittaDestinataria"].ToString();
                s.Address = sqlDataReader["Indirizzo"].ToString();
                s.Destinatario = sqlDataReader["NominativoDestinatario"].ToString();
                s.Price = Convert.ToDouble(sqlDataReader["Costo"]);
                s.DataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.IdCliente = Convert.ToInt32(sqlDataReader["IdAzienda"]);
                spedizioni.Add(s);
            }

            conn.Close();
            return spedizioni;
        }

        public static Cliente getClienteById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Clienti where IdCliente = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Cliente c = new Cliente();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.Id = Convert.ToInt32(sqlDataReader["IdCliente"]);
                c.Name = sqlDataReader["Nome"].ToString();
                c.Surname = sqlDataReader["Cognome"].ToString();
                c.BirthDay = Convert.ToDateTime(sqlDataReader["DataNascita"]);
                c.CF = sqlDataReader["CF"].ToString();
            }

            conn.Close();
            return c;
        }

        public static Azienda getAziendaById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Azienda where IdAzienda = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Azienda a = new Azienda();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                a.Id = Convert.ToInt32(sqlDataReader["IdAzienda"]);
                a.Nominativo = sqlDataReader["Nominativo"].ToString();
                a.RagioneSociale = sqlDataReader["RagioneSociale"].ToString();
                a.PartitaIVA = sqlDataReader["PartitaIva"].ToString();
            }

            conn.Close();
            return a;
        }

        public static Spedizione getSpedizioneFromClientiById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from SpedizioneClienti where IdSpedizione=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Spedizione s = new Spedizione();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                s.Id = Convert.ToInt32(sqlDataReader["IdSpedizione"]);
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.Weight = Convert.ToDouble(sqlDataReader["Peso"]);
                s.Destination = sqlDataReader["CittaDestinataria"].ToString();
                s.Address = sqlDataReader["Indirizzo"].ToString();
                s.Destinatario = sqlDataReader["NominativoDestinatario"].ToString();
                s.Price = Convert.ToDouble(sqlDataReader["Costo"]);
                s.DataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
            }

            conn.Close();
            return s;
        }
        public static Spedizione getSpedizioneFromAziendaById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from SpedizioneAzienda where IdSpedizione=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Spedizione s = new Spedizione();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                s.Id = Convert.ToInt32(sqlDataReader["IdSpedizione"]);
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.Weight = Convert.ToDouble(sqlDataReader["Peso"]);
                s.Destination = sqlDataReader["CittaDestinataria"].ToString();
                s.Address = sqlDataReader["Indirizzo"].ToString();
                s.Destinatario = sqlDataReader["NominativoDestinatario"].ToString();
                s.Price = Convert.ToDouble(sqlDataReader["Costo"]);
                s.DataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.IdCliente = Convert.ToInt32(sqlDataReader["IdAzienda"]);
            }

            conn.Close();
            return s;
        }

        public static List<AggiornamentoSpedizione> getAllUpdateSFromClienteById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from AggiornamentoSClienti where IdSClienti=@id ORDER BY DataAggiornamento DESC", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<AggiornamentoSpedizione> update = new List<AggiornamentoSpedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                AggiornamentoSpedizione a = new AggiornamentoSpedizione();
                a.Id = Convert.ToInt32(sqlDataReader["IdAggiornamento"]);
                a.State = sqlDataReader["Stato"].ToString();
                a.City = sqlDataReader["Luogo"].ToString();
                a.Description = sqlDataReader["Descrizione"].ToString();
                a.Update = Convert.ToDateTime(sqlDataReader["DataAggiornamento"]);
                a.IdSpedizione = Convert.ToInt32(sqlDataReader["IdSClienti"]);
                update.Add(a);
            }

            conn.Close();
            return update;
        }
        public static List<AggiornamentoSpedizione> getAllUpdateSFromAziendaById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from AggiornamentoSAzienda where IdSAzienda=@id ORDER BY DataAggiornamento DESC", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<AggiornamentoSpedizione> update = new List<AggiornamentoSpedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                AggiornamentoSpedizione a = new AggiornamentoSpedizione();
                a.Id = Convert.ToInt32(sqlDataReader["IdAggiornamento"]);
                a.State = sqlDataReader["Stato"].ToString();
                a.City = sqlDataReader["Luogo"].ToString();
                a.Description = sqlDataReader["Descrizione"].ToString();
                a.Update = Convert.ToDateTime(sqlDataReader["DataAggiornamento"]);
                a.IdSpedizione = Convert.ToInt32(sqlDataReader["IdSAzienda"]);
                update.Add(a);
            }

            conn.Close();
            return update;
        }
        public static List<Spedizione> getAllSpedizioniFromClientiByDataConsegna(DateTime dataC)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from SpedizioneClienti where DataConsegna=@dataC", conn);
            cmd.Parameters.AddWithValue("dataC", dataC.ToShortDateString());
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Spedizione> spedizioni = new List<Spedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Spedizione s = new Spedizione();
                s.Id = Convert.ToInt32(sqlDataReader["IdSpedizione"]);
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.Weight = Convert.ToDouble(sqlDataReader["Peso"]);
                s.Destination = sqlDataReader["CittaDestinataria"].ToString();
                s.Address = sqlDataReader["Indirizzo"].ToString();
                s.Destinatario = sqlDataReader["NominativoDestinatario"].ToString();
                s.Price = Convert.ToDouble(sqlDataReader["Costo"]);
                s.DataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                spedizioni.Add(s);
            }

            conn.Close();
            return spedizioni;
        }

        public static List<Spedizione> getAllSpedizioniFromAziendaByDataConsegna(DateTime dataC)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from SpedizioneAzienda where DataConsegna=@dataC", conn);
            cmd.Parameters.AddWithValue("dataC", dataC.ToShortDateString());
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Spedizione> spedizioni = new List<Spedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Spedizione s = new Spedizione();
                s.Id = Convert.ToInt32(sqlDataReader["IdSpedizione"]);
                s.DataSpedizione = Convert.ToDateTime(sqlDataReader["DataSpedizione"]);
                s.Weight = Convert.ToDouble(sqlDataReader["Peso"]);
                s.Destination = sqlDataReader["CittaDestinataria"].ToString();
                s.Address = sqlDataReader["Indirizzo"].ToString();
                s.Destinatario = sqlDataReader["NominativoDestinatario"].ToString();
                s.Price = Convert.ToDouble(sqlDataReader["Costo"]);
                s.DataConsegna = Convert.ToDateTime(sqlDataReader["DataConsegna"]);
                s.IdCliente = Convert.ToInt32(sqlDataReader["IdAzienda"]);
                spedizioni.Add(s);
            }

            conn.Close();
            return spedizioni;
        }

        public static TotSpedizioniNonConsegnate getTotSpedizioniNonConsegnate()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS TotaleSpedizioniNonConsegnate FROM " +
                "(SELECT IdSClienti AS IdSpedizione FROM AggiornamentoSClienti WHERE Stato <> 'Consegnato' " +
                "UNION ALL SELECT IdSAzienda AS IdSpedizione FROM AggiornamentoSAzienda WHERE Stato <> 'Consegnato') AS CombinedAggiornamenti " +
                "WHERE IdSpedizione NOT IN (SELECT IdSClienti AS IdSpedizione FROM AggiornamentoSClienti WHERE Stato = 'Consegnato'" +
                " UNION SELECT IdSAzienda AS IdSpedizione FROM AggiornamentoSAzienda WHERE Stato = 'Consegnato')", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            TotSpedizioniNonConsegnate t = new TotSpedizioniNonConsegnate();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                t.TotSpedizioni = Convert.ToInt32(sqlDataReader["TotaleSpedizioniNonConsegnate"]);
            }

            conn.Close();
            return t;
        }

        public static List<TotXCitta> getAllSpedizioniGroupByCity()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT Citta, COUNT(*) AS TotaleSpedizioni FROM (SELECT CittaDestinataria AS Citta FROM SpedizioneClienti UNION ALL SELECT CittaDestinataria AS Citta FROM SpedizioneAzienda) AS CombinedSpedizioni GROUP BY Citta", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<TotXCitta> tot = new List<TotXCitta>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                TotXCitta t = new TotXCitta();
                t.Citta = sqlDataReader["Citta"].ToString();
                t.TotSpedizioni = Convert.ToInt32(sqlDataReader["TotaleSpedizioni"]);
                tot.Add(t);
            }

            conn.Close();
            return tot;
        }

    }
}