using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Textnode
    {
        public int ID { get; set; }

        public string text;

        public string nodeName;

        public Textnode(int iD, string text, string nodeName)
        {
            
            this.ID = iD;
            this.text = text;
            this.nodeName = nodeName;

        }








        public override string ToString()
        {
            return "Id="+ID+" text='"+text+"'"+" nodename='"+this.nodeName+"'";
        }

        public static void InsertIntoDB(Textnode tn,string connectionString)
        {
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection established");
                    string query = string.Format("insert into deez(text,nodename) values('{0}','{1}')", tn.text, tn.nodeName);
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();

                    }
                }
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Textnode? LoadNodeFromDB(int id,string connectionString)
        {
            Textnode tn = null;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection established");
                    string query = string.Format("select * from deez where deez.id = {0}", id);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            if (reader[0].ToString() == null || reader[1].ToString() == null) { return null; } 
                            tn = new Textnode(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString());
                            
                        }
                    }
                }

                return tn;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tn;
        }


        public static List<Textnode>? LoadAllNodes(string connectionString)
        {
            List<Textnode> list = new List<Textnode>();

            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection established");    
                    string query = string.Format("select * from deez");

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            if (reader[0].ToString() == null || reader[1].ToString() == null) { return list; }
                            Textnode tn = new(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString());

                            list.Add(tn);

                        }
                    }
                }

                return list;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }



    }
}
