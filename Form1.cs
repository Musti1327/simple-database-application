using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace simple_database_application
{
    public partial class Form1 : Form
    {
        private DataSet dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=10.0.1.124;Initial Catalog=info;User ID=sa;Password=Passw0rd;TrustServerCertificate=True;");

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO [UserData] (Name, PhoneNum, Email) VALUES (@Name, @PhoneNum, @Email)", con);
            cmd.Parameters.AddWithValue("@Name", Name1.Text);
            cmd.Parameters.AddWithValue("@PhoneNum", int.Parse(PhoneNum.Text));
            cmd.Parameters.AddWithValue("@Email", Email.Text);

            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Data Gemt!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=10.0.1.124;Initial Catalog=info;User ID=sa;Password=Passw0rd;TrustServerCertificate=True;");

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from [UserData]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
