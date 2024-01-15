/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 15/01/2024
 * Time: 14:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace praktikum_module_4
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			
			Vertex vertex = new Vertex();
			vertex.Add("1010", -1);
			vertex.getIndexDataOfData("1010");
			Console.WriteLine(			vertex.getIndexDataOfData("1010"));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
		}
	}
}