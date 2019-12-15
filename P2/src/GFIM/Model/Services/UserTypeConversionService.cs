using System;

namespace GFAB.Model{

  public class UserTypeConversionService{

    public static string ToString(UserType userType){

      switch(userType){
        case UserType.ADMIN:
          return "Administrator";
        case UserType.EXTERNAL:
          return "External";
        case UserType.INTERNAL:
          return "Internal";
        default:
          return "Kitchen Worker";
      }
    }

    public static UserType ToUserType(string userType){

      if(userType == null){
        throw new ArgumentNullException("cannot convert null user type");
      }

      switch(userType.ToString()){
        case "administrator":
          return UserType.ADMIN;
        case "external":
          return UserType.EXTERNAL;
        case "internal":
          return UserType.INTERNAL;
        case "kitchen worker":
          return UserType.EXTERNAL;
        default:
          throw new ArgumentException("cannot convert unknown user type");
      }

    }

  }

}