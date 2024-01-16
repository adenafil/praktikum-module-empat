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
		private List<string> data = new List<string>();
		private List<int> indexData = new List<int>();
		
		public Vertex()
		{
		}
		
		public Vertex(String data, int indexData)
		{
			this.data.Add(data);
			this.indexData.Add(indexData);
		}
		
		public int getIndexDataOfData(string data)
		{
			bool found = false;
			int indexData = -1;
			int putaranData = 1;
			this.data.ForEach(e => {
			                  	if (e.Equals(data))
			                  	{
			                  		found = true;
			                  	}
			                  	if (!found) {
			               			++putaranData;
			                  	}
			                  });
			
			int menghitungIndex = 1;
		
			this.indexData.ForEach(e => {
			                       	
			                       	if (putaranData == menghitungIndex) indexData =  int.Parse(e.ToString());
			                       	menghitungIndex++;
			                       });
			
			return indexData;
		}
		
		public void Add(string data, int indexData)
		{
			this.data.Add(data);
			this.indexData.Add(indexData);
		}
		
		public bool doesContain(string data)
		{
			return this.data.Contains(data);
		}
		
	}
}
