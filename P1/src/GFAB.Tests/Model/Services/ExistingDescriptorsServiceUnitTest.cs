using System;
using System.Collections.Generic;
using System.Linq;
using GFAB.Model;
using Xunit;

namespace GFAB.Tests{

	public class ExistingDescriptorsServiceUnitTests{

		[Fact]
		public void TestInjectDescriptorsWithNullDictionaryThrowsArgumentNullException(){

			Dictionary<string,List<string>> descriptors = null;

			Action inject = () => ExistingDescriptorsService.InjectDescriptors(descriptors);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectDescriptorsWithNullDictionaryStringListThrowsArgumentNullException(){

			Dictionary<string,List<string>> descriptors = new Dictionary<string, List<string>>();

			descriptors.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fibre", null);

			Action inject = () => ExistingDescriptorsService.InjectDescriptors(descriptors);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectDescriptorsWithNullDictionaryStringListElementsThrowsArgumentNullException(){

			Dictionary<string,List<string>> descriptors = new Dictionary<string, List<string>>();

			descriptors.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fibre", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fat", new List<string>(new string[]{"g", null}));

			Action inject = () => ExistingDescriptorsService.InjectDescriptors(descriptors);

			Assert.Throws<ArgumentNullException>(inject);
		}

		[Fact]
		public void TestInjectDescriptorsWithDuplicatedElementsOnStringListThrowsArgumentException(){

			Dictionary<string,List<string>> descriptors = new Dictionary<string, List<string>>();

			descriptors.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fibre", new List<string>(new string[]{"g", "g"}));

			Action inject = () => ExistingDescriptorsService.InjectDescriptors(descriptors);

			Assert.Throws<ArgumentException>(inject);
		}

		[Fact]
		public void TestInjectDescriptorsWithDictionaryThatDoesNotContainNullOrDuplicatedElementsOnStringListsCompletesSuccessfuly(){

			Dictionary<string,List<string>> descriptors = new Dictionary<string, List<string>>();

			descriptors.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptors.Add("Fibre", new List<string>(new string[]{"g", "mg"}));

			ExistingDescriptorsService.InjectDescriptors(descriptors);
		}

		[Fact]
		public void TestExistingDescriptorsReturnsInjectedDescriptors(){

			// Clear existing descriptors
			ExistingDescriptorsService.InjectDescriptors(new Dictionary<string, List<string>>());

			Dictionary<string, List<string>> existingDescriptors = ExistingDescriptorsService.ExistingDescriptors;

			Assert.Empty(existingDescriptors);

			// Now inject new dictionary

			Dictionary<string,List<string>> descriptorsToInject = new Dictionary<string, List<string>>();

			descriptorsToInject.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptorsToInject.Add("Fibre", new List<string>(new string[]{"g", "mg"}));

			ExistingDescriptorsService.InjectDescriptors(descriptorsToInject);

			Dictionary<string, List<string>> expectedDescriptors = new Dictionary<string, List<string>>(descriptorsToInject.ToList());

			existingDescriptors = ExistingDescriptorsService.ExistingDescriptors;

			Assert.Equal(expectedDescriptors, existingDescriptors);
		}

		[Fact]
		public void TestExistingDescriptorsReturnsCopyOfExistingDescriptorsList(){

			// Clear existing descriptors
			ExistingDescriptorsService.InjectDescriptors(new Dictionary<string, List<string>>());

			Dictionary<string, List<string>> existingDescriptors = ExistingDescriptorsService.ExistingDescriptors;

			Assert.Empty(existingDescriptors);

			// Now inject new dictionary

			Dictionary<string,List<string>> descriptorsToInject = new Dictionary<string, List<string>>();

			descriptorsToInject.Add("Salt", new List<string>(new string[]{"g", "mg"}));

			descriptorsToInject.Add("Fat", new List<string>(new string[]{"g", "mg"}));

			ExistingDescriptorsService.InjectDescriptors(descriptorsToInject);

			existingDescriptors = ExistingDescriptorsService.ExistingDescriptors;

			// Now add new descriptor to returned dictionary

			existingDescriptors.Add("Calorie", new List<string>(new string[]{"cal", "kcal"}));

			// Retrieve dictionary of service

			Dictionary<string,List<string>> updatedDescriptorsDictionary = ExistingDescriptorsService.ExistingDescriptors;

			Assert.NotEqual(existingDescriptors, updatedDescriptorsDictionary);
		}
	}

}