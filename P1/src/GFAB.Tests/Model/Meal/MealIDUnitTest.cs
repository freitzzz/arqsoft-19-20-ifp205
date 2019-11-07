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

    [Fact]
    public void TestMealIDDoesNotProveEqualityToDifferentClassObject(){

      string name = "Stone Soup";

			MealID mealId = MealID.ValueOf(name);

      object differentClassObject = "";

      Assert.NotEqual(mealId, differentClassObject);
    }

    [Fact]
    public void TestMealIDProvesEqualityToMealIDWithEqualName(){

      string name = "Stone Soup";

			MealID mealId = MealID.ValueOf(name);

      MealID equalMealID = MealID.ValueOf(name);

      Assert.Equal(mealId, equalMealID);
    }

    [Fact]
    public void TestMealIDDoesNotProveEqualityToMealIDWithDifferentName(){

      string name = "Stone Soup";

			MealID mealId = MealID.ValueOf(name);

      MealID differentMealID = MealID.ValueOf("Duck Rice");

      Assert.NotEqual(mealId, differentMealID);
    }

    [Fact]
    public void TestMealIDHasSameHashCodeAsMealIDWithEqualName(){

      string name = "Stone Soup";

			MealID mealId = MealID.ValueOf(name);

      MealID equalMealID = MealID.ValueOf(name);

      int mealIdHashCode = mealId.GetHashCode();

      int equalMealIDHashCode = equalMealID.GetHashCode();

      Assert.Equal(mealIdHashCode, equalMealIDHashCode);
    }

    [Fact]
    public void TestMealIDHasDifferentHashCodeAsMealIDWithEqualName(){

      string name = "Stone Soup";

			MealID mealId = MealID.ValueOf(name);

      MealID differentMealID = MealID.ValueOf("Duck Rice");

      int mealIdHashCode = mealId.GetHashCode();

      int differentMealIDHashCode = differentMealID.GetHashCode();

      Assert.NotEqual(mealIdHashCode, differentMealIDHashCode);
    }

	}

}