using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
	public class Indexer
	{
		private double[] Arr;
		private int Start { get; set; }
		public int Length { get; set; }

		private bool IsCorrectIndex(int index)
		{
			if (index >= 0 && index < Length)
				return true;
			else
				return false;
		}

		public double this[int index] {
			get
			{
				if (IsCorrectIndex(index))
					return Arr[Start+index];
				else
					throw new IndexOutOfRangeException();
				
			}
			set
			{
				if(IsCorrectIndex(index))
					Arr[Start+index] = value;
				else
					throw new IndexOutOfRangeException();
			}
		}

		public Indexer(double[] array, int start, int length)
		{
			if (start < 0 || start >= array.Length || length < 0 || start + length > array.Length)
				throw new ArgumentException();
			Arr = array;
			Start = start;
			Length = length;
		}
	}
	
}
