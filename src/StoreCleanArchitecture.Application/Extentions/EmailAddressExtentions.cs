using System.Text.RegularExpressions;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Application.Extentions;

public static class EmailAddressExtentions
{
    public static bool ValidateEmail(this User user)
    {
        Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        return regex.IsMatch(user.Email);
    }
}