using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV_1.BaoCao
{
    public partial class xRpt_SPDSDONGHOCPHI : DevExpress.XtraReports.UI.XtraReport
    {
        public xRpt_SPDSDONGHOCPHI(String malop, String nienkhoa, int hocky)
        {
            InitializeComponent();
            ds1.EnforceConstraints = false;
            this.sP_DSDONGHOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_DSDONGHOCPHITableAdapter.Fill(ds1.SP_DSDONGHOCPHI, malop, nienkhoa, hocky);
        }

    }
}
