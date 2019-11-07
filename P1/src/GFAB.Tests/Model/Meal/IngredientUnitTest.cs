using System;
using System.Collections.Generic;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class IngredientUnitTest{

		// Inject existing ingredients before running tests
		public IngredientUnitTest(){

			List<string> existingIngredients = new List<string>();

			existingIngredients.Add("Olive Oil");

			existingIngredients.Add("Red Lentils");

			existingIngredients.Add("Milk");

			ExistingIngredientsService.InjectIngredients(existingIngredients);
		}

		[Fact]
		public void TestIngredientWithNullNameThrowsArgumentNullException(){

			string name = null;

			Action valueOf = () => Ingredient.ValueOf(name);

			Assert.Throws<ArgumentNullException>(valueOf);
		}

		[Fact]
		public void TestIngredientWithNameThatDoesNotExistsThrowsArgumentException(){

			string name = "this ingredient does not exist";

			Action valueOf = () => Ingredient.ValueOf(name);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestIngredientWithNameThatExistsCompletesSuccessfully(){

			string name = ExistingIngredientsService.ExistingIngredients[0];

			Ingredient ingredient = Ingredient.ValueOf(name);
		}

		[Fact]
		public void TestIngredientNameReturnsStringPassedOnValueOf(){

			string name = ExistingIngredientsService.ExistingIngredients[0];

			Ingredient ingredient = Ingredient.ValueOf(name);

			string ingredientName = ingredient.Name;

			Assert.Equal(name, ingredientName);
		}

    [Fact]
    public void TestIngredientDoesNotProveEqualityToDifferentClassObject(){

      string name = ExistingIngredientsService.ExistingIngredients[0];

			Ingredient ingredient = Ingredient.ValueOf(name);

      object differentClassObject = "";

      Assert.NotEqual(ingredient, differentClassObject);
    }

    [Fact]
    public void TestIngredientProvesEqualityToIngredientWithEqualName(){

      string name = ExistingIngredientsService.ExistingIngredients[0];

			Ingredient ingredient = Ingredient.ValueOf(name);

      Ingredient equalIngredient = Ingredient.ValueOf(name);

      Assert.Equal(ingredient, equalIngredient);
    }

    [Fact]
    public void TestIngredientDoesNotProveEqualityToIngredientWithDifferentName(){

      string name = ExistingIngredientsService.ExistingIngredients[0];

			Ingredient ingredient = Ingredient.ValueOf(name);

      Ingredient differentIngredient = Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[1]);

      Assert.NotEqual(ingredient, differentIngredient);
    }

    [Fact]
    public void TestIngredientHasSameHashCodeAsIngredientWithEqualName(){

      string name = ExistingIngredientsService.ExistingIngredients[0];

			Ingredient ingredient = Ingredient.ValueOf(name);

      Ingredient equalIngredient = Ingredient.ValueOf(name);

      int ingredientHashCode = ingredient.GetHashCode();

      int equalIngredientHashCode = equalIngredient.GetHashCode();

      Assert.Equal(ingredientHashCode, equalIngredientHashCode);
    }

    [Fact]
    public void TestIngredientHasDifferentHashCodeAsIngredientWithEqualName(){

      string name = ExistingIngredientsService.ExistingIngredients[0];

			Ingredient ingredient = Ingredient.ValueOf(name);

      Ingredient differentIngredient = Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[1]);

      int ingredientHashCode = ingredient.GetHashCode();

      int differentIngredientHashCode = differentIngredient.GetHashCode();

      Assert.NotEqual(ingredientHashCode, differentIngredientHashCode);
    }

	}

}