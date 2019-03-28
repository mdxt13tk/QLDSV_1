using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDSV_1
{
    public partial class frmSPDSDONGHOCPHI : Form
    {
        public frmSPDSDONGHOCPHI()
        {
            InitializeComponent();
        }
        
        private void frmSPDSDONGHOCPHI_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.hOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOCPHITableAdapter.Fill(this.DS.HOCPHI);
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.DS.LOP);

            cmbBoPhan.DataSource = Program.bds_DSPM;
            cmbBoPhan.DisplayMember = "TENCN";
            cmbBoPhan.ValueMember = "TENSERVER";
            cmbBoPhan.SelectedIndex = Program.mBophan;

            cmbBoPhan.Enabled = false;
            txtTenLop.Enabled = false;

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            dict.Add(3, "3");
            cmbHocKy.DataSource = new BindingSource(dict, null);
            cmbHocKy.DisplayMember = "Value";
            cmbHocKy.ValueMember = "Key";

        }
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            BaoCao.xRpt_SPDSDONGHOCPHI rpt = new BaoCao.xRpt_SPDSDONGHOCPHI(cmbMaLop.SelectedValue.ToString(), cmbNienKhoa.SelectedValue.ToString(), int.Parse(cmbHocKy.SelectedValue.ToString()));
            rpt.lblMaLop.Text = "Mã lớp:  " + cmbMaLop.SelectedValue.ToString();
            rpt.lblTenLop.Text = "Tên lớp:  " + txtTenLop.Text;
            rpt.lblNienKhoa.Text = "Niên khóa:  " + cmbNienKhoa.SelectedValue.ToString();
            rpt.lblHocKy.Text = "Học kỳ:  " + cmbHocKy.SelectedValue.ToString();
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
