namespace TRACEABILITY_CARD_SYSTEM
{
    partial class Traceability_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Traceability_Main));
            this.txtDopid = new System.Windows.Forms.TextBox();
            this.dgvIfsdata = new System.Windows.Forms.DataGridView();
            this.RECIDPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOPIDPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTRACTPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PART_NOPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTIONPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOT_PEGGED_QTYPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PER_QTYPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAG_QTYPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REM_QTYPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTE_TEXTPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARD_QTYPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENT_CARD_NOPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_EPF_NOPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATEDPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDATEDPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTEDPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTED_QTYPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAL_PRINT_QTYPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTED_YNPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRACE_NOPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NOPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIfsdatafetch = new System.Windows.Forms.Button();
            this.btnFetchifstodsi = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.prgrsbar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabCardprint = new System.Windows.Forms.TabControl();
            this.tabpgPrint = new System.Windows.Forms.TabPage();
            this.tabpgReprint = new System.Windows.Forms.TabPage();
            this.dgvReprint = new System.Windows.Forms.DataGridView();
            this.RECID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTRACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PART_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOT_PEGGED_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PER_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAG_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REM_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTE_TEXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARD_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENT_CARD_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OP_EPF_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPDATED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTED_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAL_PRINT_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTED_YN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRACE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CARD_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabpgPrinters = new System.Windows.Forms.TabPage();
            this.lblDefaultprinter = new System.Windows.Forms.Label();
            this.lstboxPrinters = new System.Windows.Forms.ListBox();
            this.dtpTraceno = new System.Windows.Forms.DateTimePicker();
            this.btnPrintdopid = new System.Windows.Forms.Button();
            this.txtPrintdop = new System.Windows.Forms.TextBox();
            this.cntxtmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyitem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteitem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangepegqty = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIfsdata)).BeginInit();
            this.tabCardprint.SuspendLayout();
            this.tabpgPrint.SuspendLayout();
            this.tabpgReprint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReprint)).BeginInit();
            this.tabpgPrinters.SuspendLayout();
            this.cntxtmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDopid
            // 
            this.txtDopid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDopid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDopid.Location = new System.Drawing.Point(62, 10);
            this.txtDopid.Name = "txtDopid";
            this.txtDopid.Size = new System.Drawing.Size(100, 23);
            this.txtDopid.TabIndex = 0;
            this.txtDopid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDopid_KeyDown);
            this.txtDopid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDopid_KeyPress);
            // 
            // dgvIfsdata
            // 
            this.dgvIfsdata.AllowUserToAddRows = false;
            this.dgvIfsdata.AllowUserToDeleteRows = false;
            this.dgvIfsdata.AllowUserToResizeRows = false;
            this.dgvIfsdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIfsdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RECIDPrint,
            this.DOPIDPrint,
            this.CONTRACTPrint,
            this.PART_NOPrint,
            this.DESCRIPTIONPrint,
            this.TOT_PEGGED_QTYPrint,
            this.PER_QTYPrint,
            this.BAG_QTYPrint,
            this.REM_QTYPrint,
            this.NOTE_TEXTPrint,
            this.CARD_QTYPrint,
            this.CURRENT_CARD_NOPrint,
            this.OP_EPF_NOPrint,
            this.CREATEDPrint,
            this.UPDATEDPrint,
            this.PRINTEDPrint,
            this.PRINTED_QTYPrint,
            this.BAL_PRINT_QTYPrint,
            this.PRINTED_YNPrint,
            this.TRACE_NOPrint,
            this.ORDER_NOPrint});
            this.dgvIfsdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIfsdata.Location = new System.Drawing.Point(3, 3);
            this.dgvIfsdata.Name = "dgvIfsdata";
            this.dgvIfsdata.Size = new System.Drawing.Size(881, 568);
            this.dgvIfsdata.TabIndex = 1;
            this.dgvIfsdata.TabStop = false;
            this.dgvIfsdata.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvIfsdata_CellBeginEdit);
            this.dgvIfsdata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIfsdata_CellEndEdit);
            this.dgvIfsdata.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvIfsdata_CellValidating);
            this.dgvIfsdata.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIfsdata_CellValueChanged);
            this.dgvIfsdata.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvIfsdata_MouseClick);
            // 
            // RECIDPrint
            // 
            this.RECIDPrint.DataPropertyName = "RECID";
            this.RECIDPrint.HeaderText = "RECID";
            this.RECIDPrint.Name = "RECIDPrint";
            this.RECIDPrint.ReadOnly = true;
            // 
            // DOPIDPrint
            // 
            this.DOPIDPrint.DataPropertyName = "DOP_ID";
            this.DOPIDPrint.HeaderText = "DOP_ID";
            this.DOPIDPrint.Name = "DOPIDPrint";
            this.DOPIDPrint.ReadOnly = true;
            // 
            // CONTRACTPrint
            // 
            this.CONTRACTPrint.DataPropertyName = "CONTRACT";
            this.CONTRACTPrint.HeaderText = "CONTRACT";
            this.CONTRACTPrint.Name = "CONTRACTPrint";
            this.CONTRACTPrint.ReadOnly = true;
            // 
            // PART_NOPrint
            // 
            this.PART_NOPrint.DataPropertyName = "PART_NO";
            this.PART_NOPrint.HeaderText = "PART_NO";
            this.PART_NOPrint.Name = "PART_NOPrint";
            this.PART_NOPrint.ReadOnly = true;
            // 
            // DESCRIPTIONPrint
            // 
            this.DESCRIPTIONPrint.DataPropertyName = "DESCRIPTION";
            this.DESCRIPTIONPrint.HeaderText = "DESCRIPTION";
            this.DESCRIPTIONPrint.Name = "DESCRIPTIONPrint";
            this.DESCRIPTIONPrint.ReadOnly = true;
            // 
            // TOT_PEGGED_QTYPrint
            // 
            this.TOT_PEGGED_QTYPrint.DataPropertyName = "TOT_PEGGED_QTY";
            this.TOT_PEGGED_QTYPrint.HeaderText = "TOT_PEGGED_QTY";
            this.TOT_PEGGED_QTYPrint.Name = "TOT_PEGGED_QTYPrint";
            this.TOT_PEGGED_QTYPrint.ReadOnly = true;
            // 
            // PER_QTYPrint
            // 
            this.PER_QTYPrint.DataPropertyName = "PER_QTY";
            this.PER_QTYPrint.HeaderText = "PER_QTY";
            this.PER_QTYPrint.Name = "PER_QTYPrint";
            // 
            // BAG_QTYPrint
            // 
            this.BAG_QTYPrint.DataPropertyName = "BAG_QTY";
            this.BAG_QTYPrint.HeaderText = "BAG_QTY";
            this.BAG_QTYPrint.Name = "BAG_QTYPrint";
            this.BAG_QTYPrint.ReadOnly = true;
            // 
            // REM_QTYPrint
            // 
            this.REM_QTYPrint.DataPropertyName = "REM_QTY";
            this.REM_QTYPrint.HeaderText = "REM_QTY";
            this.REM_QTYPrint.Name = "REM_QTYPrint";
            this.REM_QTYPrint.ReadOnly = true;
            // 
            // NOTE_TEXTPrint
            // 
            this.NOTE_TEXTPrint.DataPropertyName = "NOTE_TEXT";
            this.NOTE_TEXTPrint.HeaderText = "NOTE_TEXT";
            this.NOTE_TEXTPrint.Name = "NOTE_TEXTPrint";
            // 
            // CARD_QTYPrint
            // 
            this.CARD_QTYPrint.DataPropertyName = "CARD_QTY";
            this.CARD_QTYPrint.HeaderText = "CARD_QTY";
            this.CARD_QTYPrint.Name = "CARD_QTYPrint";
            this.CARD_QTYPrint.ReadOnly = true;
            // 
            // CURRENT_CARD_NOPrint
            // 
            this.CURRENT_CARD_NOPrint.DataPropertyName = "CURRENT_CARD_NO";
            this.CURRENT_CARD_NOPrint.HeaderText = "CURRENT_CARD_NO";
            this.CURRENT_CARD_NOPrint.Name = "CURRENT_CARD_NOPrint";
            this.CURRENT_CARD_NOPrint.ReadOnly = true;
            // 
            // OP_EPF_NOPrint
            // 
            this.OP_EPF_NOPrint.DataPropertyName = "OP_EPF_NO";
            this.OP_EPF_NOPrint.HeaderText = "OP_EPF_NO";
            this.OP_EPF_NOPrint.Name = "OP_EPF_NOPrint";
            this.OP_EPF_NOPrint.ReadOnly = true;
            // 
            // CREATEDPrint
            // 
            this.CREATEDPrint.DataPropertyName = "CREATED";
            this.CREATEDPrint.HeaderText = "CREATED";
            this.CREATEDPrint.Name = "CREATEDPrint";
            this.CREATEDPrint.ReadOnly = true;
            // 
            // UPDATEDPrint
            // 
            this.UPDATEDPrint.DataPropertyName = "UPDATED";
            this.UPDATEDPrint.HeaderText = "UPDATED";
            this.UPDATEDPrint.Name = "UPDATEDPrint";
            this.UPDATEDPrint.ReadOnly = true;
            // 
            // PRINTEDPrint
            // 
            this.PRINTEDPrint.DataPropertyName = "PRINTED";
            this.PRINTEDPrint.HeaderText = "PRINTED";
            this.PRINTEDPrint.Name = "PRINTEDPrint";
            this.PRINTEDPrint.ReadOnly = true;
            // 
            // PRINTED_QTYPrint
            // 
            this.PRINTED_QTYPrint.DataPropertyName = "PRINTED_QTY";
            this.PRINTED_QTYPrint.HeaderText = "PRINTED_QTY";
            this.PRINTED_QTYPrint.Name = "PRINTED_QTYPrint";
            this.PRINTED_QTYPrint.ReadOnly = true;
            // 
            // BAL_PRINT_QTYPrint
            // 
            this.BAL_PRINT_QTYPrint.DataPropertyName = "BAL_PRINT_QTY";
            this.BAL_PRINT_QTYPrint.HeaderText = "BAL_PRINT_QTY";
            this.BAL_PRINT_QTYPrint.Name = "BAL_PRINT_QTYPrint";
            this.BAL_PRINT_QTYPrint.ReadOnly = true;
            // 
            // PRINTED_YNPrint
            // 
            this.PRINTED_YNPrint.DataPropertyName = "PRINTED_YN";
            this.PRINTED_YNPrint.HeaderText = "PRINTED_YN";
            this.PRINTED_YNPrint.Name = "PRINTED_YNPrint";
            this.PRINTED_YNPrint.ReadOnly = true;
            // 
            // TRACE_NOPrint
            // 
            this.TRACE_NOPrint.DataPropertyName = "TRACE_NO";
            this.TRACE_NOPrint.HeaderText = "TRACE_NO";
            this.TRACE_NOPrint.Name = "TRACE_NOPrint";
            this.TRACE_NOPrint.ReadOnly = true;
            // 
            // ORDER_NOPrint
            // 
            this.ORDER_NOPrint.DataPropertyName = "ORDER_NO";
            this.ORDER_NOPrint.HeaderText = "ORDER_NO";
            this.ORDER_NOPrint.Name = "ORDER_NOPrint";
            this.ORDER_NOPrint.ReadOnly = true;
            // 
            // btnIfsdatafetch
            // 
            this.btnIfsdatafetch.Enabled = false;
            this.btnIfsdatafetch.Location = new System.Drawing.Point(402, 10);
            this.btnIfsdatafetch.Name = "btnIfsdatafetch";
            this.btnIfsdatafetch.Size = new System.Drawing.Size(110, 55);
            this.btnIfsdatafetch.TabIndex = 5;
            this.btnIfsdatafetch.Text = "FETCH FROM IFS";
            this.btnIfsdatafetch.UseVisualStyleBackColor = true;
            this.btnIfsdatafetch.Click += new System.EventHandler(this.btnIfsdatafetch_Click);
            // 
            // btnFetchifstodsi
            // 
            this.btnFetchifstodsi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnFetchifstodsi.Location = new System.Drawing.Point(168, 10);
            this.btnFetchifstodsi.Name = "btnFetchifstodsi";
            this.btnFetchifstodsi.Size = new System.Drawing.Size(111, 54);
            this.btnFetchifstodsi.TabIndex = 2;
            this.btnFetchifstodsi.Text = "FETCH";
            this.btnFetchifstodsi.UseVisualStyleBackColor = false;
            this.btnFetchifstodsi.Click += new System.EventHandler(this.btnFetchifstodsi_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(568, 42);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(100, 23);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "SHOW ALL";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrint.Location = new System.Drawing.Point(285, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 55);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "PRINT EXPORT ORDERS";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "DOP ID";
            // 
            // prgrsbar
            // 
            this.prgrsbar.Enabled = false;
            this.prgrsbar.Location = new System.Drawing.Point(801, 9);
            this.prgrsbar.Name = "prgrsbar";
            this.prgrsbar.Size = new System.Drawing.Size(100, 23);
            this.prgrsbar.TabIndex = 8;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // tabCardprint
            // 
            this.tabCardprint.Controls.Add(this.tabpgPrint);
            this.tabCardprint.Controls.Add(this.tabpgReprint);
            this.tabCardprint.Controls.Add(this.tabpgPrinters);
            this.tabCardprint.Location = new System.Drawing.Point(6, 65);
            this.tabCardprint.Name = "tabCardprint";
            this.tabCardprint.SelectedIndex = 0;
            this.tabCardprint.Size = new System.Drawing.Size(895, 600);
            this.tabCardprint.TabIndex = 9;
            this.tabCardprint.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabCardprint_Selecting);
            // 
            // tabpgPrint
            // 
            this.tabpgPrint.Controls.Add(this.dgvIfsdata);
            this.tabpgPrint.Location = new System.Drawing.Point(4, 22);
            this.tabpgPrint.Name = "tabpgPrint";
            this.tabpgPrint.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgPrint.Size = new System.Drawing.Size(887, 574);
            this.tabpgPrint.TabIndex = 0;
            this.tabpgPrint.Text = "PRINT";
            this.tabpgPrint.UseVisualStyleBackColor = true;
            // 
            // tabpgReprint
            // 
            this.tabpgReprint.Controls.Add(this.dgvReprint);
            this.tabpgReprint.Location = new System.Drawing.Point(4, 22);
            this.tabpgReprint.Name = "tabpgReprint";
            this.tabpgReprint.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgReprint.Size = new System.Drawing.Size(887, 574);
            this.tabpgReprint.TabIndex = 1;
            this.tabpgReprint.Text = "RE-PRINT";
            this.tabpgReprint.UseVisualStyleBackColor = true;
            // 
            // dgvReprint
            // 
            this.dgvReprint.AllowUserToAddRows = false;
            this.dgvReprint.AllowUserToDeleteRows = false;
            this.dgvReprint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReprint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RECID,
            this.DOP_ID,
            this.CONTRACT,
            this.PART_NO,
            this.DESCRIPTION,
            this.TOT_PEGGED_QTY,
            this.PER_QTY,
            this.BAG_QTY,
            this.REM_QTY,
            this.NOTE_TEXT,
            this.CARD_QTY,
            this.CURRENT_CARD_NO,
            this.OP_EPF_NO,
            this.CREATED,
            this.UPDATED,
            this.PRINTED,
            this.PRINTED_QTY,
            this.BAL_PRINT_QTY,
            this.PRINTED_YN,
            this.TRACE_NO,
            this.CARD_COUNT,
            this.ORDER_NO});
            this.dgvReprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReprint.Location = new System.Drawing.Point(3, 3);
            this.dgvReprint.Name = "dgvReprint";
            this.dgvReprint.Size = new System.Drawing.Size(881, 568);
            this.dgvReprint.TabIndex = 0;
            this.dgvReprint.TabStop = false;
            this.dgvReprint.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvReprint_CellBeginEdit);
            this.dgvReprint.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReprint_CellEndEdit);
            this.dgvReprint.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvReprint_CellValidating);
            this.dgvReprint.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReprint_CellValueChanged);
            // 
            // RECID
            // 
            this.RECID.DataPropertyName = "RECID";
            this.RECID.HeaderText = "RECID";
            this.RECID.Name = "RECID";
            this.RECID.ReadOnly = true;
            // 
            // DOP_ID
            // 
            this.DOP_ID.DataPropertyName = "DOP_ID";
            this.DOP_ID.HeaderText = "DOP_ID";
            this.DOP_ID.Name = "DOP_ID";
            this.DOP_ID.ReadOnly = true;
            // 
            // CONTRACT
            // 
            this.CONTRACT.DataPropertyName = "CONTRACT";
            this.CONTRACT.HeaderText = "CONTRACT";
            this.CONTRACT.Name = "CONTRACT";
            this.CONTRACT.ReadOnly = true;
            // 
            // PART_NO
            // 
            this.PART_NO.DataPropertyName = "PART_NO";
            this.PART_NO.HeaderText = "PART_NO";
            this.PART_NO.Name = "PART_NO";
            this.PART_NO.ReadOnly = true;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.DataPropertyName = "DESCRIPTION";
            this.DESCRIPTION.HeaderText = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.ReadOnly = true;
            // 
            // TOT_PEGGED_QTY
            // 
            this.TOT_PEGGED_QTY.DataPropertyName = "TOT_PEGGED_QTY";
            this.TOT_PEGGED_QTY.HeaderText = "TOT_PEGGED_QTY";
            this.TOT_PEGGED_QTY.Name = "TOT_PEGGED_QTY";
            this.TOT_PEGGED_QTY.ReadOnly = true;
            // 
            // PER_QTY
            // 
            this.PER_QTY.DataPropertyName = "PER_QTY";
            this.PER_QTY.HeaderText = "PER_QTY";
            this.PER_QTY.Name = "PER_QTY";
            // 
            // BAG_QTY
            // 
            this.BAG_QTY.DataPropertyName = "BAG_QTY";
            this.BAG_QTY.HeaderText = "BAG_QTY";
            this.BAG_QTY.Name = "BAG_QTY";
            this.BAG_QTY.ReadOnly = true;
            // 
            // REM_QTY
            // 
            this.REM_QTY.DataPropertyName = "REM_QTY";
            this.REM_QTY.HeaderText = "REM_QTY";
            this.REM_QTY.Name = "REM_QTY";
            this.REM_QTY.ReadOnly = true;
            // 
            // NOTE_TEXT
            // 
            this.NOTE_TEXT.DataPropertyName = "NOTE_TEXT";
            this.NOTE_TEXT.HeaderText = "NOTE_TEXT";
            this.NOTE_TEXT.Name = "NOTE_TEXT";
            // 
            // CARD_QTY
            // 
            this.CARD_QTY.DataPropertyName = "CARD_QTY";
            this.CARD_QTY.HeaderText = "CARD_QTY";
            this.CARD_QTY.Name = "CARD_QTY";
            this.CARD_QTY.ReadOnly = true;
            // 
            // CURRENT_CARD_NO
            // 
            this.CURRENT_CARD_NO.DataPropertyName = "CURRENT_CARD_NO";
            this.CURRENT_CARD_NO.HeaderText = "CURRENT_CARD_NO";
            this.CURRENT_CARD_NO.Name = "CURRENT_CARD_NO";
            this.CURRENT_CARD_NO.ReadOnly = true;
            // 
            // OP_EPF_NO
            // 
            this.OP_EPF_NO.DataPropertyName = "OP_EPF_NO";
            this.OP_EPF_NO.HeaderText = "OP_EPF_NO";
            this.OP_EPF_NO.Name = "OP_EPF_NO";
            this.OP_EPF_NO.ReadOnly = true;
            // 
            // CREATED
            // 
            this.CREATED.DataPropertyName = "CREATED";
            this.CREATED.HeaderText = "CREATED";
            this.CREATED.Name = "CREATED";
            this.CREATED.ReadOnly = true;
            // 
            // UPDATED
            // 
            this.UPDATED.DataPropertyName = "UPDATED";
            this.UPDATED.HeaderText = "UPDATED";
            this.UPDATED.Name = "UPDATED";
            this.UPDATED.ReadOnly = true;
            // 
            // PRINTED
            // 
            this.PRINTED.DataPropertyName = "PRINTED";
            this.PRINTED.HeaderText = "PRINTED";
            this.PRINTED.Name = "PRINTED";
            this.PRINTED.ReadOnly = true;
            // 
            // PRINTED_QTY
            // 
            this.PRINTED_QTY.DataPropertyName = "PRINTED_QTY";
            this.PRINTED_QTY.HeaderText = "PRINTED_QTY";
            this.PRINTED_QTY.Name = "PRINTED_QTY";
            this.PRINTED_QTY.ReadOnly = true;
            // 
            // BAL_PRINT_QTY
            // 
            this.BAL_PRINT_QTY.DataPropertyName = "BAL_PRINT_QTY";
            this.BAL_PRINT_QTY.HeaderText = "BAL_PRINT_QTY";
            this.BAL_PRINT_QTY.Name = "BAL_PRINT_QTY";
            this.BAL_PRINT_QTY.ReadOnly = true;
            // 
            // PRINTED_YN
            // 
            this.PRINTED_YN.DataPropertyName = "PRINTED_YN";
            this.PRINTED_YN.HeaderText = "PRINTED_YN";
            this.PRINTED_YN.Name = "PRINTED_YN";
            // 
            // TRACE_NO
            // 
            this.TRACE_NO.DataPropertyName = "TRACE_NO";
            this.TRACE_NO.HeaderText = "TRACE_NO";
            this.TRACE_NO.Name = "TRACE_NO";
            this.TRACE_NO.ReadOnly = true;
            // 
            // CARD_COUNT
            // 
            this.CARD_COUNT.DataPropertyName = "CARD_COUNT";
            this.CARD_COUNT.HeaderText = "CARD_COUNT";
            this.CARD_COUNT.Name = "CARD_COUNT";
            this.CARD_COUNT.ReadOnly = true;
            // 
            // ORDER_NO
            // 
            this.ORDER_NO.DataPropertyName = "ORDER_NO";
            this.ORDER_NO.HeaderText = "ORDER_NO";
            this.ORDER_NO.Name = "ORDER_NO";
            this.ORDER_NO.ReadOnly = true;
            // 
            // tabpgPrinters
            // 
            this.tabpgPrinters.Controls.Add(this.lblDefaultprinter);
            this.tabpgPrinters.Controls.Add(this.lstboxPrinters);
            this.tabpgPrinters.Location = new System.Drawing.Point(4, 22);
            this.tabpgPrinters.Name = "tabpgPrinters";
            this.tabpgPrinters.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgPrinters.Size = new System.Drawing.Size(887, 574);
            this.tabpgPrinters.TabIndex = 2;
            this.tabpgPrinters.Text = "PRINTERS";
            this.tabpgPrinters.UseVisualStyleBackColor = true;
            // 
            // lblDefaultprinter
            // 
            this.lblDefaultprinter.AutoSize = true;
            this.lblDefaultprinter.Location = new System.Drawing.Point(569, 33);
            this.lblDefaultprinter.Name = "lblDefaultprinter";
            this.lblDefaultprinter.Size = new System.Drawing.Size(0, 13);
            this.lblDefaultprinter.TabIndex = 1;
            // 
            // lstboxPrinters
            // 
            this.lstboxPrinters.FormattingEnabled = true;
            this.lstboxPrinters.Location = new System.Drawing.Point(21, 20);
            this.lstboxPrinters.Name = "lstboxPrinters";
            this.lstboxPrinters.Size = new System.Drawing.Size(365, 485);
            this.lstboxPrinters.TabIndex = 0;
            this.lstboxPrinters.SelectedIndexChanged += new System.EventHandler(this.lstboxPrinters_SelectedIndexChanged);
            this.lstboxPrinters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstboxPrinters_MouseDoubleClick);
            // 
            // dtpTraceno
            // 
            this.dtpTraceno.Location = new System.Drawing.Point(62, 39);
            this.dtpTraceno.Name = "dtpTraceno";
            this.dtpTraceno.Size = new System.Drawing.Size(100, 20);
            this.dtpTraceno.TabIndex = 1;
            // 
            // btnPrintdopid
            // 
            this.btnPrintdopid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrintdopid.Location = new System.Drawing.Point(674, 9);
            this.btnPrintdopid.Name = "btnPrintdopid";
            this.btnPrintdopid.Size = new System.Drawing.Size(111, 54);
            this.btnPrintdopid.TabIndex = 5;
            this.btnPrintdopid.Text = "PRINT WITH DOP LOCAL ORDERS";
            this.btnPrintdopid.UseVisualStyleBackColor = false;
            this.btnPrintdopid.Click += new System.EventHandler(this.btnPrintdopid_Click);
            // 
            // txtPrintdop
            // 
            this.txtPrintdop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPrintdop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrintdop.Location = new System.Drawing.Point(568, 9);
            this.txtPrintdop.Name = "txtPrintdop";
            this.txtPrintdop.Size = new System.Drawing.Size(100, 23);
            this.txtPrintdop.TabIndex = 4;
            this.txtPrintdop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrintdop_KeyDown);
            this.txtPrintdop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrintdop_KeyPress);
            // 
            // cntxtmenu
            // 
            this.cntxtmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyitem,
            this.pasteitem});
            this.cntxtmenu.Name = "cntxtmenu";
            this.cntxtmenu.Size = new System.Drawing.Size(103, 48);
            // 
            // copyitem
            // 
            this.copyitem.Name = "copyitem";
            this.copyitem.Size = new System.Drawing.Size(102, 22);
            this.copyitem.Text = "Copy";
            // 
            // pasteitem
            // 
            this.pasteitem.Name = "pasteitem";
            this.pasteitem.Size = new System.Drawing.Size(102, 22);
            this.pasteitem.Text = "Paste";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "DOP ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TRC NO";
            // 
            // btnChangepegqty
            // 
            this.btnChangepegqty.Location = new System.Drawing.Point(801, 39);
            this.btnChangepegqty.Name = "btnChangepegqty";
            this.btnChangepegqty.Size = new System.Drawing.Size(93, 42);
            this.btnChangepegqty.TabIndex = 12;
            this.btnChangepegqty.Text = "Change Pegged Qty";
            this.btnChangepegqty.UseVisualStyleBackColor = true;
            this.btnChangepegqty.Click += new System.EventHandler(this.btnChangepegqty_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(947, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 13);
            this.lblUsername.TabIndex = 13;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(947, 39);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 13);
            this.lblLevel.TabIndex = 14;
            // 
            // Traceability_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 616);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnChangepegqty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTraceno);
            this.Controls.Add(this.txtPrintdop);
            this.Controls.Add(this.tabCardprint);
            this.Controls.Add(this.prgrsbar);
            this.Controls.Add(this.btnPrintdopid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnFetchifstodsi);
            this.Controls.Add(this.btnIfsdatafetch);
            this.Controls.Add(this.txtDopid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Traceability_Main";
            this.Text = "Traceability Card System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Traceability_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIfsdata)).EndInit();
            this.tabCardprint.ResumeLayout(false);
            this.tabpgPrint.ResumeLayout(false);
            this.tabpgReprint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReprint)).EndInit();
            this.tabpgPrinters.ResumeLayout(false);
            this.tabpgPrinters.PerformLayout();
            this.cntxtmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDopid;
        private System.Windows.Forms.DataGridView dgvIfsdata;
        private System.Windows.Forms.Button btnIfsdatafetch;
        private System.Windows.Forms.Button btnFetchifstodsi;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prgrsbar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TabControl tabCardprint;
        private System.Windows.Forms.TabPage tabpgPrint;
        private System.Windows.Forms.TabPage tabpgReprint;
        private System.Windows.Forms.DataGridView dgvReprint;
        private System.Windows.Forms.DateTimePicker dtpTraceno;
        private System.Windows.Forms.Button btnPrintdopid;
        private System.Windows.Forms.TextBox txtPrintdop;
        private System.Windows.Forms.ContextMenuStrip cntxtmenu;
        private System.Windows.Forms.ToolStripMenuItem copyitem;
        private System.Windows.Forms.ToolStripMenuItem pasteitem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangepegqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOP_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTRACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOT_PEGGED_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PER_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn REM_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTE_TEXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARD_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENT_CARD_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_EPF_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATED;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPDATED;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTED;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTED_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAL_PRINT_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTED_YN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRACE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARD_COUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECIDPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOPIDPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTRACTPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NOPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTIONPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOT_PEGGED_QTYPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PER_QTYPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAG_QTYPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn REM_QTYPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTE_TEXTPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CARD_QTYPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENT_CARD_NOPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn OP_EPF_NOPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATEDPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPDATEDPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTEDPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTED_QTYPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAL_PRINT_QTYPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTED_YNPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRACE_NOPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NOPrint;
        private System.Windows.Forms.TabPage tabpgPrinters;
        private System.Windows.Forms.ListBox lstboxPrinters;
        private System.Windows.Forms.Label lblDefaultprinter;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLevel;
    }
}

