using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace CarInsuranceAPI.Models
{
	public class TCarBrand
	{
		public int BrandID;
		public string Name;
	}


	public class TCarModel
	{
		public int ModelID;
		public int BrandId;
		public string Name;
	}


	public class TCarBrands : IEnumerable<TCarBrand>
	{
	List<TCarBrand> CarBrands;

	public IEnumerator<TCarBrand> GetEnumerator()
	{
		return CarBrands.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public TCarBrands()
	{
		this.CarBrands = new List<TCarBrand>();
	}

	public void Add(int BrandID, string name)
	{
		CarBrands.Add(new TCarBrand { BrandID = BrandID, Name = name });
	}

	public IEnumerable<string> Names()
	{
		return from value in this.CarBrands select value.Name;
	}
}


	public class TCarModels : IEnumerable<TCarModel>
	{
		List<TCarModel> models;

		public IEnumerator<TCarModel> GetEnumerator()
		{
			return models.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//throw new NotImplementedException();
			return GetEnumerator();
		}

		public TCarModels()
		{
			this.models = new List<TCarModel>();
		}

		public void Add(string name, int BrandId)
		{
			models.Add(new TCarModel { BrandId = BrandId, Name = name });
		}

		public IEnumerable<string> Names()
		{
			return from value in this.models select value.Name;
		}
	}
	
}