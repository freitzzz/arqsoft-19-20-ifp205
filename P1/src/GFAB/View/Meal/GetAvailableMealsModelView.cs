using System.Collections.Generic;
using System.Runtime.Serialization;
using GFAB.Model;

namespace GFAB.View
{

  [CollectionDataContract]
  public class GetAvailableMealsModelView : List<GetAvailableMealsModelView.GetAvailableMealElement>
  {

    [DataContract]
    public class GetAvailableMealElement
    {
      public long Id;

      public string Designation;

      public string Type;
    }

    public GetAvailableMealsModelView(List<Meal> meals)
    {

      foreach (Meal meal in meals)
      {

        GetAvailableMealElement element = new GetAvailableMealElement();

        element.Id = meal.ID;

        element.Designation = meal.Designation.Id;

        element.Type = meal.Type.Name;

        Add(element);
      }

    }

  }

}