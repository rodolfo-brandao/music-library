namespace MusicLibrary.Application.Utils;

/// <summary>
/// Provides a set of common validation messages for when a validation rule fails.
/// </summary>
internal static class ValidationFailureMessages
{
    /// <summary>
    /// Provides a validation message for when a certain record property is empty.
    /// </summary>
    /// <param name="propertyName">The name of the respective property.</param>
    /// <returns>A message indicating that the property cannot be empty.</returns>
    public static string ForEmptyProperty(string propertyName) => $"'{propertyName}' cannot be empty.";

    /// <summary>
    /// Provides a validation message for when a certain property maximum length is exceeded.
    /// </summary>
    /// <param name="propertyName">The name of the respective property.</param>
    /// <param name="maxLength">The maximum length allowed.</param>
    /// <returns>A message indicating that the property length was exceeded.</returns>
    public static string ForExceededMaxLength(string propertyName, ushort maxLength) =>
        $"Max length of '{propertyName}' exceeded. Must be at most {maxLength} characters.";

    /// <summary>
    /// Provides a validation message for when a certain property minimum length is not met.
    /// </summary>
    /// <param name="propertyName">The name of the respective property.</param>
    /// <param name="minLength">The minimum length required.</param>
    /// <returns>A message indicating that a property minimum length requirement was not met.</returns>
    public static string ForMinimumLengthRequirement(string propertyName, ushort minLength) =>
        $"The minimum length for '{propertyName}' must be at least {minLength} characters.";

    /// <summary>
    /// Provides a validation message for when a record property conflicts with an existing one.
    /// </summary>
    /// <param name="recordName">The name of the respective record.</param>
    /// <param name="propertyName">The name of the respective property.</param>
    /// <param name="propertyValue">The value of the respective property.</param>
    /// <returns>A message indicating that a record property conflicted with an existing one.</returns>
    public static string ForRecordConflict(string recordName, string propertyName, object propertyValue) =>
        $"'{recordName}' with '{propertyName}' equal to '{propertyValue}' already exists.";

    /// <summary>
    /// Provides a validation message for when a record is not found.
    /// </summary>
    /// <param name="recordName">The name of the respective record.</param>
    /// <returns>A message indicating that the record could not be found.</returns>
    public static string ForRecordNotFound(string recordName) => $"'{recordName}' not found.";
}