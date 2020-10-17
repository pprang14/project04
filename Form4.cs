using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project001
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=;database=elearningdb";

                string lesson = comboBox1.SelectedItem.ToString();
                string student = comboBox2.SelectedItem.ToString();
                string teacher = comboBox3.SelectedItem.ToString();



                string query = "INSERT INTO using1 (use_lesson,use_student,use_teacher,use_date) VALUES ('" + lesson + "','" + student + "','" + teacher + "','" + this.textBox1.Text + "')";

                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);

                MySqlDataReader MyReader2;

                MyConn2.Open();

                MyReader2 = MyCommand2.ExecuteReader();

                MessageBox.Show("Save Data");

                while (MyReader2.Read())
                {



                }

                MyConn2.Close();

            }

            catch (Exception ex)
            {



                MessageBox.Show(ex.Message);

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection MyConn2 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=elearningdb");
                string ses = "SELECT * FROM elearningdb.lesson";

                MyConn2.Open();

                MySqlCommand MyCommand2 = new MySqlCommand(ses, MyConn2);

                MySqlDataReader MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {
                    comboBox1.Items.Add(MyReader2.GetString("les_name"));

                }
                MySqlConnection MyConn3 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=elearningdb");
                string std = "SELECT * FROM elearningdb.student";

                MyConn3.Open();

                MySqlCommand MyCommand3 = new MySqlCommand(std, MyConn3);

                MySqlDataReader MyReader3 = MyCommand3.ExecuteReader();

                while (MyReader3.Read())
                {
                    comboBox2.Items.Add(MyReader3.GetString("stu_fname"));

                }
                MySqlConnection MyConn4 = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=elearningdb");
                string th = "SELECT * FROM elearningdb.teacher";

                MyConn4.Open();

                MySqlCommand MyCommand4 = new MySqlCommand(th, MyConn4);

                MySqlDataReader MyReader4 = MyCommand4.ExecuteReader();

                while (MyReader4.Read())
                {
                    comboBox3.Items.Add(MyReader4.GetString("tea_fname"));

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string MyConnection3 = "datasource=localhost;port=3306;username=root;password=;database=elearningdb";
                string Query = "select * from using1;";
                MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
                MySqlCommand MyCommand3 = new MySqlCommand(Query, MyConn3);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand3;

                DataTable dTable = new DataTable();

                MyAdapter.Fill(dTable);

                dataGridView1.DataSource = dTable;



                // MyConn3.Close(); 

            }

            catch (Exception ex)
            {



                MessageBox.Show(ex.Message);

            }
        }
    }
}
