using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
namespace StatRub_v1
{
    public partial class switchboard_items : MetroFramework.Forms.MetroForm
    {
        public string CmdText = "SELECT * FROM `switchboard items`";
        public string ConnString = "Server=localhost; Database=movedb; Uid=root; Pwd=root";
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;
        public switchboard_items()
        {
            InitializeComponent();
         

        }
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `switchboard items`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "switchboard items");
                dataGridView1.DataSource = dataSet.Tables["switchboard items"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А101", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            MySqlConnection = new MySqlConnection(@"Server = 127.0.0.1; Database = movedb; Uid = Admin; Pwd = 123");
            MySqlConnection.Open();
            LoadData();
        }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["switchboard items"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "switchboard items");
                dataGridView1.DataSource = dataSet.Tables["switchboard items"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А102", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удавить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["switchboard items"].Rows[rowIndex].Delete();
                            SqlDataAdapter.Update(dataSet, "switchboard items");


                        }
                    }
                    else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["switchboard items"].NewRow();
                        row["SwitchboardID"] = dataGridView1.Rows[rowIndex].Cells["SwitchboardID"].Value;
                        row["ItemNumber"] = dataGridView1.Rows[rowIndex].Cells["ItemNumber"].Value;
                        row["ItemText"] = dataGridView1.Rows[rowIndex].Cells["ItemText"].Value;
                        row["Command"] = dataGridView1.Rows[rowIndex].Cells["Command"].Value;
                        row["Argument"] = dataGridView1.Rows[rowIndex].Cells["Argument"].Value;
                     

                        dataSet.Tables["switchboard items"].Rows.Add(row);
                        dataSet.Tables["switchboard items"].Rows.RemoveAt(dataSet.Tables["switchboard items"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                        SqlDataAdapter.Update(dataSet, "switchboard items");
                        NewRowAdding = false; // Update New Rows
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataSet.Tables["switchboard items"].Rows[r]["SwitchboardID"] = dataGridView1.Rows[r].Cells["SwitchboardID"].Value;
                        dataSet.Tables["switchboard items"].Rows[r]["ItemNumber"] = dataGridView1.Rows[r].Cells["ItemNumber"].Value;
                        dataSet.Tables["switchboard items"].Rows[r]["ItemText"] = dataGridView1.Rows[r].Cells["ItemText"].Value;
                        dataSet.Tables["switchboard items"].Rows[r]["Command"] = dataGridView1.Rows[r].Cells["Command"].Value;
                        dataSet.Tables["switchboard items"].Rows[r]["Argument"] = dataGridView1.Rows[r].Cells["Argument"].Value;
                      
                        SqlDataAdapter.Update(dataSet, "switchboard items");
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = "Delete";
                    }

                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А103", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            switchboard_items.ActiveForm.Hide();
            Main_Form MyForm2 = new Main_Form();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            {
                try
                {
                    if (NewRowAdding == false)
                    {
                        NewRowAdding = true;
                        int lastRow = dataGridView1.Rows.Count - 2;
                        DataGridViewRow row = dataGridView1.Rows[lastRow];
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[5, lastRow] = linkCell;
                        row.Cells["Delete"].Value = "Insert"; // Оьработка команды
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка А104", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
