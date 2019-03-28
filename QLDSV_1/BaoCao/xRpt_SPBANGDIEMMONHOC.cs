using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV_1.BaoCao
{
    public partial class xRpt_SPBANGDIEMMONHOC : DevExpress.XtraReports.UI.XtraReport
    {
        public xRpt_SPBANGDIEMMONHOC(String tenlop, String tenmh, short lanthi)
        {
            InitializeComponent();
            ds1.EnforceConstraints = false;
            this.sP_BANGDIEMMONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_BANGDIEMMONHOCTableAdapter.Fill(ds1.SP_BANGDIEMMONHOC, tenlop, tenmh, lanthi);
        }

    }
}
