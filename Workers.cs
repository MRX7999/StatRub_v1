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
    public partial class Workers : MetroFramework.Forms.MetroForm
    {
        public string CmdText = "SELECT * FROM `staff` ";
        public string ConnString = "Server=localhost; Database=movedb; Uid=root; Pwd=root";
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;
        public Workers()
        {
            InitializeComponent();
          

        }
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `project status`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "project status");
                dataGridView1.DataSource = dataSet.Tables["project status"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[10, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А101", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["project status"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "project status");
                dataGridView1.DataSource = dataSet.Tables["project status"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[10, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А102", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            MySqlConnection = new MySqlConnection(@"Server = 127.0.0.1; Database = movedb; Uid = Admin; Pwd = 123");
            MySqlConnection.Open();
            LoadData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    if (e.ColumnIndex == 10)
                    {
                        string task = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

                        if (task == "Delete")
                        {
                            if (MessageBox.Show("Удавить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                            {
                                int rowIndex = e.RowIndex;
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                dataSet.Tables["project status"].Rows[rowIndex].Delete();
                                SqlDataAdapter.Update(dataSet, "project status");


                            }
                        }
                        else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                        {
                            int rowIndex = dataGridView1.Rows.Count - 2;
                            DataRow row = dataSet.Tables["project status"].NewRow();
                            row["Project_ID execution"] = dataGridView1.Rows[rowIndex].Cells["Project_ID execution"].Value;
                            row["Projects Analysis"] = dataGridView1.Rows[rowIndex].Cells["Projects Analysis"].Value;
                            row["Name"] = dataGridView1.Rows[rowIndex].Cells["Name"].Value;
                            row["Description"] = dataGridView1.Rows[rowIndex].Cells["Description"].Value;
                            row["Project Name"] = dataGridView1.Rows[rowIndex].Cells["Project Name"].Value;
                            row["Name of service"] = dataGridView1.Rows[rowIndex].Cells["Name of service"].Value;
                            row["Service Amount"] = dataGridView1.Rows[rowIndex].Cells["Service Amount"].Value;
                            row["Employees slave to the project"] = dataGridView1.Rows[rowIndex].Cells["Employees slave to the project"].Value;
                            row["Department List ID"] = dataGridView1.Rows[rowIndex].Cells["Department List ID"].Value;
                            row["Project_ID"] = dataGridView1.Rows[rowIndex].Cells["Project_ID"].Value;

                            dataSet.Tables["project status"].Rows.Add(row);
                            dataSet.Tables["project status"].Rows.RemoveAt(dataSet.Tables["project status"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[10].Value = "Delete";
                            SqlDataAdapter.Update(dataSet, "project status");
                            NewRowAdding = false; // Update New Rows
                        }
                        else if (task == "Update")
                        {
                            int r = e.RowIndex;
                            dataSet.Tables["project status"].Rows[r]["Project_ID execution"] = dataGridView1.Rows[r].Cells["Project_ID execution"].Value;
                            dataSet.Tables["project status"].Rows[r]["Projects Analysis"] = dataGridView1.Rows[r].Cells["Projects Analysis"].Value;
                            dataSet.Tables["project status"].Rows[r]["Name"] = dataGridView1.Rows[r].Cells["Name"].Value;
                            dataSet.Tables["project status"].Rows[r]["Description"] = dataGridView1.Rows[r].Cells["Description"].Value;
                            dataSet.Tables["project status"].Rows[r]["Project Name"] = dataGridView1.Rows[r].Cells["Project Name"].Value;
                            dataSet.Tables["project status"].Rows[r]["Name of service"] = dataGridView1.Rows[r].Cells["Name of service"].Value;
                            dataSet.Tables["project status"].Rows[r]["Service Amount"] = dataGridView1.Rows[r].Cells["Service Amount"].Value;
                            dataSet.Tables["project status"].Rows[r]["Employees slave to the project"] = dataGridView1.Rows[r].Cells["Employees slave to the project"].Value;
                            dataSet.Tables["project status"].Rows[r]["Department List ID"] = dataGridView1.Rows[r].Cells["Department List ID"].Value;
                            dataSet.Tables["project status"].Rows[r]["Project_ID"] = dataGridView1.Rows[r].Cells["Project_ID"].Value;

                            SqlDataAdapter.Update(dataSet, "project status");
                            dataGridView1.Rows[e.RowIndex].Cells[10].Value = "Delete";
                        }

                        ReloadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка А103", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
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
                            dataGridView1[10, lastRow] = linkCell;
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
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Workers.ActiveForm.Hide();
            Main_Form MyForm2 = new Main_Form();
            MyForm2.ShowDialog();
            Close();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // update
            try
            {
                if (NewRowAdding == false)
                {

                    int ri = dataGridView1.SelectedCells[0].RowIndex; // index Seletced


                    DataGridViewRow eRows = dataGridView1.Rows[ri]; //*********************************************************************************************************


                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[10, ri] = linkCell;
                    eRows.Cells["Delete"].Value = "Update"; // Оьработка команды
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А105", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}
