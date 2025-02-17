﻿namespace SmartParking.BusinessLogic.CommandExecutor;

public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
{
    Task<TResult> Handle(TCommand command);
}
