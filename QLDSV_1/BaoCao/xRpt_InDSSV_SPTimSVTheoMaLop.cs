using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV_1.BaoCao
{
    public partial class xRpt_InDSSV_SPTimSVTheoMaLop : DevExpress.XtraReports.UI.XtraReport
    {
        public xRpt_InDSSV_SPTimSVTheoMaLop(String malop)
        {
            InitializeComponent();
            ds1.EnforceConstraints = false;
            this.sP_TIMSV_THEOMALOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_TIMSV_THEOMALOPTableAdapter.Fill(ds1.SP_TIMSV_THEOMALOP, malop);
            //this.sP_TIMSV_THEOMALOPTableAdapter.Fill(ds1.SP_TIMSV_THEOMALOP, "d15cqcn1");
        }

    }
}
