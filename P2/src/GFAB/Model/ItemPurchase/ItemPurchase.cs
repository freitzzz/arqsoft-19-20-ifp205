using System;

namespace GFAB.Model{

  public class ItemPurchase : AggregateRoot<ItemPurchaseID>{

    public long ID {get; protected set;}

    public UserType Type {get; protected set;}

    public ItemID ItemID {get; protected set;}

    public ItemPurchaseID PurchaseID {get; protected set;}

    public DateTime PurchaseDate {get; protected set;}

    public ItemPurchase(UserType type, ItemID item){

      grantItemNotNull(item);

      Type = type;

      ItemID = item;

      DateTime purchaseDate = DateTime.Now;

      PurchaseDate = purchaseDate;

      PurchaseID = ItemPurchaseID.ValueOf(type, item, purchaseDate);

    }

    protected ItemPurchase(){}

    private void grantItemNotNull(ItemID item)
    {
      if(item == null){
        throw new ArgumentNullException("item purchase item cannot be null");
      }
    }

    public ItemPurchaseID Id()
    {
      return PurchaseID;
    }
  }

}