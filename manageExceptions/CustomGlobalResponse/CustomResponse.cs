namespace manageExceptions.CustomGlobalResponse;

public class CustomResponse<T>
{
    public T Body { get; set; }
    public ErrorResponse Error { get; set; }

    public CustomResponse(T body)
    {
        Body = body;
    }
    public static CustomResponse<T> Create(T body)
    {
        return new CustomResponse<T>(body);
    }

}
public class ErrorResponse
{
    public int Code { get; set; }
    public string Message { get; set; }
}

