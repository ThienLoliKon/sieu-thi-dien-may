namespace stdm
{
	partial class frmReportInHD
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.crptViewInHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.rptInHoaDon1 = new stdm.rptInHoaDon();
			this.SuspendLayout();
			// 
			// crptViewInHD
			// 
			this.crptViewInHD.ActiveViewIndex = -1;
			this.crptViewInHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crptViewInHD.Cursor = System.Windows.Forms.Cursors.Default;
			this.crptViewInHD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crptViewInHD.Location = new System.Drawing.Point(0, 0);
			this.crptViewInHD.Name = "crptViewInHD";
			this.crptViewInHD.Size = new System.Drawing.Size(947, 546);
			this.crptViewInHD.TabIndex = 0;
			// 
			// frmReportInHD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 546);
			this.Controls.Add(this.crptViewInHD);
			this.Name = "frmReportInHD";
			this.Text = "frmReportInHD";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmReportInHD_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crptViewInHD;
		private rptInHoaDon rptInHoaDon1;
	}
}