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
    public partial class CreateDoctors : Form
    {
        SqlConnection sqlConnection = null;

        public CreateDoctors()
        {
            InitializeComponent();
        }

        private void CreateDoctors_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyHospital"].ConnectionString);

            sqlConnection.Open();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Doctors] (Name, Surname, Middle_Name, Specialization, Cabinet) VALUES (@Name, @Surname, @Middle_Name, @Specialization, @Cabinet)",
                sqlConnection);

            command.Parameters.AddWithValue("Surname", textBox1.Text);
            command.Parameters.AddWithValue("Name", textBox2.Text);
            command.Parameters.AddWithValue("Middle_Name", textBox3.Text);
            command.Parameters.AddWithValue("Specialization", textBox6.Text);
            command.Parameters.AddWithValue("Cabinet", textBox5.Text);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }
    }
}
