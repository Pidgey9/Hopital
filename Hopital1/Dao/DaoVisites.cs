using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Gestions;

namespace Dao
{

    public class DaoVisites
    {
        public bool Insert(Visites v)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "insert into Visites values(@idPatient,@date,@medecin,@numSalle,@tarif)";


            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("idPatient", SqlDbType.Int).Value = v.IdPatient;
            command.Parameters.Add("date", SqlDbType.DateTime).Value = v.Date;
            command.Parameters.Add("medecin", SqlDbType.NVarChar).Value = v.Medecin;
            command.Parameters.Add("numSalle", SqlDbType.Int).Value = v.NumSalle;
            command.Parameters.Add("tarif", SqlDbType.Int).Value = v.Tarif;

            connection1.Open();
            command.ExecuteNonQuery();
            connection1.Close();

            return true;
        }
        public List<Visites> SelectAll()
        {

            List<Visites> liste = new List<Visites>();


            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "select * from Visites";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Visites v = new Visites(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
                liste.Add(v);

            }


            connection1.Close();
            return liste;
        }


        public Visites SelectById(int id)
        {
            Visites v = null;
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "select * from Visites where id=" + id;

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();



            if (reader.Read())
                v = new Visites(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));


            connection1.Close();

            return v;

        }

        public Visites SelectByIdPatient(int idPatient)
        {
            Visites v = null;
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "select * from Visites where idPatient='" + idPatient + "'";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection1);

            connection1.Open();

            SqlDataReader reader = command.ExecuteReader();




            if (reader.Read())
                v = new Visites(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));


            connection1.Close();

            return v;

        }
        public bool Update(Visites v)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            string sql = "update Visites set idPatient=@idPatient, date = @date, medecin = @medecin, tarif = @tarif where id=@id ";

            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand command = connection1.CreateCommand();
            command.CommandText = sql;

            command.Parameters.Add("id", SqlDbType.Int).Value = v.Id;
            command.Parameters.Add("idPatient", SqlDbType.Int).Value = v.IdPatient;
            command.Parameters.Add("date", SqlDbType.NVarChar).Value = v.Date;
            command.Parameters.Add("medecin", SqlDbType.NVarChar).Value = v.Medecin;
            command.Parameters.Add("numSalle", SqlDbType.Int).Value = v.NumSalle;
            command.Parameters.Add("tarif", SqlDbType.Int).Value = v.Tarif;

            connection1.Open();
            int nb = command.ExecuteNonQuery();
            connection1.Close();
            if (nb > 0)
                return true;

            return false;

        }
        public bool Delete(int id)
        {
            string connectionString = @"Data Source=DESKTOP-F1NS20D;Initial Catalog=HOPITAL;Integrated Security=True";
            SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();
            //traitement
            string sql = "delete Visites where id = " + id;
            SqlCommand command = new SqlCommand(sql, connection1);
            int nb = command.ExecuteNonQuery();
            connection1.Close();

            if (nb > 0)
                return true;

            return false;

        }

    }
}
