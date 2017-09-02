
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace smartcity.Library
{

  /// <summary>
    /// Database operation 
    /// </summary>
    public static class DatabaseOperation
    {
        private static string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\jay\Documents\smartCity.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlConnection Sqlconnection = new SqlConnection(ConnectionString);

        public static void Connect()
        {
            if(Sqlconnection.State!=ConnectionState.Open)               
            Sqlconnection.Open();
        }
        public static void Disconnect()
        {
            if (Sqlconnection.State == ConnectionState.Open)        
            Sqlconnection.Close(); 
        }

        public static SqlDataReader SelectQuery(string Query)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader conReader;
            conReader = null;
            cmd.CommandText = Query;
            cmd.Connection = Sqlconnection;
            cmd.CommandType = CommandType.Text;
            try
            {
                conReader = cmd.ExecuteReader();                
            }
            catch (Exception ex)
            {
               // Cabservce.ShowMessage("Error", ex.ToString(), MessageDialogStyle.Affirmative);              
            }

            return conReader;
        }

        public static void InsertUpdateDelete(string Query)
        {            
            SqlCommand cmd = new SqlCommand();            
            cmd.CommandText = Query;
            cmd.Connection = Sqlconnection;
            cmd.CommandType = CommandType.Text;
            try
            {
                 cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // Cabservce.ShowMessage("Error", ex.ToString(), MessageDialogStyle.Affirmative);

            }
        }

        public static DataSet SelectQueryDataSet(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query, Sqlconnection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
               // Cabservce.ShowMessage("Error", ex.ToString(), MessageDialogStyle.Affirmative);
            }

            return dataSet;
        }

    }
}