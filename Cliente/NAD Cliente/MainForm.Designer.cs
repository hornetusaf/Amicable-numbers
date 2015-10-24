/*
 * Created by SharpDevelop.
 * User: Hornet
 * Date: 10/16/2014
 * Time: 10:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NAD_Cliente
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
			this.ipTextBox = new System.Windows.Forms.TextBox();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.desconectarButton = new System.Windows.Forms.Button();
			this.conectarButton = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// ipTextBox
			// 
			this.ipTextBox.Location = new System.Drawing.Point(89, 7);
			this.ipTextBox.Name = "ipTextBox";
			this.ipTextBox.Size = new System.Drawing.Size(100, 20);
			this.ipTextBox.TabIndex = 0;
			// 
			// portTextBox
			// 
			this.portTextBox.Location = new System.Drawing.Point(243, 7);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(46, 20);
			this.portTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Direccion Ip:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(195, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Puerto:";
			// 
			// desconectarButton
			// 
			this.desconectarButton.Location = new System.Drawing.Point(376, 5);
			this.desconectarButton.Name = "desconectarButton";
			this.desconectarButton.Size = new System.Drawing.Size(86, 23);
			this.desconectarButton.TabIndex = 4;
			this.desconectarButton.Text = "Desconectar";
			this.desconectarButton.UseVisualStyleBackColor = true;
			this.desconectarButton.Click += new System.EventHandler(this.DesconectarButtonClick);
			// 
			// conectarButton
			// 
			this.conectarButton.Location = new System.Drawing.Point(295, 5);
			this.conectarButton.Name = "conectarButton";
			this.conectarButton.Size = new System.Drawing.Size(75, 23);
			this.conectarButton.TabIndex = 5;
			this.conectarButton.Text = "Conectar";
			this.conectarButton.UseVisualStyleBackColor = true;
			this.conectarButton.Click += new System.EventHandler(this.ConectarButtonClick);
			// 
			// statusLabel
			// 
			this.statusLabel.Location = new System.Drawing.Point(12, 33);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(452, 23);
			this.statusLabel.TabIndex = 6;
			this.statusLabel.Text = "Status: Desconectado";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 57);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(452, 23);
			this.progressBar1.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(476, 92);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.conectarButton);
			this.Controls.Add(this.desconectarButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.portTextBox);
			this.Controls.Add(this.ipTextBox);
			this.MaximumSize = new System.Drawing.Size(492, 130);
			this.MinimumSize = new System.Drawing.Size(492, 130);
			this.Name = "MainForm";
			this.Text = "NAD Cliente";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button conectarButton;
		private System.Windows.Forms.Button desconectarButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.TextBox ipTextBox;
	}
}
