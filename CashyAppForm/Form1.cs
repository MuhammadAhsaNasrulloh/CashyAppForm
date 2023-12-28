using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashyAppForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        int indexRow;
        int selectedRow;
        int selectedRowIndex;

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Barang", typeof(string));
            table.Columns.Add("Kode Barang", typeof(string));
            table.Columns.Add("Stok", typeof(int));
            table.Columns.Add("Harga", typeof(int));

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            DataGridViewRow row = dataGridView1.Rows[indexRow];
            txtBarang.Text = row.Cells[0].Value.ToString();
            txtKodeBarang.Text = row.Cells[1].Value.ToString();
            txtStock.Text = row.Cells[2].Value.ToString();
            txtHarga.Text = row.Cells[3].Value.ToString();

            selectedRowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[indexRow];
            txtBarang.Text = selectedRow.Cells[0].Value.ToString();
            txtKodeBarang.Text = selectedRow.Cells[1].Value.ToString();
            txtStock.Text = selectedRow.Cells[2].Value.ToString();
            txtHarga.Text = selectedRow.Cells[3].Value.ToString();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtBarang.Text == string.Empty || txtKodeBarang.Text == string.Empty || txtStock.Text == string.Empty || txtHarga.Text == string.Empty)
            {
                MessageBox.Show("Isi dengan Lengkap");
            }
            else
            {
                table.Rows.Add(txtBarang.Text, txtKodeBarang.Text, txtStock.Text, txtHarga.Text);
                dataGridView1.DataSource = table;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtBarang.Text;
            newDataRow.Cells[1].Value = txtKodeBarang.Text;
            newDataRow.Cells[2].Value = txtStock.Text;
            newDataRow.Cells[3].Value = txtHarga.Text;
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
