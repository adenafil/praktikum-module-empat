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
		// membuat object vertex
		private Vertex vertices;
		
		// constructor
		public Graph()
		{
			vertices = new Vertex();
		}
		
		/// <summary>
		/// method untuk melakukan bfs
		/// </summary>
		/// <param name="input">input saklar pertama</param>
		/// <param name="result">input saklar yang kedua atau yang diinginkan</param>
		public void BFS(int[] input, int[] result)
		{
			// variabel untuk menyimpan langkah langkah yang sudah dilalui dengan methode BFS
			int langkahs = 0;
			// var untuk menampung data bool apakah sudah menemukan output saklar yang diharapkan atau belum
			bool isInputSameAsResult = false;
			
			// jika ternyata input dan resultya sama nilainya
			if (isInputAndResultAlreadySame(input, result))
			{
				// assign variabel isInputSameAsResult dengan nilai true
				isInputSameAsResult = true;
			}
			// jika ternyata tidak sama atau nilai var isInputSameAsResult masih false maka akan masuk ke scope bawah
			else
			{
				// membuat queue dataOutputSaklar
				Queue<int[]> dataOutputOfSaklar = new Queue<int[]>();
				// nilai input dari parameter dimasukan ke dalam queue
				dataOutputOfSaklar.Enqueue(input);
				// kemudian juga ditambahkann ke objek vertex
				// nilai awal indexnya adalah -1
				this.vertices.Add(ArrIntToString(input), -1);
				
				// jika length pada queue dataOutputSaklar tidak sama dengan 0
				// dan input dan result masih belum sama maka lakukanlah
				// perulangan terus menerus hingga kondisi tersebut ada yang beda
				while (dataOutputOfSaklar.Count != 0 && !isInputSameAsResult)
				{
					// mengincrement var langkahs
					++langkahs;
					// melakukan dequeue pada var dataOutputSaklar
					// sekaligus menaruhnya ke array outputSaklar
					int[] outputSaklar = dataOutputOfSaklar.Dequeue();
					// membuat var numOfSaklr dan memberinya nilai index
					// yang artinya kita akan mulai bfs dengan index 0 pada output saklar tersbut
					int numOfSaklarIndex = 0;
					
					// selama nilai dari var numOfSaklarIdex tidak sama dengan
					// panjang dari array outputSaklar maka lakukan terus perulangan
					while (numOfSaklarIndex < outputSaklar.Length)
					{
						// melakukan press saklar yang dimulai dengan index 0
						// kemudian tampung ke array tempOutput
						int[] tempOutput = ChangeSaklarByIndex(outputSaklar, numOfSaklarIndex);
						
						// Jika output saklar dari tempOutput masih belum ada pada objek
						// vertex maka masuklah ke scope dan sebaliknya.
						if (!this.vertices.doesContain(ArrIntToString(tempOutput)))
						{
							// menambahkan output hasill press tadi ke dalam vertex
							this.vertices.Add(ArrIntToString(tempOutput), numOfSaklarIndex);
							// kemudian menambahkan output hasil press saklar tadi ke
							// dalam queue pada variabel dataOutputSaklar
							dataOutputOfSaklar.Enqueue(tempOutput);
							
							// melakukan pengecekan apakah output dari saklar yang dipress tadi
							// sudah sama dengan saklar pada output result ?
							// jika iya maka lakukan break atau berhenti jika tidak maka tetaplah looping
							if (isInputAndResultAlreadySame(tempOutput, result))
							{
								isInputSameAsResult = true;
								break;
							}
						}
						// increment index untuk mengpress saklar
						++numOfSaklarIndex;
						
					}
				}
			}
			
			// kemudian jika looping while tadi sudah selesai
			// entah karena queuenya sudah kosong atau sudah ditemukan
			// maka lakukan pencegecekan jika sudah ditemukan maka printlah
			// output-outputnya
			if (isInputSameAsResult) printResult(result, langkahs);
			// jika tak ditemukan maka print Mustahil
			else Console.WriteLine("Mustahil");
			
		}
		
		/// <summary>
		/// Method untuk melakukan perubahan output pada saklar
		/// dengan memencet atau memilih index mana yang ingin tak
		/// dirubah dan sisanya terubah
		/// </summary>
		/// <param name="outputSaklar">output saklar</param>
		/// <param name="numOfSaklarIndex">index mana yang ingin dipilih (0-max length)</param>
		/// <returns>mengembalikan hasil output yang sudah dipress</returns>
		public int[] ChangeSaklarByIndex(int[] outputSaklar, int numOfSaklarIndex)
		{
			// membuat variabel int array result dengan length
			// sesuai panjang dari length outputSaklar
			int[] result = new int[outputSaklar.Length];
			// kemudian melakukan looping sebanyak length pada
			// output saklar tersebut.
			for (int i = 0; i < outputSaklar.Length; i++)
			{
				// cek apakah index yang dipress sama dengan
				// index dari looping for
				if (numOfSaklarIndex == i)
				{
					// jika iya maka jangan lakukan perubahan
					// semisal 1 0 1 0
					// dan index yang dipress sama dengan index looping for 
					// maka dia akan menjadi 0 0 0 1 (jika yang dipress index 1)
					result[i] = outputSaklar[i];
				}
				else
				{
					// jika iya tidak sama dengan index maka rubahlah
					// either saklarnya menjadi off(0) atau on(1)
					result[i] = (outputSaklar[i] + 1) % 2;
				}
			}
			
			// mengembalikan hasil output press
			return result;
		}
		
		/// <summary>
		/// Method untuk merubah int array menjadi string
		/// </summary>
		/// <param name="data">data atau output saklr</param>
		/// <returns>return hasil converternya yang berubah string dari output saklar</returns>
		public String ArrIntToString(int[] data)
		{
			// membuat variabel result dengan nilai null
			string result = null;
			// lakukan looping sebanyak length dari parameter data
			for (int i = 0; i < data.Length; i++)
			{
				// lakukan addition asignment ke dalam variabel result
				// dari index nilai array data
				result += data[i];
			}
			// return hasil convernya
			return result;
		}
		
		/// <summary>
		/// Method untuk mengecek output dari ke dua saklar
		/// apakah dia sama atau tidak sama
		/// </summary>
		/// <param name="input">output saklar pertama</param>
		/// <param name="result">output saklar kedua</param>
		/// <returns>jika sama kembalikan true dan sebaliknya</returns>
		public bool isInputAndResultAlreadySame(int[] input, int[] result)
		{
			// lakuakn convert dari data array int pada 2 parameter
			// jika sudah dirubah menjadi string
			// maka gunakanlah method string yang bernama Equals
			// jika hasil pengecekan tersebut sama maka returnkanlah true
			// dan sebaliknya
			return ArrIntToString(input).Equals(ArrIntToString(result));
		}
		
		/// <summary>
		/// Method untuk melakukan print output saklar
		/// dan memberitahukanya juga index apa saja yang dipress
		/// sehingga mendapatkan hasil yang sesuai denga saklar kedua
		/// </summary>
		/// <param name="result">output hasil</param>
		/// <param name="langkahs">langkah langkah yang sudah dilalui dari hasil while loop pada BFS</param>
		public void printResult(int[] result, int langkahs)
		{
			// print langkahnya
			Console.WriteLine(langkahs + " langkah");
			// membuat list dari kumpulan index saklar yang dipress dan outputnya
			List<String> countPressOfSaklar = new List<string>();

			// kemudian convert dia menjadi string dan menaruhnya
			// ke dalam variabel outputSaklar
			string outputSaklar = ArrIntToString(result);
			// membuat variabel integer array yang bernama tempoutput
			// dengan array dari variabel result
			int[] tempOutput = result;
			
			// lakukan for looping dengan nilai index yang sesuai dengan vertex dari output result
			// dan dilooping selama nilai dari index vertex/ index datanya tidak sama dengan -1
			// dan juga lakukan assignment dari setiap looping dengan mencari index dari output saklar
			// pada variabel atau objex vertexnya
			for (int index = this.vertices.getIndexDataOfData(ArrIntToString(result)); index != -1; index = this.vertices.getIndexDataOfData(outputSaklar))
			{
				// masukan ke dalam list countPressOFSaklar
				countPressOfSaklar.Add("Press " + index + " : " + outputSaklar);
				// kemudian lakukan press untuk mendapatkan output sebelumnya
				// dan assignyalah ke dalam array tempOutput
				tempOutput = ChangeSaklarByIndex(tempOutput, index);
				// kemudian convertlah menjadi string
				outputSaklar = ArrIntToString(tempOutput);
			}
			
			// jika sudah selesai melakukan looping
			// maka reverselah setiap langkah dan pressnya tadi
			countPressOfSaklar.Reverse();
			// kemudian printlah setiap data dari list
			// variabel countPressOfSaklar tersebut
			countPressOfSaklar.ForEach(Console.WriteLine);
		}
	}
}
