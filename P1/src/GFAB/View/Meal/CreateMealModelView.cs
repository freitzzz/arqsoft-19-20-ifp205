using System.Collections.Generic;
using System.Runtime.Serialization;
using GFAB.Model;
using static GFAB.View.CreateMealModelView.CreateMealModelViewDescriptors;

namespace GFAB.View{

	[DataContract]
	public class CreateMealModelView{

		public string Designation;

		public string Type;
		
		public List<string> Ingredients;

		public List<string> Allergens;

		public CreateMealModelViewDescriptors Descriptors;


		[CollectionDataContract]
		public class CreateMealModelViewDescriptors : List<CreateMealModelViewDescriptorsElement>{

			[DataContract]
			public class CreateMealModelViewDescriptorsElement{

				public string Name;

				public double Quantity;

				public string QuantityUnit;

				public CreateMealModelViewDescriptorsElement(Descriptor descriptor){

					Name = descriptor.Name;

					Quantity = descriptor.Quantity;

					QuantityUnit = descriptor.QuantityUnit;

				}

			}

			public CreateMealModelViewDescriptors(List<Descriptor> descriptors){

				foreach(Descriptor descriptor in descriptors){

					CreateMealModelViewDescriptorsElement element = new CreateMealModelViewDescriptorsElement(descriptor);

					Add(element);

				}

			}

		}

	}

}