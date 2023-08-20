namespace MusicLibrary.Application.Utils;

/// <summary>
/// Provides a set of common validation messages for when a validation rule fails.
/// </summary>
internal static class ValidationFailureMessages
{
    /// <summary>
    /// Provides a validation message for when a certain record property is empty.
    /// </summary>
    /// <param name="propertyName">The name of the property.</param>
    /// <returns>A message indicating that the property cannot be empty.</returns>
    public static string ForEmptyProperty(string propertyName) => $"'{propertyName}' cannot be empty.";

    /// <summary>
    /// Provides a validation message for when a record is not found.
    /// </summary>
    /// <param name="recordName">The name of the record.</param>
    /// <returns>A message indicating that the record could not be found.</returns>
    public static string ForRecordNotFound(string recordName) => $"'{recordName}' not found.";
}