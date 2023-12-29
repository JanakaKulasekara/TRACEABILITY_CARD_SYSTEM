using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OracleClient;
using TRACEABILITY_CARD_SYSTEM.Logic;
using System.Threading;


namespace TRACEABILITY_CARD_SYSTEM
{
    public partial class ChangePegQty : Form
    {
        public ChangePegQty()
        {
            InitializeComponent();
        }

        private void btnSearchdop_Click(object sender, EventArgs e)
        {
            BLL objbll = new BLL();


            if (txtChngpegdopid.Text == "")
            {
                MessageBox.Show("TEXT FILED EMPTY!!!", "Info");
                txtChngpegdopid.Text = "";
            }


            else
            {

                dgvChangepegqty.DataSource = null;
                dgvChangepegqty.Rows.Clear();
                dgvChangepegqty.DataSource = objbll.ShowDataInDgvChangePeggedQty(Convert.ToInt32(txtChngpegdopid.Text));
                txtChngpegdopid.Text = "";
            }


        }

        private void txtChngpegdopid_KeyDown(object sender, KeyEventArgs e)
        {

            BLL objbll = new BLL();

            if (e.KeyValue == 13 && txtChngpegdopid.Text != "")
            {

                if (txtChngpegdopid.Text == "")
                {
                    MessageBox.Show("TEXT FILED EMPTY!!!", "Info");
                    txtChngpegdopid.Text = "";
                }

                else
                {

                    dgvChangepegqty.DataSource = null;
                    dgvChangepegqty.Rows.Clear();
                    dgvChangepegqty.DataSource = objbll.ShowDataInDgvChangePeggedQty(Convert.ToInt32(txtChngpegdopid.Text));
                    txtChngpegdopid.Text = "";
                    
                    
                }
            }








        }

        private void txtChngpegdopid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void dgvChangepegqty_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dgvChangepegqty_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvChangepegqty.CurrentCell.ColumnIndex;
            string columnName = dgvChangepegqty.Columns[columnIndex].Name;

            if (columnIndex == 6)
            {
                
                //dgvIfsdata.DataSource = null;
                //dgvIfsdata.Rows.Clear();
                //dgvIfsdata.DataSource = objbll7.ShowDataInDGV();

                int currpegqty = Convert.ToInt32(dgvChangepegqty.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value);
                int newpegqty = Convert.ToInt32(dgvChangepegqty.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                int remqty = newpegqty - currpegqty;
                int perqty = Convert.ToInt32(dgvChangepegqty.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value);
                int recid = Convert.ToInt32(dgvChangepegqty.Rows[e.RowIndex].Cells[e.ColumnIndex - 6].Value);
                char printdyn = Convert.ToChar(dgvChangepegqty.Rows[e.RowIndex].Cells[e.ColumnIndex + 10].Value);


                if (remqty < 0)
                {
                    MessageBox.Show("MINUS", "Info");
                }

                else if (remqty == 0) 
                {
                    MessageBox.Show("No Change Of Pegged Qty!","Info");
                }

                else
                {

                    if (printdyn == 'N')
                    {
                        BLL objbll10 = new BLL();
                        objbll10.UpdatePeggedQty(Convert.ToInt32(newpegqty), Convert.ToInt32(perqty), Convert.ToInt32(newpegqty), Convert.ToChar('N'), Convert.ToInt32(recid));
                    }

                    else 
                    {
                        BLL objbll6 = new BLL();
                        objbll6.UpdatePeggedQty(Convert.ToInt32(newpegqty), Convert.ToInt32(perqty), Convert.ToInt32(remqty), Convert.ToChar('N'), Convert.ToInt32(recid));
                    }

                   
                }

                //string newpegdqty = Convert.ToString(dgvChangepegqty.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                //MessageBox.Show(data);

                //MessageBox.Show(data2);


                ///string remqty = Convert.ToString(dgvChangepegqty.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value);
                //




                //dgvIfsdata.DataSource = null;
                //dgvIfsdata.Rows.Clear();
                //dgvIfsdata.DataSource = objbll6.ShowDataInDGV();



            }

            else
            {
                MessageBox.Show("PLS SELECT CELL FROM NEW_PEGGED_QTY COLUMN ONLY!!!", "Info");

                BLL objbll7 = new BLL();

            }
        }

        private void dgvChangepegqty_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvChangepegqty.CancelEdit();
            }
        }

        private void dgvChangepegqty_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvChangepegqty_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            BLL objbllok = new BLL();
            
        }
    }
}
