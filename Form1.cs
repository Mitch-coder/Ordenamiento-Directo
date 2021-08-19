using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoDeOrdenamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int N, aux, k, i;
        int[] numbers;
        void print()
        {
            for (int k = 0; k < N; k++)
            {
                txtOrder.Text = txtOrder.Text + numbers[k] + " ";
            }
            txtOrder.Text = txtOrder.Text + "\n\n";
        }
        public void BubleSortMinor()
        {
            int i = 0;
            N = 0;
            foreach (int Element in lbNumbers.Items)
            {
                Array.Resize(ref numbers, N + 1);
                numbers[N] = Element;
                N = N + 1;
            }
            txtOrder.Clear();
            for (i = 1; i < N; i++)
            {
                for (int j = N - 1; j > 0; j--)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        aux = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = aux;
                    }      
                }
            }
            print();

        }
        public void BubleSortMajor()
        {
            N = 0;
            foreach (int Element in lbNumbers.Items)
            {
                Array.Resize(ref numbers, N + 1);
                numbers[N] = Element;
                N = N + 1;
            }
            txtOrder.Clear();
            for (i = N-1; i > 0; i--)
            {
                for (int j = 0; j <i; j++)
                {
                    if (numbers[j]>numbers[j+1])
                    {
                        aux = numbers[j];
                        numbers[j] = numbers[j+1];
                        numbers[j+1] = aux;
                    }
                    
                }
            }
            print();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lbNumbers.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbMethod.Items.Add("Burbuja Mayor");
            cbMethod.Items.Add("Burbuja Menor");
            cbMethod.Items.Add("Burbuja Bandera");
            cbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMethod.SelectedIndex==0)
            {
                BubleSortMinor();
            }
            if (cbMethod.SelectedIndex == 1)
            {
                BubleSortMajor();
            }
            if (cbMethod.SelectedIndex == 2)
            {
                BubleSortSignal();
            }
        }
        private void TxtNumber_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int Num = int.Parse(txtNumber.Text);
                lbNumbers.Items.Add(Num);
                lcountInsert.Text = Convert.ToString(lbNumbers.Items.Count + "Elementos insertados");
                txtNumber.Clear();
                txtNumber.Focus();
            }

        }

        public void BubleSortSignal()
        {
            N = 0;
            foreach (int Element in lbNumbers.Items)
            {
                Array.Resize(ref numbers, N + 1);
                numbers[N] = Element;
                N = N + 1;
            }
            txtOrder.Clear();
            i = 0;
            bool flat = false;
            while (i<N-1&&flat==false)
            {
                flat = true;
                for (int j = 0; j < N-1; j++)
                {
                    if (numbers[j]>numbers[j+1])
                    {
                        int aux = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = aux;
                        flat = false;
                    }
                   
                }
                i = i + 1;
            }
            print();
        }

       

    }
}
