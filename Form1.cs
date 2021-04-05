using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp2
{
	public partial class Form1 : Form
	{
		Color co;
		int MAX_WID= Screen.PrimaryScreen.Bounds.Width;
		int MAX_HEI = Screen.PrimaryScreen.Bounds.Height;
		string[] op_li = { "", "" };

		public Form1(string[] args)
		{

			InitializeComponent();
			this.WindowState = FormWindowState.Maximized;
			op_li = File.ReadAllLines(@"D:\Program Files\ImageSeer\options.cfg");//缩写args报错

			if (args.Length==1){//记录新项
				FileInfo fi = new FileInfo(args[0]);
				File.Delete(@"D:\Program Files\ImageSeer\relay.jpg");
				fi.CopyTo(@"D:\Program Files\ImageSeer\relay.jpg");
				Process.Start(@"D:\Program Files\ImageSeer\ShortCut\ShortCut.exe");
			}

			Bitmap image = new Bitmap(@"D:\Program Files\ImageSeer\relay.jpg");
			PictureBox pb1 = new PictureBox();
			double mh = (float)MAX_HEI / image.Height;
			double mw = (float)MAX_WID / image.Width;

			if (mh < mw)
			{
				pb1.Location = new Point((MAX_WID - (int)(mh * image.Width)) / 2, 0);
				pb1.Size = new Size((int)(image.Width * mh), MAX_HEI);
			}
			else
			{
				pb1.Location = new Point(0, (MAX_HEI - (int)(mw * image.Height)) / 2);
				pb1.Size = new Size(MAX_WID, (int)(image.Height * mw));
			}
			//MessageBox.Show(op_li[0]);

			pb1.Image = image;

			pb1.SizeMode = PictureBoxSizeMode.Zoom;
			pb1.Click += new EventHandler(this.pb1_Click);
			this.Controls.Add(pb1);

			int color = int.Parse(op_li[0]);  //获取背景
			this.BackColor = Color.FromArgb(color, color, color);

		}

		private void Form1_Click(object sender, EventArgs e)
		{
			co = this.BackColor;
			op_li[0] = (255 - co.R).ToString();
			this.BackColor = Color.FromArgb(255 - co.R, 255 - co.G, 255 - co.B);

		}

		private void pb1_Click(object sender, EventArgs e)
		{
			File.WriteAllLines(@"D:\Program Files\ImageSeer\options.cfg", op_li);
			Application.Exit();
		}
	}
}
