using AltoHttp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pluto_Launcher_V1
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private Form2 form2;

        public Form1()
        {
            InitializeComponent();
            // Initialisiere den Timer
            timer = new Timer();
            timer.Interval = 5000; // Timer feuert nach 5 Sekunden
            timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Schließe die Form nach 5 Sekunden
            timer.Stop(); // Stoppe den Timer
            await FadeOutAndCloseForm2();
        }

        private async Task FadeOutAndCloseForm2()
        {
            for (double opacity = 1.0; opacity >= 0; opacity -= 0.1)
            {
                form2.Opacity = opacity; // Setze die Opacity-Eigenschaft der Form
                await Task.Delay(100); // Warte für einen kurzen Moment
            }
            form2.Close(); // Schließe die Form, wenn die Opacity 0 erreicht hat
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Wählen Sie einen Ordner aus";
                folderBrowserDialog.ShowNewFolderButton = true;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    MessageBox.Show("Gewählter Ordner: " + selectedPath);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Erstelle eine Instanz von Form2
            form2 = new Form2();

            // Bestimme die Position von Form2 relativ zum Bildschirm
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int form2Width = form2.Width;
            int form2Height = form2.Height;

            // Berechne die Position von Form2 in der unteren rechten Ecke
            int x = screenWidth - form2Width;
            int y = screenHeight - form2Height;

            // Setze die Position von Form2
            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(x, y);

            // Zeige Form2 an
            form2.Show();

            // Starte den Timer nachdem Form2 angezeigt wurde
            timer.Start();
        }
    }
}




