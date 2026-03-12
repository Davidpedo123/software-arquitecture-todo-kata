using ArchitectureKata.TodoList.Cqrs;
using ArchitectureKata.TodoList.Cqrs.Models;

namespace ArchitectureKata.TodoList.UseCases;

public class DeleteTaskUseCase : IUseCase<DeleteTaskRequest, DeleteTaskResult>
{
    private readonly ICommand<DeleteTaskRequest, DeleteTaskResult> _command;

    public DeleteTaskUseCase(ICommand<DeleteTaskRequest, DeleteTaskResult> command)
    {
        _command = command;
    }

    public Task<DeleteTaskResult> ExecuteAsync(DeleteTaskRequest input, CancellationToken cancellationToken = default)
        => _command.ExecuteAsync(input, cancellationToken);
}
