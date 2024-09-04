using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

using Ardalis.GuardClauses;

using BuildingBlocks.Exceptions;

namespace BuildingBlocks.Extensions.GuardClauses;

public static partial class EmailExtentions
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
}
