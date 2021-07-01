namespace Components.Core.Exceptions
{
    using System;

    public static class Throw
    {
        #region InvalidOperation
        public static void InvalidOperationException(string message) => throw new InvalidOperationException(message);
        public static void InvalidOperationException(string message, Exception innerEx) => throw new InvalidOperationException(message, innerEx);
        #endregion InvalidOperation

        #region Argument

        #endregion Argument

        #region ArgumentNull
        public static void ArgumentNullException(string paramName) => throw new ArgumentNullException(paramName);
        #endregion ArgumentNull

        #region ArgumentOutOfRange

        #endregion ArgumentOutOfRange
    }
}
