using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics;

namespace BAI_1
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txb_a.Text) || string.IsNullOrEmpty(txb_x.Text) || string.IsNullOrEmpty(txb_p.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ giá trị cho a, x và p.");
                return;
            }
            // Kiểm tra và chuyển đổi giá trị của a, x và p
            if (!BigInteger.TryParse(txb_a.Text, out BigInteger a))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ cho a.");
                return;
            }
            if (!BigInteger.TryParse(txb_x.Text, out BigInteger x))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ cho x.");
                return;
            }
            if (!BigInteger.TryParse(txb_p.Text, out BigInteger p))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ cho p.");
                return;
            }
            //BigInteger a = BigInteger.Parse(txb_a.Text);  // Cơ số
            //BigInteger x = BigInteger.Parse(txb_x.Text); ; // Số mũ
            //BigInteger p = BigInteger.Parse(txb_p.Text); ; // Mod
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BigInteger result = ModExponentiation(a, x, p);
            stopwatch.Stop();

            // Thời gian thực thi
            TimeSpan executionTime = stopwatch.Elapsed;
            txb_kq.Text = result.ToString();

            // Hiển thị thời gian thực thi
            txb_time.Text = executionTime.TotalMilliseconds.ToString() + " ms";
            // Đo tài nguyên hệ thống
            Process currentProcess = Process.GetCurrentProcess();
            long memoryUsage = currentProcess.WorkingSet64; // Bộ nhớ đã sử dụng (bytes)
            long cpuUsage = currentProcess.TotalProcessorTime.Ticks; // Thời gian CPU đã sử dụng (ticks)
            txb_memory.Text = memoryUsage.ToString() + " bytes";
            txb_CPU.Text = cpuUsage.ToString() + " ticks";
        }
        
        public static BigInteger ModExponentiation(BigInteger a, BigInteger x, BigInteger p)
        {
            if (p == 1)
                return 0; // Bất kỳ số nào mod 1 đều bằng 0
            BigInteger result = 1;
            a = a % p; // Giảm cơ số a mod p
            while (x > 0)
            {
                if (x % 2 == 1)
                {
                    result = (result * a) % p;
                }
                a = (a * a) % p;
                x /= 2;
            }
            return result;
        }
    }
}
