/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 15/01/2024
 * Time: 14:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace praktikum_module_4
{
	/// <summary>
	/// Description of Vertex.
	/// </summary>
	public class Vertex
	{
		// list untuk menyimpan data output saklar
		private List<string> data = new List<string>();
		// list untuk menyimpan index data saklar yang di klik
		private List<int> indexData = new List<int>();
		
		// Constructor biasa
		public Vertex()
		{
		}
		
		// Constructor dengan langsung bisa menambah data pada variabel
		public Vertex(String data, int indexData)
		{
			this.data.Add(data);
			this.indexData.Add(indexData);
		}
		
		/// <summary>
		/// Method untuk mencari index saklar yang diklik untuk mencapai hasil akhir yang dinginkan.
		/// data tersebut tertampung pada list indexData
		/// </summary>
		/// <param name="data">output saklar</param>
		/// <returns>mengembalikan index dari output saklar tersebut</returns>
		public int getIndexDataOfData(string data)
		{
			// found var untuk menyimpan data jika index berhasil ditemukan
			bool found = false;
			// initialize nilai awal dengan -1
			int indexData = -1;
			// variabel untuk menghitung putaran ForEach pada list data
			int putaranData = 1;
			// kemudian melakukan for each dengan lambda
			this.data.ForEach(e => {
			                  	// jika data pada list data sama dengan nilai dari variabel atau parameter data
			                  	if (e.Equals(data))
			                  	{
			                  		// maka assign var found menjadi true
			                  		found = true;
			                  	}
			                  	// jika masih belum ditemukan maka lakukan increment pada var putaran data
			                  	if (!found) {
			               			++putaranData;
			                  	}
			                  });
			
			// var menghitung sama dengan putaran data
			// bedanya dia digunakan untuk list indexData
			int menghitungIndex = 1;
		
			// kemudian lakukan for each dengan lambda
			this.indexData.ForEach(e => {
			                       	// jika putaran data (var yang menghitung putaran index pada var data)
			                       	// equal atau sama dengan menghitung data (var yang menghitung putaran pada list index dari var indexData)
			                       	// maka assign nilai index data pada scope method getIndexDataOfData() dengan nilai dari list indexData
			                       	if (putaranData == menghitungIndex) indexData =  int.Parse(e.ToString());
			                       	// jika kondisi di atas = false, maka lakukanlah increment
			                       	menghitungIndex++;
			                       });
			
			// mengembalikan nilai indexData
			// jika tidak ditemukan nilai yang dicari maka akan mengambilkan -1
			// sebaliknya akan mengambilkan nilai yang dicari
			return indexData;
		}
		
		/// <summary>
		/// Method untuk menambahkan data output sakalr dan index yang dipilih.
		/// </summary>
		/// <param name="data">output saklar</param>
		/// <param name="indexData">index yang dipilih</param>
		public void Add(string data, int indexData)
		{
			// menambhkan data dan index data ke list data dan indexData
			this.data.Add(data);
			this.indexData.Add(indexData);
		}
		
		/// <summary>
		/// Method untuk mengecek apakah output dari saklar sudah
		/// terisi pada list data
		/// </summary>
		/// <param name="data">output saklar</param>
		/// <returns>return true jika ada dan sebaliknya</returns>
		public bool doesContain(string data)
		{
			return this.data.Contains(data);
		}
		
	}
}
