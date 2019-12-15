using System.Collections.Generic;
using System.Runtime.Serialization;
using GFAB.Model;
using static GFAB.View.GetAvailableMealTypesModelView;

namespace GFAB.View{

	[CollectionDataContract]
	public class GetAvailableMealTypesModelView : List<GetAvailableMealTypesModelViewElement>{

		[DataContract]
		public class GetAvailableMealTypesModelViewElement{

			public int Id {get;set;}

			public string Name {get;set;}

			public GetAvailableMealTypesModelViewElement(string mealType){

				Name = mealType;

			}
		}

		public GetAvailableMealTypesModelView(List<string> mealTypes){

			for(int i=0; i<mealTypes.Count;i++){

				string mealType = mealTypes[i];

				GetAvailableMealTypesModelViewElement element = new GetAvailableMealTypesModelViewElement(mealType);

				element.Id = i + 1;

        Add(element);
			}

		}

	}

}