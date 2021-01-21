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
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace StatRub_v1
{
    public partial class AutoRezation : MetroFramework.Forms.MetroForm

    {
        public AutoRezation()
        {
            InitializeComponent();
            notifyIcon1.BalloonTipText = "Приложение работает в фоновом режиме";
            notifyIcon1.BalloonTipTitle = "StatRub_v1_Client";
        }
       

        private void AutoRezation_Load(object sender, EventArgs e)
        {
         

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void Button_Go_ON_Click(object sender, EventArgs e) //8******************************************************
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            player.SoundLocation = "C:\\Users\\ruban\\Desktop\\StatRub_v1\\Mili-sustain-Ghost-In-The-Shell-SAC-2045-Ending-Theme__Audio-VK4.ru_.wav";
            player.Play();
            string Connect = "server=localhost;uid=root;password=root;persistsecurityinfo=True;database=movedb";
            string CommandText = "SELECT Count(*) FROM  users WHERE login = '" + waterMark1.Text + "' AND pass = '" + waterMark2.Text + "' LIMIT 1";
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "2")
            {
                this.Hide();
                Main_Form f2 = new Main_Form();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введенных данных!");
            }

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void fileSystemWatcher2_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void waterMark2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void waterMark1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Regestration_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegestrationFrom f2 = new RegestrationFrom();
            f2.Show();
        }

       

        private void FormAutorezatian_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(10000);
            }
        }

        private void StatRub_v1_Client_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }
    }
    }


  
    
    

