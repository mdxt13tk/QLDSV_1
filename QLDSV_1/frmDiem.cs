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
    public partial class frmDiem : Form
    {
        Boolean nhapdiem=false;
        public frmDiem()
        {
            InitializeComponent();
        }
        
        private void frmDiem_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.DS.LOP);

            cmbBoPhan.DataSource = Program.bds_DSPM;
            cmbBoPhan.DisplayMember = "TENCN";
            cmbBoPhan.ValueMember = "TENSERVER";
            cmbBoPhan.SelectedIndex = Program.mBophan;

            grbOKCancel.Enabled = false;
            txtTenLop.Enabled = txtTenMH.Enabled=false;
            grctrlSPNhapDiem.Enabled = grctrlSPSuaDiem.Enabled = false;
            grctrlSPNhapDiem.Visible = false;

            if (Program.mGroup == "PGV")
            {
                cmbBoPhan.Enabled = true;
            }
            else
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
                    MessageBox.Show("Lỗi kết nối đến BỘ PHẬN mới!", "", MessageBoxButtons.OK);
                else
                {
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.DS.LOP);
                    this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
                }
            }
            
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            cmbBoPhan.Enabled = false;
            grbDiem.Enabled = false;
            grbOKCancel.Enabled = true;
            grctrlSPNhapDiem.Enabled = grctrlSPSuaDiem.Enabled=true;

            string strLenh = "EXEC SP_SUADIEMMONHOC '" + cmbMaLop.SelectedValue.ToString() + "', '" + cmbMaMH.SelectedValue.ToString() + "', '" + cmbLanThi.SelectedValue.ToString() + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);

            if (Program.myReader.HasRows)
            {
                MessageBox.Show("Điểm đã được nhập! Sửa điểm ...");

                this.nhapdiem = false;
                grctrlSPSuaDiem.Visible = true;
                grctrlSPNhapDiem.Visible = false;
                try
                {
                    this.sP_SUADIEMMONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sP_SUADIEMMONHOCTableAdapter.Fill(this.DS.SP_SUADIEMMONHOC, cmbMaLop.SelectedValue.ToString(), cmbMaMH.SelectedValue.ToString(), int.Parse(cmbLanThi.SelectedValue.ToString()));
                    Program.myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi "+ ex.Message);
                }
            }
            else
            {
                this.nhapdiem = true;
                grctrlSPSuaDiem.Visible = false;
                grctrlSPNhapDiem.Visible = true;
                grctrlSPNhapDiem.Dock = DockStyle.Fill;
                try
                {
                    this.sP_NHAPDIEMMONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sP_NHAPDIEMMONHOCTableAdapter.Fill(this.DS.SP_NHAPDIEMMONHOC, cmbMaLop.SelectedValue.ToString());
                    Program.myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi "+ ex.Message);
                }
            }
            Program.myReader.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.nhapdiem)
            {
                int dem = bdsSPNhapDiem.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (((DataRowView)bdsSPNhapDiem[i])["DIEM"].ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập điểm cho sinh viên này!\n" + "Mã SV: " + ((DataRowView)bdsSPNhapDiem[i])["MASV"].ToString());
                        grvSPNhapDiem.FocusedRowHandle = i;
                        return;
                    }
                    if (float.Parse(((DataRowView)bdsSPNhapDiem[i])["DIEM"].ToString()) > 10)
                    {
                        MessageBox.Show("Điểm không được lớn hơn 10!\n" + "Mã SV: " + ((DataRowView)bdsSPNhapDiem[i])["MASV"].ToString());
                        grvSPNhapDiem.FocusedRowHandle = i;
                        return;
                    }
                    if (float.Parse(((DataRowView)bdsSPNhapDiem[i])["DIEM"].ToString()) < 0)
                    {
                        MessageBox.Show("Điểm phải lớn hơn hoặc bằng 0!\n" + "Mã SV: " + ((DataRowView)bdsSPNhapDiem[i])["MASV"].ToString());
                        grvSPNhapDiem.FocusedRowHandle = i;
                        return;
                    }
                }
                
                string strLenh = "";
                for (int i = 0; i < dem; i++)
                {
                    strLenh = "INSERT INTO dbo.DIEM (MASV,MAMH,LAN,DIEM) VALUES (@MASV,@MAMH,@LAN,@DIEM)";
                    using (SqlConnection sqlConn = new SqlConnection(Program.connstr))
                    using (SqlCommand sqlcmd = new SqlCommand(strLenh, sqlConn))
                    {
                        sqlcmd.Parameters.AddWithValue("@MASV", grvSPNhapDiem.GetRowCellValue(i, "MASV").ToString().Trim());
                        sqlcmd.Parameters.AddWithValue("@MAMH", cmbMaMH.SelectedValue.ToString());
                        sqlcmd.Parameters.AddWithValue("@LAN", int.Parse(cmbLanThi.SelectedValue.ToString()));
                        sqlcmd.Parameters.AddWithValue("@DIEM", float.Parse(grvSPNhapDiem.GetRowCellValue(i, "DIEM").ToString().Trim()));
                        sqlConn.Open();
                        try
                        {
                            sqlcmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi ghi điểm! "+ex.Message, "", MessageBoxButtons.OK);
                            sqlConn.Close();
                            return;
                        }
                        sqlConn.Close();
                    }
                }
                MessageBox.Show("Ghi điểm thành công!", "", MessageBoxButtons.OK);
                bdsSPNhapDiem.EndEdit();
            }
            else
            {
                int dem = bdsSPSuaDiem.Count;
                for (int i = 0; i < dem; i++)
                {
                    if (((DataRowView)bdsSPSuaDiem[i])["DIEM"].ToString() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập điểm cho sinh viên này!\n"+ "Mã SV: "+ ((DataRowView)bdsSPSuaDiem[i])["MASV"].ToString());
                        grvSPSuaDiem.FocusedRowHandle = i;
                        return;
                    }
                    if (float.Parse(((DataRowView)bdsSPSuaDiem[i])["DIEM"].ToString()) > 10)
                    {
                        MessageBox.Show("Điểm không được lớn hơn 10!\n"+ "Mã SV: "+ ((DataRowView)bdsSPSuaDiem[i])["MASV"].ToString());
                        grvSPSuaDiem.FocusedRowHandle = i;
                        return;
                    }
                    if (float.Parse(((DataRowView)bdsSPSuaDiem[i])["DIEM"].ToString()) < 0)
                    {
                        MessageBox.Show("Điểm phải lớn hơn hoặc bằng 0!\n" + "Mã SV: " + ((DataRowView)bdsSPSuaDiem[i])["MASV"].ToString());
                        grvSPSuaDiem.FocusedRowHandle = i;
                        return;
                    }
                }
                string strLenh = "";
                for (int i = 0; i < dem; i++)
                {
                    strLenh = "UPDATE dbo.DIEM SET DIEM = @DIEM WHERE MASV = @MASV and MAMH = @MAMH and LAN = @LAN";
                    using (SqlConnection sqlConn = new SqlConnection(Program.connstr))
                    using (SqlCommand sqlcmd = new SqlCommand(strLenh, sqlConn))
                    {
                        sqlcmd.Parameters.AddWithValue("@MASV", grvSPSuaDiem.GetRowCellValue(i, "MASV").ToString().Trim());
                        sqlcmd.Parameters.AddWithValue("@MAMH", cmbMaMH.SelectedValue.ToString());
                        sqlcmd.Parameters.AddWithValue("@LAN", int.Parse(cmbLanThi.SelectedValue.ToString()));
                        sqlcmd.Parameters.AddWithValue("@DIEM", float.Parse(grvSPSuaDiem.GetRowCellValue(i, "DIEM").ToString().Trim()));
                        sqlConn.Open();
                        try
                        {
                            sqlcmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi ghi điểm! "+ex.Message , "", MessageBoxButtons.OK);
                            sqlConn.Close();
                            return;

                        }
                        sqlConn.Close();
                    }
                }
                MessageBox.Show("Ghi điểm thành công!", "", MessageBoxButtons.OK);
                bdsSPSuaDiem.EndEdit();
            }
            sP_NHAPDIEMMONHOCTableAdapter.Fill(DS.SP_NHAPDIEMMONHOC, "");
            sP_SUADIEMMONHOCTableAdapter.Fill(DS.SP_SUADIEMMONHOC, "", "", 0);
            grbDiem.Enabled = true;
            grbOKCancel.Enabled = false;
            grctrlSPNhapDiem.Enabled = grctrlSPSuaDiem.Enabled = false;
            if (Program.mGroup == "PGV")
            {
                cmbBoPhan.Enabled = true;
            }
            else cmbBoPhan.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bdsSPNhapDiem.CancelEdit();
            bdsSPSuaDiem.CancelEdit();
            grbDiem.Enabled = true;
            grbOKCancel.Enabled = false;
            grctrlSPNhapDiem.Enabled = false;
            grctrlSPSuaDiem.Enabled = false;
            if (Program.mGroup == "PGV")
            {
                cmbBoPhan.Enabled = true;
            }
            else cmbBoPhan.Enabled = false;
        }
        
    }
}
