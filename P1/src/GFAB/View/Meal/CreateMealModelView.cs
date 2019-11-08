using System.Collections.Generic;
using System.Runtime.Serialization;
using GFAB.Model;
using static GFAB.View.CreateMealModelView.CreateMealModelViewDescriptors;

namespace GFAB.View{

	[DataContract]
	public class CreateMealModelView{

		public string Designation {get;set;}

		public string Type {get;set;}
		
		public List<string> Ingredients {get;set;}

		public List<string> Allergens {get;set;}

		public CreateMealModelViewDescriptors Descriptors {get;set;}


		[CollectionDataContract]
		public class CreateMealModelViewDescriptors : List<CreateMealModelViewDescriptorsElement>{

			[DataContract]
			public class CreateMealModelViewDescriptorsElement{

				public string Name {get;set;}

				public double Quantity {get;set;}

				public string QuantityUnit {get;set;}

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