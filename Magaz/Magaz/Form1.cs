using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Magaz
{
    public partial class Form1 : Form
    {
        ProductContext db;
        public Form1()
        {
            
            InitializeComponent();
            

            db = new ProductContext();
            db.Products.Load();
            dataGridView.DataSource = db.Products.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Product products = new Product();

            ProdForm products = new ProdForm();
            DialogResult result=products.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            //Products products = new Products();
            //product.Name = products.textBox1.Text;

            products.numericUpDown1.Value = (decimal)products.Price;
            products.textBox1.Text = products.ProductName;
            products.Manufacture = products.comboBox1.SelectedItem.ToString();

            db.Products.Add(product);
            db.SaveChanges();

            MessageBox.Show("Новый продукт добавлен");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count > 0)
            {

                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                
                ProdForm products = new ProdForm();
                //Product plForm = new Product();
                products.numericUpDown1.Value = (decimal)products.Price;
                products.textBox1.Text = products.ProductName;
                products.Manufacture=products.comboBox1.SelectedItem.ToString();

                DialogResult result= products.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                products.numericUpDown1.Value = (decimal)products.Price;
                products.textBox1.Text = products.ProductName;
                products.Manufacture = products.comboBox1.SelectedItem.ToString();

                db.SaveChanges();
                dataGridView.Refresh();
                MessageBox.Show("Продукт обновлен");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {

                int index = dataGridView.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                ProductForm product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();

                MessageBox.Show("Продукт удален");
            }

        }
    }
}
