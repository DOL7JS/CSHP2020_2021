using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cv04
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            stats.UpdatedStats += new UpdatedStatsEventHandler(UpdatekHandler);
            difficultyLabel.Text = "Lehká";
            correctLabel.Text = "0";
            missedLabel.Text = "0";
            accurancyLabel.Text = "0";

        }
        private void UpdatekHandler(object sender, EventArgs eventArgs)
        {
            missedLabel.Text = stats.Missed.ToString();
            correctLabel.Text = stats.Correct.ToString();
            accurancyLabel.Text = stats.Accurancy.ToString();
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            gameListBox.Items.Add((Keys)rand.Next('A', 'Z'));
            if (gameListBox.Items.Count > 5)
            {
                timer1.Stop();
                gameListBox.Items.Clear();
                gameListBox.Items.Add("G");
                gameListBox.Items.Add("A");
                gameListBox.Items.Add("M");
                gameListBox.Items.Add("E");
                gameListBox.Items.Add(" ");
                gameListBox.Items.Add("O");
                gameListBox.Items.Add("V");
                gameListBox.Items.Add("E");
                gameListBox.Items.Add("R");
                gameListBox.Items.Add("!");
                MessageBox.Show("Game over !! ");
            }
        }

        private void gameListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameListBox.Items.Contains(e.KeyCode))
            {
                gameListBox.Items.Remove(e.KeyCode);
                gameListBox.Refresh();
                if (timer1.Interval > 450)
                {
                    timer1.Interval -= 80;
                    difficultyLabel.Text = "Lehká";

                }
                else if (timer1.Interval > 250)
                {
                    timer1.Interval -= 15;
                    difficultyLabel.Text = "Střední";
                }
                else if (timer1.Interval > 150)
                {
                    timer1.Interval -= 8;
                    difficultyLabel.Text = "Těžká";
                }
                stats.Update(true);
            }
            else
            {
                stats.Update(false);
            }
            if (timer1.Interval > 0 && timer1.Interval < 800)
            {
                diffucultProgressBar.Value = 800 - timer1.Interval;

            }
            else
            {
                diffucultProgressBar.Value = 0;

            }
        }
    }
}
