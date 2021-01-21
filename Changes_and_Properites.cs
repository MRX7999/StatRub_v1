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
using System.Data.SqlClient;

namespace StatRub_v1
{
    public partial class Changes_and_Properites : MetroFramework.Forms.MetroForm
    {
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;
        public Changes_and_Properites()
        {
            InitializeComponent();


        }
        //Блок обработки исключений, не звбыть!!!!!!!!!!!
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `project implementation`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "project implementation");
                dataGridView1.DataSource = dataSet.Tables["project implementation"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А101", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //   private void LLoadData(MySqlConnection SqlConnection)
        //   {
        //   try
        //  {

        //    SqlDataAdapter = new MySqlDataAdapter(@"SELECT * FROM `project implementation`", SqlConnection);
        //   sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
        //   sqlBuilder.GetInsertCommand();
        //    sqlBuilder.GetInsertCommand();
        //     sqlBuilder.GetDeleteCommand();
        //init pull data set, remeber Andrew it;
        //     dataSet = new DataSet();
        //    SqlDataAdapter.Fill(dataSet, "Project Manager");
        //     dataGridView1.DataSource = dataSet.Tables["Project Manager"]; //For key
        //     for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //      {
        //          DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
        //          dataGridView1[6, i] = linkCell;
        //      }

        //    }
        //    catch (Exception ex)
        //   {
        //       MessageBox.Show(ex.Message, "Ошибка А101", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //   }
        //  }


        private void Form5_Load(object sender, EventArgs e)
        {
            MySqlConnection = new MySqlConnection(@"Server = 127.0.0.1; Database = movedb; Uid = Admin; Pwd = 123");
            MySqlConnection.Open();
            LoadData();


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Changes_and_Properites.ActiveForm.Hide();
            Main_Form MyForm2 = new Main_Form();
            MyForm2.ShowDialog();
            Close();
        }

        // private void ReloadData()
        //  {
        //   try
        //   {

        // reload data pull ****************
        //     dataSet.Tables["project implementation"].Clear();


        //reload data pull end ***************
        //     SqlDataAdapter.Fill(dataSet, "project implementation");
        //    dataGridView1.DataSource = dataSet.Tables["project implementation"]; //For key
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //   {
        //       DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
        //      dataGridView1[6, i] = linkCell;
        //  }
        //
        //  }
        //   catch (Exception ex)
        //   {
        //      MessageBox.Show(ex.Message, "Ошибка А101", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //  }


        //  }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["project implementation"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "project implementation");
                dataGridView1.DataSource = dataSet.Tables["project implementation"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, i] = linkCell;
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
                if (e.ColumnIndex == 9)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удавить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["project implementation"].Rows[rowIndex].Delete();
                            SqlDataAdapter.Update(dataSet, "project implementation");


                        }
                    }
                    else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["project implementation"].NewRow();
                        row["Project_ID"] = dataGridView1.Rows[rowIndex].Cells["Project_ID"].Value;
                        row["Equipment list"] = dataGridView1.Rows[rowIndex].Cells["Equipment list"].Value;
                        row["Services"] = dataGridView1.Rows[rowIndex].Cells["Services"].Value;
                        row["Data"] = dataGridView1.Rows[rowIndex].Cells["Data"].Value;
                        row["Time"] = dataGridView1.Rows[rowIndex].Cells["Time"].Value;
                        row["Cabinets"] = dataGridView1.Rows[rowIndex].Cells["Cabinets"].Value;
                        row["Customer"] = dataGridView1.Rows[rowIndex].Cells["Customer"].Value;
                        row["Project Manager"] = dataGridView1.Rows[rowIndex].Cells["Project Manager"].Value;
                        row["Customer_ID"] = dataGridView1.Rows[rowIndex].Cells["Customer_ID"].Value;

                        dataSet.Tables["project implementation"].Rows.Add(row);
                        dataSet.Tables["project implementation"].Rows.RemoveAt(dataSet.Tables["project implementation"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "Delete";
                        SqlDataAdapter.Update(dataSet, "project implementation");
                        NewRowAdding = false; // Update New Rows
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        dataSet.Tables["project implementation"].Rows[r]["Project_ID"] = dataGridView1.Rows[r].Cells["Project_ID"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Equipment list"] = dataGridView1.Rows[r].Cells["Equipment list"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Services"] = dataGridView1.Rows[r].Cells["Services"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Data"] = dataGridView1.Rows[r].Cells["Data"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Time"] = dataGridView1.Rows[r].Cells["Time"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Cabinets"] = dataGridView1.Rows[r].Cells["Cabinets"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Customer"] = dataGridView1.Rows[r].Cells["Customer"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Project Manager"] = dataGridView1.Rows[r].Cells["Project Manager"].Value;
                        dataSet.Tables["project implementation"].Rows[r]["Customer_ID"] = dataGridView1.Rows[r].Cells["Customer_ID"].Value;
                        SqlDataAdapter.Update(dataSet, "project implementation");
                        dataGridView1.Rows[e.RowIndex].Cells[9].Value = "Delete";
                    }

                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А103", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        { // INSERT ***********************************************************



        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        { //DELETE  *******************************************************




        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e) /// USER ADD ROWS *********************************************
        {
            try
            {
                if (NewRowAdding == false)
                {
                    NewRowAdding = true;
                    int lastRow = dataGridView1.Rows.Count - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[9, lastRow] = linkCell;
                    row.Cells["Delete"].Value = "Insert"; // Оьработка команды
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А104", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    dataGridView1[9, ri] = linkCell;
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
