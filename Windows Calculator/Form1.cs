using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Calculator
{
    public partial class Form1 : Form
    {
        double first, second, answer;
        string function;
        Class1 head;
        Class1 current;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblequation.Text = "";
            head = null;
            current = head;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 9;
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + 0;
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = txtcurrent.Text + ".";
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            addtolist("+");
            printlist();
            txtcurrent.Clear();
        }

        private void btnsubtract_Click(object sender, EventArgs e)
        {
            addtolist("-");
            printlist();
            txtcurrent.Clear();
        }

        private void btnmultiplication_Click(object sender, EventArgs e)
        {
            addtolist("*");
            printlist();
            txtcurrent.Clear();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtcurrent.Clear();
        }

        private void btnclearall_Click(object sender, EventArgs e)
        {
            txtcurrent.Clear();
            first = second = answer = 0;
            lblequation.Text = "";
            function = "";
        }

        private void btndivision_Click(object sender, EventArgs e)
        {
            addtolist("/");
            printlist();
            txtcurrent.Clear();
        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            if(Double.TryParse(txtcurrent.Text, out second))
            {
                if (function == "+")
                {
                    answer = first + second;
                }
                else if(function == "-")
                {
                    answer = first + second;
                }
                else if (function == "*")
                {
                    answer = first + second;
                }
                else if (function == "/")
                {
                    answer = first + second;
                }
                else
                {
                    txtcurrent.Text = "ERROR";
                }
                txtcurrent.Text = "" + answer;
                lblequation.Text = lblequation.Text + second + "=";
            }
            else
            {
                txtcurrent.Text = "ERROR";
            }

            
        }

        private void addtolist(string s)
        {
            if(Double.TryParse(txtcurrent.Text, out first))
            {
                if(head == null)
                {
                    head = new Class1();
                    current = head;
                    current.number = first;
                    current.n = true;
                    if(s != "=")
                    {
                        current.next = new Class1();
                        current = current.next;
                        current.symbol = s;
                        current.n = false;
                        current.next = null;
                    }
                }
                else
                {
                    current.next = new Class1();
                    current = current.next;
                    current.number = first;
                    current.n = true;
                    if (s != "=")
                    {
                        current.next = new Class1();
                        current = current.next;
                        current.symbol = s;
                        current.n = false;
                        current.next = null;
                    }
                }
            }
            else
            {
                lblequation.Text = "ERROR";
                txtcurrent.Clear();
            }
        }

        private void printlist()
        {
            Class1 print = head;
            string temp = "";
            while(print != null)
            {
                if(print.n)
                {
                    temp = temp + print.number;
                }
                else
                {
                    temp = temp + print.symbol;
                }

                print = print.next;
            }

            lblequation.Text = temp;
        }
    }
}
