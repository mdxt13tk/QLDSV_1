using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDSV_1
{
    public partial class frmHocPhi : Form
    {
        Boolean checkAdd = false;
        String nienkhoa = "";
        int hocky;
        public frmHocPhi()
        {
            InitializeComponent();
        }
        private void frmHocPhi_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            cmbBoPhan.DataSource = Program.bds_DSPM;
            cmbBoPhan.DisplayMember = "TENCN";
            cmbBoPhan.ValueMember = "TENSERVER";
            cmbBoPhan.SelectedIndex = Program.mBophan;
            cmbBoPhan.Enabled = false;

            grctrlSPDongHP.Enabled = false;
            grbOKCancel.Visible = false;
            bar2.Visible = false;
            btnNhapSV.Enabled = false;

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "1");
            dict.Add(2, "2");
            dict.Add(3, "3");
            cmbHocKy.DataSource = new BindingSource(dict, null);
            cmbHocKy.DisplayMember = "Value";
            cmbHocKy.ValueMember = "Key";

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập MÃ SV!");
                txtMaSV.Focus();
                return;
            }
            string strLenh = "EXEC SP_TIMSVHP '" + txtMaSV.Text + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (!Program.myReader.HasRows)
            {
                MessageBox.Show("Sinh viên không tồn tại hoặc đã NGHỈ HỌC!", "", MessageBoxButtons.OK);
                Program.myReader.Close();
                txtMaSV.Focus();
                return;
            }
            Program.myReader.Read();
            lblHoTen.Text = Program.myReader.GetString(1);
            lblMaLop.Text = Program.myReader.GetString(2);
            Program.myReader.Close();
            
            this.sP_DONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DONGHOCPHITableAdapter.Fill(this.DS.SP_DONGHOCPHI, txtMaSV.Text);

            grctrlSPDongHP.Enabled = true;
            bar2.Visible = true;
            btnLoad.Enabled = false;
            btnNhapSV.Enabled = true;
            txtMaSV.Enabled = false;
            if (bdsSPDongHP.Count == 0)
            {
                btnEdit.Enabled = false;
            }
            else btnEdit.Enabled = true;

        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grbOKCancel.Visible = true;
            grbHocPhi.Enabled = false;
            bdsSPDongHP.AddNew();
            
            btnAdd.Enabled = btnEdit.Enabled = btnExit.Enabled =btnReload.Enabled= false;

            grctrlSPDongHP.Enabled = false;
            
            checkAdd = true;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            grbOKCancel.Visible = true;
            grbHocPhi.Enabled = false;

            btnAdd.Enabled = btnEdit.Enabled= btnExit.Enabled =btnReload.Enabled= false;
            
            grctrlSPDongHP.Enabled = false;
            nienkhoa = txtNienKhoa.Text; hocky = int.Parse(cmbHocKy.SelectedValue.ToString());
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNienKhoa.Text == "")
            {
                MessageBox.Show("NIÊN KHÓA không được để trống!", "", MessageBoxButtons.OK);
                txtNienKhoa.Focus();
                return;
            }
            if (txtHP.Text == "")
            {
                MessageBox.Show("HỌC PHÍ không được để trống!", "", MessageBoxButtons.OK);
                txtHP.Focus();
                return;
            }
            if (txtST.Text == "")
            {
                MessageBox.Show("SỐ TIỀN ĐÃ ĐÓNG không được để trống!", "", MessageBoxButtons.OK);
                txtST.Focus();
                return;
            }
            try
            {
                int hp = int.Parse(txtHP.Text);
                if (hp < 0)
                {
                    MessageBox.Show("HỌC PHÍ không được âm!", "", MessageBoxButtons.OK);
                    txtHP.Focus();
                    return;
                }
            }
            catch(Exception ex) {
                txtHP.Focus();
            }

            try
            {
                int st = int.Parse(txtST.Text);
                if (st < 0)
                {
                    MessageBox.Show("SỐ TIỀN không được âm!", "", MessageBoxButtons.OK);
                    txtST.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                txtST.Focus();
            }
            

            if (checkAdd)
            {
                checkAdd = false;
                string strLenh = "INSERT INTO dbo.HOCPHI (MASV,NIENKHOA,HOCKY,HOCPHI,SOTIENDADONG) VALUES (@MASV,@NIENKHOA,@HOCKY,@HOCPHI,@SOTIENDADONG)";
                using (SqlConnection sqlConn = new SqlConnection(Program.connstr))
                using (SqlCommand sqlcmd = new SqlCommand(strLenh, sqlConn))
                {
                    sqlcmd.Parameters.AddWithValue("@NIENKHOA", txtNienKhoa.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@HOCKY", int.Parse(cmbHocKy.SelectedValue.ToString()));
                    sqlcmd.Parameters.AddWithValue("@HOCPHI", int.Parse(txtHP.Text.Trim()));
                    sqlcmd.Parameters.AddWithValue("@SOTIENDADONG", int.Parse(txtST.Text.Trim()));
                    sqlcmd.Parameters.AddWithValue("@MASV", txtMaSV.Text.Trim());
                    sqlConn.Open();
                    try
                    {
                        sqlcmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu học phí:\n" + ex.Message,"",MessageBoxButtons.OK);
                        sqlConn.Close();
                        return;
                    }
                    sqlConn.Close();
                }
                MessageBox.Show("Lưu dữ liệu thành công!", "", MessageBoxButtons.OK);
                bdsSPDongHP.EndEdit();
            }
            else
            {
                String strLenh1 = "UPDATE dbo.HOCPHI SET NIENKHOA = @NIENKHOA, HOCKY=@HOCKY, HOCPHI=@HOCPHI, SOTIENDADONG=@SOTIENDADONG WHERE MASV = @MASV and NIENKHOA=N'" + nienkhoa + "' and HOCKY=" + hocky;
                using (SqlConnection sqlConn = new SqlConnection(Program.connstr))
                using (SqlCommand sqlcmd = new SqlCommand(strLenh1, sqlConn))
                {
                    sqlcmd.Parameters.AddWithValue("@MASV", txtMaSV.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@NIENKHOA", txtNienKhoa.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@HOCKY", int.Parse(cmbHocKy.SelectedValue.ToString()));
                    sqlcmd.Parameters.AddWithValue("@HOCPHI", int.Parse(txtHP.Text.Trim()));
                    sqlcmd.Parameters.AddWithValue("@SOTIENDADONG", int.Parse(txtST.Text.Trim()));
                    sqlConn.Open();
                    try
                    {
                        sqlcmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu học phí!\n" + ex.Message,"",MessageBoxButtons.OK);
                        sqlConn.Close();
                        return;
                    }
                    sqlConn.Close();
                }
                MessageBox.Show("Lưu dữ liệu thành công!", "", MessageBoxButtons.OK);
                bdsSPDongHP.EndEdit();
            }
            this.sP_DONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DONGHOCPHITableAdapter.Fill(DS.SP_DONGHOCPHI, txtMaSV.Text.Trim());

            grbHocPhi.Enabled = true;
            btnNhapSV.Enabled = true;
            grbOKCancel.Visible = false;
            btnAdd.Enabled = btnEdit.Enabled = btnExit.Enabled = btnReload.Enabled=true;
            grctrlSPDongHP.Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (checkAdd == true)
            {
                //bdsSPDongHP.CancelEdit();
                bdsSPDongHP.RemoveCurrent();
                checkAdd = false;
            }
            else
            {
                bdsSPDongHP.CancelEdit();
            }
            btnAdd.Enabled =btnEdit.Enabled = btnExit.Enabled =btnNhapSV.Enabled= btnReload.Enabled=  true;
            grctrlSPDongHP.Enabled = true;
            grbOKCancel.Visible = false;
            grbHocPhi.Enabled = true;
        }

        private void btnNhapSV_Click(object sender, EventArgs e)
        {
            txtMaSV.Enabled = true;
            bar2.Visible = false;
            btnNhapSV.Enabled = false;
            btnLoad.Enabled = true;
            grctrlSPDongHP.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.sP_DONGHOCPHITableAdapter.Fill(this.DS.SP_DONGHOCPHI, txtMaSV.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload :" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            btnNhapSV.Enabled = true;

        }

        
    }
}
