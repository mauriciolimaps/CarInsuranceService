using System.Linq;
using System.Collections;
using System.Collections.Generic;



namespace CarInsuranceAPI.Models
{
	public class TCarCoverage
	{
		public string description;
	}


	public class TCarCoverages : IEnumerable<TCarCoverage>
	{
		List<TCarCoverage> CarCoverages;

		public IEnumerator<TCarCoverage> GetEnumerator()
		{
			return CarCoverages.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<TCarCoverage> IEnumerable<TCarCoverage>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		public TCarCoverages()
		{
			this.CarCoverages = new List<TCarCoverage>();
		}

		public void Add(string description)
		{
			CarCoverages.Add(new TCarCoverage { description = description });
		}

		public IEnumerable<TCarCoverage> Names()
		{
			return from value in this.CarCoverages select value;
		}
	}
}