using System;
using System.Collections.Generic;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class MealTypeUnitTest{

		// Inject existing meal types before running tests
		public MealTypeUnitTest(){

			List<string> existingMealTypes = new List<string>();

			existingMealTypes.Add("Soup");

			existingMealTypes.Add("Main Course");

			existingMealTypes.Add("Dessert");

			ExistingMealTypesService.InjectMealTypes(existingMealTypes);
		}

		[Fact]
		public void TestMealTypeWithNullNameThrowsArgumentNullException(){

			string name = null;

			Action valueOf = () => MealType.ValueOf(name);

			Assert.Throws<ArgumentNullException>(valueOf);
		}

		[Fact]
		public void TestMealTypeWithNameThatDoesNotExistsThrowsArgumentException(){

			string name = "this meal type does not exist";

			Action valueOf = () => MealType.ValueOf(name);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealTypeWithNameThatExistsCompletesSuccessfully(){

			string name = ExistingMealTypesService.ExistingMealTypes[0];

			MealType type = MealType.ValueOf(name);
		}

		[Fact]
		public void TestMealTypeNameReturnsStringPassedOnValueOf(){

			string name = ExistingMealTypesService.ExistingMealTypes[0];

			MealType type = MealType.ValueOf(name);

			string mealTypeName = type.Name;

			Assert.Equal(name, mealTypeName);
		}

    [Fact]
    public void TestMealTypeDoesNotProveEqualityToDifferentClassObject(){

      string name = ExistingMealTypesService.ExistingMealTypes[0];

			MealType mealType = MealType.ValueOf(name);

      object differentClassObject = "";

      Assert.NotEqual(mealType, differentClassObject);
    }

    [Fact]
    public void TestMealTypeProvesEqualityToMealTypeWithEqualName(){

      string name = ExistingMealTypesService.ExistingMealTypes[0];

			MealType mealType = MealType.ValueOf(name);

      MealType equalMealType = MealType.ValueOf(name);

      Assert.Equal(mealType, equalMealType);
    }

    [Fact]
    public void TestMealTypeDoesNotProveEqualityToMealTypeWithDifferentName(){

      string name = ExistingMealTypesService.ExistingMealTypes[0];

			MealType mealType = MealType.ValueOf(name);

      MealType differentMealType = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[1]);

      Assert.NotEqual(mealType, differentMealType);
    }

    [Fact]
    public void TestMealTypeHasSameHashCodeAsMealTypeWithEqualName(){

      string name = ExistingMealTypesService.ExistingMealTypes[0];

			MealType mealType = MealType.ValueOf(name);

      MealType equalMealType = MealType.ValueOf(name);

      int mealTypeHashCode = mealType.GetHashCode();

      int equalMealTypeHashCode = equalMealType.GetHashCode();

      Assert.Equal(mealTypeHashCode, equalMealTypeHashCode);
    }

    [Fact]
    public void TestMealTypeHasDifferentHashCodeAsMealTypeWithEqualName(){

      string name = ExistingMealTypesService.ExistingMealTypes[0];

			MealType mealType = MealType.ValueOf(name);

      MealType differentMealType = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[1]);

      int mealTypeHashCode = mealType.GetHashCode();

      int differentMealTypeHashCode = differentMealType.GetHashCode();

      Assert.NotEqual(mealTypeHashCode, differentMealTypeHashCode);
    }

	}

}