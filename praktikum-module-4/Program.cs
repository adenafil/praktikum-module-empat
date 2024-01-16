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
			Graph graph = new Graph();
			graph.BFS(StringArrToIntArr(getInput()), StringArrToIntArr(getInput()));
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static String[] getInput()
		{
			return Console.ReadLine().Split(' ');
		}
		
		public static int[] StringArrToIntArr(String[] value)
		{
			int[] result = new int[value.Length];
			for (int i = 0; i < value.Length; i++) {
				result[i] = int.Parse(value[i]);
			}
			return result;
		}
	}
}