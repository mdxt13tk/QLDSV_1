using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV_1.BaoCao
{
    public partial class xRpt_SPPhieuDiemThi : DevExpress.XtraReports.UI.XtraReport
    {
        public xRpt_SPPhieuDiemThi(String tenlop, String tenmh, int hk, DateTime ngaythi, short lanthi)
        {
            InitializeComponent();
            ds1.EnforceConstraints = false;
            this.sP_PHIEUDIEMTHI_v1TableAdapter.Fill(ds1.SP_PHIEUDIEMTHI_v1, tenlop, tenmh, hk, ngaythi, lanthi);
        }

    }
}
