namespace QLDSV_1
{
    partial class frmDiem
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
            System.Windows.Forms.Label mALOPLabel;
            System.Windows.Forms.Label tENLOPLabel;
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label tENMHLabel;
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbBoPhan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbDiem = new System.Windows.Forms.GroupBox();
            this.txtTenMH = new DevExpress.XtraEditors.TextEdit();
            this.bdsMonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new QLDSV_1.DS();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLanThi = new System.Windows.Forms.ComboBox();
            this.cmbMaMH = new System.Windows.Forms.ComboBox();
            this.txtTenLop = new DevExpress.XtraEditors.TextEdit();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMaLop = new System.Windows.Forms.ComboBox();
            this.lOPTableAdapter = new QLDSV_1.DSTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new QLDSV_1.DSTableAdapters.TableAdapterManager();
            this.mONHOCTableAdapter = new QLDSV_1.DSTableAdapters.MONHOCTableAdapter();
            this.bdsSPSuaDiem = new System.Windows.Forms.BindingSource(this.components);
            this.sP_SUADIEMMONHOCTableAdapter = new QLDSV_1.DSTableAdapters.SP_SUADIEMMONHOCTableAdapter();
            this.grctrlSPSuaDiem = new DevExpress.XtraGrid.GridControl();
            this.grvSPSuaDiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbOKCancel = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.bdsSPNhapDiem = new System.Windows.Forms.BindingSource(this.components);
            this.sP_NHAPDIEMMONHOCTableAdapter = new QLDSV_1.DSTableAdapters.SP_NHAPDIEMMONHOCTableAdapter();
            this.grctrlSPNhapDiem = new DevExpress.XtraGrid.GridControl();
            this.grvSPNhapDiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMASV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIEM = new DevExpress.XtraGrid.Columns.GridColumn();
            mALOPLabel = new System.Windows.Forms.Label();
            tENLOPLabel = new System.Windows.Forms.Label();
            mAMHLabel = new System.Windows.Forms.Label();
            tENMHLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grbDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSPSuaDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlSPSuaDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSPSuaDiem)).BeginInit();
            this.panel2.SuspendLayout();
            this.grbOKCancel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSPNhapDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlSPNhapDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSPNhapDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // mALOPLabel
            // 
            mALOPLabel.AutoSize = true;
            mALOPLabel.Location = new System.Drawing.Point(12, 25);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(51, 16);
            mALOPLabel.TabIndex = 0;
            mALOPLabel.Text = "Mã lớp:";
            // 
            // tENLOPLabel
            // 
            tENLOPLabel.AutoSize = true;
            tENLOPLabel.Location = new System.Drawing.Point(252, 25);
            tENLOPLabel.Name = "tENLOPLabel";
            tENLOPLabel.Size = new System.Drawing.Size(56, 16);
            tENLOPLabel.TabIndex = 2;
            tENLOPLabel.Text = "Tên lớp:";
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(12, 71);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(83, 16);
            mAMHLabel.TabIndex = 4;
            mAMHLabel.Text = "Mã môn học:";
            // 
            // tENMHLabel
            // 
            tENMHLabel.AutoSize = true;
            tENMHLabel.Location = new System.Drawing.Point(252, 71);
            tENMHLabel.Name = "tENMHLabel";
            tENMHLabel.Size = new System.Drawing.Size(88, 16);
            tENMHLabel.TabIndex = 6;
            tENMHLabel.Text = "Tên môn học:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbBoPhan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 70);
            this.panel1.TabIndex = 0;
            // 
            // cmbBoPhan
            // 
            this.cmbBoPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoPhan.FormattingEnabled = true;
            this.cmbBoPhan.Location = new System.Drawing.Point(123, 24);
            this.cmbBoPhan.Name = "cmbBoPhan";
            this.cmbBoPhan.Size = new System.Drawing.Size(700, 24);
            this.cmbBoPhan.TabIndex = 3;
            this.cmbBoPhan.SelectedIndexChanged += new System.EventHandler(this.cmbBoPhan_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bộ phận: ";
            // 
            // grbDiem
            // 
            this.grbDiem.Controls.Add(this.txtTenMH);
            this.grbDiem.Controls.Add(this.btnBatDau);
            this.grbDiem.Controls.Add(this.label2);
            this.grbDiem.Controls.Add(this.cmbLanThi);
            this.grbDiem.Controls.Add(tENMHLabel);
            this.grbDiem.Controls.Add(mAMHLabel);
            this.grbDiem.Controls.Add(this.cmbMaMH);
            this.grbDiem.Controls.Add(tENLOPLabel);
            this.grbDiem.Controls.Add(this.txtTenLop);
            this.grbDiem.Controls.Add(mALOPLabel);
            this.grbDiem.Controls.Add(this.cmbMaLop);
            this.grbDiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbDiem.Location = new System.Drawing.Point(0, 0);
            this.grbDiem.Name = "grbDiem";
            this.grbDiem.Size = new System.Drawing.Size(830, 117);
            this.grbDiem.TabIndex = 1;
            this.grbDiem.TabStop = false;
            // 
            // txtTenMH
            // 
            this.txtTenMH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsMonHoc, "TENMH", true));
            this.txtTenMH.Location = new System.Drawing.Point(346, 69);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(231, 20);
            this.txtTenMH.TabIndex = 11;
            // 
            // bdsMonHoc
            // 
            this.bdsMonHoc.DataMember = "MONHOC";
            this.bdsMonHoc.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(735, 45);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(75, 23);
            this.btnBatDau.TabIndex = 10;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lần thi:";
            // 
            // cmbLanThi
            // 
            this.cmbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanThi.FormattingEnabled = true;
            this.cmbLanThi.Location = new System.Drawing.Point(659, 67);
            this.cmbLanThi.Name = "cmbLanThi";
            this.cmbLanThi.Size = new System.Drawing.Size(54, 24);
            this.cmbLanThi.TabIndex = 8;
            // 
            // cmbMaMH
            // 
            this.cmbMaMH.DataSource = this.bdsMonHoc;
            this.cmbMaMH.DisplayMember = "MAMH";
            this.cmbMaMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaMH.FormattingEnabled = true;
            this.cmbMaMH.Location = new System.Drawing.Point(101, 67);
            this.cmbMaMH.Name = "cmbMaMH";
            this.cmbMaMH.Size = new System.Drawing.Size(128, 24);
            this.cmbMaMH.TabIndex = 5;
            this.cmbMaMH.ValueMember = "MAMH";
            // 
            // txtTenLop
            // 
            this.txtTenLop.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLop, "TENLOP", true));
            this.txtTenLop.Location = new System.Drawing.Point(310, 23);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(403, 20);
            this.txtTenLop.TabIndex = 3;
            // 
            // bdsLop
            // 
            this.bdsLop.DataMember = "LOP";
            this.bdsLop.DataSource = this.DS;
            // 
            // cmbMaLop
            // 
            this.cmbMaLop.DataSource = this.bdsLop;
            this.cmbMaLop.DisplayMember = "MALOP";
            this.cmbMaLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaLop.FormattingEnabled = true;
            this.cmbMaLop.Location = new System.Drawing.Point(71, 21);
            this.cmbMaLop.Name = "cmbMaLop";
            this.cmbMaLop.Size = new System.Drawing.Size(158, 24);
            this.cmbMaLop.TabIndex = 1;
            this.cmbMaLop.ValueMember = "MALOP";
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DIEMTableAdapter = null;
            this.tableAdapterManager.GIANGVIENTableAdapter = null;
            this.tableAdapterManager.HOCPHITableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = this.lOPTableAdapter;
            this.tableAdapterManager.MONHOCTableAdapter = this.mONHOCTableAdapter;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV_1.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // bdsSPSuaDiem
            // 
            this.bdsSPSuaDiem.DataMember = "SP_SUADIEMMONHOC";
            this.bdsSPSuaDiem.DataSource = this.DS;
            // 
            // sP_SUADIEMMONHOCTableAdapter
            // 
            this.sP_SUADIEMMONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // grctrlSPSuaDiem
            // 
            this.grctrlSPSuaDiem.DataSource = this.bdsSPSuaDiem;
            this.grctrlSPSuaDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grctrlSPSuaDiem.Location = new System.Drawing.Point(0, 407);
            this.grctrlSPSuaDiem.MainView = this.grvSPSuaDiem;
            this.grctrlSPSuaDiem.Name = "grctrlSPSuaDiem";
            this.grctrlSPSuaDiem.Size = new System.Drawing.Size(1039, 287);
            this.grctrlSPSuaDiem.TabIndex = 4;
            this.grctrlSPSuaDiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSPSuaDiem});
            // 
            // grvSPSuaDiem
            // 
            this.grvSPSuaDiem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grvSPSuaDiem.GridControl = this.grctrlSPSuaDiem;
            this.grvSPSuaDiem.Name = "grvSPSuaDiem";
            this.grvSPSuaDiem.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Mã SV";
            this.gridColumn1.FieldName = "MASV";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Họ và tên";
            this.gridColumn2.FieldName = "HOTEN";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Điểm";
            this.gridColumn3.FieldName = "DIEM";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grbOKCancel);
            this.panel2.Controls.Add(this.grbDiem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1039, 117);
            this.panel2.TabIndex = 5;
            // 
            // grbOKCancel
            // 
            this.grbOKCancel.Controls.Add(this.btnCancel);
            this.grbOKCancel.Controls.Add(this.btnOK);
            this.grbOKCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbOKCancel.Location = new System.Drawing.Point(830, 0);
            this.grbOKCancel.Name = "grbOKCancel";
            this.grbOKCancel.Size = new System.Drawing.Size(209, 117);
            this.grbOKCancel.TabIndex = 6;
            this.grbOKCancel.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(19, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(19, 22);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // bdsSPNhapDiem
            // 
            this.bdsSPNhapDiem.DataMember = "SP_NHAPDIEMMONHOC";
            this.bdsSPNhapDiem.DataSource = this.DS;
            // 
            // sP_NHAPDIEMMONHOCTableAdapter
            // 
            this.sP_NHAPDIEMMONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // grctrlSPNhapDiem
            // 
            this.grctrlSPNhapDiem.DataSource = this.bdsSPNhapDiem;
            this.grctrlSPNhapDiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grctrlSPNhapDiem.Location = new System.Drawing.Point(0, 187);
            this.grctrlSPNhapDiem.MainView = this.grvSPNhapDiem;
            this.grctrlSPNhapDiem.Name = "grctrlSPNhapDiem";
            this.grctrlSPNhapDiem.Size = new System.Drawing.Size(1039, 220);
            this.grctrlSPNhapDiem.TabIndex = 6;
            this.grctrlSPNhapDiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSPNhapDiem});
            // 
            // grvSPNhapDiem
            // 
            this.grvSPNhapDiem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMASV,
            this.colHOTEN,
            this.colDIEM});
            this.grvSPNhapDiem.GridControl = this.grctrlSPNhapDiem;
            this.grvSPNhapDiem.Name = "grvSPNhapDiem";
            this.grvSPNhapDiem.OptionsView.ShowGroupPanel = false;
            // 
            // colMASV
            // 
            this.colMASV.AppearanceCell.Options.UseTextOptions = true;
            this.colMASV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMASV.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMASV.AppearanceHeader.Options.UseTextOptions = true;
            this.colMASV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMASV.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMASV.Caption = "Mã SV";
            this.colMASV.FieldName = "MASV";
            this.colMASV.Name = "colMASV";
            this.colMASV.OptionsColumn.AllowEdit = false;
            this.colMASV.OptionsColumn.AllowFocus = false;
            this.colMASV.Visible = true;
            this.colMASV.VisibleIndex = 0;
            // 
            // colHOTEN
            // 
            this.colHOTEN.AppearanceCell.Options.UseTextOptions = true;
            this.colHOTEN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHOTEN.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHOTEN.AppearanceHeader.Options.UseTextOptions = true;
            this.colHOTEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHOTEN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHOTEN.Caption = "Họ và tên";
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.OptionsColumn.AllowEdit = false;
            this.colHOTEN.OptionsColumn.AllowFocus = false;
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 1;
            // 
            // colDIEM
            // 
            this.colDIEM.AppearanceCell.Options.UseTextOptions = true;
            this.colDIEM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDIEM.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDIEM.AppearanceHeader.Options.UseTextOptions = true;
            this.colDIEM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDIEM.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDIEM.Caption = "Điểm";
            this.colDIEM.FieldName = "DIEM";
            this.colDIEM.Name = "colDIEM";
            this.colDIEM.Visible = true;
            this.colDIEM.VisibleIndex = 2;
            // 
            // frmDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 694);
            this.Controls.Add(this.grctrlSPSuaDiem);
            this.Controls.Add(this.grctrlSPNhapDiem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDiem";
            this.Text = "Nhập điểm sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbDiem.ResumeLayout(false);
            this.grbDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSPSuaDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlSPSuaDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSPSuaDiem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grbOKCancel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsSPNhapDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grctrlSPNhapDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSPNhapDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbBoPhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbDiem;
        private DS DS;
        private System.Windows.Forms.BindingSource bdsLop;
        private DSTableAdapters.LOPTableAdapter lOPTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.TextEdit txtTenLop;
        private System.Windows.Forms.ComboBox cmbMaLop;
        private DSTableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLanThi;
        private System.Windows.Forms.ComboBox cmbMaMH;
        private System.Windows.Forms.BindingSource bdsSPSuaDiem;
        private DSTableAdapters.SP_SUADIEMMONHOCTableAdapter sP_SUADIEMMONHOCTableAdapter;
        private DevExpress.XtraGrid.GridControl grctrlSPSuaDiem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSPSuaDiem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grbOKCancel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraEditors.TextEdit txtTenMH;
        private System.Windows.Forms.BindingSource bdsMonHoc;
        private System.Windows.Forms.BindingSource bdsSPNhapDiem;
        private DSTableAdapters.SP_NHAPDIEMMONHOCTableAdapter sP_NHAPDIEMMONHOCTableAdapter;
        private DevExpress.XtraGrid.GridControl grctrlSPNhapDiem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSPNhapDiem;
        private DevExpress.XtraGrid.Columns.GridColumn colMASV;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIEM;
    }
}