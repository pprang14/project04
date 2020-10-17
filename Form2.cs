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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 n2 = new Form3();
            n2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=;database=elearningdb";

                string query = "INSERT INTO teacher (tea_fname,tea_lname,tea_number,te_email) VALUES " +
                    "('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text+"')";

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string MyConnection3 = "datasource=localhost;port=3306;username=root;password=;database=elearningdb";
                string Query = "select * from teacher;";
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
