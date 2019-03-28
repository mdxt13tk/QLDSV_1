using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_1
{
    public partial class frmLop : Form
    {
        int vitri = 0;
        String makh = "";
        
        Boolean checkAdd = false;
        public frmLop()
        {
            InitializeComponent();
        }
       

        private void frmLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.SINHVIEN' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.DS.LOP);
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

            makh = ((DataRowView)bdsLop[0])["MAKH"].ToString();

            txtMaKhoa.Text = makh;
            txtMaKhoa.Enabled = false;
            //txtMaLop.Enabled = txtTenLop.Enabled = true;
            
            grbLop.Visible = false;
            if (bdsLop.Count == 0)
            {
                btnEdit.Enabled = false;
            }
            else btnEdit.Enabled = true;


            cmbBoPhan.DataSource = Program.bds_DSPM;
            cmbBoPhan.DisplayMember = "TENCN";
            cmbBoPhan.ValueMember = "TENSERVER";
            cmbBoPhan.SelectedIndex = Program.mBophan;
            if (Program.mGroup == "PGV")
            {
                cmbBoPhan.Enabled = true;
                bar2.Visible = false;
            }
            else cmbBoPhan.Enabled = false;


        }

        private void cmbBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.SelectedIndex==2)
            {
                MessageBox.Show("Login không đủ quyền truy cập!", "", MessageBoxButtons.OK);
                cmbBoPhan.SelectedIndex = Program.mBophan;
                return;
            }
            if(Program.FrmDangNhap.Visible==false)
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
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.DS.LOP);
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

                    makh = ((DataRowView)bdsLop[bdsLop.Position])["MAKH"].ToString();
                }
            }
            
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;

            grbLop.Visible = true;
            bdsLop.AddNew();
            txtMaKhoa.Text = makh;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnRestore.Enabled = btnReload.Enabled = btnExit.Enabled = false;

            grctrlLop.Enabled = false;
            checkAdd = true;

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String malop = "";
            if (bdsSV.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp này vì Lớp đã có sinh viên.", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa Lớp này??", "Xác nhận.", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    malop = (((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString());
                    bdsLop.RemoveCurrent();
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Update(this.DS.LOP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa Lớp.\nBạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.lOPTableAdapter.Fill(this.DS.LOP);
                    bdsLop.Position = bdsLop.Find("MALOP", malop);
                    return;

                }
            }
            if (bdsLop.Count == 0) btnDelete.Enabled = false;
            btnRestore.Enabled = true;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;

            grbLop.Visible = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnExit.Enabled = btnRestore.Enabled = false;
            btnRestore.Enabled = true;
            grctrlLop.Enabled = false;

        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            vitri = bdsLop.Position;
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được thiếu!", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return;
            }
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được thiếu!", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }

            int dem1 = 0, dem2=0;
            for (int i = 0; i < bdsLop.Count; i++)
            {
                if (txtMaLop.Text.Trim() == ((DataRowView)bdsLop[i])["MALOP"].ToString().Trim())
                    dem1++;
                if (txtTenLop.Text.Trim() == ((DataRowView)bdsLop[i])["TENLOP"].ToString().Trim())
                    dem2++;
            }
            if (dem1 == 2)
            {
                MessageBox.Show("Mã lớp bị trùng!", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return;
            }
            String strLenh = "EXEC SP_TIMLOPOUTSITE_THEOMA '" + txtMaLop.Text + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.HasRows)
            {
                MessageBox.Show("Mã lớp bị trùng ở khoa khác!", "", MessageBoxButtons.OK);
                Program.myReader.Close();
                txtMaLop.Focus();
                return;
            }
            Program.myReader.Close();
            
            if (dem2 == 2)
            {
                MessageBox.Show("Tên lớp bị trùng!", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }
            strLenh = "EXEC SP_TIMLOPOUTSITE_THEOTEN N'" + txtTenLop.Text + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.HasRows)
            {
                MessageBox.Show("Tên lớp bị trùng ở khoa khác!", "", MessageBoxButtons.OK);
                Program.myReader.Close();
                txtTenLop.Focus();
                return;
            }
            Program.myReader.Close();

            try
            {
                bdsLop.EndEdit();
                //bdsLop.ResetCurrentItem();
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Update(this.DS.LOP);
                MessageBox.Show("Lưu dữ liệu thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi lớp.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            grbLop.Visible = false;
            grctrlLop.Enabled = true;
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRestore.Enabled = btnExit.Enabled = btnReload.Enabled= true;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (checkAdd == true)
            {
                bdsLop.RemoveCurrent();
                bdsLop.CancelEdit();
                checkAdd = false;
            }
            else
            {
                bdsLop.CancelEdit();
            }
            btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = btnRestore.Enabled = btnGhi.Enabled = btnExit.Enabled = btnReload.Enabled= true;
            grctrlLop.Enabled = true;
            grbLop.Visible = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.lOPTableAdapter.Fill(this.DS.LOP);
                this.sINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLop.CancelEdit();
            if (btnAdd.Enabled == false) bdsLop.Position = vitri;
            grctrlLop.Enabled = true;
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnReload.Enabled = true;
            btnRestore.Enabled = false;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        
    }
}
