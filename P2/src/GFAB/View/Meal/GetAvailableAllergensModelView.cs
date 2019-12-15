using System.Collections.Generic;
using System.Runtime.Serialization;
using static GFAB.View.GetAvailableAllergensModelView;

namespace GFAB.View{

	[CollectionDataContract]
	public class GetAvailableAllergensModelView : List<GetAvailableAllergensModelViewElement>{

		[DataContract]
		public class GetAvailableAllergensModelViewElement{

			public int Id{get;set;}

			public string Name{get;set;}

			public GetAvailableAllergensModelViewElement(string name){

				Name = name;

			}
		}

		public GetAvailableAllergensModelView(List<string> allergens){

			for(int i=0; i<allergens.Count;i++){

				string allergen = allergens[i];

				GetAvailableAllergensModelViewElement element = new GetAvailableAllergensModelViewElement(allergen);

				element.Id = i + 1;

        Add(element);
			}

		}

	}

}