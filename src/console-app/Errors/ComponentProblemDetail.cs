namespace ConsoleApp.Errors
{
    using ConsoleApp.Errors.Base;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    // <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on https://tools.ietf.org/html/rfc7807.
    /// Contains 'extended members' which are allowable in accordance with the official RFC.
    /// </summary>
    public class ComponentProblemDetail : ProblemDetail
    {
        /// <summary>
        /// The Component Error Code, represented as a string value.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// The Component Error Category, represented as a string value.
        /// </summary>
        public string ErrorCategory { get; set; }

        /// <summary>
        /// A collection of model Validation Errors relating to the API request.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ICollection<ValidationError> ValidationErrors { get; set; }
    }
}
