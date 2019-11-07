using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GFAB.Model{

	[CollectionDataContract]
	public class GetAvailableMeals : List<GetAvailableMeals.GetAvailableMealItem>{

		public class GetAvailableMealItem{
			public int id;
			
			public string designation;

			public string type;
		}

		public GetAvailableMeals(List<Meal> meals){

			foreach(Meal meal in meals){

				GetAvailableMealItem item = new GetAvailableMealItem();

				item.designation = meal.Designation.Id;

				item.type = meal.Type.Name;

			}

		}

	}

}