using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyHospital
{
    public partial class CreateDisease : Form
    {
        SqlConnection sqlConnection = null;

        public CreateDisease()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateDisease_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyHospital"].ConnectionString);

            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
               $"INSERT INTO [Disease] (Disease, Start_date, End_date, Surname_pat, Name_pat, Middle_Name_pat) VALUES (@Disease, @Start_date, @End_date, @Surname_pat, @Name_pat, @Middle_Name_pat)",
               sqlConnection);

            DateTime date = DateTime.Parse(textBox6.Text);
            DateTime date2 = DateTime.Parse(textBox5.Text);

            command.Parameters.AddWithValue("Disease", textBox4.Text);
            command.Parameters.AddWithValue("Start_date", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("End_date", $"{date2.Month}/{date2.Day}/{date2.Year}");
            command.Parameters.AddWithValue("Surname_pat", textBox1.Text);
            command.Parameters.AddWithValue("Name_pat", textBox2.Text);
            command.Parameters.AddWithValue("Middle_Name_pat", textBox3.Text);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }
    }
}
