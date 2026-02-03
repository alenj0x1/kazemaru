using backend.Models;

namespace backend.Helpers;

public static class ManageResponse
{
    public static GenericResponse<T> Create<T>(T data, string message = "request successful", bool isSuccess = true)
    {
        return new GenericResponse<T>
        {
            Data = data,
            Message = message,
            Ok = isSuccess,
        };
    }
}