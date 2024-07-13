namespace manageExceptions.GlobalExceptions;

#region CustomException withouth preCustomMessage
public class CustomBaseException : Exception
{
    public CustomBaseException(
        string message)
        : base(message)
    {
    }
}
#endregion

#region CustomException with preCustomMessage
public class CustomException : Exception
{
    private const string _customErrMessage = "Error occurred: ";

    public CustomException(
        string message)
        : base(_customErrMessage + message)
    {
    }
}

#endregion
