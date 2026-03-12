namespace ArchitectureKata.TodoList.Cqrs.Models;

public record DeleteTaskResult(bool Success, string? Error = null);
