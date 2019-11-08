using System.Collections.Generic;
using System.Runtime.Serialization;
using GFAB.Model;
using static GFAB.View.GetAvailableIngredientsModelView;

namespace GFAB.View{

	[CollectionDataContract]
	public class GetAvailableIngredientsModelView : List<GetAvailableIngredientsModelViewElement>{

		[DataContract]
		public class GetAvailableIngredientsModelViewElement{

			public int Id;

			public string Name;

			public GetAvailableIngredientsModelViewElement(string ingredient){

				Name = ingredient;

			}
		}

		public GetAvailableIngredientsModelView(List<string> ingredients){

			for(int i=0; i<ingredients.Count;i++){

				string ingredient = ingredients[i];

				GetAvailableIngredientsModelViewElement element = new GetAvailableIngredientsModelViewElement(ingredient);

				element.Id = i + 1;
			}

		}

	}

}