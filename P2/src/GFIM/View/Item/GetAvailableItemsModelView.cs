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

      public long IdentificationNumber {get; set;}

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

        element.IdentificationNumber = item.IdentificationNumber;

        element.MealId = item.MealId.Id;

        element.Location = item.Location.Name;

        element.AvailableToServeUntil = item.LivenessPeriod.EndDateTime.ToString("yyyy'-'MM'-'ddTHH':'mm':'ss");

        element.ProductionDate = item.ProductionDate.ToString("yyyy'-'MM'-'dd");

        element.ExpirationDate = item.ExpirationDate.ToString("yyyy'-'MM'-'dd");

        Add(element);
      }

    }

  }

}