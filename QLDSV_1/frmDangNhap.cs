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
    public partial class frmDangNhap : Form
    {
        
        public frmDangNhap()
        {
            InitializeComponent();
            
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet.v_DSPM' table. You can move, or remove it, as needed.
            this.v_DSPMTableAdapter.Fill(this.qLDSVDataSet.v_DSPM);
            cmbBoPhan.SelectedIndex = 1; cmbBoPhan.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        private void cmbBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.SelectedValue != null)
                Program.servername = cmbBoPhan.SelectedValue.ToString();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" && txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập gì cả!", "Lỗi đăng nhập!", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }
            if (txtLogin.Text.Trim() == "" && txtPass.Text.Trim() != "")
            {
                MessageBox.Show("Bạn chưa nhập username!", "Lỗi đăng nhập!", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }
            if (txtLogin.Text.Trim() != "" && txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập password!", "Lỗi đăng nhập!", MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }
            Program.mlogin = txtLogin.Text.Trim();
            Program.password = txtPass.Text.Trim();
            if (Program.KetNoi() == 0) return;
            //else MessageBox.Show("Đăng nhập thành công!", "", MessageBoxButtons.OK);

            Program.mBophan = cmbBoPhan.SelectedIndex;
            Program.bds_DSPM = bdsDSPM;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

            String strLenh = "EXEC SP_THONGTINDANGNHAP '" + Program.mlogin + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null)
            {
                //MessageBox.Show("Tài khoản này không tồn tại trong hệ thống.\nKhông tìm thấy: " + Program.mlogin, "Lỗi đăng nhập!", MessageBoxButtons.OK);
                return;
            }
            Program.myReader.Read();
            Program.username = Program.myReader.GetString(0);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login này không có quyền truy cập dữ liệu.", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();

            Program.FrmMain = new frmMain();

            Program.FrmMain.MAGV.Text = "MÃ GIẢNG VIÊN : " + Program.username;
            Program.FrmMain.HOTEN.Text = " ||   HỌ VÀ TÊN : " + Program.mHoten;
            Program.FrmMain.NHOM.Text = " ||   NHÓM : " + Program.mGroup;

            Program.FrmMain.Show();
            Program.FrmDangNhap.Visible=false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Program.FrmDangNhap.Close();
        }
    }
}
