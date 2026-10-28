using GreenTech.Test.API.IAM.Application.Errors;
using GreenTech.Test.API.IAM.Application.Services;
using GreenTech.Test.API.IAM.Domain.Model.Aggregates;
using GreenTech.Test.API.IAM.Domain.Model.Commands;
using GreenTech.Test.API.IAM.Domain.Repositories;
using GreenTech.Test.API.Shared.Application.Patterns;
using GreenTech.Test.API.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GreenTech.Test.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ILogger<User> logger
    ) : IUserCommandService
{
    public async Task<Result<User, CreateUserError>> Handle(CreateUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var existingSource =
            await userRepository.FindByUserIdAsync(command.UserId, cancellationToken);
        if (existingSource != null)
        {
            logger.LogWarning("Duplicate user rejected for UserId {userId}", command.UserId);
            return new Result<User, CreateUserError>.Failure(CreateUserError.DuplicatedUser);
        }

        try
        {
            var user = new User(command);
            await userRepository.AddAsync(user, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);
            return new Result<User, CreateUserError>.Success(user);
        }
        catch (ArgumentException ex)
        {
            logger.LogError(ex, "Invalid arguments while creating user for UserId {userId}", command.UserId);
            return new Result<User, CreateUserError>.Failure(CreateUserError.UnexpectedError);
        }
        catch (DbUpdateException ex) when (IsDuplicateKeyViolation(ex))
        {
            logger.LogWarning("Duplicate key violation creating user for for UserId {userId}", command.UserId);
            return new Result<User, CreateUserError>.Failure(CreateUserError.DuplicatedUser);
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Database failed creating user for UserId {userId}", command.UserId);
            return new Result<User, CreateUserError>.Failure(CreateUserError.UnexpectedError);
        }
        catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error occured while creating user for UserId {userId}", command.UserId);
            return new Result<User, CreateUserError>.Failure(CreateUserError.UnexpectedError);
        }
    }
    
    private static bool IsDuplicateKeyViolation(DbUpdateException exception)
    {
        for (Exception? current = exception; current is not null; current = current.InnerException)
        {
            if (!string.Equals(current.GetType().Name, "MySqlException", StringComparison.Ordinal)) continue;
            var numberProperty = current.GetType().GetProperty("Number");
            if (numberProperty?.PropertyType == typeof(int) &&
                numberProperty.GetValue(current) is int errorCode &&
                errorCode == 1062)
                return true;
        }
        return false;
    }
}