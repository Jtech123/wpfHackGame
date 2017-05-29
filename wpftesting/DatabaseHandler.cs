using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpftesting
{
    class DatabaseHandler
    {
        private MsgHandler msgHandler;
        public string GetConfig()
        {
            WebClient client = new WebClient();
            string htmlCode = client.DownloadString("http://jtechgame.alwaysdata.net/download/item1/upload/upload/hidden/configuration.php?code=secure");
            string conn = htmlCode.Substring(105, 111);
            return conn;
        }

        

        public DatabaseHandler()
        {
            msgHandler = new MsgHandler();
        }

        //private string databaseName = string.Empty;
        /*public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }*/

        public string Password { get; set; }
        private MySqlConnection connection = null;
        
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DatabaseHandler _instance = null;
        public static DatabaseHandler Instance()
        {
            if (_instance == null)
                _instance = new DatabaseHandler();
            return _instance;
        }

        public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                //if (String.IsNullOrEmpty(databaseName))
                    //result = false;
                string connstring = string.Format("Server=mysql-jtechgame.alwaysdata.net; database=jtechgame_hack; UID=jtechgame_backup; password=Th1s1s@b@ckup");
                connection = new MySqlConnection(connstring);
                if(Connection == null || connection.State == ConnectionState.Closed)
                    connection.Open();
                result = true;
            }

            return result;
        }

        public void ResetConn()
        {
            try
            {
                if (Connection != null)
                {
                string connstring = string.Format("Server=mysql-jtechgame.alwaysdata.net; database=jtechgame_hack; UID=jtechgame_backup; password=Th1s1s@b@ckup");
                    connection = new MySqlConnection(connstring);
                    if (Connection == null || connection.State == ConnectionState.Closed)
                        connection.Open();
                }
            }
            catch (Exception ex)
            {
                this.msgHandler.CreateMessage("Connection Error", ex.ToString());

                if (msgHandler.IsAgreed())
                {
                    ResetConn();
                }
                
            }
        }

        public void Close()
        {
            if(connection.State == ConnectionState.Open)
                connection.Close();
        }
        public DataTable Select(string query, string name)
        {
            if (this.IsConnect())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter returnVal = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable(name);
                returnVal.Fill(dt);
                return dt;
            }
            else
            {
                this.Close();
                DataTable dt = new DataTable(name);
                return dt;
            }
        }

        public MySqlDataReader Select2(string query)
        {
            if(this.IsConnect())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader returnVal = cmd.ExecuteReader();
                return returnVal;
            }
            else
            {
                return null;
            }
        }
    }
}
