using System;

namespace GFAB.Model
{

  /// <summary>
  /// TimePeriod is a model that identifies a period of time
  /// </summary>
  public class TimePeriod : ValueObject
  {

    /// <summary>
    /// Start date time indicates the time in which the period starts
    /// </summary>
    /// <value</value>
    // TODO: @PedroCoelho remove set usage to comply with Value Object pattern
    public DateTime StartDateTime { get; set; }

    /// <summary>
    /// End date time indicates the time in which the period ends
    /// </summary>
    /// <value></value>
    // TODO: @PedroCoelho remove set usage to comply with Value Object pattern
    public DateTime EndDateTime { get; set; }

    /// <summary>
    /// Creates a TimePeriod based on its start and end date time period
    /// </summary>
    /// <param name="startDateTime">The date time in which the time period starts</param>
    /// <param name="endDateTime">The date time in which the time period ends</param>
    /// <returns>TimePeriod for the desired period of time</returns>
    // TODO: Unit test this function
    public static TimePeriod ValueOf(DateTime startDateTime, DateTime endDateTime)
    {
      return new TimePeriod(startDateTime, endDateTime);
    }

    /// <summary>
    /// Private and only constructor allowed for TimePeriod
    /// Object construction modifictions should be done via ValueOf function variations
    /// </summary>
    /// <param name="startDateTime">The date time in which the time period starts</param>
    /// <param name="endDateTime">The date time in which the time period ends</param>
    // TODO: Unit test this constructor
    private TimePeriod(DateTime startDateTime, DateTime endDateTime)
    {
      grantStartDateTimeCannotBeNull(startDateTime);

      grantEndDateTimeCannotBeNull(endDateTime);

      grantStartDateTimeIsBeforeEndDateTime(startDateTime, endDateTime);

      this.StartDateTime = startDateTime;

      this.EndDateTime = endDateTime;
    }

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void grantStartDateTimeIsBeforeEndDateTime(DateTime startDateTime, DateTime endDateTime)
    {
      throw new NotImplementedException();
    }

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void grantEndDateTimeCannotBeNull(DateTime endDateTime)
    {
      throw new NotImplementedException();
    }

    // TODO: @PedroCoelho implement this verification method (should throw ArgumentException if verification fails)
    private void grantStartDateTimeCannotBeNull(DateTime startDateTime)
    {
      throw new NotImplementedException();
    }
  }
}