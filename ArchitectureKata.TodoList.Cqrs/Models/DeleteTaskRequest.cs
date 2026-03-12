namespace ArchitectureKata.TodoList.Cqrs.Models;

public record DeleteTaskRequest(Guid TaskId, Guid UserId);
