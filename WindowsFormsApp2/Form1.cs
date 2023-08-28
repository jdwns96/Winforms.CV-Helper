using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVHelper
{
    public partial class Form1 : Form
    {
        //private List<string> _list = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Design();
            Setting();
        }


        private void Design()
        {
            txtInput.AutoSize = false;
            //txtInput.Size = new Size(142, 27);
            txtInput.Height = 28;
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Padding = new Padding(3, 3, 3, 3);
        }

        private void Setting()
        {
            dataGridView.ColumnCount = 1;
            dataGridView.Columns[0].Name = "Content";
            dataGridView.Columns["Content"].ReadOnly = true;
            dataGridView.CellClick += dataGridView_CellClick;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(text)) return;

            //_list.Add(text);
            dataGridView.Rows.Add(text);

            txtInput.Clear();

        }
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in a valid row
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dataGridView.Rows[e.RowIndex];
                string content = clickedRow.Cells["Content"].Value?.ToString();

                if (!string.IsNullOrEmpty(content))
                {
                    //MessageBox.Show($"You clicked the row with content: {content}", "Row Clicked");
 

                    // Copy the content to clipboard
                    Clipboard.SetText(content);

                }
            }
        }



    }
}
