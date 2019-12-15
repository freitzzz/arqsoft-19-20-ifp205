namespace GFAB.Model{

  public class ItemIdentificationNumberGeneratorService{
    
    public static Generator RequestGenerator(){

      return new RandomNumberGenerator();

    }

  }

}