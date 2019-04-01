using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarInsuranceAPI.Models;


namespace CarInsuranceAPI.Controllers
{
    public class CoveragesController : ApiController
    {
		private TCarCoverages coverages;

		public CoveragesController()
		{
			coverages = new TCarCoverages();

			coverages.Add("Seguro Completo"  );
			coverages.Add("Seguro Auto Roubo");
			coverages.Add("Seguro para terceiros");
			coverages.Add("Seguro de acidentes para passageiros");
		}

		// GET api/insurance/cars/coverages
		public IEnumerable<TCarCoverage> Get()
		{
			return coverages;
		}
	}
}
