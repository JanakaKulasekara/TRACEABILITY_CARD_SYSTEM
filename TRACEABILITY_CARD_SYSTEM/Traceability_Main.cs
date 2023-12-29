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
    public partial class Traceability_Main : Form
    {
        private string p;
        private string level;
        private int ret;

        public Traceability_Main()
        {
            InitializeComponent();
        }

        public Traceability_Main(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
            InitializeComponent();
        }

        public Traceability_Main(string p, string level, int ret)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.level = level;
            this.ret = ret;

            InitializeComponent();
        }

        private void btnIfsdatafetch_Click(object sender, EventArgs e)
        {

            ////string connStr = ConfigurationManager.ConnectionStrings["ConnectionStringIFS"].ConnectionString;
            //string CONNECTION_STRING = "User Id=IFSAPP;Password=ifsit2011;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.100.78)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME = SRI)))";


            //System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(CONNECTION_STRING);
            //OracleDataReader orareader = null;


            //conn.Open();
            //System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand();


            //cmd.Connection = conn;
            //cmd.CommandText =
            //    "select DH.dop_id,DH.part_no,DH.description,DH.contract,DDCO.pegged_qty"
            //    + "from IFSAPP.DOP_HEAD DH"
            //    + "inner join"
            //    + "IFSAPP.DOP_DEMAND_CUST_ORD DDCO"
            //    + "on"
            //    + "DH.dop_id=DDCO.dop_id"

            //    + "where DH.dop_id=276400";

            //cmd.CommandType = CommandType.Text;

            //DataSet ds = new DataSet("IFSDATSET1");
            //DataTable dt = new DataTable("IFSDAT1");
            //OracleDataAdapter adapter = new OracleDataAdapter();
            //adapter.SelectCommand = cmd;
            //adapter.Fill(dt);

            //dgvIfsdata.DataSource = dt;

            //ds.Tables.Add(dt);


            //orareader = cmd.ExecuteReader();



            //while (orareader.Read())
            //{


            //}





            //conn.Close();
            //conn.Dispose();
            btnIfsdatafetch.Enabled = false;
            //btnIfsdatafetch.Text = "Loading...";

            BLL objbllfetchifs = new BLL();
            int result = objbllfetchifs.FetchDataFromIFS();

            //if (!backgroundWorker.IsBusy) 
            //{
            //    backgroundWorker.RunWorkerAsync();
            //    btnIfsdatafetch.Enabled = false;
            //    btnIfsdatafetch.Text = "Loading...";
            //}





            //prgrsbar.Refresh();
            //int percent = (int)(((double)(prgrsbar.Value - prgrsbar.Minimum) /(double)(prgrsbar.Maximum - prgrsbar.Minimum)) * 100);
            //using (Graphics gr = prgrsbar.CreateGraphics())
            //{
            //    gr.DrawString(percent.ToString() + "%",
            //        SystemFonts.DefaultFont,
            //        Brushes.Black,
            //        new PointF(prgrsbar.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
            //            SystemFonts.DefaultFont).Width / 2.0F),
            //        prgrsbar.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
            //            SystemFonts.DefaultFont).Height / 2.0F)));
            //}




            MessageBox.Show("TOT RECORDS FETCHED - " + result.ToString(), "Info");

            btnIfsdatafetch.Enabled = true;
            btnIfsdatafetch.Text = "FETCH FROM IFS";




        }



        private void StartBackgroundWork()
        {
            if (Application.RenderWithVisualStyles)
                prgrsbar.Style = ProgressBarStyle.Marquee;
            else
            {
                prgrsbar.Style = ProgressBarStyle.Continuous;
                prgrsbar.Maximum = 100;
                prgrsbar.Value = 0;
                timer.Enabled = true;
            }
            backgroundWorker.RunWorkerAsync();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (prgrsbar.Value < prgrsbar.Maximum)
                prgrsbar.Increment(5);
            else
                prgrsbar.Value = prgrsbar.Minimum;
        }








        private void btnFetchifstodsi_Click(object sender, EventArgs e)
        {
            BLL objbll = new BLL();

            if (txtDopid.Text == "")
            {
                MessageBox.Show("TEXT FILED EMPTY!!!", "Info");
                txtDopid.Text = "";
            }

            else
            {

                if (tabCardprint.SelectedTab.Name == "tabpgPrint")
                {
                    int result = objbll.InsertToTraceDetails(txtDopid.Text.Trim(), dtpTraceno.Value.ToString("dd/MM/yyyy"));

                    if (result == 0)
                    {
                        MessageBox.Show("DOPID NOT FOUND!!!", "Info");
                        dgvIfsdata.DataSource = null;
                        dgvIfsdata.Rows.Clear();
                        dgvIfsdata.DataSource = objbll.ShowDataInDGV();
                        txtDopid.Text = "";
                    }

                    else if (result == -1)
                    {
                        MessageBox.Show("DOPID ALREADY IN THE SYSTEM!!!", "Info");
                        dgvIfsdata.DataSource = null;
                        dgvIfsdata.Rows.Clear();
                        dgvIfsdata.DataSource = objbll.ShowDataInDGV(Convert.ToInt32(txtDopid.Text));
                        txtDopid.Text = "";
                    }



                    else
                    {
                        MessageBox.Show("NEW DOPID UPDATED!!!", "Info");
                        dgvIfsdata.DataSource = null;
                        dgvIfsdata.Rows.Clear();
                        dgvIfsdata.DataSource = objbll.ShowDataInDGV();
                        txtDopid.Text = "";

                    }

                }

                else if (tabCardprint.SelectedTab.Name == "tabpgReprint")
                {
                    dgvReprint.DataSource = null;
                    dgvReprint.Rows.Clear();
                    dgvReprint.DataSource = objbll.ShowDataInReprintTab(Convert.ToInt32(txtDopid.Text));
                    txtDopid.Text = "";

                }

                else
                {
                    MessageBox.Show("Pls select a tab");

                }



            }




        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            BLL objbll2 = new BLL();

            dgvIfsdata.DataSource = null;
            dgvIfsdata.Rows.Clear();
            dgvIfsdata.DataSource = objbll2.ShowDataInDGV();

        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            BLL objbll4 = new BLL();
            //objbll4.PrintLabels();

            dgvIfsdata.DataSource = null;
            dgvIfsdata.Rows.Clear();
            dgvIfsdata.DataSource = objbll4.ShowDataInDGV();

        }

        private void txtDopid_KeyDown(object sender, KeyEventArgs e)
        {
            BLL objbll = new BLL();

            if (e.KeyValue == 13 && txtDopid.Text != "")
            {

                if (txtDopid.Text == "")
                {
                    MessageBox.Show("TEXT FILED EMPTY!!!", "Info");
                    txtDopid.Text = "";
                }

                else
                {

                    if (tabCardprint.SelectedTab.Name == "tabpgPrint")
                    {
                        int result = objbll.InsertToTraceDetails(txtDopid.Text.Trim(), dtpTraceno.Value.ToString("dd/MM/yyyy"));

                        if (result == 0)
                        {
                            MessageBox.Show("DOPID NOT FOUND!!!", "Info");
                            dgvIfsdata.DataSource = null;
                            dgvIfsdata.Rows.Clear();
                            dgvIfsdata.DataSource = objbll.ShowDataInDGV();
                            txtDopid.Text = "";
                        }

                        else if (result == -1)
                        {
                            MessageBox.Show("DOPID ALREADY IN THE SYSTEM!!!", "Info");
                            dgvIfsdata.DataSource = null;
                            dgvIfsdata.Rows.Clear();
                            dgvIfsdata.DataSource = objbll.ShowDataInDGV(Convert.ToInt32(txtDopid.Text));
                            txtDopid.Text = "";
                        }



                        else
                        {
                            MessageBox.Show("NEW " + result.ToString().Trim() + " DOPID UPDATED!!!", "Info");
                            dgvIfsdata.DataSource = null;
                            dgvIfsdata.Rows.Clear();
                            dgvIfsdata.DataSource = objbll.ShowDataInDGV();
                            txtDopid.Text = "";

                        }

                    }

                    else if (tabCardprint.SelectedTab.Name == "tabpgReprint")
                    {
                        dgvReprint.DataSource = null;
                        dgvReprint.Rows.Clear();
                        dgvReprint.DataSource = objbll.ShowDataInReprintTab(Convert.ToInt32(txtDopid.Text));
                        txtDopid.Text = "";

                    }

                    else
                    {
                        MessageBox.Show("Pls select a tab");

                    }


                }
            }


        }

        private void Traceability_Main_Load(object sender, EventArgs e)
        {
            lblUsername.Text = this.p;
            lblLevel.Text = this.level;

            BLL objbll2 = new BLL();

            dgvIfsdata.DataSource = null;
            dgvIfsdata.Rows.Clear();
            dgvIfsdata.DataSource = objbll2.ShowDataInDGV();



            lstboxPrinters.DataSource = objbll2.GetPrinters();

            lblDefaultprinter.Text = objbll2.GetDefaultPrinter();

            //backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {








            //for (int i = 1; i <= 100; i++)
            //{
            //    // Wait 100 milliseconds.
            //    Thread.Sleep(100);
            //    // Report progress.
            //    backgroundWorker.ReportProgress(i);
            //}
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            prgrsbar.Value = e.ProgressPercentage;
            // Set the text.
            this.Text = e.ProgressPercentage.ToString();
        }



        private void btnPrintdopid_Click(object sender, EventArgs e)
        {
            if (txtPrintdop.Text == "")
            {
                MessageBox.Show("TEXT FILED EMPTY!!!", "Info");
                txtPrintdop.Text = "";
            }


            else
            {

                if (tabCardprint.SelectedTab.Name == "tabpgPrint")
                {

                    BLL objbll4 = new BLL();
                    //objbll4.PrintLabels(Convert.ToInt32(txtPrintdop.Text.Trim()));
                    objbll4.PrintLabelsDopWise(Convert.ToInt32(txtPrintdop.Text.Trim()));


                    dgvIfsdata.DataSource = null;
                    dgvIfsdata.Rows.Clear();
                    dgvIfsdata.DataSource = objbll4.ShowDataInDGV(Convert.ToInt32(txtPrintdop.Text.Trim()));
                    txtPrintdop.Text = "";

                }

                else if (tabCardprint.SelectedTab.Name == "tabpgReprint")
                {
                    BLL objbll12 = new BLL();
                    objbll12.RePrintLabels(Convert.ToInt32(txtPrintdop.Text.Trim()));


                    dgvReprint.DataSource = null;
                    dgvReprint.Rows.Clear();
                    dgvReprint.DataSource = objbll12.ShowDataInReprintTab(Convert.ToInt32(txtPrintdop.Text));
                    txtPrintdop.Text = "";

                }

                else
                {
                    MessageBox.Show("Pls select a tab");

                }



            }

        }

        private void dgvIfsdata_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //string data = dgvIfsdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //MessageBox.Show(data);
        }

        private void dgvIfsdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvIfsdata.CurrentCell.ColumnIndex;
            string columnName = dgvIfsdata.Columns[columnIndex].DataPropertyName;

            //if (columnName != "PER_QTY" && columnName != "NOTE_TEXT")
            // {
            //     MessageBox.Show("PLS SELECT CELL FROM PER_QTY COLUMN ONLY!!!", "Info");

            //     BLL objbll7 = new BLL();

            //     //dgvIfsdata.DataSource = null;
            //     //dgvIfsdata.Rows.Clear();
            //     //dgvIfsdata.DataSource = objbll7.ShowDataInDGV();

            // }


            // else
            // {
            //     //string data = dgvIfsdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //     ////MessageBox.Show(data);
            //     //string data2 = dgvIfsdata.Rows[e.RowIndex].Cells[e.ColumnIndex - 6].Value.ToString();
            //     ////MessageBox.Show(data2);




            //     //BLL objbll6 = new BLL();
            //     //objbll6.UpdatePerQty(Convert.ToInt32(data), Convert.ToInt32(data2));

            //     //dgvIfsdata.DataSource = null;
            //     //dgvIfsdata.Rows.Clear();
            //     //dgvIfsdata.DataSource = objbll6.ShowDataInDGV();


            //     //char varprintflag = Convert.ToChar(dgvReprint.Rows[e.RowIndex].Cells[columnName: "PRINTED_YN"].Value);
            //     //MessageBox.Show(data);
            //    int varrecid = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[columnName : "RECID"].Value);
            //     //MessageBox.Show(data2);
            //     int varperqty = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[columnName: "PER_QTY"].Value);

            //     string varnotetext = Convert.ToString(dgvIfsdata.Rows[e.RowIndex].Cells[columnName: "NOTE_TEXT"].Value);




            //         BLL objbll11 = new BLL();
            //         objbll11.UpdatePerQty(varperqty, varrecid, varnotetext);

            //         //dgvIfsdata.DataSource = null;
            //         //dgvIfsdata.Rows.Clear();
            //         //dgvIfsdata.DataSource = objbll6.ShowDataInDGV();


            // }


            if (dgvIfsdata.Rows[e.RowIndex].Cells[0].Value != null && dgvIfsdata.Rows[e.RowIndex].Cells[0].Value.ToString() != String.Empty)
            {
                MessageBox.Show("Not Null");
            }






            if (columnIndex == 6)
            {
                int varrecid = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[0].Value);
                //MessageBox.Show(data2);
                int varperqty = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[6].Value);

                string varnotetext = Convert.ToString(dgvIfsdata.Rows[e.RowIndex].Cells[9].Value);


                BLL objbll11 = new BLL();
                objbll11.UpdatePerQty(varperqty, varrecid, varnotetext);

            }
            else if (columnIndex == 9)
            {
                int varrecid = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[0].Value);
                //MessageBox.Show(data2);
                int varperqty = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[6].Value);

                string varnotetext = Convert.ToString(dgvIfsdata.Rows[e.RowIndex].Cells[9].Value);


                BLL objbll11 = new BLL();
                objbll11.UpdatePerQty(varperqty, varrecid, varnotetext);

            }

           //else if (columnName == "PER_QTY") 
            //{
            //    int varrecid = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[0].Value);
            //    //MessageBox.Show(data2);
            //    int varperqty = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[6].Value);

           //    string varnotetext = Convert.ToString(dgvIfsdata.Rows[e.RowIndex].Cells[9].Value);


           //    BLL objbll11 = new BLL();
            //    objbll11.UpdatePerQty(varperqty, varrecid, varnotetext);

           //}

           //else if (columnName == "NOTE_TEXT")
            //{
            //    int varrecid = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[0].Value);
            //    //MessageBox.Show(data2);
            //    int varperqty = Convert.ToInt32(dgvIfsdata.Rows[e.RowIndex].Cells[6].Value);

           //    string varnotetext = Convert.ToString(dgvIfsdata.Rows[e.RowIndex].Cells[9].Value);


           //    BLL objbll11 = new BLL();
            //    objbll11.UpdatePerQty(varperqty, varrecid, varnotetext);

           //}
            else
            {
                MessageBox.Show("Pls select PER_QTY coloumn or NOTE_TEXT column only!!!", "Info");
            }






        }

        private void dgvIfsdata_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvIfsdata.CancelEdit();
            }
        }

        private void dgvIfsdata_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //string data = dgvIfsdata.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //MessageBox.Show(data);
        }

        private void txtPrintdop_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13 && txtPrintdop.Text != "")
            {


                if (txtPrintdop.Text == "")
                {
                    MessageBox.Show("TEXT FILED EMPTY!!!", "Info");
                    txtPrintdop.Text = "";
                }


                else
                {


                    if (tabCardprint.SelectedTab.Name == "tabpgPrint")
                    {
                        BLL objbll9 = new BLL();
                        //objbll9.PrintLabels(Convert.ToInt32(txtPrintdop.Text.Trim()));
                        objbll9.PrintLabelsDopWise(Convert.ToInt32(txtPrintdop.Text.Trim()));



                        dgvIfsdata.DataSource = null;
                        dgvIfsdata.Rows.Clear();
                        dgvIfsdata.DataSource = objbll9.ShowDataInDGV(Convert.ToInt32(txtPrintdop.Text.Trim()));
                        txtPrintdop.Text = "";

                    }

                    else if (tabCardprint.SelectedTab.Name == "tabpgReprint")
                    {
                        BLL objbll12 = new BLL();
                        objbll12.RePrintLabels(Convert.ToInt32(txtPrintdop.Text.Trim()));


                        dgvReprint.DataSource = null;
                        dgvReprint.Rows.Clear();
                        dgvReprint.DataSource = objbll12.ShowDataInReprintTab(Convert.ToInt32(txtPrintdop.Text));
                        txtPrintdop.Text = "";

                    }

                    else
                    {
                        MessageBox.Show("Pls select a tab");

                    }


                }
            }
        }

        private void txtDopid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtPrintdop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgvIfsdata_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cntxtmenu.Show(dgvIfsdata, new Point(e.X, e.Y));

            }


        }

        private void btnChangepegqty_Click(object sender, EventArgs e)
        {
            ChangePegQty objchangepegqty = new ChangePegQty();
            objchangepegqty.ShowDialog();
        }

        private void dgvReprint_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dgvReprint_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvReprint.CurrentCell.ColumnIndex;
            string columnName = dgvReprint.Columns[columnIndex].Name;

            //if (columnName != "PRINTED_YN" && columnName != "PER_QTY" && columnName != "NOTE_TEXT")
            //{
            //    MessageBox.Show("PLS SELECT CELL FROM PRINTED_YN COLUMN ONLY!!!", "Info");

            //    BLL objbll7 = new BLL();

            //    //dgvIfsdata.DataSource = null;
            //    //dgvIfsdata.Rows.Clear();
            //    //dgvIfsdata.DataSource = objbll7.ShowDataInDGV();

            //}

            //else
            //{
            //    char varprintflag = Convert.ToChar(dgvReprint.Rows[e.RowIndex].Cells[columnName: "PRINTED_YN"].Value);
            //    //MessageBox.Show(data);
            //    int varrecid = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[columnName: "RECID"].Value);
            //    //MessageBox.Show(data2);
            //    int varperqty = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[columnName: "PER_QTY"].Value);

            //    string varnotetext = Convert.ToString(dgvReprint.Rows[e.RowIndex].Cells[columnName: "NOTE_TEXT"].Value);

            //    if (varprintflag == 'Y' || varprintflag == 'N')
            //    {


            //        BLL objbll11 = new BLL();
            //        objbll11.UpdateReprintFlag(varprintflag, varrecid, varperqty, varnotetext);

            //        //dgvIfsdata.DataSource = null;
            //        //dgvIfsdata.Rows.Clear();
            //        //dgvIfsdata.DataSource = objbll6.ShowDataInDGV();
            //    }


            //    else 
            //    {
            //        MessageBox.Show("Y or N only!!!, No empty fields!!!", "Info");
            //    }
            //}


            if (columnIndex == 6)
            {
                char varprintflag = Convert.ToChar(dgvReprint.Rows[e.RowIndex].Cells[18].Value);
                //MessageBox.Show(data);
                int varrecid = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[0].Value);
                //MessageBox.Show(data2);
                int varperqty = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[6].Value);

                string varnotetext = Convert.ToString(dgvReprint.Rows[e.RowIndex].Cells[9].Value);

                if (varprintflag == 'Y' || varprintflag == 'N')
                {


                    BLL objbll11 = new BLL();
                    objbll11.UpdateReprintFlag(varprintflag, varrecid, varperqty, varnotetext);

                    //dgvIfsdata.DataSource = null;
                    //dgvIfsdata.Rows.Clear();
                    //dgvIfsdata.DataSource = objbll6.ShowDataInDGV();
                }


                else
                {
                    MessageBox.Show("Y or N only!!!, No empty fields!!!", "Info");
                }
            }

            else if (columnIndex == 9)
            {
                char varprintflag = Convert.ToChar(dgvReprint.Rows[e.RowIndex].Cells[18].Value);
                //MessageBox.Show(data);
                int varrecid = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[0].Value);
                //MessageBox.Show(data2);
                int varperqty = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[6].Value);

                string varnotetext = Convert.ToString(dgvReprint.Rows[e.RowIndex].Cells[9].Value);

                if (varprintflag == 'Y' || varprintflag == 'N')
                {


                    BLL objbll11 = new BLL();
                    objbll11.UpdateReprintFlag(varprintflag, varrecid, varperqty, varnotetext);

                    //dgvIfsdata.DataSource = null;
                    //dgvIfsdata.Rows.Clear();
                    //dgvIfsdata.DataSource = objbll6.ShowDataInDGV();
                }


                else
                {
                    MessageBox.Show("Y or N only!!!, No empty fields!!!", "Info");
                }
            }

            else if (columnIndex == 18)
            {
                char varprintflag = Convert.ToChar(dgvReprint.Rows[e.RowIndex].Cells[18].Value);
                //MessageBox.Show(data);
                int varrecid = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[0].Value);
                //MessageBox.Show(data2);
                int varperqty = Convert.ToInt32(dgvReprint.Rows[e.RowIndex].Cells[6].Value);

                string varnotetext = Convert.ToString(dgvReprint.Rows[e.RowIndex].Cells[9].Value);

                if (varprintflag == 'Y' || varprintflag == 'N')
                {


                    BLL objbll11 = new BLL();
                    objbll11.UpdateReprintFlag(varprintflag, varrecid, varperqty, varnotetext);

                    //dgvIfsdata.DataSource = null;
                    //dgvIfsdata.Rows.Clear();
                    //dgvIfsdata.DataSource = objbll6.ShowDataInDGV();
                }


                else
                {
                    MessageBox.Show("Y or N only!!!, No empty fields!!!", "Info");
                }
            }

            else
            {
                MessageBox.Show("Pls select from PER_QTY, NOTE_TEXT or PRINTED_YN columns!!!", "Info");
            }
        }

        private void dgvReprint_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvReprint.CancelEdit();
            }
        }

        private void dgvReprint_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lstboxPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lstboxPrinters.SelectedItem == null)
            //{
            //    return;
            //}
            //else 
            //{
            //    string printer = lstboxPrinters.SelectedItem.ToString().Trim();
            //    BLL objbll20 = new BLL();
            //    objbll20.SetPrinters(printer);
            //}

        }

        private void lstboxPrinters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lstboxPrinters.IndexFromPoint(e.Location);
            string printer = this.lstboxPrinters.SelectedItem.ToString().Trim();
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                DialogResult dialogResult = MessageBox.Show("Set As Default Printer?", "Info", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BLL objbll20 = new BLL();
                    objbll20.SetPrinters(printer);
                    lblDefaultprinter.Text = objbll20.GetDefaultPrinter();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }



            }
        }

        private void tabCardprint_Selecting(object sender, TabControlCancelEventArgs e)
        {

            // This blocks the user from opening the second tab
            if (e.Action == TabControlAction.Selecting && e.TabPageIndex == 1 && this.ret == 2)
                e.Cancel = true;

        }


    }
}
