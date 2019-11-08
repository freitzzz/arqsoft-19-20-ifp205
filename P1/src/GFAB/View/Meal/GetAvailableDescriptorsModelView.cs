using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using static GFAB.View.GetAvailableDescriptorsModelView;

namespace GFAB.View{

	[CollectionDataContract]
	public class GetAvailableDescriptorsModelView : List<GetAvailableDescriptorsModelViewElement>{

		[DataContract]
		public class GetAvailableDescriptorsModelViewElement{

			public int Id{get;set;}

			public string Name{get;set;}

      public List<string> QuantityUnits{get;set;}

			public GetAvailableDescriptorsModelViewElement(string name, List<string> quantityUnits){

				Name = name;

        QuantityUnits = quantityUnits;

			}
		}

		public GetAvailableDescriptorsModelView(Dictionary<string, List<string>> descriptors){

      List<string> descriptorNames = descriptors.Keys.ToList();

			for(int i=0; i<descriptorNames.Count;i++){

				string name = descriptorNames[i];
        
        List<string> quantityUnits = descriptors[name];

				GetAvailableDescriptorsModelViewElement element = new GetAvailableDescriptorsModelViewElement(name, quantityUnits);

				element.Id = i + 1;

        Add(element);
			}

		}

	}

}