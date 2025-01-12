namespace backend.Models
{
  public class GenericResponse<T>
  {
    public string? Message { get; set; }
    public bool Ok { get; set; }
    public T? Data { get; set; }
    public DateTime Timestamp { get; } = DateTime.UtcNow;
  }
}
