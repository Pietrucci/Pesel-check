using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pesel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] s;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "xD")
            {
                rok.Text = "Xd";
                miesiac.Text = "XD";
                dzien.Text = "xD";
                plec.Text = "xd";
                return;
            }

            label1.Visible = false;
            if (textBox1.Text.Length != 11 || peselTest() == false)
            {
                label1.Visible = true;
                return;
            }

            if (s[9] % 2 == 0)
                plec.Text = "Kobieta";
            else plec.Text = "Mężczyzna";

            dzien.Text = (10 * s[4] + s[5]).ToString();

            int m = 10 * s[2] + s[3];
            int r = 10 * s[0] + s[1];

            int month = 0;
            int year = 0;

            if (m >= 1 && m <= 12)
            {
                year += 1900 + 10 * s[0] + s[1];
                month += 10 * s[2] + s[3];
            }

            if (m >= 20 && m <= 32)
            {
                year += 2000 + 10 * s[0] + s[1];
                month += 10 * s[2] + s[3];
                month -= 10;
            }

            if (m >= 81 && m <= 92)
            {
                year += 1800 + 10 * s[0] + s[1];
                month += 10 * s[2] + s[3];
                month -= 80;
            }

            if (m >= 41 && m <= 50)
            {
                year += 2100 + 10 * s[0] + s[1];
                month += 10 * s[2] + s[3];
                month -= 20;
            }

            rok.Text = year.ToString();
            miesiac.Text = getMonth(month);

        }

        private string getMonth(int m)
        {
            if (m == 1 || m == 01)
                return "Styczeń";
            if (m == 2 || m == 02)
                return "Luty";
            if (m == 3 || m == 03)
                return "Marzec";
            if (m == 4 || m == 04)
                return "Kwiecień";
            if (m == 5 || m == 05)
                return "Maj";
            if (m == 6 || m == 06)
                return "Czerwiec";
            if (m == 7 || m == 07)
                return "Lipiec";
            if (m == 8 || m == 08)
                return "Sierpień";
            if (m == 9 || m == 09)
                return "Wrzesień";
            if (m == 10)
                return "Październik";
            if (m == 11)
                return "Listopad";
            if (m == 12)
                return "Grudzień";
            return "ERROR";
        }

        private bool peselTest()
        {
                        s = new int[11];
            for (int i = 0; i < 11; i++)
            {
                s[i] = textBox1.Text.ElementAt(i) - '0';
            }

            int temp = 9 * s[0] + 7 * s[1] + 3 * s[2] + 1 * s[3] + 9 * s[4] + 7 * s[5] + 3 * s[6] + 1 * s[7] + 9 * s[8] + 7 * s[9];
            string temps = temp.ToString();
            return (temps.Last() - '0' == s[10]);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
