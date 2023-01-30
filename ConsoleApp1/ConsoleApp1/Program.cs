using System.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = "sa";
            consStringBuilder.Password = "student";
            consStringBuilder.InitialCatalog = "test";
            consStringBuilder.DataSource = "PC975";
            consStringBuilder.ConnectTimeout = 30;
            SqlConnection connection;

            Textnode? node1 = Textnode.LoadNodeFromDB(3, consStringBuilder.ConnectionString);

            Console.WriteLine(node1);

            Textnode node2 = new Textnode(0, "Node Insertion text","NodeNameNew");
            Textnode.InsertIntoDB(node2,consStringBuilder.ConnectionString);

            List<Textnode>? nodes = Textnode.LoadAllNodes(consStringBuilder.ConnectionString);
            nodes.ForEach(node => Console.WriteLine(node));
 
        }
    }
}