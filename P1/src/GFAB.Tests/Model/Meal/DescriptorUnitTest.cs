using System;
using System.Collections.Generic;
using System.Linq;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class DescriptorUnitTest{

		// Inject existing descriptors before running tests
		public DescriptorUnitTest(){

			Dictionary<string, List<string>> descriptors = new Dictionary<string, List<string>>();

			descriptors.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fibre", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fat", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Calorie", new List<string>(new string[]{"cal", "kcal"}));

			ExistingDescriptorsService.InjectDescriptors(descriptors);
		}

		[Fact]
		public void TestDescriptorWithNullNameThrowsArgumentNullException(){

			string name = null;

			double quantity = 50;

			string quantityUnit = "g";

			Action valueOf = () => Descriptor.ValueOf(name, quantity, quantityUnit);

			Assert.Throws<ArgumentNullException>(valueOf);
		}

		[Fact]
		public void TestDescriptorWithNameThatDoesNotExistThrowsArgumentException(){

			string name = "this descriptor does not exist";

			double quantity = 50;

			string quantityUnit = "g";

			Action valueOf = () => Descriptor.ValueOf(name, quantity, quantityUnit);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestDescriptorWithQuantityThatIsLowerThanZeroThrowsArgumentException(){

			string name = ExistingDescriptorsService.ExistingDescriptors.Keys.ToList()[0];

			double quantity = -1;

			string quantityUnit = "g";

			Action valueOf = () => Descriptor.ValueOf(name, quantity, quantityUnit);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestDescriptorWithQuantityThatIsEqualToZeroThrowsArgumentException(){

			string name = ExistingDescriptorsService.ExistingDescriptors.Keys.ToList()[0];

			double quantity = 0;

			string quantityUnit = "g";

			Action valueOf = () => Descriptor.ValueOf(name, quantity, quantityUnit);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestDescriptorWithNullQuantityUnitThrowsArgumentNullException(){

			string name = ExistingDescriptorsService.ExistingDescriptors.Keys.ToList()[0];

			double quantity = 50;

			string quantityUnit = null;

			Action valueOf = () => Descriptor.ValueOf(name, quantity, quantityUnit);

			Assert.Throws<ArgumentNullException>(valueOf);
		}

		[Fact]
		public void TestDescriptorWithNameAndQuantityUnitThatDoNotMatchThrowsArgumentException(){

			string name = "Salt";

			double quantity = 50;

			string quantityUnit = "cal";

			Action valueOf = () => Descriptor.ValueOf(name, quantity, quantityUnit);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestDescriptorWithQuantityThatIsGreaterThanOneHundredGramsThrowsArgumentException(){

			string name = "Salt";

			double quantity = 100.1;

			string quantityUnit = "g";

			Action valueOf = () => Descriptor.ValueOf(name, quantity, quantityUnit);

			Assert.Throws<ArgumentException>(valueOf);
		}

		[Fact]
		public void TestDescriptorThatCompliesWithRulesCompletesSuccessfully(){

			string name = "Salt";

			double quantity = 100;

			string quantityUnit = "g";

			Descriptor.ValueOf(name, quantity, quantityUnit);

			quantity = 50;

			Descriptor.ValueOf(name, quantity, quantityUnit);
		}

		[Fact]
		public void TestDescriptorNameReturnsStringPassedOnValueOf(){

			string name = "Salt";

			double quantity = 50;

			string quantityUnit = "g";

			Descriptor descriptor = Descriptor.ValueOf(name, quantity, quantityUnit);

			string descriptorName = descriptor.Name;

			Assert.Equal(name, descriptorName);
		}

		[Fact]
		public void TestDescriptorQuantityReturnsDoublePassedOnValueOf(){

			string name = "Salt";

			double quantity = 50;

			string quantityUnit = "g";

			Descriptor descriptor = Descriptor.ValueOf(name, quantity, quantityUnit);

			double descriptorQuantity = descriptor.Quantity;

			Assert.Equal(quantity, descriptorQuantity);
		}

		[Fact]
		public void TestDescriptorQuantityUnitReturnsStringPassedOnValueOf(){

			string name = "Salt";

			double quantity = 50;

			string quantityUnit = "g";

			Descriptor descriptor = Descriptor.ValueOf(name, quantity, quantityUnit);

			string descriptorQuantityUnit = descriptor.QuantityUnit;

			Assert.Equal(quantityUnit, descriptorQuantityUnit);
		}

		[Fact]
		public void TestDescriptorQuantityInGramsReturnsDescriptorQuantityConvertedInGrams(){

			string name = "Calorie";

			double quantity = 50;

			string quantityUnit = "cal";

			Descriptor descriptor = Descriptor.ValueOf(name, quantity, quantityUnit);

			double quantityInGrams = descriptor.QuantityInGrams();

			double expectedQuantityInGrams = DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

			Assert.Equal(expectedQuantityInGrams, quantityInGrams);
		}

	}

}