using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormApp
{
    public partial class Form1 : Form
    {
        private List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();

            if (File.Exists("save.txt"))
            {
                StreamReader reader = new StreamReader("save.txt");
                comboBox1.Items.Clear();
                while (!reader.EndOfStream)
                {
                    Product temp = new Product();
                    string[] param = reader.ReadLine().Split('}');
                    temp.Name = param[0];
                    temp.Description = param[1];
                    temp.Characteristic = param[2];
                    temp.Cost = int.Parse(param[3]);
                    products.Add(temp);
                    comboBox1.Items.Add(temp.Name);
                }

                comboBox1.SelectedIndex = 0;
                reader.Close();
            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            StreamWriter writer = new StreamWriter("save.txt");
            foreach (var product in products)
            {
                writer.WriteLine($"{product.Name}}}" +
                                 $"{product.Description}}}" +
                                 $"{product.Characteristic}}}" +
                                 $"{product.Cost}");
            }
            writer.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cost.Text = products[comboBox1.SelectedIndex].Cost.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product temp = new Product();
            Form2 f2 = new Form2(temp, "Add");
            f2.ShowDialog();
            temp = f2.product;
            if (temp.Name.Length > 0)
            {
                products.Add(temp);
                comboBox1.Items.Add(temp.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index >= 0)
                listBox1.Items.Add(products[index].Name);
            TotalCost.Text = (int.Parse(TotalCost.Text) + products[index].Cost).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index >= 0)
            {
                Product temp = products[index];
                Form2 f2 = new Form2(temp, "Edit");
                f2.ShowDialog();
                temp = f2.product;
                if (temp.Name.Length > 0)
                {
                    products[index] = temp;
                    comboBox1.Items[index] = temp.Name;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            TotalCost.Text = "0";
        }
    }

    public class Product
    {
        public string Name;
        public string Description;
        public string Characteristic;
        public int Cost;
    }
}
