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
    public partial class staff : MetroFramework.Forms.MetroForm
    {
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;

        public staff()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `staff`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "staff");
                dataGridView1.DataSource = dataSet.Tables["staff"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[4, i] = linkCell;
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
                dataSet.Tables["staff"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "staff");
                dataGridView1.DataSource = dataSet.Tables["staff"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[4, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А102", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form12_Load(object sender, EventArgs e)
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
                    if (e.ColumnIndex == 4)
                    {
                        string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                        if (task == "Delete")
                        {
                            if (MessageBox.Show("Удавить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                            {
                                int rowIndex = e.RowIndex;
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                dataSet.Tables["staff"].Rows[rowIndex].Delete();
                                SqlDataAdapter.Update(dataSet, "staff");


                            }
                        }
                        else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                        {
                            int rowIndex = dataGridView1.Rows.Count - 2;
                            DataRow row = dataSet.Tables["staff"].NewRow();
                            row["ID_NAME"] = dataGridView1.Rows[rowIndex].Cells["ID_NAME"].Value;
                            row["Passport data"] = dataGridView1.Rows[rowIndex].Cells["Passport data"].Value;
                            row["Employee Phone Numbers"] = dataGridView1.Rows[rowIndex].Cells["Employee Phone Numbers"].Value;
                            row["Staff"] = dataGridView1.Rows[rowIndex].Cells["Staff"].Value;

                            dataSet.Tables["staff"].Rows.Add(row);
                            dataSet.Tables["staff"].Rows.RemoveAt(dataSet.Tables["staff"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[4].Value = "Delete";
                            SqlDataAdapter.Update(dataSet, "staff");
                            NewRowAdding = false; // Update New Rows
                        }
                        else if (task == "Update")
                        {
                            int r = e.RowIndex;
                            dataSet.Tables["staff"].Rows[r]["ID_NAME"] = dataGridView1.Rows[r].Cells["ID_NAME"].Value;
                            dataSet.Tables["staff"].Rows[r]["Passport data"] = dataGridView1.Rows[r].Cells["Passport data"].Value;
                            dataSet.Tables["staff"].Rows[r]["Employee Phone Numbers"] = dataGridView1.Rows[r].Cells["Employee Phone Numbers"].Value;
                            dataSet.Tables["staff"].Rows[r]["Staff"] = dataGridView1.Rows[r].Cells["Staff"].Value;

                            SqlDataAdapter.Update(dataSet, "staff");
                            dataGridView1.Rows[e.RowIndex].Cells[4].Value = "Delete";
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
                            dataGridView1[4, lastRow] = linkCell;
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
            staff.ActiveForm.Hide();
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

                    dataGridView1[4, ri] = linkCell;
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
