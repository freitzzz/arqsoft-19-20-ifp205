using System;
using System.Collections.Generic;
using System.Linq;

namespace GFAB.Model
{

  /// <summary>
  /// Meal is a model that represents a portion of food that is available to be produced
  /// </summary>
  /// <typeparam name="MealID"></typeparam>
  public class Meal : AggregateRoot<MealID>
  {
    /// <summary>
    /// Internal identifier (database)
    /// </summary>
    public long ID { get; protected set; }

    /// <summary>
    /// Designation identifies the meal as unique in the business
    /// </summary>
    public MealID Designation { get; protected set; }

    // Private instance of allergens
    private List<Allergen> allergens;

    /// <summary>
    /// Allergens identifies the allergens which the meal may contain
    /// </summary>
    // TODO: @Freitas Unit test accessor
    public List<Allergen> Allergens
    {
      get => new List<Allergen>(allergens);
      protected set => allergens = value;
    }

    // Private instance of ingredients
    private List<Ingredient> ingredients;

    /// <summary>
    /// Ingredients identifies the ingredients which the meal is composed by
    /// </summary>
    // TODO: @Freitas Unit test accessor
    public List<Ingredient> Ingredients
    {
      get => new List<Ingredient>(ingredients);
      protected set => ingredients = value;
    }

    /// <summary>
    /// Type identifies the meal type
    /// </summary>
    public MealType Type { get; protected set; }

    // Private instance of descriptors
    private List<Descriptor> descriptors;

    /// <summary>
    /// Descriptors identifies the meal nutritional data
    /// </summary>
    // TODO: @Freitas Unit test accessor
    public List<Descriptor> Descriptors
    {
      get => new List<Descriptor>(descriptors);
      protected set => descriptors = value;
    }

    /// <summary>
    /// Creates a meal that does not contain allergens
    /// </summary>
    /// <param name="designation">A string that identifies the meal</param>
    /// <param name="type">The type of the meal</param>
    /// <param name="ingredients">The ingredients that are composed by the meal</param>
    /// <param name="descriptors">The nutritional data of the meal</param>
    // TODO: @Freitas Unit test
    public Meal(string designation, MealType type, List<Ingredient> ingredients,
        List<Descriptor> descriptors)
    {
      MealID id = MealID.ValueOf(designation);


      grantIngredientsCannotBeNull(ingredients);

      grantIngredientsProvideAtLeastOneIngredient(ingredients);

      grantIngredientsElementsCannotBeNull(ingredients);

      grantIngredientsCannotBeDuplicated(ingredients);


      grantDescriptorsCannotBeNull(descriptors);

      grantDescriptorsProvideAtLeastOneDescriptor(descriptors);

      grantDescriptorsElementsCannotBeNull(descriptors);

      grantDescriptorsCannotBeDuplicated(descriptors);

      grantDescriptorsQuantitySumCannotBeGreaterThanOneHundredGrams(descriptors);

      Designation = id;

      Type = type;

      Ingredients = new List<Ingredient>(ingredients);

      Descriptors = new List<Descriptor>(descriptors);

      Allergens = new List<Allergen>();
    }

    /// <summary>
    /// Creates a meal with all its specifications
    /// </summary>
    /// <param name="designation">A string that identifies the meal</param>
    /// <param name="type">The type of the meal</param>
    /// <param name="ingredients">The ingredients that are composed by the meal</param>
    /// <param name="descriptors">The nutritional data of the meal</param>
    /// <param name="allergens">The allergens which the meal contains</param>
    // TODO: @Freitas Unit test
    public Meal(string designation, MealType type, List<Ingredient> ingredients,
      List<Descriptor> descriptors, List<Allergen> allergens)
      : this(designation, type, ingredients, descriptors)
    {

      grantAllergensCannotBeNull(allergens);

      grantAllergensElementsCannotBeNull(allergens);

      grantAllergensCannotBeDuplicated(allergens);

      Allergens = new List<Allergen>(allergens);
    }

    // Necessary for EF ORM
    protected Meal(){}

    /// <summary>
    /// Returns the meal business identifier
    /// </summary>
    /// <returns>MealID that identifies the meal</returns>
    // TODO: @Freitas Unit test
    public MealID Id()
    {
      return Designation;
    }

    // Verifies if the allergens are not duplicated
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantAllergensCannotBeDuplicated(List<Allergen> allergens)
    {
      int countAsList = allergens.Count;

      int countAsSet = allergens.Select((allergen) => allergen.Name.ToLower()).ToHashSet().Count;

      bool hasDuplicates = countAsList > countAsSet;

      if (hasDuplicates)
      {
        throw new ArgumentException("meal allergens cannot have duplicated allergens");
      }
    }

    // Verifies if the allergens list is not null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantAllergensCannotBeNull(List<Allergen> allergens)
    {
      if (allergens == null)
      {
        throw new ArgumentNullException("meal allergens cannot be null");
      }
    }

    // Verifies if the allergens list does not contain null elements
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantAllergensElementsCannotBeNull(List<Allergen> allergens)
    {

      bool hasNullElements = allergens.Contains(null);

      if (hasNullElements)
      {
        throw new ArgumentNullException("meal allergens cannot have null allergens");
      }

    }

    // Verifies that the descriptors quantity sum is not greater than 100 g
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantDescriptorsQuantitySumCannotBeGreaterThanOneHundredGrams(List<Descriptor> descriptors)
    {

      double descriptorsQuantitySum = 0;

      descriptors.ForEach((descriptor) => descriptorsQuantitySum += descriptor.QuantityInGrams());

      if (descriptorsQuantitySum > 100)
      {
        throw new ArgumentException("descriptors quantity sum cannot be greater than 100g");
      }

    }

    // Verifies that the descriptors list does not contain duplicated elements
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantDescriptorsCannotBeDuplicated(List<Descriptor> descriptors)
    {
      int countAsList = descriptors.Count;

      int countAsSet = descriptors.Select((descriptor) => descriptor.Name.ToLower()).ToHashSet().Count;

      bool hasDuplicates = countAsList > countAsSet;

      if (hasDuplicates)
      {
        throw new ArgumentException("meal descriptors cannot have duplicated descriptors");
      }
    }

    // Verifies that the descriptors list provides at least one descriptor
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantDescriptorsProvideAtLeastOneDescriptor(List<Descriptor> descriptors)
    {
      if (descriptors.Count == 0)
      {
        throw new ArgumentException("meal descriptors must provide at least one descriptor");
      }
    }

    // Verifies that the descriptors list is not null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantDescriptorsCannotBeNull(List<Descriptor> descriptors)
    {
      if (descriptors == null)
      {
        throw new ArgumentNullException("meal descriptors cannot be null");
      }
    }

    // Verifies that the descriptors list cannot contain null elements
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantDescriptorsElementsCannotBeNull(List<Descriptor> descriptors)
    {

      bool hasNullElements = descriptors.Contains(null);

      if (hasNullElements)
      {
        throw new ArgumentNullException("meal descriptors cannot have null descriptors");
      }

    }

    // Verifies that the ingredients list cannot contain duplicated elements
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantIngredientsCannotBeDuplicated(List<Ingredient> ingredients)
    {
      int countAsList = ingredients.Count;

      int countAsSet = ingredients.Select((ingredient) => ingredient.Name.ToLower()).ToHashSet().Count;

      bool hasDuplicates = countAsList > countAsSet;

      if (hasDuplicates)
      {
        throw new ArgumentException("meal ingredients cannot have duplicated ingredients");
      }
    }

    // Verifies that the ingredients list provides at least on ingredient
    // If this verification fails an ArgumentException is thrown
    // TODO: @Freitas Unit test
    private void grantIngredientsProvideAtLeastOneIngredient(List<Ingredient> ingredients)
    {
      if (ingredients.Count == 0)
      {
        throw new ArgumentException("meal ingredients must provide at least one ingredient");
      }
    }

    // Verifies that the ingredients list cannot be null
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantIngredientsCannotBeNull(List<Ingredient> ingredients)
    {
      if (ingredients == null)
      {
        throw new ArgumentNullException("meal ingredients cannot be null");
      }
    }

    // Verifies that the ingredients list does not contain null elements
    // If this verification fails an ArgumentNullException is thrown
    // TODO: @Freitas Unit test
    private void grantIngredientsElementsCannotBeNull(List<Ingredient> ingredients)
    {

      bool hasNullElements = ingredients.Contains(null);

      if (hasNullElements)
      {
        throw new ArgumentNullException("meal ingredients cannot have null ingredients");
      }

    }
  }

}