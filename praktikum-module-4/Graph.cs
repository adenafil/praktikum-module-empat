/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 15/01/2024
 * Time: 14:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace praktikum_module_4
{
	/// <summary>
	/// Description of Graph.
	/// </summary>
	public class Graph
	{
		private Vertex vertices;
		
		public Graph()
		{
			vertices = new Vertex();
		}
		
		public void BFS(int[] input, int[] result)
		{
			int langkahs = 0;
			bool isInputSameAsResult = false;
			
			if (isInputAndResultAlreadySame(input, result))
			{
				isInputSameAsResult = true;
			}
			else
			{
				Queue<int[]> dataOutputOfSaklar = new Queue<int[]>();
				dataOutputOfSaklar.Enqueue(input);
				this.vertices.Add(ArrIntToString(input), -1);
				
				while (dataOutputOfSaklar.Count != 0 && !isInputSameAsResult)
				{
					++langkahs;
					int[] outputSaklar = dataOutputOfSaklar.Dequeue();
					int numOfSaklarIndex = 0;
					
					while (numOfSaklarIndex < outputSaklar.Length)
					{
						// logic is here
						int[] tempOutput = ChangeSaklarByIndex(outputSaklar, numOfSaklarIndex);
						
						if (!this.vertices.doesContain(ArrIntToString(tempOutput)))
						{
							this.vertices.Add(ArrIntToString(tempOutput), numOfSaklarIndex);
							dataOutputOfSaklar.Enqueue(tempOutput);
							
							if (isInputAndResultAlreadySame(tempOutput, result))
							{
								isInputSameAsResult = true;
								break;
							}
						}
						++numOfSaklarIndex;
						
					}
				}
			}
			
			if (isInputSameAsResult) printResult(result, langkahs);
			else Console.WriteLine("Mustahil");
			
		}
		
		public int[] ChangeSaklarByIndex(int[] outputSaklar, int numOfSaklarIndex)
		{
			int[] result = new int[outputSaklar.Length];
			for (int i = 0; i < outputSaklar.Length; i++)
			{
				if (numOfSaklarIndex == i)
				{
					result[i] = outputSaklar[i];
				}
				else
				{
					result[i] = (outputSaklar[i] + 1) % 2;
				}
			}
			
			return result;
		}
		
		
		public String ArrIntToString(int[] data)
		{
			string result = null;
			
			for (int i = 0; i < data.Length; i++)
			{
				result += data[i];
			}
			return result;
		}
		
		public bool isInputAndResultAlreadySame(int[] input, int[] result)
		{
			return ArrIntToString(input).Equals(ArrIntToString(result));
		}
		
		public void printResult(int[] result, int langkahs)
		{
			Console.WriteLine(langkahs + " langkah");
			List<String> countPressOfSaklar = new List<string>();
//			string result = null;

			string outputSaklar = ArrIntToString(result);
			int[] tempOutput = result;
			
			for (int index = this.vertices.getIndexDataOfData(ArrIntToString(result)); index != -1; index = this.vertices.getIndexDataOfData(outputSaklar))
			{
//				Console.WriteLine("Press " + index + " : " + outputSaklar);
				countPressOfSaklar.Add("Press " + index + " : " + outputSaklar);
				
//				if (isInputAndResultAlreadySame()) break;
				
				tempOutput = ChangeSaklarByIndex(tempOutput, index);
				outputSaklar = ArrIntToString(tempOutput);
			}
			
			countPressOfSaklar.Reverse();
			countPressOfSaklar.ForEach(Console.WriteLine);
		}
	}
}
