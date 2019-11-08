using System.Collections.Generic;
using System.Runtime.Serialization;
using static GFAB.View.GetAvailableIngredientsModelView;

namespace GFAB.View{

	[CollectionDataContract]
	public class GetAvailableIngredientsModelView : List<GetAvailableIngredientsModelViewElement>{

		[DataContract]
		public class GetAvailableIngredientsModelViewElement{

			public int Id {get;set;}

			public string Name {get;set;}

			public GetAvailableIngredientsModelViewElement(string ingredient){

				Name = ingredient;

			}
		}

		public GetAvailableIngredientsModelView(List<string> ingredients){

			for(int i=0; i<ingredients.Count;i++){

				string ingredient = ingredients[i];

				GetAvailableIngredientsModelViewElement element = new GetAvailableIngredientsModelViewElement(ingredient);

				element.Id = i + 1;

        Add(element);
			}

		}

	}

}