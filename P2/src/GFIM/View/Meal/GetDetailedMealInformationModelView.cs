using System.Collections.Generic;
using System.Runtime.Serialization;
using static GFIM.View.GetDetailedMealInformationModelView.GetDetailedMealInformationModelViewAllergens;
using static GFIM.View.GetDetailedMealInformationModelView.GetDetailedMealInformationModelViewDescriptors;
using static GFIM.View.GetDetailedMealInformationModelView.GetDetailedMealInformationModelViewIngredients;

namespace GFIM.View
{

  [DataContract]
  public class GetDetailedMealInformationModelView
  {

    public long Id {get;set;}

    public string Designation {get;set;}

    public string Type {get;set;}

    public GetDetailedMealInformationModelViewAllergens Allergens {get;set;}

    public GetDetailedMealInformationModelViewIngredients Ingredients {get;set;}

    public GetDetailedMealInformationModelViewDescriptors Descriptors {get;set;}

    public GetDetailedMealInformationModelView(){}

    [CollectionDataContract]
    public class GetDetailedMealInformationModelViewAllergens : List<GetDetailedMealInformationModelViewAllergensElement>
    {


      [DataContract]
      public class GetDetailedMealInformationModelViewAllergensElement
      {

        public string Name {get;set;}

        public GetDetailedMealInformationModelViewAllergensElement(){}

      }

      public GetDetailedMealInformationModelViewAllergens(){}

    }

    [CollectionDataContract]
    public class GetDetailedMealInformationModelViewIngredients : List<GetDetailedMealInformationModelViewIngredientsElement>
    {


      [DataContract]
      public class GetDetailedMealInformationModelViewIngredientsElement
      {

        public string Name {get;set;}

        public GetDetailedMealInformationModelViewIngredientsElement(){}

      }

      public GetDetailedMealInformationModelViewIngredients(){}

    }


    [CollectionDataContract]
    public class GetDetailedMealInformationModelViewDescriptors : List<GetDetailedMealInformationModelViewDescriptorsElement>
    {

      [DataContract]
      public class GetDetailedMealInformationModelViewDescriptorsElement
      {

        public string Name {get;set;}

        public double Quantity {get;set;}

        public string QuantityUnit {get;set;}

        public GetDetailedMealInformationModelViewDescriptorsElement(){}

      }

      public GetDetailedMealInformationModelViewDescriptors(){}

    }


  }

}