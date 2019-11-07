using System;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests
{

  public class DescriptorQuantityUnitConversionServiceUnitTest
  {

    [Fact]
    public void TestConvertToGramsWithNullQuantityUnitThrowsArgumentError()
    {

		double quantity = 50;

		string quantityUnit = null;

		Action convert = () => DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		Assert.Throws<ArgumentException>(convert);

    }

	[Fact]
	public void TestConvertToGramsWithUnrecognizedQuantityUnitThrowsArgumentError()
    {

		double quantity = 50;

		string quantityUnit = "this quantity unit does not exist";

		Action convert = () => DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		Assert.Throws<ArgumentException>(convert);

    }

	[Fact]
	public void TestConvertToGramsWithRecognizedQuantityUnitCompletesWithSuccess()
    {

		double quantity = 50;

		string quantityUnit = "g";

		double result = DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		double expected = 50;

		Assert.Equal(expected, result);

    }

	[Fact]
	public void TestConvertToGramsWithGramQuantityUnitReturnsCorrectResult()
    {

		double quantity = 50;

		// grams quantity unit is identified by 'g'

		string quantityUnit = "g";

		double result = DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		// grams conversion to grams is given by the calculus of quantity * 1

		double expected = quantity * 1;

		Assert.Equal(expected, result);

    }

	[Fact]
	public void TestConvertToGramsWithKilogramQuantityUnitReturnsCorrectResult()
    {

		double quantity = 50;

		// kilo grams quantity unit is identified by 'kg'

		string quantityUnit = "kg";

		double result = DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		// grams conversion to grams is given by the calculus of quantity * 1000

		double expected = quantity * 1000;

		Assert.Equal(expected, result);

    }

	[Fact]
	public void TestConvertToGramsWithMiligramQuantityUnitReturnsCorrectResult()
    {

		double quantity = 50;

		// grams quantity unit is identified by 'mg'

		string quantityUnit = "mg";

		double result = DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		// grams conversion to grams is given by the calculus of quantity * 0.001

		double expected = quantity * 0.001;

		Assert.Equal(expected, result);

    }

	[Fact]
	public void TestConvertToGramsWithCalorieQuantityUnitReturnsCorrectResult()
    {

		double quantity = 50;

		// calorie quantity unit is identified by 'cal'

		string quantityUnit = "cal";

		double result = DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		// grams conversion to grams is given by the calculus of quantity * 0.12959782

		double expected = quantity * 0.12959782;

		Assert.Equal(expected, result);

    }

	[Fact]
	public void TestConvertToGramsWithKilocalorieQuantityUnitReturnsCorrectResult()
    {

		double quantity = 50;

		// calorie quantity unit is identified by 'kcal'

		string quantityUnit = "kcal";

		double result = DescriptorQuantityUnitConversionService.ConvertToGrams(quantity, quantityUnit);

		// grams conversion to grams is given by the calculus of quantity * 129.59782

		double expected = quantity * 129.59782;

		Assert.Equal(expected, result);

    }

  }

}