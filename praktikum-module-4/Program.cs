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
			// Membuat variabel objek Graph
			Graph graph = new Graph();
			// memanggil BFS method pada graph
			// kemudian memberikan parameter array integer
			// sesuai yang dimasukan di terminal
			graph.BFS(StringArrToIntArr(getInput()), StringArrToIntArr(getInput()));
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		/// <summary>
		/// Method untuk meminta input dari termianl
		/// </summary>
		/// <returns></returns>
		public static String[] getInput()
		{
			// melakukan split ' ' yang mengembalikan
			// return array string
			return Console.ReadLine().Split(' ');
		}
		
		/// <summary>
		/// Method untuk merubah array string menjadi
		/// array integer
		/// </summary>
		/// <param name="value">array string</param>
		/// <returns>array integer</returns>
		public static int[] StringArrToIntArr(String[] value)
		{
			// membuat variabel array integer dengan length
			// sesuai dari valuenya
			int[] result = new int[value.Length];
			// lakukan looping sepanjang array valuenya
			for (int i = 0; i < value.Length; i++) {
				// assign ke dalam result dengan melakukan
				// parse terlebih dulu sehingga berubah menjadi integer
				result[i] = int.Parse(value[i]);
			}
			// mengembalikan integer array
			return result;
		}
	}
}