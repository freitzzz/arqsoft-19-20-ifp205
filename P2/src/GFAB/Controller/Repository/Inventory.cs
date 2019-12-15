namespace GFAB.Controllers{

  public class Inventory{

    private static Inventory instance;

    public static Inventory Instance(){

      if(instance == null){
        instance = new Inventory();
      }

      return instance;

    }

  }

}