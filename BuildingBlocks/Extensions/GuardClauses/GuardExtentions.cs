using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

using Ardalis.GuardClauses;

using BuildingBlocks.Exceptions;

namespace BuildingBlocks.Extensions.GuardClauses;

public static partial class GuardExtentions
{
    public static void ValidEmail(
        this IGuardClause guardClause,
        string input,
        [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new InvalidEmailException("Email can't be empty");
        }

        if (!EmailRegex().Match(input).Success)
        {
            throw new InvalidEmailException("The email is invalid");
        }
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailRegex();

    public static void ValidDocument(
        this IGuardClause guardClause,
        string input,
        [CallerArgumentExpression("input")] string? parameterName = null)
    {

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new InvalidDocumentException("Document can't be empty");
        }

        if (input.Length != 14)
        {
            throw new InvalidDocumentException(
                "Document Invalid, length must be 14 digits and the format is XXX.XXX.XXX-XX");
        }
    }

    public static void IsMinor(
        this IGuardClause guardClause,
        DateTime input,
        [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (DateTime.Now.Year - input.Year < 18)
        {
            throw new ArgumentException("User can't be a minor!");
        }
    }

    public static void IsInFuture(
        this IGuardClause guardClause,
        DateTime input,
        [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input > DateTime.Now)
        {
            throw new ArgumentException("Date can't be in the future");
        }
    }
}
