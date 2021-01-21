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
    public partial class Projects : MetroFramework.Forms.MetroForm
    {
      
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;
        public Projects()
        {
            InitializeComponent();
         
        }
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `subcontracting organizations`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "subcontracting organizations");
                dataGridView1.DataSource = dataSet.Tables["subcontracting organizations"]; //For key
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

        private void Form4_Load(object sender, EventArgs e)
        {
            MySqlConnection = new MySqlConnection(@"Server = 127.0.0.1; Database = movedb; Uid = Admin; Pwd = 123");
            MySqlConnection.Open();
            LoadData();
        }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["subcontracting organizations"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "subcontracting organizations");
                dataGridView1.DataSource = dataSet.Tables["subcontracting organizations"]; //For key
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Projects.ActiveForm.Hide();
            Main_Form MyForm2 = new Main_Form();
            MyForm2.ShowDialog();
            Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    if (e.ColumnIndex == 4)
                    {
                        string task = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                        if (task == "Delete")
                        {
                            if (MessageBox.Show("Удавить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                            {
                                int rowIndex = e.RowIndex;
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                dataSet.Tables["subcontracting organizations"].Rows[rowIndex].Delete();
                                SqlDataAdapter.Update(dataSet, "subcontracting organizations");


                            }
                        }
                        else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                        {
                            int rowIndex = dataGridView1.Rows.Count - 2;
                            DataRow row = dataSet.Tables["subcontracting organizations"].NewRow();
                            row["Contract"] = dataGridView1.Rows[rowIndex].Cells["Contract"].Value;
                            row["Name organization"] = dataGridView1.Rows[rowIndex].Cells["Name organization"].Value;
                            row["Sub org contract"] = dataGridView1.Rows[rowIndex].Cells["Sub org contract"].Value;
                            row["Cost"] = dataGridView1.Rows[rowIndex].Cells["Cost"].Value;
                            row["Time of ending"] = dataGridView1.Rows[rowIndex].Cells["Time of ending"].Value;

                            dataSet.Tables["subcontracting organizations"].Rows.Add(row);
                            dataSet.Tables["subcontracting organizations"].Rows.RemoveAt(dataSet.Tables["subcontracting organizations"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                            SqlDataAdapter.Update(dataSet, "subcontracting organizations");
                            NewRowAdding = false; // Update New Rows
                        }
                        else if (task == "Update")
                        {
                            int r = e.RowIndex;
                            dataSet.Tables["subcontracting organizations"].Rows[r]["Contract"] = dataGridView1.Rows[r].Cells["Contract"].Value;
                            dataSet.Tables["subcontracting organizations"].Rows[r]["Name organization"] = dataGridView1.Rows[r].Cells["Name organization"].Value;
                            dataSet.Tables["subcontracting organizations"].Rows[r]["Sub org contract"] = dataGridView1.Rows[r].Cells["Sub org contract"].Value;
                            dataSet.Tables["subcontracting organizations"].Rows[r]["Cost"] = dataGridView1.Rows[r].Cells["Cost"].Value;
                            dataSet.Tables["subcontracting organizations"].Rows[r]["Time of ending"] = dataGridView1.Rows[r].Cells["Time of ending"].Value;

                            SqlDataAdapter.Update(dataSet, "subcontracting organizations");
                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
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
        private void metroButton3_Click(object sender, EventArgs e)
        {
            ReloadData();
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

                    dataGridView1[5, ri] = linkCell;
                    eRows.Cells["Delete"].Value = "Update"; // Оьработка команды
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А105", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
