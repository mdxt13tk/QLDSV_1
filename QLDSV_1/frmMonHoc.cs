using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_1
{
    public partial class frmMonHoc : Form
    {
        int vitri = 0;
        Boolean checkAdd = false;
        public frmMonHoc()
        {
            InitializeComponent();
        }
        
        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            
            DS.EnforceConstraints = false;
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.DS.MONHOC);

            grbMonHoc.Visible = false;
            if (bdsMonHoc.Count == 0)
            {
                btnEdit.Enabled = false;
            }
            else btnEdit.Enabled = true;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMonHoc.Position;

            grbMonHoc.Visible = true;
            bdsMonHoc.AddNew();
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRestore.Enabled = btnReload.Enabled = btnExit.Enabled = false;

            grctrlMonHoc.Enabled = false;
            //checkGhi = false;
            checkAdd = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String mamh = "";
            if (MessageBox.Show("Bạn có thực sự muốn xóa MÔN HỌC này??", "Xác nhận.", MessageBoxButtons.OKCancel) == DialogResult.OK)
                try
                {
                    mamh = (((DataRowView)bdsMonHoc[bdsMonHoc.Position])["MAMH"].ToString());
                    bdsMonHoc.RemoveCurrent();
                    this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.mONHOCTableAdapter.Update(this.DS.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa Lớp.\nBạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
                    bdsMonHoc.Position = bdsMonHoc.Find("MAMH", mamh);
                    return;
                }
            if (bdsMonHoc.Count == 0)
            {
                btnDelete.Enabled = false;
            }
            btnRestore.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            vitri = bdsMonHoc.Position;
            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn không được thiếu!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn không được thiếu!", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }

            int dem1 = 0, dem2=0;
            for (int i = 0; i < bdsMonHoc.Count; i++)
            {
                if (txtMaMH.Text.Trim() == ((DataRowView)bdsMonHoc[i])["MAMH"].ToString().Trim())
                    dem1++;
                if (txtTenMH.Text.Trim() == ((DataRowView)bdsMonHoc[i])["TENMH"].ToString().Trim())
                    dem2++;
            }
            if (dem1 == 2)
            {
                MessageBox.Show("Mã môn bị trùng!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (dem2 == 2)
            {
                MessageBox.Show("Tên môn bị trùng!", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }

            try
            {
                bdsMonHoc.EndEdit();
                //bdsLop.ResetCurrentItem();
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Update(this.DS.MONHOC);
                MessageBox.Show("Lưu dữ liệu thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi Môn.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            grbMonHoc.Visible = false;
            grctrlMonHoc.Enabled = true;
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRestore.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            //checkGhi = true;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMonHoc.Position;

            grbMonHoc.Visible = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnExit.Enabled = btnRestore.Enabled = false;
            btnRestore.Enabled = true;
            grctrlMonHoc.Enabled = false;
            //checkGhi = false;
        }

        private void btnRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMonHoc.CancelEdit();
            if (btnAdd.Enabled == false) bdsMonHoc.Position = vitri;
            grctrlMonHoc.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = true;
            btnRestore.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.mONHOCTableAdapter.Fill(this.DS.MONHOC);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (checkAdd == true)
            {
                bdsMonHoc.RemoveCurrent();
                bdsMonHoc.CancelEdit();
                checkAdd = false;
            }
            else
            {
                bdsMonHoc.CancelEdit();
            }
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRestore.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            grctrlMonHoc.Enabled = true;
            grbMonHoc.Visible = false;
            //checkGhi = false;
        }
    }
}
