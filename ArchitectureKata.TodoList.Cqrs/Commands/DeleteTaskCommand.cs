using ArchitectureKata.TodoList.Cqrs;
using ArchitectureKata.TodoList.Cqrs.Models;

namespace ArchitectureKata.TodoList.Cqrs.Commands;

public class DeleteTaskCommand : ICommand<DeleteTaskRequest, DeleteTaskResult>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommand(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<DeleteTaskResult> ExecuteAsync(DeleteTaskRequest request, CancellationToken cancellationToken = default)
    {
        var task = await _taskRepository.GetByIdAsync(request.TaskId, cancellationToken);
        
        if (task == null)
            return new DeleteTaskResult(false, Error: "Task not found.");
            
        if (task.UserId != request.UserId)
            return new DeleteTaskResult(false, Error: "Access denied. Task does not belong to the user.");

        await _taskRepository.DeleteAsync(request.TaskId, cancellationToken);
        return new DeleteTaskResult(true);
    }
}
