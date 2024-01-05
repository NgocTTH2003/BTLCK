using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace BTLCK
{
    public partial class FormDangKy : Form
    {
        private float scale = 1.0f;

        public FormDangKy()
        {
            InitializeComponent();
        }

        private void FormDangKy_Resize(object sender, EventArgs e)
        {
            UpdatePanelScale();
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            // Tăng tỷ lệ phóng to
            scale += 0.1f;
            UpdatePanelScale();
        }

        private void UpdatePanelScale()
        {
            // Cập nhật tỷ lệ phóng to cho Panel
            panelDangKy.Scale(new SizeF(scale, scale));
        }
    }
}
