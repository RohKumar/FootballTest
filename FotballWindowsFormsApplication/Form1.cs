using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotballWindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Team");
            dataTable.Columns.Add("Played");
            dataTable.Columns.Add("Win");
            dataTable.Columns.Add("Lose");
            dataTable.Columns.Add("Draw");
            dataTable.Columns.Add("For Goal");
            dataTable.Columns.Add("Against Goal");
            dataTable.Columns.Add("For-Against goal Difference");
            string filePath = @textBox1.Text;
                // @"../../AppData/football.csv";
                //@textBox1.Text;
                //@"D:/Programing Test/FootballExercise2017/FootballExercise2017/FootballExercise/football.csv";
            StreamReader streamReader = new StreamReader(filePath);
            string[] totalData = new string[File.ReadAllLines(filePath).Length];
            totalData = streamReader.ReadLine().Split(',');
            while (!streamReader.EndOfStream)
            {
                totalData = streamReader.ReadLine().Split(',');
                string diff = (int.Parse(totalData[5]) - int.Parse(totalData[6])).ToString();
                dataTable.Rows.Add(totalData[0], totalData[1], totalData[2], totalData[3], totalData[4], totalData[5], totalData[6], diff);
            }
            dataGridView1.DataSource = dataTable;
            dataGridView1.Sort(this.dataGridView1.Columns[4], ListSortDirection.Ascending);
            label1.Text = "The Smallest For-Against goal Difference is for team ->" + dataGridView1[0, 0].Value.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

