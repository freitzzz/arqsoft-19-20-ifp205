using System;

namespace GFAB.Model
{
  /// <summary>
  /// Location is a model that identifies a location (e.g. ISEP)
  /// </summary>
  public class Location : ValueObject
  {

    /// <summary>
    /// Name indicates the location name
    /// </summary>
    /// <value></value>
    public string Name { get; protected set;}

    /// <summary>
    /// Creates a Location based on a specified string
    /// </summary>
    /// <param name="name">A string that identifies the location name</param>
    /// <returns>Location for the specified string</returns>
    // TODO: Unit test this function
	public static Location ValueOf(string name)
    {
      return new Location(name);
    }

    /// <summary>
    /// Private and only constructor allowed for Location
    /// Object construction modifications should be done via ValueOf function variations
    /// </summary>
    /// <param name="name">The name that identifies the location</param>
    private Location(string name)
    {

      GrantNameCannotBeNull(name);

      GrantNameHasAtLeastThreeCharacters(name);

      this.Name = name;
    }

    // Necessary for EF ORM
    protected Location(){}

    private void GrantNameHasAtLeastThreeCharacters(string name)
    {
      if(name.Length < 3) 
        throw new ArgumentException("name must have more than 3 characters");
    }

    private void GrantNameCannotBeNull(string name)
    {
      if(String.IsNullOrEmpty(name)) 
        throw new ArgumentException("name cannot be empty");
    }
  }
}