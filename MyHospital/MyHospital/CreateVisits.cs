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
    public partial class CreateVisits : Form
    {

        SqlConnection sqlConnection = null;

        public CreateVisits()
        {
            InitializeComponent();
        }

        private void CreateVisits_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyHospital"].ConnectionString);

            sqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Visits] (Surname_doc, Name_doc, Middle_Name_doc, Specialization, Surname_pat, Name_pat, Middle_name_pat) VALUES (@Surname_doc, @Name_doc, @Middle_Name_doc, @Specialization, @Surname_pat, @Name_pat, @Middle_name_pat)",
                sqlConnection);

            command.Parameters.AddWithValue("Surname_doc", textBox1.Text);
            command.Parameters.AddWithValue("Name_doc", textBox2.Text);
            command.Parameters.AddWithValue("Middle_Name_doc", textBox3.Text);
            command.Parameters.AddWithValue("Specialization", textBox6.Text);
            command.Parameters.AddWithValue("Surname_pat", textBox4.Text);
            command.Parameters.AddWithValue("Name_pat", textBox5.Text);
            command.Parameters.AddWithValue("Middle_Name_pat", textBox8.Text);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }
    }
}
