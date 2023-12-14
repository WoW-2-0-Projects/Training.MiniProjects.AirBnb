using AirBnb.Domain.Common.Exceptions;

namespace AirBnb.Domain.Exceptions;

/// <summary>
/// Represents entity exception
/// </summary>
public class EntityExceptionBase(
    Guid entityId,
    string message,
    Exception? innerException = default,
    ExceptionVisibility visibility = ExceptionVisibility.Public
) : ExceptionBase(message, innerException, visibility)
{
    public Guid Id { get; set; } = entityId;
}