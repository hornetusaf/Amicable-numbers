using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;


namespace NAD_Cliente
{
	public partial class MainForm : Form
	{
		TcpClient _client;
		StreamReader _sReader;
		StreamWriter _sWriter;
		Boolean _isConnected;
		Thread tClient;
		String ipAddress, myIp;
		Int32 portNum;
		long inicio, N;
		Thread calcularThread;
		
		public MainForm()
		{
			InitializeComponent();
			IPHostEntry host;
			host=Dns.GetHostEntry(Dns.GetHostName());
			foreach(IPAddress ip in host.AddressList)
			{
				if(ip.AddressFamily == AddressFamily.InterNetwork)
				{
					myIp = ip.ToString();
					break;
				}
			}
			calcularThread = new Thread(new ThreadStart(calcular));
			desconectarButton.Enabled=false;
		}
		
		public void clientConnect()
		{
			_client = new TcpClient();
			
			try
			{
				_client.Connect(ipAddress, portNum);
			}
			catch (SocketException e)
			{
				
			}
			
			HandleCommunication();
		}
		
		public void HandleCommunication()
		{
			if(_client.Connected)
			{
				_isConnected = true;
				_sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
				_sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);
			}
			else
			{
				_isConnected=false;
				_client.Close();
				tClient.Interrupt();
				tClient=null;
			}
			
			if(_isConnected)
			{
				
				conectarButton.Invoke(new Action(() =>
				                                 {
				                                 	conectarButton.Enabled=false;
				                                 }));
				desconectarButton.Invoke(new Action(() =>
				                                    {
				                                    	desconectarButton.Enabled=true;
				                                    }));
				statusLabel.Invoke(new Action(() =>
				                              {
				                              	statusLabel.Text="Status: Conectado";
				                              }));
			}
			
			String sDataIncomming = null;
			String[] numeros = null;
			
			while (_isConnected)
			{
				try
				{
					sDataIncomming = _sReader.ReadLine();
				}
				catch (IOException)
				{
					
				}
				
				if(sDataIncomming == "chao")
				{
					if(calcularThread.IsAlive)
					{
						_isConnected=false;
						calcularThread.Interrupt();
						calcularThread=null;
						_client.Close();
						statusLabel.Text="Status: Desconectado";
						conectarButton.Enabled=true;
						desconectarButton.Enabled=false;
					}
					else
					{
						_isConnected=false;
						_client.Close();
						statusLabel.Invoke(new Action(() =>
						                              {
						                              	statusLabel.Text="Status: Desconectado";
						                              }));
						
						conectarButton.Invoke(new Action(() =>
						                                 {
						                                 	conectarButton.Enabled=true;
						                                 }));
						
						desconectarButton.Invoke(new Action(() =>
						                                    {
						                                    	desconectarButton.Enabled=false;
						                                    }));
						_client.Close();
						tClient.Interrupt();
						tClient=null;
					}
				}
				else
					if(_isConnected)
				{
					numeros = sDataIncomming.Split(' ');
					
					inicio = Convert.ToInt64(numeros[0]);
					N = Convert.ToInt64(numeros[1]);
					
					statusLabel.Invoke(new Action(() =>
					                              {
					                              	statusLabel.Text="Status: Calculando numeros entre "+inicio.ToString()+" y "+N.ToString();
					                              }));
					
					calcularThread.Start();
				}
			}
		}
		
		public void calcular()
		{
			long n1, n2, acum1, acum2, i;
			
			progressBar1.Invoke(new Action(() =>
			                               {
			                               	progressBar1.Minimum=(int)inicio;
			                               	progressBar1.Maximum=(int)N;
			                               }));
			
			for(n1=inicio; n1<N; n1=n1+1)
			{
				for(n2=n1+1; n2<=N; n2=n2+1)
				{
					acum1= 0; acum2= 0;
					
					for (i= 1; i<=n1/2; i= i+1)
					{
						if (n1%i== 0)
							acum1= acum1+i;
					}
					for (i= 1; i<=n2/2; i= i+1)
					{
						if (n2%i== 0)
							acum2= acum2+i;
					}
					//
					if (n1== acum2 && n2== acum1)
					{
						_sWriter.WriteLine(n1.ToString()+" "+n2.ToString());
						_sWriter.Flush();
					}
				}
				
				progressBar1.Invoke(new Action(() =>
				                               {
				                               	progressBar1.Value=(int)n1;
				                               }));
			}
			
			statusLabel.Invoke(new Action(() =>
			                              {
			                              	statusLabel.Text="Status: Finalizado el calculo";
			                              }));
			
			calcularThread.Interrupt();
			calcularThread=null;
			calcularThread = new Thread(new ThreadStart(calcular));
		}
		
		void ConectarButtonClick(object sender, EventArgs e)
		{
			ipAddress= ipTextBox.Text;
			portNum= Convert.ToInt32(portTextBox.Text);
			
			tClient = new Thread(new ThreadStart(clientConnect));
			tClient.Start();
		}
		
		void DesconectarButtonClick(object sender, EventArgs e)
		{
			_isConnected=false;
			_sWriter.WriteLine("chao "+myIp);
			_sWriter.Flush();
			_sReader.Dispose();
			_sReader.Close();
			
			_client.Close();
			tClient.Interrupt();
			tClient=null;
			
			statusLabel.Text="Status: Desconectado";
			conectarButton.Enabled=true;
			desconectarButton.Enabled=false;
		}
	}
}
