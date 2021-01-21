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
    public partial class Sub_in_a_row : MetroFramework.Forms.MetroForm
    {
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;
        public Sub_in_a_row()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `sub in a row`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "sub in a row");
                dataGridView1.DataSource = dataSet.Tables["sub in a row"]; //For key
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

        private void Form11_Load(object sender, EventArgs e)
        {
            MySqlConnection = new MySqlConnection(@"Server = 127.0.0.1; Database = movedb; Uid = Admin; Pwd = 123");
            MySqlConnection.Open();
            LoadData();
        }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["sub in a row"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "sub in a row");
                dataGridView1.DataSource = dataSet.Tables["sub in a row"]; //For key
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
                                dataSet.Tables["sub in a row"].Rows[rowIndex].Delete();
                                SqlDataAdapter.Update(dataSet, "sub in a row");


                            }
                        }
                        else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                        {
                            int rowIndex = dataGridView1.Rows.Count - 2;
                            DataRow row = dataSet.Tables["sub in a row"].NewRow();
                            row["Sub_ID"] = dataGridView1.Rows[rowIndex].Cells["Sub_ID"].Value;
                            row["Project_ID execution"] = dataGridView1.Rows[rowIndex].Cells["Project_ID execution"].Value;
                            row["Subcontract hire cost"] = dataGridView1.Rows[rowIndex].Cells["Subcontract hire cost"].Value;
                            row["Projects on which suborder works"] = dataGridView1.Rows[rowIndex].Cells["Projects on which suborder works"].Value;

                            dataSet.Tables["sub in a row"].Rows.Add(row);
                            dataSet.Tables["sub in a row"].Rows.RemoveAt(dataSet.Tables["sub in a row"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                            SqlDataAdapter.Update(dataSet, "sub in a row");
                            NewRowAdding = false; // Update New Rows
                        }
                        else if (task == "Update")
                        {
                            int r = e.RowIndex;
                            dataSet.Tables["sub in a row"].Rows[r]["Sub_ID"] = dataGridView1.Rows[r].Cells["Sub_ID"].Value;
                            dataSet.Tables["sub in a row"].Rows[r]["Project_ID execution"] = dataGridView1.Rows[r].Cells["Project_ID execution"].Value;
                            dataSet.Tables["sub in a row"].Rows[r]["Subcontract hire cost"] = dataGridView1.Rows[r].Cells["Subcontract hire cost"].Value;
                            dataSet.Tables["sub in a row"].Rows[r]["Projects on which suborder works"] = dataGridView1.Rows[r].Cells["Projects on which suborder works"].Value;

                            SqlDataAdapter.Update(dataSet, "ongoing projects and their implementation");
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Sub_in_a_row.ActiveForm.Hide();
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

                    dataGridView1[5, ri] = linkCell;
                    eRows.Cells["Delete"].Value = "Update"; // Оьработка команды
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А105", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
     
        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}
