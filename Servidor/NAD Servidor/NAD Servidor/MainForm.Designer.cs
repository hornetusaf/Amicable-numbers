/*
 * Created by SharpDevelop.
 * User: Hornet
 * Date: 10/15/2014
 * Time: 2:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NAD_Servidor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.ipLabel = new System.Windows.Forms.Label();
			this.portLabel = new System.Windows.Forms.Label();
			this.clientesListBox = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buscarButton = new System.Windows.Forms.Button();
			this.numeroTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.resultadoTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ipLabel
			// 
			this.ipLabel.Location = new System.Drawing.Point(12, 9);
			this.ipLabel.Name = "ipLabel";
			this.ipLabel.Size = new System.Drawing.Size(100, 23);
			this.ipLabel.TabIndex = 0;
			this.ipLabel.Text = "Ip: 00.00.00.00";
			// 
			// portLabel
			// 
			this.portLabel.Location = new System.Drawing.Point(12, 32);
			this.portLabel.Name = "portLabel";
			this.portLabel.Size = new System.Drawing.Size(100, 23);
			this.portLabel.TabIndex = 1;
			this.portLabel.Text = "Puerto: 1234";
			// 
			// clientesListBox
			// 
			this.clientesListBox.FormattingEnabled = true;
			this.clientesListBox.Location = new System.Drawing.Point(232, 35);
			this.clientesListBox.Name = "clientesListBox";
			this.clientesListBox.Size = new System.Drawing.Size(214, 95);
			this.clientesListBox.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(232, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(214, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Clientes conectados:";
			// 
			// buscarButton
			// 
			this.buscarButton.Location = new System.Drawing.Point(151, 79);
			this.buscarButton.Name = "buscarButton";
			this.buscarButton.Size = new System.Drawing.Size(75, 23);
			this.buscarButton.TabIndex = 4;
			this.buscarButton.Text = "Buscar";
			this.buscarButton.UseVisualStyleBackColor = true;
			this.buscarButton.Click += new System.EventHandler(this.BuscarButtonClick);
			// 
			// numeroTextBox
			// 
			this.numeroTextBox.Location = new System.Drawing.Point(12, 81);
			this.numeroTextBox.Name = "numeroTextBox";
			this.numeroTextBox.Size = new System.Drawing.Size(133, 20);
			this.numeroTextBox.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Numero maximo a buscar:";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 107);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(214, 23);
			this.progressBar1.TabIndex = 8;
			// 
			// resultadoTextBox
			// 
			this.resultadoTextBox.Location = new System.Drawing.Point(12, 182);
			this.resultadoTextBox.Multiline = true;
			this.resultadoTextBox.Name = "resultadoTextBox";
			this.resultadoTextBox.ReadOnly = true;
			this.resultadoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.resultadoTextBox.Size = new System.Drawing.Size(434, 98);
			this.resultadoTextBox.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 156);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(434, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "Pares de numeros amigos encontrados:";
			// 
			// statusLabel
			// 
			this.statusLabel.Location = new System.Drawing.Point(12, 133);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(434, 23);
			this.statusLabel.TabIndex = 11;
			this.statusLabel.Text = "Status:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 292);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.resultadoTextBox);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numeroTextBox);
			this.Controls.Add(this.buscarButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.clientesListBox);
			this.Controls.Add(this.portLabel);
			this.Controls.Add(this.ipLabel);
			this.MaximumSize = new System.Drawing.Size(474, 330);
			this.MinimumSize = new System.Drawing.Size(474, 330);
			this.Name = "MainForm";
			this.Text = "NAD Servidor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox resultadoTextBox;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox numeroTextBox;
		private System.Windows.Forms.Button buscarButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox clientesListBox;
		private System.Windows.Forms.Label portLabel;
		private System.Windows.Forms.Label ipLabel;
	}
}
