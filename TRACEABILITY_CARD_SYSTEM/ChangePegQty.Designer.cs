namespace TRACEABILITY_CARD_SYSTEM
{
    partial class ChangePegQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePegQty));
            this.txtChngpegdopid = new System.Windows.Forms.TextBox();
            this.dgvChangepegqty = new System.Windows.Forms.DataGridView();
            this.btnSearchdop = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangepegqty)).BeginInit();
            this.SuspendLayout();
            // 
            // txtChngpegdopid
            // 
            this.txtChngpegdopid.Location = new System.Drawing.Point(99, 29);
            this.txtChngpegdopid.Name = "txtChngpegdopid";
            this.txtChngpegdopid.Size = new System.Drawing.Size(100, 20);
            this.txtChngpegdopid.TabIndex = 0;
            this.txtChngpegdopid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChngpegdopid_KeyDown);
            this.txtChngpegdopid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChngpegdopid_KeyPress);
            // 
            // dgvChangepegqty
            // 
            this.dgvChangepegqty.AllowUserToAddRows = false;
            this.dgvChangepegqty.AllowUserToDeleteRows = false;
            this.dgvChangepegqty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChangepegqty.Location = new System.Drawing.Point(12, 95);
            this.dgvChangepegqty.Name = "dgvChangepegqty";
            this.dgvChangepegqty.Size = new System.Drawing.Size(828, 292);
            this.dgvChangepegqty.TabIndex = 0;
            this.dgvChangepegqty.TabStop = false;
            this.dgvChangepegqty.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvChangepegqty_CellBeginEdit);
            this.dgvChangepegqty.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChangepegqty_CellEndEdit);
            this.dgvChangepegqty.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvChangepegqty_CellValidating);
            this.dgvChangepegqty.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChangepegqty_CellValueChanged);
            this.dgvChangepegqty.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvChangepegqty_MouseClick);
            // 
            // btnSearchdop
            // 
            this.btnSearchdop.Location = new System.Drawing.Point(244, 29);
            this.btnSearchdop.Name = "btnSearchdop";
            this.btnSearchdop.Size = new System.Drawing.Size(75, 23);
            this.btnSearchdop.TabIndex = 1;
            this.btnSearchdop.Text = "Search";
            this.btnSearchdop.UseVisualStyleBackColor = true;
            this.btnSearchdop.Click += new System.EventHandler(this.btnSearchdop_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(636, 402);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(718, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ChangePegQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 466);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnSearchdop);
            this.Controls.Add(this.dgvChangepegqty);
            this.Controls.Add(this.txtChngpegdopid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(870, 500);
            this.MinimumSize = new System.Drawing.Size(870, 500);
            this.Name = "ChangePegQty";
            this.ShowInTaskbar = false;
            this.Text = "Change_Pegged_Qty";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangepegqty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChngpegdopid;
        private System.Windows.Forms.DataGridView dgvChangepegqty;
        private System.Windows.Forms.Button btnSearchdop;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}