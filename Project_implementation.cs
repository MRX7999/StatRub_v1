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
    public partial class Project_implementation : MetroFramework.Forms.MetroForm
    {
        public string CmdText = "SELECT * FROM `project implementation`" ;
        public string ConnString = "Server=localhost; Database=movedb; Uid=root; Pwd=root";
        private MySqlDataAdapter SqlDataAdapter = null;
        private MySqlCommandBuilder sqlBuilder = null;
        private DataSet dataSet = null;
        private MySqlConnection MySqlConnection = null;
        private bool NewRowAdding = false;
        public Project_implementation()
        {
            InitializeComponent();
          
        }
        private void LoadData()
        {
            try
            {

                SqlDataAdapter = new MySqlDataAdapter("SELECT *, 'Delete' AS `Delete` FROM `ongoing projects and their implementation`", MySqlConnection);
                sqlBuilder = new MySqlCommandBuilder(SqlDataAdapter); // inser, update, delete, and more *****
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                //init pull data set, remeber Andrew it;
                dataSet = new DataSet();
                SqlDataAdapter.Fill(dataSet, "ongoing projects and their implementation");
                dataGridView1.DataSource = dataSet.Tables["ongoing projects and their implementation"]; //For key
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
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        
            
        }

        private void Ft2_Load(object sender, EventArgs e)
        {
            MySqlConnection = new MySqlConnection(@"Server = 127.0.0.1; Database = movedb; Uid = Admin; Pwd = 123");
            MySqlConnection.Open();
            LoadData();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Project_implementation.ActiveForm.Hide();
            Main_Form MyForm2 = new Main_Form();
            MyForm2.ShowDialog();
            Close();
        }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["ongoing projects and their implementation"].Clear();

                //init pull data set, remeber Andrew it;

                SqlDataAdapter.Fill(dataSet, "ongoing projects and their implementation");
                dataGridView1.DataSource = dataSet.Tables["ongoing projects and their implementation"]; //For key
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
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                                dataSet.Tables["ongoing projects and their implementation"].Rows[rowIndex].Delete();
                                SqlDataAdapter.Update(dataSet, "ongoing projects and their implementation");


                            }
                        }
                        else if (task == "Insert") // заполнение с конца + Project ID нужно ввести
                        {
                            int rowIndex = dataGridView1.Rows.Count - 2;
                            DataRow row = dataSet.Tables["ongoing projects and their implementation"].NewRow();
                            row["ID_List of services now available"] = dataGridView1.Rows[rowIndex].Cells["ID_List of services now available"].Value;
                            row["Cost"] = dataGridView1.Rows[rowIndex].Cells["Cost"].Value;
                            row["Contract_ID"] = dataGridView1.Rows[rowIndex].Cells["Contract_ID"].Value;
                            row["ID_Category"] = dataGridView1.Rows[rowIndex].Cells["ID_Category"].Value;

                            dataSet.Tables["ongoing projects and their implementation"].Rows.Add(row);
                            dataSet.Tables["ongoing projects and their implementation"].Rows.RemoveAt(dataSet.Tables["ongoing projects and their implementation"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[4].Value = "Delete";
                            SqlDataAdapter.Update(dataSet, "ongoing projects and their implementation");
                            NewRowAdding = false; // Update New Rows
                        }
                        else if (task == "Update")
                        {
                            int r = e.RowIndex;
                            dataSet.Tables["ongoing projects and their implementation"].Rows[r]["ID_List of services now available"] = dataGridView1.Rows[r].Cells["ID_List of services now available"].Value;
                            dataSet.Tables["ongoing projects and their implementation"].Rows[r]["Cost"] = dataGridView1.Rows[r].Cells["Cost"].Value;
                            dataSet.Tables["ongoing projects and their implementation"].Rows[r]["Contract_ID"] = dataGridView1.Rows[r].Cells["Contract_ID"].Value;
                            dataSet.Tables["ongoing projects and their implementation"].Rows[r]["ID_Category"] = dataGridView1.Rows[r].Cells["ID_Category"].Value;

                            SqlDataAdapter.Update(dataSet, "ongoing projects and their implementation");
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

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {

        }
    }
}
