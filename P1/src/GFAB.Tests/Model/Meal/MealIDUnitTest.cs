using System;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class MealIDUnitTest{

		[Fact]
		public void TestMealIDWithNullIdThrowsArgumentNullException(){

			string id = null;

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentNullException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatIsPrecededBySpaceCharacterThrowsArgumentException(){

			string id = " Stone Soup";

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatIsPrecededByTabCharacterThrowsArgumentException(){

			string id = "	Stone Soup";

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatIsPrecededBySpaceCharactersThrowsArgumentException(){

			string id = "   Stone Soup";

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatContainsNumbersThrowsArgumentException(){

			string id = "Stone4";

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatContainsSymbolsThrowsArgumentException(){

			string id = "Stone$";

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatStartsWithLowerCaseLetterThrowsArgumentException(){

			string id = "stone soup";

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatIsLessThanThreeCharactersLongThrowsArgumentException(){

			string id = "St";

			Action valueOf = () => MealID.ValueOf(id);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestMealIDWithIdThatCompliesWithRulesCompletesSuccessfully(){

			string id = "Stone Soup";

			MealID.ValueOf(id);

			string idWithoutSpace = "Stonesoup";

			MealID.ValueOf(idWithoutSpace);
		}

		[Fact]
		public void TestMealIDIdReturnsStringPassedOnValueOf(){

			string id = "Stone Soup";

			MealID mealId = MealID.ValueOf(id);

			string Id = mealId.Id;

			Assert.Equal(id, Id);
		}

	}

}