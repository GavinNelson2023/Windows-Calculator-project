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
            this.KeyPreview = true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 9;
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
            txtcurrent.Text = txtcurrent.Text + 0;
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            if(txtcurrent.Text == "ERROR")
            {
                txtcurrent.Clear();
            }
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
            head = null;
            current = null;
        }

        private void btndivision_Click(object sender, EventArgs e)
        {
            addtolist("/");
            printlist();
            txtcurrent.Clear();
        }

        private void btnequal_Click(object sender, EventArgs e)
        {
            addtolist("=");
            printlist();
            txtcurrent.Clear();
            double answer = calculate();
            txtcurrent.Text = "" + answer;

        }

        private void addtolist(string s)
        {
            if (Double.TryParse(txtcurrent.Text, out first))
            {
                if (head == null)
                {
                    head = new Class1();
                    current = head;
                    current.number = first;
                    current.n = true;

                    current.next = new Class1();
                    current = current.next;
                    current.symbol = s;
                    current.n = false;
                    current.next = null;
                }
                else
                {
                    current.next = new Class1();
                    current = current.next;
                    current.number = first;
                    current.n = true;

                    current.next = new Class1();
                    current = current.next;
                    current.symbol = s;
                    current.n = false;
                    current.next = null;
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
            while (print != null)
            {
                if (print.n)
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

        private double calculate()
        {
            double a = 0;
            multiply();
            divide();
            add();
            subtract();

            return head.number;

        }

        private void multiply()
        {
            Class1 m = head;
            Class1 temp;

            while(m.symbol != "=")
            {
                if(m.next.symbol == "*")
                {
                    double answer = m.number * m.next.next.number;
                    temp = m.next.next.next;
                    m.next = temp;
                    m.number = answer;
                }
                else
                {
                    m = m.next;
                }

            }

        }

        private void divide()
        {
            Class1 d = head;
            Class1 temp;

            while (d.symbol != "=")
            {
                if (d.next.symbol == "/")
                {
                    double answer = d.number / d.next.next.number;
                    temp = d.next.next.next;
                    d.next = temp;
                    d.number = answer;
                }
                else
                {
                    d = d.next;
                }

            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char p = e.KeyChar;
            if(p == '1' || p == '2' || p == '3' || p == '4' || p == '5' || p == '6' || p == '7' || p == '8' || p == '9' || p == '0')
            {
                if (txtcurrent.Text == "ERROR")
                {
                    txtcurrent.Clear();
                }
                txtcurrent.Text = txtcurrent.Text + p;
            }
            else if (p == '+' || p == '-' || p == '/' || p == '*')
            {
                string s = "" + p;
                addtolist(s);
                printlist();
                txtcurrent.Clear();
            }
            else if (p == (char)Keys.Enter)
            {
                addtolist("=");
                printlist();
                txtcurrent.Clear();
                double answer = calculate();
                txtcurrent.Text = "" + answer;
            }
        }

        private void add()
        {
            Class1 a = head;
            Class1 temp;

            while (a.symbol != "=")
            {
                if (a.next.symbol == "+")
                {
                    double answer = a.number + a.next.next.number;
                    temp = a.next.next.next;
                    a.next = temp;
                    a.number = answer;
                }
                else
                {
                    a = a.next;
                }
                

            }

        }

        private void subtract()
        {
            Class1 s = head;
            Class1 temp;

            while (s.symbol != "=")
            {
                if (s.next.symbol == "-")
                {
                    double answer = s.number - s.next.next.number;
                    temp = s.next.next.next;
                    s.next = temp;
                    s.number = answer;
                }
                else
                {
                    s = s.next;
                }

            }

        }


    }
}
