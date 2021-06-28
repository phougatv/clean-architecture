namespace ConsoleApp.Errors
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;

    /// <summary> Component Exception which wraps the details of a HTTP API error. </summary>
    public class ComponentException : Exception
    {
        #region Public Properties
        /// <summary>
        /// The Error Category.
        /// </summary>
        public ErrorCategory ErrorCategory { get; set; }

        /// <summary>
        /// The Error Code.
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// The Error Message (detail).
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The HTTP Status Code.
        /// </summary>
        public int StatusCode { get; set; } = StatusCodes.Status500InternalServerError;

        /// <summary>
        /// The model Validation Errors (if any).
        /// </summary>
        public ICollection<ValidationError> ValidationErrors { get; set; }
        #endregion Public Properties

        #region Constructor
        /// <summary>
        /// Creates an instance of <see cref="ComponentException"/>
        /// </summary>
        /// <param name="httpStatusCode">The HttpStatusCode <see cref="StatusCodes"/> or <see cref="HttpStatusCode"/>.</param>
        public ComponentException(int httpStatusCode)
            : this(httpStatusCode, ErrorCategory.None, ErrorCode.None, null, null)
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="ComponentException"/>
        /// </summary>
        /// <param name="httpStatusCode">The HttpStatusCode <see cref="int"/></param>
        /// <param name="errorCategory">The ErrorCategory <see cref="ErrorCategory"/></param>
        /// <param name="errorCode">The ErrorCode <see cref="ErrorCode"/></param>
        /// <param name="errorMessage">The ErrorMessage <see cref="string"/></param>
        /// <param name="validationErrors">The model ValidationErrors <see cref="ICollection{ValidationError}"/></param>
        public ComponentException(
            int httpStatusCode,
            ErrorCategory errorCategory,
            ErrorCode errorCode,
            string errorMessage,
            ICollection<ValidationError> validationErrors)
        {
            if (errorCode != ErrorCode.None && errorCategory == ErrorCategory.None)
                // Default the ErrorCategory to 'Custom' if a custom ErrorCode has 
                // been specified and an ErrorCategory has not been specified.
                errorCategory = ErrorCategory.Custom;
            else if (errorCategory == ErrorCategory.None)
                // Default the ErrorCategory to 'Protocol' if an ErrorCategory has not been specified.
                errorCategory = ErrorCategory.Protocol;

            ErrorCategory = errorCategory;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            StatusCode = httpStatusCode;
            ValidationErrors = validationErrors;

        }
        #endregion Constructor
    }
}
