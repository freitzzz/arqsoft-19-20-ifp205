using System;
using System.Collections.Generic;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class MealUnitTest{

		// Inject existing meal types, ingredients, descriptors and allergens
		// before tests

		public MealUnitTest(){

			List<string> existingMealTypes = new List<string>();

			existingMealTypes.Add("Soup");

			existingMealTypes.Add("Main Course");

			existingMealTypes.Add("Dessert");

			ExistingMealTypesService.InjectMealTypes(existingMealTypes);

			
			List<string> existingIngredients = new List<string>();

			existingIngredients.Add("Olive Oil");

			existingIngredients.Add("Red Lentils");

			existingIngredients.Add("Milk");

			ExistingIngredientsService.InjectIngredients(existingIngredients);


			Dictionary<string, List<string>> descriptors = new Dictionary<string, List<string>>();

			descriptors.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fibre", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fat", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Calorie", new List<string>(new string[]{"cal", "kcal"}));

			ExistingDescriptorsService.InjectDescriptors(descriptors);


			List<string> existingAllergens = new List<string>();

			existingAllergens.Add("Celery");

			existingAllergens.Add("Nuts");

			existingAllergens.Add("Oat");

			ExistingAllergensService.InjectAllergens(existingAllergens);
		}

		[Fact]
		public void MealWithNullIngredientsListThrowsArgumentNullException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = null;


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentNullException>(newMeal);
		}

		[Fact]
		public void MealWithEmptyIngredientsListThrowsArgumentException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentException>(newMeal);
		}

		[Fact]
		public void MealWithNullIngredientsListElementsThrowsArgumentNullException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));

			ingredients.Add(null);


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentNullException>(newMeal);
		}

		[Fact]
		public void MealWithDuplicatedIngredientsListElementsThrowsArgumentException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentException>(newMeal);
		}

		[Fact]
		public void MealWithNullDescriptorsListThrowsArgumentNullException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = null;


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentNullException>(newMeal);
		}

		[Fact]
		public void MealWithEmptyDescriptorsListThrowsArgumentException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentException>(newMeal);
		}

		[Fact]
		public void MealWithNullDescriptorsListElementsThrowsArgumentNullException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));

			descriptors.Add(null);


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentNullException>(newMeal);
		}

		[Fact]
		public void MealWithDuplicatedDescriptorsListElementsThrowsArgumentException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));
			
			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentException>(newMeal);
		}

		[Fact]
		public void MealWithDescriptorsWhichQuantitySumIsGreaterThanOneHundredGramsThrowsArgumentException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Salt", 50, "g"));
			
			descriptors.Add(Descriptor.ValueOf("Fat", 50.1, "g"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentException>(newMeal);
		}

		[Fact]
		public void MealWithNullAllergensListThrowsArgumentNullException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = null;

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentNullException>(newMeal);
		}

		[Fact]
		public void MealWithNullAllergensListElementsThrowsArgumentNullException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			allergens.Add(null);

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentNullException>(newMeal);
		}

		[Fact]
		public void MealWithDuplicatedAllergensListElementsThrowsArgumentException(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));

			
			Action newMeal = () => new Meal(designation, type, ingredients, descriptors, allergens);

			Assert.Throws<ArgumentException>(newMeal);
		}

		[Fact]
		public void MealThatCompliesWithRulesCompletesSuccessfully(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			new Meal(designation, type, ingredients, descriptors, allergens);
		}

		[Fact]
		public void TestMealDesignationReturnsDesignationPassedOnConstructorAsMealID(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			Meal meal = new Meal(designation, type, ingredients, descriptors, allergens);

			string expectedDesignation = meal.Designation.Id;

			Assert.Equal(expectedDesignation, designation);
		}

		[Fact]
		public void TestMealAllergensReturnsCopyOfAllergensPassedOnConstructor(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			Meal meal = new Meal(designation, type, ingredients, descriptors, allergens);

			List<Allergen> mealAllergens = meal.Allergens;

			// now lets add a new allergen to returned list

			mealAllergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[1]));

			List<Allergen> expectedAllergens = meal.Allergens;

			Assert.NotEqual(expectedAllergens, mealAllergens);
		}

		[Fact]
		public void TestMealIngredientsReturnsCopyOfIngredientsPassedOnConstructor(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			Meal meal = new Meal(designation, type, ingredients, descriptors, allergens);

			List<Ingredient> mealIngredients = meal.Ingredients;

			// now lets add a new ingredient to returned list

			mealIngredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[1]));

			List<Ingredient> expectedIngredients = meal.Ingredients;

			Assert.NotEqual(expectedIngredients, mealIngredients);
		}

		[Fact]
		public void TestMealDescriptorsReturnsCopyOfDescriptorsPassedOnConstructor(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			Meal meal = new Meal(designation, type, ingredients, descriptors, allergens);

			List<Descriptor> mealDescriptors = meal.Descriptors;

			// now lets add a new descriptor to returned list

			mealDescriptors.Add(Descriptor.ValueOf("Salt", 50, "g"));

			List<Descriptor> expectedDescriptors = meal.Descriptors;

			Assert.NotEqual(expectedDescriptors, mealDescriptors);
		}

		[Fact]
		public void TestMealTypeReturnsMealTypePassedOnConstructor(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			Meal meal = new Meal(designation, type, ingredients, descriptors, allergens);

			string expectedMealType = meal.Type.Name;

			Assert.Equal(expectedMealType, type.Name);
		}

		[Fact]
		public void TestMealIdReturnsDesignationPassedOnConstructorAsMealID(){

			string designation = "Stone Soup";

			MealType type = MealType.ValueOf(ExistingMealTypesService.ExistingMealTypes[0]);

			List<Ingredient> ingredients = new List<Ingredient>();

			ingredients.Add(Ingredient.ValueOf(ExistingIngredientsService.ExistingIngredients[0]));


			List<Descriptor> descriptors = new List<Descriptor>();

			descriptors.Add(Descriptor.ValueOf("Calorie", 50, "cal"));


			List<Allergen> allergens = new List<Allergen>();

			allergens.Add(Allergen.ValueOf(ExistingAllergensService.ExistingAllergens[0]));
			
			Meal meal = new Meal(designation, type, ingredients, descriptors, allergens);

			string mealID = meal.Id().Id;

			Assert.Equal(designation, mealID);
		}

	}

}