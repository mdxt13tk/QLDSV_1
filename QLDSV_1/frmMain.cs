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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Boolean dangxuat = false;
        public frmMain()
        {
            InitializeComponent();
            
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype) return f;
            return null;
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dangxuat = true;
            Program.FrmDangNhap.Visible = true;
            Program.FrmMain.Close();
        }

        private void btnLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmLop));
            if (frm != null) frm.Activate();
            else
            {
                frmLop f = new frmLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSinhVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmSinhVien));
            if (frm != null) frm.Activate();
            else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnInDSSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmInDSSV_SPTimSVTheoMaLop));
            if (frm != null) frm.Activate();
            else
            {
                frmInDSSV_SPTimSVTheoMaLop f = new frmInDSSV_SPTimSVTheoMaLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnPhieuDiemThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Form frm = this.CheckExists(typeof(frmSPPhieuDiemThi));
            //if (frm != null) frm.Activate();
            //else
            //{
            //    frmSPPhieuDiemThi f = new frmSPPhieuDiemThi();
            //    f.MdiParent = this;
            //    f.Show();
            //}
        }

        private void btnBDMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmSPBANGDIEMMONHOC));
            if (frm != null) frm.Activate();
            else
            {
                frmSPBANGDIEMMONHOC f = new frmSPBANGDIEMMONHOC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSDONGHP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmSPDSDONGHOCPHI));
            if (frm != null) frm.Activate();
            else
            {
                frmSPDSDONGHOCPHI f = new frmSPDSDONGHOCPHI();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDiem));
            if (frm != null) frm.Activate();
            else
            {
                frmDiem f = new frmDiem();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHocPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmHocPhi));
            if (frm != null) frm.Activate();
            else
            {
                frmHocPhi f = new frmHocPhi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Program.mGroup == "PKT")
            {
                btnLop.Enabled = btnSinhVien.Enabled = btnMonHoc.Enabled = btnDiem.Enabled = btnBDMH.Enabled = btnInDSSV.Enabled = btnPhieuDiemThi.Enabled = false;
                btnHocPhi.Enabled = btnDSDONGHP.Enabled = true;
            }
            if (Program.mGroup == "USER")
            {
                btnLop.Enabled = btnSinhVien.Enabled = btnDiem.Enabled = btnBDMH.Enabled = btnInDSSV.Enabled = btnPhieuDiemThi.Enabled = btnHocPhi.Enabled = btnDSDONGHP.Enabled = false;
                btnMonHoc.Enabled = true;
            }
            if (Program.mGroup == "PGV")
            {
                btnLop.Enabled = btnSinhVien.Enabled = btnMonHoc.Enabled = btnDiem.Enabled =  true;
                btnHocPhi.Enabled = btnDSDONGHP.Enabled = btnBDMH.Enabled = btnInDSSV.Enabled = btnPhieuDiemThi.Enabled = false;
            }
            if (Program.mGroup=="KHOA")
            {
                btnLop.Enabled = btnSinhVien.Enabled = btnMonHoc.Enabled = btnDiem.Enabled = btnBDMH.Enabled = btnInDSSV.Enabled = btnPhieuDiemThi.Enabled = true;
                btnHocPhi.Enabled = btnDSDONGHP.Enabled = false;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!dangxuat)
            {
                if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận.", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Program.FrmDangNhap.Visible = true;
                    Program.FrmDangNhap.Close();
                }
                else e.Cancel=true;
            }
        }
    }
}
