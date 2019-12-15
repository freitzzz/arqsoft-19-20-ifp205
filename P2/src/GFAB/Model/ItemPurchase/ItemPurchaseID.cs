using System;

namespace GFAB.Model{

  public class ItemPurchaseID : ValueObject{
    
    public string Id;

    public static ItemPurchaseID ValueOf(UserType type, ItemID item, DateTime purchaseDate){

      string id = UserTypeConversionService.ToString(type) + "_" + item.Id + "_" + purchaseDate.ToString();

      return new ItemPurchaseID(id);

    }

    private ItemPurchaseID(string name){

      grantNameNotNull(name);

      Id = name;

    }

    protected ItemPurchaseID(){}

    private void grantNameNotNull(string name)
    {
      if(name == null){
        throw new ArgumentNullException("item purchase id name cannot be null");
      }
    }
  }

}