using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GFAB.View{

  [DataContract]
  public class ExistingDataModelView{

    public List<string> Allergens {get; set;}

    public List<string> Ingredients {get; set;}

    public List<string> MealTypes {get; set;}

    public Dictionary<string, List<string>> Descriptors {get; set;}

  }

}