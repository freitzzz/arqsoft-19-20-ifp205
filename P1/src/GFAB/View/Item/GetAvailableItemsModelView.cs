using System.Collections.Generic;
using System.Runtime.Serialization;
using GFAB.Model;

namespace GFAB.View
{

  [CollectionDataContract]
  public class GetAvailableItemsModelView : List<GetAvailableItemsModelView.GetAvailableItemElement>
  {

    [DataContract]
    public class GetAvailableItemElement
    {
      public long Id {get;set;}

      public string MealId {get; set;}

      public string Location {get;set;}

      public string AvailableToServeUntil {get;set;}

      public string ProductionDate {get;set;}

      public string ExpirationDate {get;set;}
    }

    public GetAvailableItemsModelView(List<Item> items)
    {

      foreach (Item item in items)
      {

        GetAvailableItemElement element = new GetAvailableItemElement();

        element.Id = item.ID;

        element.MealId = item.mealId.Id;

        element.Location = item.location.Name;

        element.AvailableToServeUntil = item.livenessPeriod.EndDateTime.ToString("yyyy'-'MM'-'dd");

        element.ProductionDate = item.productionDate.ToString("yyyy'-'MM'-'dd");

        element.ExpirationDate = item.expirationDate.ToString("yyyy'-'MM'-'dd");

        Add(element);
      }

    }

  }

}