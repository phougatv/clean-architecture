namespace ConsoleApp.Errors
{
    using static Microsoft.AspNetCore.Http.StatusCodes;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> Handles Model-Validation automatically </summary>
    public class ValidateModelActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Return immediately if Model-State is valid.
            if (context.ModelState.IsValid)
                return;

            // If Model-State is invalid get its entries
            var modelStateEntries = context.ModelState.Where(modelStateEntry => modelStateEntry.Value.Errors.Count > 0).ToArray();
            var errorMessage = "A Validation Error occurred.";
            ICollection<ValidationError> validationErrors = null;
            if (modelStateEntries.Any())
            {
                if (modelStateEntries.Length == 1
                    && modelStateEntries.First().Value.Errors.Count == 1
                    && modelStateEntries.First().Key == string.Empty)
                {
                    // Make the error message specific, if there is only one entry and no key.
                    errorMessage = modelStateEntries.First().Value.Errors.First().ErrorMessage;
                }
                else
                {
                    errorMessage = "See ValidationErrors for details.";
                    validationErrors = new List<ValidationError>();
                    foreach (var modelStateEntry in modelStateEntries)
                    {
                        foreach (var modelStateError in modelStateEntry.Value.Errors)
                        {
                            var modelStateErrorMessage = modelStateError.ErrorMessage;
                            if (string.IsNullOrEmpty(modelStateErrorMessage))
                                modelStateErrorMessage = "Invalid model supplied.";

                            // Add a Validation Error for each Model-State Error.
                            validationErrors.Add(new ValidationError
                            {
                                Name = modelStateEntry.Key,
                                Description = modelStateErrorMessage
                            });
                        }
                    }
                }
            }

            throw new ComponentException(Status400BadRequest, ErrorCategory.Custom, ErrorCode.RequestInvalid, errorMessage, validationErrors);
        }
    }
}
