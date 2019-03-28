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
    public partial class frmSPBANGDIEMMONHOC : Form
    {
        public frmSPBANGDIEMMONHOC()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmSPBANGDIEMMONHOC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.SP_LANTHI' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.DS.DIEM);
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.DS.LOP);
            
            txtMaLop.Enabled = false;
            txtMaMH.Enabled = false;

            cmbBoPhan.DataSource = Program.bds_DSPM;
            cmbBoPhan.DisplayMember = "TENCN";
            cmbBoPhan.ValueMember = "TENSERVER";
            cmbBoPhan.SelectedIndex = Program.mBophan;

            if (Program.mGroup == "KHOA")
            {
                cmbBoPhan.Enabled = false;
            }

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            cmbLanThi.DataSource = new BindingSource(dict, null);
            cmbLanThi.DisplayMember = "Value";
            cmbLanThi.ValueMember = "Key";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.SelectedIndex == 2)
            {
                MessageBox.Show("Login không đủ quyền truy cập!", "", MessageBoxButtons.OK);
                cmbBoPhan.SelectedIndex = Program.mBophan;
                return;
            }
            if (Program.FrmDangNhap.Visible == false)
            {
                if (cmbBoPhan.SelectedValue != null && cmbBoPhan.SelectedValue.ToString() == "System.Data.DataRowView") return;
                Program.servername = cmbBoPhan.SelectedValue.ToString();
                if (cmbBoPhan.SelectedIndex != Program.mBophan)
                {
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                }
                else
                {
                    Program.mlogin = Program.mloginDN;
                    Program.password = Program.passwordDN;
                }

                if (Program.KetNoi() == 0)
                    MessageBox.Show("Lỗi kết nối đến BỘ PHẬN mới", "", MessageBoxButtons.OK);
                else
                {
                    this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.dIEMTableAdapter.Fill(this.DS.DIEM);
                    this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.DS.LOP);
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(cmbLanThi.SelectedValue != null)
            {
                BaoCao.xRpt_SPBANGDIEMMONHOC rpt = new BaoCao.xRpt_SPBANGDIEMMONHOC(cmbTenLop.SelectedValue.ToString(), cmbTenMH.SelectedValue.ToString(), short.Parse(cmbLanThi.SelectedValue.ToString()));
                rpt.lblTenLop.Text = "Tên lớp:   " + cmbTenLop.SelectedValue.ToString();
                rpt.lblTenMH.Text = "Tên môn học:   " + cmbTenMH.SelectedValue.ToString();
                rpt.lblLanThi.Text = "Lần thi:   " + cmbLanThi.SelectedValue.ToString();
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else
            {
                MessageBox.Show("Không có bảng điểm môn học này!", "", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
