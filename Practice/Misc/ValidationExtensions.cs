using System.ComponentModel.DataAnnotations;

namespace S7_ModelBinding_Validations.Misc;

public static class ValidationExtensions
{
    public static string FormatErrorMessage (this ValidationContext validationContext, string messageTemplate, params object[] memberNames)
    {
        // assuming all the placeholders are given in the memberNames array
        // if a placeholder is missing, it will throw an exception

        return string.Format(messageTemplate, memberNames);
    }
}
