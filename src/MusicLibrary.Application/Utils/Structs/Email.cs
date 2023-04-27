using System.Text.RegularExpressions;

namespace MusicLibrary.Application.Utils.Structs;

/// <summary>
/// Represents the data type of an e-mail address.
/// </summary>
public readonly struct Email
{
    private const string EmailAddressPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

    private readonly string _value;
    private readonly TimeSpan _regexMatchTimeout;

    public string Value => _value;
    public bool IsValid => IsValidAddress(_value);

    public Email(string address, TimeSpan? regexMatchTimeoutInMilliseconds = default)
    {
        _value = address;
        _regexMatchTimeout = regexMatchTimeoutInMilliseconds ?? TimeSpan.FromMilliseconds(250);
    }

    private bool IsValidAddress(string address)
    {
        try
        {
            return !string.IsNullOrWhiteSpace(address) && Regex.IsMatch(address, EmailAddressPattern,
                RegexOptions.IgnoreCase, _regexMatchTimeout);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}