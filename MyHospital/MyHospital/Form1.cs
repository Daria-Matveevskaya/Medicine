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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;
using System.Collections.ObjectModel;

namespace MyHospital
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = null;
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommandBuilder scb;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myHospitalDataSet2.Doctors". При необходимости она может быть перемещена или удалена.
            this.doctorsTableAdapter1.Fill(this.myHospitalDataSet2.Doctors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myHospitalDataSet1.Disease". При необходимости она может быть перемещена или удалена.
            this.diseaseTableAdapter.Fill(this.myHospitalDataSet1.Disease);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myHospitalDataSet.Doctors". При необходимости она может быть перемещена или удалена.
            this.doctorsTableAdapter.Fill(this.myHospitalDataSet.Doctors);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyHospital"].ConnectionString);

            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Соединение с БД установленно!");
            }

            SqlDataAdapter dataAdapter= new SqlDataAdapter(
                "SELECT Surname AS 'Фамилия', Name AS 'Имя', Middle_Name AS 'Отчетсво', Date_of_birth AS 'Дата_рождения'," +
                "Gender AS 'Пол', Address AS 'Адрес проживания', Phone AS 'Телефон' FROM Patients",
                sqlConnection);

            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(
               "SELECT Surname AS 'Фамилия', Name AS 'Имя', Middle_Name AS 'Отчетсво', Specialization AS 'Специализация'," +
               "Cabinet AS 'Кабинет' FROM Doctors",
               sqlConnection);

            SqlDataAdapter dataAdapter3 = new SqlDataAdapter(
               "SELECT Surname_doc AS 'Фамилия', Name_doc AS 'Имя', Middle_Name_doc AS 'Отчетсво', Specialization AS 'Специализация', " +
               "Surname_pat AS 'Фамилия_', Name_pat AS 'Имя_', Middle_Name_pat AS 'Отчество_' FROM Visits",
               sqlConnection);

            SqlDataAdapter dataAdapter4 = new SqlDataAdapter(
               "SELECT Disease AS 'Диагноз', Start_date AS 'Начало', End_date AS 'Конец', " +
               "Surname_pat AS 'Фамилия', Name_pat AS 'Имя', Middle_Name_pat AS 'Отчество' FROM Disease",
               sqlConnection);

            DataSet dataSet = new DataSet();
            DataSet dataSet2 = new DataSet();
            DataSet dataSet3 = new DataSet();
            DataSet dataSet4 = new DataSet();

            dataAdapter.Fill(dataSet);
            dataAdapter2.Fill(dataSet2);
            dataAdapter3.Fill(dataSet3);
            dataAdapter4.Fill(dataSet4);

            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView2.DataSource = dataSet2.Tables[0];
            dataGridView3.DataSource = dataSet3.Tables[0];
            dataGridView4.DataSource = dataSet4.Tables[0];

            panel7.Visible = false;
            panel5.Visible = false;
            panel9.Visible = false;
            panel11.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreatePerson f = new CreatePerson();
            f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия LIKE '%{textBox1.Text}%'";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Имя LIKE '%{textBox2.Text}%'";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Отчество LIKE '%{textBox3.Text}%'";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Пол LIKE '%{comboBox1.Text}%'";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDoctors z = new CreateDoctors();
            z.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            panel5.Visible = true;
            panel5.Dock = DockStyle.Fill;

            panel7.Visible = false;
            panel9.Visible = false;
            panel11.Visible = false;

        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            panel7.Visible = true;
            panel7.Dock = DockStyle.Fill;

            panel5.Visible = false;
            panel9.Visible = false;
            panel11.Visible = false;
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            panel9.Visible = true;
            panel9.Dock = DockStyle.Fill;

            panel5.Visible = false;
            panel7.Visible = false;
            panel11.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateVisits v = new CreateVisits();
            v.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            sda = new SqlDataAdapter("SELECT Surname_doc AS 'Фамилия', Name_doc AS 'Имя', Middle_Name_doc AS 'Отчетсво', Specialization AS 'Специализация', " +
               "Surname_pat AS 'Фамилия_', Name_pat AS 'Имя_', Middle_Name_pat AS 'Отчество_' FROM Visits",
               sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия LIKE '%{textBox9.Text}%'";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Имя LIKE '%{textBox8.Text}%'";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Отчество LIKE '%{textBox7.Text}%'";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Специализация LIKE '%{comboBox3.Text}%'";
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия_ LIKE '%{textBox15.Text}%'";
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Имя_ LIKE '%{textBox14.Text}%'";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = $"Отчество_ LIKE '%{textBox13.Text}%'";
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_MouseClick(object sender, MouseEventArgs e)
        {
            panel11.Visible = true;
            panel11.Dock = DockStyle.Fill;

            panel5.Visible = false;
            panel9.Visible = false;
            panel7.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateDisease y = new CreateDisease();
            y.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            sda = new SqlDataAdapter("SELECT Disease AS 'Диагноз', Start_date AS 'Начало', End_date AS 'Конец', " +
                "Surname_pat AS 'Фамилия', Name_pat AS 'Имя', Middle_Name_pat AS 'Отчество' FROM Disease", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView4.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            sda = new SqlDataAdapter("SELECT Surname AS 'Фамилия', Name AS 'Имя', Middle_Name AS 'Отчетсво', Date_of_birth AS 'Дата_рождения'," +
                "Gender AS 'Пол', Address AS 'Адрес проживания', Phone AS 'Телефон' FROM Patients",sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            sda = new SqlDataAdapter("SELECT Surname AS 'Фамилия', Name AS 'Имя', Middle_Name AS 'Отчетсво', " +
                "Specialization AS 'Специализация',Cabinet AS 'Кабинет' FROM Doctors", sqlConnection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия LIKE '%{textBox12.Text}%'";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"Имя LIKE '%{textBox11.Text}%'";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"Отчетсво LIKE '%{textBox10.Text}%'";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = $"Диагноз LIKE '%{comboBox4.Text}%'";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel5.Dock = DockStyle.Fill;

            panel7.Visible = false;
            panel9.Visible = false;
            panel11.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel7.Dock = DockStyle.Fill;

            panel5.Visible = false;
            panel9.Visible = false;
            panel11.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            panel9.Dock = DockStyle.Fill;

            panel5.Visible = false;
            panel7.Visible = false;
            panel11.Visible = false;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
            panel11.Dock = DockStyle.Fill;

            panel5.Visible = false;
            panel9.Visible = false;
            panel7.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = $"Специализация LIKE '%{comboBox2.Text}%'";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия LIKE '%{textBox6.Text}%'";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = $"Имя LIKE '%{textBox5.Text}%'";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = $"Отчество LIKE '%{textBox4.Text}%'";
        }
    }
}
