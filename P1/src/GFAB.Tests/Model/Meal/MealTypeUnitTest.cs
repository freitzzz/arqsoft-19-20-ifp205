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

	}

}