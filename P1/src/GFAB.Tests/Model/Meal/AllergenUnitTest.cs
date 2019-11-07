using System;
using System.Collections.Generic;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class AllergenUnitTest{

		// Inject existing allergens before running tests
		public AllergenUnitTest(){

			List<string> existingAllergens = new List<string>();

			existingAllergens.Add("Celery");

			existingAllergens.Add("Nuts");

			existingAllergens.Add("Oat");

			ExistingAllergensService.InjectAllergens(existingAllergens);
		}

		[Fact]
		public void TestAllergenWithNullNameThrowsArgumentNullException(){

			string name = null;

			Action valueOf = () => Allergen.ValueOf(name);

			Assert.Throws<ArgumentNullException>(valueOf);
		}

		[Fact]
		public void TestAllergenWithNameThatDoesNotExistsThrowsArgumentException(){

			string name = "this allergen does not exist";

			Action valueOf = () => Allergen.ValueOf(name);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestAllergenWithNameThatExistsCompletesSuccessfully(){

			string name = ExistingAllergensService.ExistingAllergens[0];

			Allergen allergen = Allergen.ValueOf(name);
		}

		[Fact]
		public void TestAllergenNameReturnsStringPassedOnValueOf(){

			string name = ExistingAllergensService.ExistingAllergens[0];

			Allergen allergen = Allergen.ValueOf(name);

			string allergenName = allergen.Name;

			Assert.Equal(name, allergenName);
		}

    [Fact]
    public void TestAllergenDoesNotProveEqualityToDifferentClassObject(){

      string name = ExistingAllergensService.ExistingAllergens[0];

			Allergen allergen = Allergen.ValueOf(name);

      object differentClassObject = "";

      Assert.NotEqual(allergen, differentClassObject);
    }

    [Fact]
    public void TestAllergenProvesEqualityToAllergenWithEqualName(){

      string name = ExistingAllergensService.ExistingAllergens[0];

			Allergen allergen = Allergen.ValueOf(name);

      Allergen equalAllergen = Allergen.ValueOf(name);

      Assert.Equal(allergen, equalAllergen);
    }

    [Fact]
    public void TestAllergenDoesNotProveEqualityToAllergenWithDifferentName(){

      string name = ExistingAllergensService.ExistingAllergens[0];

			Allergen allergen = Allergen.ValueOf(name);

      Allergen differentAllergen = Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[1]);

      Assert.NotEqual(allergen, differentAllergen);
    }

    [Fact]
    public void TestAllergenHasSameHashCodeAsAllergenWithEqualName(){

      string name = ExistingAllergensService.ExistingAllergens[0];

			Allergen allergen = Allergen.ValueOf(name);

      Allergen equalAllergen = Allergen.ValueOf(name);

      int allergenHashCode = allergen.GetHashCode();

      int equalAllergenHashCode = equalAllergen.GetHashCode();

      Assert.Equal(allergenHashCode, equalAllergenHashCode);
    }

    [Fact]
    public void TestAllergenHasDifferentHashCodeAsAllergenWithEqualName(){

      string name = ExistingAllergensService.ExistingAllergens[0];

			Allergen allergen = Allergen.ValueOf(name);

      Allergen differentAllergen = Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[1]);

      int allergenHashCode = allergen.GetHashCode();

      int differentAllergenHashCode = differentAllergen.GetHashCode();

      Assert.NotEqual(allergenHashCode, differentAllergenHashCode);
    }

	}

}