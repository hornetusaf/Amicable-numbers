/*
 * Created by SharpDevelop.
 * User: Hornet
 * Date: 10/15/2014
 * Time: 2:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Numeros_Amigos_Consola
{
	class Program
	{
		public static void Main(string[] args)
		{
			long n1, n2, acum1, acum2, N, i;
			string cadena;
			
			Console.WriteLine("Introduce el maximo: ");
			cadena = Console.ReadLine();
			N=Convert.ToInt64(cadena);
			
			for (n1=2; n1<N; n1= n1+1)
			{  
				for (n2= n1+ 1; n2<= N; n2= n2+1)
				{  
					//distribuir
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
						Console.WriteLine(n1+" "+n2+"\n");
				}
			}
			
			Console.WriteLine("No se encontaron mas amigos");
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}