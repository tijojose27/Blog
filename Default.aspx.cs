using System;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public string word = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string connString = @"Data Source=TIJO_DESKTOP;Initial Catalog=Sample;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string query = "SELECT Comments, Time FROM dbo.Comments";
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand comm = new SqlCommand(query, conn);
        using (conn)
        {
            try
            {
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string starword = "" + reader[0].ToString() + " <p id = 'timestamp'>" + reader[1].ToString() + "</p>";
                    word += MyComments(starword);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message.ToString();
            }
        }
    }


    public string words { get { return word; } }




    protected void Button1_Click(object sender, EventArgs e)
    {
        string connString = @"Data Source=TIJO_DESKTOP;Initial Catalog=Sample;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string query = "SELECT Comments FROM dbo.Comments";
        string comvalue = TextBox1.Text;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand comm = new SqlCommand(query, conn);
        using (conn)
        {
            try
            {
                conn.Open();
                comm.CommandText = ("INSERT INTO Comments(Comments) VALUES (@Comment)");
                comm.Parameters.AddWithValue("@Comment", comvalue);
                comm.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Label1.Text = "";
                Label1.Text = ex.ToString();
            }
        }
        Response.Redirect(Request.RawUrl);
    }


    public string MyComments(string ans)
    {
        string full = "<li> " + ans + "</li>";
        return full;
    }
}