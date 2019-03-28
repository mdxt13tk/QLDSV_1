using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data.SqlClient;
using System.Data;

namespace QLDSV_1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //TestRun{
        public static frmLop FormLop;
        
        //}.

        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static SqlDataReader myReader;
        public static String servername = "";
        public static String username = "";
        public static String mlogin = "";
        public static String password = "";

        //login
        public static String database = "QLDSV";
        public static String remotelogin = "HTKN";
        public static String remotepassword = "123";
        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String mHoten = "";
        public static int mBophan = 0;
        

        public static BindingSource bds_DSPM = new BindingSource(); //giữ bdsDSPM khi đăng nhập
        public static frmMain FrmMain;
        public static frmDangNhap FrmDangNhap;

        static void TestRun()
        {
            String testconn = "Data Source=TK13\\SERVER01;Initial Catalog=QLDSV;Persist Security Info=True;User ID=hongson;Password=123";
            Program.connstr = testconn;
            Program.conn = new SqlConnection(testconn);
            FormLop = new frmLop();
            Application.Run(FormLop);
            
        }

        public static int KetNoi() //null thì lỗi, không null thì chạy
        {
            if (Program.conn != null && Program.conn.State == System.Data.ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" + Program.database + ";User ID=" + Program.mlogin + ";password=" + Program.password;
                //Program.conn.ConnectionString = connstr;
                Program.conn = new SqlConnection(Program.connstr);
                Program.conn.Open();
                return 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. \nBạn xem lại username và password.\n" + ex.Message, "Lỗi kết nối!", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String strLenh) //truy vấn nhanh, chỉ thích hợp để xem; không cho sửa, thêm, xóa; nếu nhiều dòng, chỉ cho phép đi xuống, k cho phép đi ngược lại.
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandTimeout = 300; // Đợi lệnh chạy. đơn vị: giây.
            if (Program.conn.State == ConnectionState.Closed)
            Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch(SqlException ex)
            {
                Program.conn.Close(); //vì sao phải close kết nối??
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            BonusSkins.Register();
            FrmDangNhap = new frmDangNhap();
            Application.Run(FrmDangNhap);
            //TestRun();
            
        }
    }
}
