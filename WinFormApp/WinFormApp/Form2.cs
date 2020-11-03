using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Form2 : Form
    {
        public Product product;
        public Form2(Product product, string mode)
        {
            this.product = product;
            InitializeComponent();
            this.Text = mode;

            NameBox.Text = this.product.Name;
            Description.Text = this.product.Description;
            Characteristic.Text = this.product.Characteristic;
            Cost.Text = this.product.Cost.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            product.Name = NameBox.Text;
            product.Description = Description.Text;
            product.Characteristic = Characteristic.Text;
            product.Cost = int.Parse(Cost.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
