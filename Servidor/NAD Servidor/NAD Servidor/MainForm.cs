using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;

namespace NAD_Servidor
{
	public partial class MainForm : Form
	{
		TcpListener _server;
		Boolean _isRunning;
		Thread tServer, buscarAmigos;
		Int32 port=8888;
		List<cliente> vecClientes;
		List<String> listaClientes;
		int k;
		String[] cadena;
		
		public MainForm()
		{
			InitializeComponent();
			k=-1;
			cadena=null;
			vecClientes = new List<cliente>();
			listaClientes = new List<String>();
			clientesListBox.DataSource = listaClientes;
			ipLabel.Text = "Ip: " + LocalIPAddress();
			portLabel.Text = "Puerto: " + port.ToString();
			buscarAmigos = new Thread(new ThreadStart(buscar));
			tServer = new Thread(new ThreadStart(TcpServer));
			tServer.Start();
		}
		
		public void TcpServer()
		{
			_server = new TcpListener(IPAddress.Any, port);
			_server.Start();
			
			_isRunning = true;
			
			LoopClients();
		}
		
		public void LoopClients()
		{
			while (_isRunning)
			{
				// wait for client connection
				TcpClient newClient = _server.AcceptTcpClient();
				// client found.
				// create a thread to handle communication
				Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
				t.Start(newClient);
			}
		}
		
		public void HandleClient(object obj)
		{
			// retrieve client from parameter passed to thread
			cliente client = new cliente((TcpClient)obj);
			
			IPEndPoint ep = client.clienteTCP.Client.RemoteEndPoint as IPEndPoint;
			if (ep != null)
				client.direccionIp = ep.Address.ToString();
			else
				client.direccionIp = "no encontrada";
			
			vecClientes.Add(client);
			k++;
			listaClientes.Add(client.direccionIp);
			
			clientesListBox.Invoke(new Action(() =>
			                                  {
			                                  	clientesListBox.DataSource = null;
			                                  	clientesListBox.DataSource = listaClientes;
			                                  }));
			
			
			Boolean bClientConnected = true;
			
			String clienteIp;
			
			while (bClientConnected)
			{
				// reads from stream
				client.datos = client.sReader.ReadLine();
				
				if(client.datos!=null)
				{
					cadena = client.datos.Split(' ');
					
					if(cadena[0] == "chao")
					{
						clienteIp=cadena[1];
						listaClientes.Remove(clienteIp);
						clientesListBox.Invoke(new Action(() =>
						                                  {
						                                  	clientesListBox.DataSource = null;
						                                  	clientesListBox.DataSource = listaClientes;
						                                  }));
						int index;
						index = vecClientes.FindIndex(cliente => cliente.direccionIp == clienteIp);
						vecClientes[index].clienteTCP.Close();
						vecClientes.RemoveAt(index);
						bClientConnected=false;
						k--;
					}
					else
					{
						resultadoTextBox.Invoke(new Action(() =>
						                                   {
						                                   	resultadoTextBox.AppendText(client.datos+"\n");
						                                   }));
					}
				}
			}
		}
		
		public string LocalIPAddress()
		{
			IPHostEntry host;
			string localIP = "";
			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					localIP = ip.ToString();
					break;
				}
			}
			return localIP;
		}
		
		public void buscar()
		{
			long n1, n2, acum1, acum2, N, i, inicio, divisor;
			Int32 j;
			string cadena, r1, r2;
			
			resultadoTextBox.Invoke(new Action(() =>
			                                   {
			                                   	resultadoTextBox.Text="";
			                                   }));
			
			cadena = numeroTextBox.Text;
			N=Convert.ToInt64(cadena);
			inicio=2;
			
			if(vecClientes.Count > 0)
			{
				divisor=N/(vecClientes.Count+1);
				divisor = (long)Math.Round((decimal)divisor, 0, MidpointRounding.AwayFromZero);
				N=divisor;
				
				for(j=0; j<vecClientes.Count; j++)
				{
					vecClientes[j].sWriter.WriteLine(inicio.ToString()+" "+N.ToString());
					vecClientes[j].sWriter.Flush();
					
					if(j==0)
						inicio=inicio+divisor-1;
					else
						inicio=inicio+divisor;
					
					N=N+divisor;
				}
			}
			
			progressBar1.Invoke(new Action(() =>
			                               {
			                               	progressBar1.Minimum = (int)inicio;
			                               	progressBar1.Maximum = (int)N;
			                               }));
			
			statusLabel.Invoke(new Action(() =>
			                              {
			                              	statusLabel.Text="Status: Calculando numeros entre "+inicio.ToString()+ " y "+N.ToString();
			                              }));
			
			for (n1=inicio; n1<N; n1=n1+1)
			{
				for (n2= n1+1; n2<=N; n2=n2+1)
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
						r1=n1.ToString();
						r2=n2.ToString();
						
						resultadoTextBox.Invoke(new Action(() =>
						                                   {
						                                   	resultadoTextBox.AppendText(r1+" "+r2+"\n");
						                                   }));
						
					}
				}
				
				progressBar1.Invoke(new Action(() =>
				                               {
				                               	progressBar1.Value = (int)n1;
				                               }));
			}
			
			resultadoTextBox.Invoke(new Action(() =>
			                                   {
			                                   	resultadoTextBox.AppendText("No se encontaron mas amigos\n");
			                                   }));
			
			buscarAmigos.Interrupt();
			buscarAmigos=null;
			buscarAmigos = new Thread(new ThreadStart(buscar));
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			cadena=null;
			for(int i=0; i<vecClientes.Count; i++)
			{
				vecClientes[i].sWriter.WriteLine("chao");
				vecClientes[i].sWriter.Flush();
			}
			
			_server.Stop();
			tServer.Abort();
			if(buscarAmigos.IsAlive)
				buscarAmigos.Abort();
		}
		
		void BuscarButtonClick(object sender, EventArgs e)
		{
			long N;
			string cadena = numeroTextBox.Text;
			if(long.TryParse(cadena, out N))
				buscarAmigos.Start();
		}		
	}
	
	public class cliente
	{
		public StreamWriter sWriter;
		public StreamReader sReader;
		public TcpClient clienteTCP;
		public String datos;
		public String direccionIp;
		
		public cliente(TcpClient obj)
		{
			clienteTCP = (TcpClient)obj;
			sReader = new StreamReader(obj.GetStream(), Encoding.ASCII);
			sWriter = new StreamWriter(obj.GetStream(), Encoding.ASCII);
			datos = "";
			direccionIp = "";
		}
	}
}
