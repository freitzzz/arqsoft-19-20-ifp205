using System;
using System.Collections.Generic;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class ExistingMealTypesServiceUnitTests{

		[Fact]
		public void TestInjectMealTypesWithNullStringListThrowsArgumentNullException(){

			List<string> mealTypes = null;

			Action inject = () => ExistingMealTypesService.InjectMealTypes(mealTypes);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectMealTypesWithNullStringListElementsThrowsArgumentNullException(){

			List<string> mealTypes = new List<string>();

			mealTypes.Add("Soup");

			mealTypes.Add(null);

			Action inject = () => ExistingMealTypesService.InjectMealTypes(mealTypes);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectMealTypesWithDuplicatedElementsOnStringListThrowsArgumentException(){

			List<string> mealTypes = new List<string>();

			mealTypes.Add("Soup");

			mealTypes.Add("Main Course");

			mealTypes.Add("soUp");

			Action inject = () => ExistingMealTypesService.InjectMealTypes(mealTypes);

			Assert.Throws<ArgumentException>(inject);
		}

		[Fact]
		public void TestInjectMealTypesWithStringListThatDoesNotContainNullOrDuplicatedElementsCompletesSuccessfuly(){

			List<string> mealTypes = new List<string>();

			mealTypes.Add("Soup");

			mealTypes.Add("Main Course");

			mealTypes.Add("Dessert");

			ExistingMealTypesService.InjectMealTypes(mealTypes);
		}

		[Fact]
		public void TestExistingMealTypesReturnsInjectedMealTypes(){

			// Clear existing meal types
			ExistingMealTypesService.InjectMealTypes(new List<string>());

			List<string> existingMealTypes = ExistingMealTypesService.ExistingMealTypes;

			Assert.Empty(existingMealTypes);

			// Now inject new list

			List<string> mealTypesToInject = new List<string>();

			mealTypesToInject.Add("Soup");

			ExistingMealTypesService.InjectMealTypes(mealTypesToInject);

			List<string> expectedMealTypes = new List<string>(mealTypesToInject);

			existingMealTypes = ExistingMealTypesService.ExistingMealTypes;

			Assert.Equal(expectedMealTypes, existingMealTypes);
		}

		[Fact]
		public void TestExistingMealTypesReturnsCopyOfExistingMealTypesList(){

			// Clear existing meal types
			ExistingMealTypesService.InjectMealTypes(new List<string>());

			List<string> existingMealTypes = ExistingMealTypesService.ExistingMealTypes;

			Assert.Empty(existingMealTypes);

			// Now inject new list

			List<string> mealTypesToInject = new List<string>();

			mealTypesToInject.Add("Soup");

			ExistingMealTypesService.InjectMealTypes(mealTypesToInject);

			existingMealTypes = ExistingMealTypesService.ExistingMealTypes;

			// Now add new meal type to returned list

			existingMealTypes.Add("Main Course");

			// Retrieve list of service

			List<string> updatedMealTypesList = ExistingMealTypesService.ExistingMealTypes;

			Assert.NotEqual(existingMealTypes, updatedMealTypesList);
		}
	}

}