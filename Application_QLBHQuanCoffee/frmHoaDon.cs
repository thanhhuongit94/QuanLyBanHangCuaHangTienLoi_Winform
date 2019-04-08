using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using QuanLyCuaHangCoffee.Models;

namespace QuanLyCuaHangCoffee
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        QuanLyHoaDon qlInvoices = new QuanLyHoaDon();

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = qlInvoices.getAllDataInvoice();//Hien thi danh sach cac hoa don
            btnXoa.Enabled = false;
        }

        //Xoa hoa don
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = dgvHoaDon.CurrentRow.Index;
            if (index < 0)
            {
                MessageBox.Show("Không tồn tại hóa đơn nào để xóa", "Thông báo!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            int maHD = int.Parse(dgvHoaDon.Rows[index].Cells[0].Value.ToString());

            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                //Xoa cac chi tiet thuoc hoa don
                new QuanLyChiTietHoaDon().deleteInvoiceDetailByInvoice_id(maHD);
                //Xoa hoa don do
                qlInvoices.deleteInvoiceByInvoice_id(maHD);
                dgvHoaDon.DataSource = qlInvoices.getAllDataInvoice();//Hien thi danh sach cac hoa don
            }
            btnXoa.Enabled = false;
        }

        //Xu ly su kien click
        private void dgvHoaDon_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
             //Lay danh sach de in
            ArrayList listHD = new QuanLyHoaDon().getAllDataInvoice();
            try
            {
                string fileName = "HoaDon.txt";
                FileStream output = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter writeFile = new StreamWriter(output);

                writeFile.WriteLine("Ngày: " + DateTime.Now);
                writeFile.WriteLine("\t\t\t\tDANH SÁCH HÓA ĐƠN");
                writeFile.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}", "Mã HD", "Mã NV", "Tổng tiền", "Ngày lập HD", "Ghi chú");
                writeFile.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                foreach (HoaDon hd in listHD)
                {
                    writeFile.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}", hd.MaHD, hd.MaNV, hd.TongTien, hd.NgayLapHD, hd.GhiChu);
                }
                writeFile.Close();
                output.Close();
                MessageBox.Show("Xuất danh sách hóa đơn thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Không tìm thấy thư mục lưu file", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (IOException)
            {
                MessageBox.Show("Không xuất danh sách ra file được", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(openFrmTrangChuAdmin));//mo from trang chu
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            System.Windows.Forms.Application.ExitThread(); //dong form xem hoa don
        }

        //Mo form trang chu
        private void openFrmTrangChuAdmin()
        {
            System.Windows.Forms.Application.Run(new frmTrangChuAdmin());
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnQuayLai_Click(this, e);
        }
    }
}
