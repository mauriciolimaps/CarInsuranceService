
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarInsuranceAPI.Models;

namespace CarInsuranceAPI
{
	// GET api/insurace/cars
	public class CarBrandsController : ApiController
	{
		TCarBrands CarBrands;
		TCarModels CarModels;

		CarBrandsController()
		{
			this.DataLoad();
		}

		private void DataLoad()
		{
			try
			{
				string filename;

				this.CarBrands = new TCarBrands();
				filename = General.AssemblyDirectory + "\\data\\marcas-carros.csv";
				using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
				{
					string line;

					file.ReadLine();
					while ((line = file.ReadLine()) != null)
					{
						string[] parts = line.Split(';');
						this.CarBrands.Add(Convert.ToInt32(parts[0]), parts[1]);
					}
				}

				this.CarModels = new TCarModels();
				filename = General.AssemblyDirectory + "\\data\\modelos-carro.csv";
				using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
				{
					string line;

					file.ReadLine();
					while ((line = file.ReadLine()) != null)
					{
							string[] parts = line.Split(';');
							this.CarModels.Add(parts[2], Convert.ToInt32(parts[1]));
					}
				}

			}
			catch (Exception ex)
			{

			}
		}

		// GET api/insurance/cars/brands
		public IEnumerable<TCarBrand> Get()
		{
			return CarBrands;
		}

		// GET api/insurance/cars/brands/{brand}
		public IEnumerable<string> Get(string brand)
		{
			IEnumerable<String> FilteredModels;

			FilteredModels = new List<string>();
			if (brand.All(char.IsNumber))
			{
					FilteredModels = CarModels.Where(CarModel => CarModel.BrandId == Convert.ToInt32(brand)).Select(CarModel => CarModel.Name);
			}

			return FilteredModels;
		}
	}
}