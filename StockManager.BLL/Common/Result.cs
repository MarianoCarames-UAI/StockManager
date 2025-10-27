namespace StockManager.BLL.Common;

/// <summary>
/// Clase genérica para manejar resultados de operaciones
/// Permite devolver éxito/error con mensaje y datos
/// </summary>
/// <typeparam name="T">Tipo de dato del resultado</typeparam>
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public List<string> Errors { get; private set; } = new();

    // Constructor privado
    private Result() { }

    /// <summary>
    /// Crea un resultado exitoso con datos
    /// </summary>
    public static Result<T> Success(T data, string message = "Operación exitosa")
    {
        return new Result<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message
        };
    }

    /// <summary>
    /// Crea un resultado exitoso sin datos
    /// </summary>
    public static Result<T> Success(string message = "Operación exitosa")
    {
        return new Result<T>
        {
            IsSuccess = true,
            Message = message
        };
    }

    /// <summary>
    /// Crea un resultado de error
    /// </summary>
    public static Result<T> Failure(string error)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = error,
            Errors = new List<string> { error }
        };
    }

    /// <summary>
    /// Crea un resultado de error con múltiples errores
    /// </summary>
    public static Result<T> Failure(List<string> errors)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = string.Join("; ", errors),
            Errors = errors
        };
    }

    /// <summary>
    /// Crea un resultado de error a partir de una excepción
    /// </summary>
    public static Result<T> Failure(Exception exception)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = exception.Message,
            Errors = new List<string> { exception.Message }
        };
    }
}

/// <summary>
/// Resultado sin tipo genérico (para operaciones que no devuelven datos)
/// </summary>
public class Result
{
    public bool IsSuccess { get; protected set; }
    public string Message { get; protected set; } = string.Empty;
    public List<string> Errors { get; protected set; } = new();

    protected Result() { }

    public static Result Success(string message = "Operación exitosa")
    {
        return new Result
        {
            IsSuccess = true,
            Message = message
        };
    }

    public static Result Failure(string error)
    {
        return new Result
        {
            IsSuccess = false,
            Message = error,
            Errors = new List<string> { error }
        };
    }

    public static Result Failure(List<string> errors)
    {
        return new Result
        {
            IsSuccess = false,
            Message = string.Join("; ", errors),
            Errors = errors
        };
    }
}
