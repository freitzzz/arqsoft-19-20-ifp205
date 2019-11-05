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
    /// <value></value>
    public DateTime StartDateTime { get; }

    /// <summary>
    /// End date time indicates the time in which the period ends
    /// </summary>
    /// <value></value>
    public DateTime EndDateTime { get; }

    /// <summary>
    /// Creates a TimePeriod based on its start and end date time period
    /// </summary>
    /// <param name="startDateTime">The date time in which the time period starts</param>
    /// <param name="endDateTime">The date time in which the time period ends</param>
    /// <returns>TimePeriod for the desired period of time</returns>
    // TODO?: Unit test this function
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
    private TimePeriod(DateTime startDateTime, DateTime endDateTime)
    {
      GrantStartDateTimeCannotBeNull(startDateTime);

      GrantEndDateTimeCannotBeNull(endDateTime);

      GrantStartDateTimeIsBeforeEndDateTime(startDateTime, endDateTime);

      this.StartDateTime = startDateTime;

      this.EndDateTime = endDateTime;
    }

    ///<summary>
    ///Verifies if startDateTime is before endDateTime
    ///<summary> 
    private void GrantStartDateTimeIsBeforeEndDateTime(DateTime startDateTime, DateTime endDateTime)
    {
      if(startDateTime >= endDateTime) {
        throw new ArgumentException("startDateTime can´t be after endDateTime");
      }
    }
    private void GrantEndDateTimeCannotBeNull(DateTime endDateTime)
    {
      if(endDateTime == null)
        throw new ArgumentNullException("endDateTime can´t be null");
    }
    private void GrantStartDateTimeCannotBeNull(DateTime startDateTime)
    {
      if(startDateTime == null)
        throw new ArgumentNullException("startDateTime can´t be null");
    }
  }
}