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
using System.Net;
using System.Media;
using System.Collections;
using System.Diagnostics;
using Magnum.FileSystem;

namespace StatRub_v1
{
    public partial class Main_Form : MetroFramework.Forms.MetroForm

    {
         
        public Main_Form()
        {
            InitializeComponent();
            LoadTable();
        }
      
        
        // private SoundPlayer Player = null; // misic ****************
        // private void PlayWav(Stream stream, bool play_looping)
        //  {
        // Остановить проигрыватель, если он запущен.
        //      if (Player != null)
        //     {
        //         Player.Stop();
        //         Player.Dispose();
        //         Player = null;
        //     }

        // Если у нас нет потока, мы закончили.
        //     if (stream == null) return;

        // Создаем новый проигрыватель для потока WAV.
        //     Player = new SoundPlayer(stream);
        //
        // Играть.
        //    if (play_looping)
        //        Player.PlayLooping();
        //    else
        //         Player.Play();
        //   }
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }
        private void LoadTable()
        {
            MySqlConnection con = new MySqlConnection
                ("Server=localhost; Database=movedb; Uid=root; Pwd=root");
            
                
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Project_implementation MyForm2 = new Project_implementation();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Project_Status MyForm2 = new Project_Status();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Categories_In_Departaments MyForm2 = new Categories_In_Departaments();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Changes_and_Properites MyForm2 = new Changes_and_Properites();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide(); // Текущая форма 
            switchboard_items MyForm2 = new switchboard_items(); //  Форма куда переходишь 
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            List_of_equipment.ActiveForm.Hide();
            staff MyForm2 = new staff();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            List_Of_Departaments MyForm2 = new List_Of_Departaments();
            MyForm2.ShowDialog();
            Close();
         
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Projects MyForm2 = new Projects();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Workers MyForm2 = new Workers();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Ongoing_Objects MyForm2 = new Ongoing_Objects();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            staff MyForm2 = new staff();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Customers MyForm2 = new Customers();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Contract MyForm2 = new Contract();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Projects MyForm2 = new Projects();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            Projects_IN_Going MyForm2 = new Projects_IN_Going();
            MyForm2.ShowDialog();
            Close();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Main_Form.ActiveForm.Hide();
            switchboard_items MyForm2 = new switchboard_items();
            MyForm2.ShowDialog();
            Close();
        }

     

        private void metroButton17_Click(object sender, EventArgs e) //****************************************** Воспроизведение музыки
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            player.SoundLocation = "C:\\Users\\ruban\\Desktop\\StatRub_v1\\Mili-sustain-Ghost-In-The-Shell-SAC-2045-Ending-Theme__Audio-VK4.ru_.wav";
            player.Play();
        }
    }
}
