using System;
using System.Collections.Generic;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class ExistingAllergensServiceUnitTests{

		[Fact]
		public void TestInjectAllergensWithNullStringListThrowsArgumentNullException(){

			List<string> allergens = null;

			Action inject = () => ExistingAllergensService.InjectAllergens(allergens);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectAllergensWithNullStringListElementsThrowsArgumentNullException(){

			List<string> allergens = new List<string>();

			allergens.Add("Nut");

			allergens.Add(null);

			Action inject = () => ExistingAllergensService.InjectAllergens(allergens);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectAllergensWithDuplicatedElementsOnStringListThrowsArgumentException(){

			List<string> allergens = new List<string>();

			allergens.Add("Nut");

			allergens.Add("Soy");

			allergens.Add("nut");

			Action inject = () => ExistingAllergensService.InjectAllergens(allergens);

			Assert.Throws<ArgumentException>(inject);
		}

		[Fact]
		public void TestInjectAllergensWithStringListThatDoesNotContainNullOrDuplicatedElementsCompletesSuccessfuly(){

			List<string> allergens = new List<string>();

			allergens.Add("Nut");

			allergens.Add("Soy");

			allergens.Add("Milk");

			ExistingAllergensService.InjectAllergens(allergens);
		}

		[Fact]
		public void TestExistingAllergensReturnsInjectedAllergens(){

			// Clear existing allergens
			ExistingAllergensService.InjectAllergens(new List<string>());

			List<string> existingAllergens = ExistingAllergensService.ExistingAllergens;

			Assert.Empty(existingAllergens);

			// Now inject new list

			List<string> allergensToInject = new List<string>();

			allergensToInject.Add("Nut");

			ExistingAllergensService.InjectAllergens(allergensToInject);

			List<string> expectedAllergens = new List<string>(allergensToInject);

			existingAllergens = ExistingAllergensService.ExistingAllergens;

			Assert.Equal(expectedAllergens, existingAllergens);
		}

		[Fact]
		public void TestExistingAllergensReturnsCopyOfExistingAllergensList(){

			// Clear existing allergens
			ExistingAllergensService.InjectAllergens(new List<string>());

			List<string> existingAllergens = ExistingAllergensService.ExistingAllergens;

			Assert.Empty(existingAllergens);

			// Now inject new list

			List<string> allergensToInject = new List<string>();

			allergensToInject.Add("Nut");

			ExistingAllergensService.InjectAllergens(allergensToInject);

			existingAllergens = ExistingAllergensService.ExistingAllergens;

			// Now add new allergen to returned list

			existingAllergens.Add("Milk");

			// Retrieve list of service

			List<string> updatedAllergensList = ExistingAllergensService.ExistingAllergens;

			Assert.NotEqual(existingAllergens, updatedAllergensList);
		}
	}

}