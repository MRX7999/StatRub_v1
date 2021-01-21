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
    public partial class Ongoing_Objects : MetroFramework.Forms.MetroForm
    {
       
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;
        public Ongoing_Objects()
        {
            InitializeComponent();
         

        }
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `type of equipment`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "type of equipment");
                dataGridView1.DataSource = dataSet.Tables["type of equipment"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
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
                dataSet.Tables["type of equipment"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "type of equipment");
                dataGridView1.DataSource = dataSet.Tables["type of equipment"]; //For key
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка А102", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form7_Load(object sender, EventArgs e)
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
                    if (e.ColumnIndex == 3)
                    {
                        string task = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                        if (task == "Delete")
                        {
                            if (MessageBox.Show("Удавить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                            {
                                int rowIndex = e.RowIndex;
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                dataSet.Tables["type of equipment"].Rows[rowIndex].Delete();
                                SqlDataAdapter.Update(dataSet, "type of equipment");


                            }
                        }
                        else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                        {
                            int rowIndex = dataGridView1.Rows.Count - 2;
                            DataRow row = dataSet.Tables["type of equipment"].NewRow();
                            row["ID_Type of equipment"] = dataGridView1.Rows[rowIndex].Cells["ID_Type of equipment"].Value;
                            row["List_ID"] = dataGridView1.Rows[rowIndex].Cells["List_ID"].Value;
                            row["Not working equipment"] = dataGridView1.Rows[rowIndex].Cells["Not working equipment"].Value;
                            
                            dataSet.Tables["type of equipment"].Rows.Add(row);
                            dataSet.Tables["type of equipment"].Rows.RemoveAt(dataSet.Tables["type of equipment"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[3].Value = "Delete";
                            SqlDataAdapter.Update(dataSet, "type of equipment");
                            NewRowAdding = false; // Update New Rows
                        }
                        else if (task == "Update")
                        {
                            int r = e.RowIndex;
                            dataSet.Tables["type of equipment"].Rows[r]["ID_Type of equipment"] = dataGridView1.Rows[r].Cells["ID_Type of equipment"].Value;
                            dataSet.Tables["type of equipment"].Rows[r]["List_ID"] = dataGridView1.Rows[r].Cells["List_ID"].Value;
                            dataSet.Tables["type of equipment"].Rows[r]["Not working equipment"] = dataGridView1.Rows[r].Cells["Not working equipment"].Value;
                           
                            SqlDataAdapter.Update(dataSet, "type of equipment");
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
                            dataGridView1[3, lastRow] = linkCell;
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
            Ongoing_Objects.ActiveForm.Hide();
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

                    dataGridView1[3, ri] = linkCell;
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
