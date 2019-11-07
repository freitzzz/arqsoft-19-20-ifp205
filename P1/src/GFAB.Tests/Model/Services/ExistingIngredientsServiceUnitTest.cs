using System;
using System.Collections.Generic;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class ExistingIngredientsServiceUnitTests{

		[Fact]
		public void TestInjectIngredientsWithNullStringListThrowsArgumentNullException(){

			List<string> ingredients = null;

			Action inject = () => ExistingIngredientsService.InjectIngredients(ingredients);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectIngredientsWithNullStringListElementsThrowsArgumentNullException(){

			List<string> ingredients = new List<string>();

			ingredients.Add("Red Lentils");

			ingredients.Add(null);

			Action inject = () => ExistingIngredientsService.InjectIngredients(ingredients);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectIngredientsWithDuplicatedElementsOnStringListThrowsArgumentException(){

			List<string> ingredients = new List<string>();

			ingredients.Add("Red Lentils");

			ingredients.Add("Olive Oil");

			ingredients.Add("red Lentils");

			Action inject = () => ExistingIngredientsService.InjectIngredients(ingredients);

			Assert.Throws<ArgumentException>(inject);
		}

		[Fact]
		public void TestInjectIngredientsWithStringListThatDoesNotContainNullOrDuplicatedElementsCompletesSuccessfuly(){

			List<string> ingredients = new List<string>();

			ingredients.Add("Olive Oil");

			ingredients.Add("Red Lentils");

			ingredients.Add("Milk");

			ExistingIngredientsService.InjectIngredients(ingredients);
		}

		[Fact]
		public void TestExistingIngredientsReturnsInjectedIngredients(){

			// Clear existing ingredients
			ExistingIngredientsService.InjectIngredients(new List<string>());

			List<string> existingIngredients = ExistingIngredientsService.ExistingIngredients;

			Assert.Empty(existingIngredients);

			// Now inject new list

			List<string> ingredientsToInject = new List<string>();

			ingredientsToInject.Add("Red Lentils");

			ExistingIngredientsService.InjectIngredients(ingredientsToInject);

			List<string> expectedIngredients = new List<string>(ingredientsToInject);

			existingIngredients = ExistingIngredientsService.ExistingIngredients;

			Assert.Equal(expectedIngredients, existingIngredients);
		}

		[Fact]
		public void TestExistingIngredientsReturnsCopyOfExistingIngredientsList(){

			// Clear existing ingredients
			ExistingIngredientsService.InjectIngredients(new List<string>());

			List<string> existingIngredients = ExistingIngredientsService.ExistingIngredients;

			Assert.Empty(existingIngredients);

			// Now inject new list

			List<string> ingredientsToInject = new List<string>();

			ingredientsToInject.Add("Red Lentils");

			ExistingIngredientsService.InjectIngredients(ingredientsToInject);

			existingIngredients = ExistingIngredientsService.ExistingIngredients;

			// Now add new ingredient to returned list

			existingIngredients.Add("Olive Oil");

			// Retrieve list of service

			List<string> updatedIngredientsList = ExistingIngredientsService.ExistingIngredients;

			Assert.NotEqual(existingIngredients, updatedIngredientsList);
		}
	}

}