using AuthService.Application.Authentication.Interfaces;
using AuthService.Application.Repository.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Enums;
using MediatR;
using Shared.Repository.Interfaces;

namespace AuthService.Application.Features.Users.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IHashingHelper _hashingHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationClaimReadRepository _operationClaimReadRepository;
        private readonly IOperationClaimWriteRepository _operationClaimWriteRepository;
        private readonly IUserOperationClaimWriteRepository _userOperationClaimWriteRepository;

        public RegisterUserHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IHashingHelper hashingHelper, IUnitOfWork unitOfWork, IOperationClaimReadRepository operationClaimReadRepository, IOperationClaimWriteRepository operationClaimWriteRepository, IUserOperationClaimWriteRepository userOperationClaimWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _hashingHelper = hashingHelper;
            _unitOfWork = unitOfWork;
            _operationClaimReadRepository = operationClaimReadRepository;
            _operationClaimWriteRepository = operationClaimWriteRepository;
            _userOperationClaimWriteRepository = userOperationClaimWriteRepository;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var existMail = await _userReadRepository.GetSingleAsync(u => u.Email == request.Email);

            if (existMail != null)
                return new RegisterUserResponse
                {
                    isSuccess = false,
                    text = "Mail sistemde kayıtlı"
                };

            _hashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                CreatedDate = DateTime.Now
            };

            string errMsg = string.Empty;
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _userWriteRepository.AddAsync(user);
                var saveChangesCount = await _unitOfWork.SaveChangesAsync();

                if (saveChangesCount > 0)
                {
                    var operationClaim = await _operationClaimReadRepository.GetSingleAsync(x => x.Name == OperationClaimType.Customer.ToString());
                    var userOperationClaim = new UserOperationClaim
                    {
                        UserId = user.Id,
                        OperationClaimId = operationClaim.Id,
                        CreatedDate = DateTime.Now
                    };

                    await _userOperationClaimWriteRepository.AddAsync(userOperationClaim);
                    await _unitOfWork.SaveChangesAsync();
                    await _unitOfWork.CommitAsync();

                    return new RegisterUserResponse
                    {
                        isSuccess = true,
                        text = "Kullanıcı başarıyla kaydedildi",
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Role = operationClaim.Name
                    };
                }
                else
                {
                    throw new Exception("Kullanıcı kaydedilirken hata meydana geldi");
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                errMsg = ex.Message;
            }
            return new RegisterUserResponse
            {
                isSuccess = false,
                text = errMsg
            };
        }
    }
}
