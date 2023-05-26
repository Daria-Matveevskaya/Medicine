using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyHospital
{
    public partial class CreatePerson : Form
    {
        SqlConnection sqlConnection = null;

        public CreatePerson()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Patients] (Name, Surname, Middle_Name, Date_of_birth, Gender, Address, Phone) VALUES (@Name, @Surname, @Middle_Name, @Date_of_birth, @Gender, @Address, @Phone)",
                sqlConnection);

            DateTime date = DateTime.Parse(textBox4.Text);

            command.Parameters.AddWithValue("Surname",textBox1.Text);
            command.Parameters.AddWithValue("Name", textBox2.Text);
            command.Parameters.AddWithValue("Middle_Name", textBox3.Text);
            command.Parameters.AddWithValue("Date_of_birth", $"{date.Month}/{date.Day}/{date.Year}");
            command.Parameters.AddWithValue("Gender", comboBox1.Text);
            command.Parameters.AddWithValue("Address", textBox6.Text);
            command.Parameters.AddWithValue("Phone", textBox5.Text);

            MessageBox.Show(command.ExecuteNonQuery().ToString());
        }

        private void CreatePerson_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyHospital"].ConnectionString);

            sqlConnection.Open();
        }
    }
}
