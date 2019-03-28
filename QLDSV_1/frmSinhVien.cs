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
    public partial class frmSinhVien : Form
    {
        int vitri = 0;
        Boolean checkAdd = false;
        public frmSinhVien()
        {
            InitializeComponent();
        }
        
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.DIEM' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DS.DIEM' table. You can move, or remove it, as needed.

            DS.EnforceConstraints = false;
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.DS.DIEM);
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.DS.LOP);
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

            cmbBoPhan.DataSource = Program.bds_DSPM;
            cmbBoPhan.DisplayMember = "TENCN";
            cmbBoPhan.ValueMember = "TENSERVER";
            cmbBoPhan.SelectedIndex = Program.mBophan;

            grbSV.Visible = false;
            txtMaLop.Enabled = false;
            if (bdsSV.Count == 0)
            {
                btnEdit.Enabled = false;
            }
            else btnEdit.Enabled = true;


            if (Program.mGroup == "PGV")
            {
                cmbBoPhan.Enabled = true;
                bar2.Visible = false;
            }
            else cmbBoPhan.Enabled = false;
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
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.DS.LOP);
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
                }
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            
            grbSV.Visible = true;
            bdsSV.AddNew();
            txtMaLop.Text = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
            chkPhai.Checked = true;
            chkNghiHoc.Checked = false;
            datepNgaySinh.Checked = true;

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRestore.Enabled = btnReload.Enabled = btnExit.Enabled = false;

            grctrlLop.Enabled = grctrlSV.Enabled= false;
            //checkGhi = false;
            checkAdd = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String masv = "";
            if (chkNghiHoc.Checked)
            {
                MessageBox.Show("Sinh viên này đã nghỉ học!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa Sinh viên này??", "Đánh dấu nghỉ học?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    masv = (((DataRowView)bdsSV[bdsSV.Position])["MASV"].ToString());
                    chkNghiHoc.Checked = true;
                    bdsSV.EndEdit();
                    //bdsSV.ResetCurrentItem();
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Update(this.DS.SINHVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa Lớp.\nBạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.sINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
                    bdsSV.Position = bdsSV.Find("MASV", masv);
                    return;
                }
            }
            if (bdsSV.Count == 0) btnDelete.Enabled = false;
            btnRestore.Enabled = true;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsSV.Position;

            grbSV.Visible = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnExit.Enabled = btnRestore.Enabled = false;
            btnRestore.Enabled = true;
            grctrlLop.Enabled = false;
            grctrlSV.Enabled = false;
            //checkGhi = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được trống!", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ không được trống!", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được trống!", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            
            int dem = 0;
            for (int i = 0; i < bdsSV.Count; i++)
            {
                if (txtMaSV.Text == ((DataRowView)bdsSV[i])["MASV"].ToString().Trim())
                {
                    dem++;
                }
            }
            if (dem == 2)
            {
                MessageBox.Show("Mã sinh viên bị trùng!");
                txtMaSV.Focus();
                return;
            }
            String strLenh = "EXEC SP_TIMSVOUTSITE_THEOMA '" + txtMaSV.Text+ "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.HasRows)
            {
                MessageBox.Show("Mã sinh viên bị trùng ở khoa khác!");
                Program.myReader.Close();
                txtMaSV.Focus();
                return;
            }
            Program.myReader.Close();

            try
            {
                bdsSV.EndEdit();
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Update(this.DS.SINHVIEN);
                MessageBox.Show("Lưu dữ liệu thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi sinh viên.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            grbSV.Visible = false;
            grctrlSV.Enabled = true;
            grctrlLop.Enabled = true;
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRestore.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            //checkGhi = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (checkAdd == true)
            {
                bdsSV.RemoveCurrent();
                bdsSV.CancelEdit();
                checkAdd = false;
            }
            else
            {
                bdsSV.CancelEdit();
            }
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRestore.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            grctrlLop.Enabled = true;
            grctrlSV.Enabled = true;
            grbSV.Visible = false;
            //checkGhi = false;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
