using System.Collections.Generic;
using System.Runtime.Serialization;
using GFAB.Model;
using static GFAB.View.GetDetailedMealInformationModelView.GetDetailedMealInformationModelViewAllergens;
using static GFAB.View.GetDetailedMealInformationModelView.GetDetailedMealInformationModelViewDescriptors;
using static GFAB.View.GetDetailedMealInformationModelView.GetDetailedMealInformationModelViewIngredients;

namespace GFAB.View
{

  [DataContract]
  public class GetDetailedMealInformationModelView
  {

    public long Id;

    public string Designation;

    public string Type;

    public GetDetailedMealInformationModelViewAllergens Allergens;

    public GetDetailedMealInformationModelViewIngredients Ingredients;

    public GetDetailedMealInformationModelViewDescriptors Descriptors;


    public GetDetailedMealInformationModelView(Meal meal)
    {

      Id = meal.ID;

      Designation = meal.Designation.Id;

      Type = meal.Type.Name;

      Allergens = new GetDetailedMealInformationModelViewAllergens(meal.Allergens);

      Ingredients = new GetDetailedMealInformationModelViewIngredients(meal.Ingredients);

      Descriptors = new GetDetailedMealInformationModelViewDescriptors(meal.Descriptors);
    }

    [CollectionDataContract]
    public class GetDetailedMealInformationModelViewAllergens : List<GetDetailedMealInformationModelViewAllergensElement>
    {


      [DataContract]
      public class GetDetailedMealInformationModelViewAllergensElement
      {

        public string Name;

        public GetDetailedMealInformationModelViewAllergensElement(Allergen allergen)
        {

          Name = allergen.Name;

        }

      }


      public GetDetailedMealInformationModelViewAllergens(List<Allergen> allergens)
      {

        foreach (Allergen allergen in allergens)
        {

          GetDetailedMealInformationModelViewAllergensElement element = new GetDetailedMealInformationModelViewAllergensElement(allergen);

          Add(element);

        }

      }

    }

    [CollectionDataContract]
    public class GetDetailedMealInformationModelViewIngredients : List<GetDetailedMealInformationModelViewIngredientsElement>
    {


      [DataContract]
      public class GetDetailedMealInformationModelViewIngredientsElement
      {

        public string Name;

        public GetDetailedMealInformationModelViewIngredientsElement(Ingredient ingredient)
        {

          Name = ingredient.Name;

        }

      }

      public GetDetailedMealInformationModelViewIngredients(List<Ingredient> ingredients)
      {

        foreach (Ingredient ingredient in ingredients)
        {

          GetDetailedMealInformationModelViewIngredientsElement element = new GetDetailedMealInformationModelViewIngredientsElement(ingredient);

          Add(element);

        }

      }

    }


    [CollectionDataContract]
    public class GetDetailedMealInformationModelViewDescriptors : List<GetDetailedMealInformationModelViewDescriptorsElement>
    {

      [DataContract]
      public class GetDetailedMealInformationModelViewDescriptorsElement
      {

        public string Name;

        public double Quantity;

        public string QuantityUnit;

        public GetDetailedMealInformationModelViewDescriptorsElement(Descriptor descriptor)
        {

          Name = descriptor.Name;

          Quantity = descriptor.Quantity;

          QuantityUnit = descriptor.QuantityUnit;

        }

      }

      public GetDetailedMealInformationModelViewDescriptors(List<Descriptor> descriptors)
      {

        foreach (Descriptor descriptor in descriptors)
        {

          GetDetailedMealInformationModelViewDescriptorsElement element = new GetDetailedMealInformationModelViewDescriptorsElement(descriptor);

          Add(element);

        }

      }

    }


  }

}