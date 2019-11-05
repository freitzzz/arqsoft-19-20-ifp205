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
    // TODO: @Pedro Coelho remove set usage in order to comply with Value Object pattern
    public string Name { get; set; }

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

      grantNameCannotBeNull(name);

      grantNameHasAtLeastThreeCharacters(name);

      this.Name = name;
    }

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void grantNameHasAtLeastThreeCharacters(string name)
    {
      throw new NotImplementedException();
    }

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void grantNameCannotBeNull(string name)
    {
      throw new NotImplementedException();
    }
  }
}