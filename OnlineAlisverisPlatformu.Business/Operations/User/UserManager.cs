using OnlineAlisverisPlatformu.Business.DataProtection;
using OnlineAlisverisPlatformu.Business.Operations.User.Dtos;
using OnlineAlisverisPlatformu.Business.Types;
using OnlineAlisverisPlatformu.Data.Entities;
using OnlineAlisverisPlatformu.Data.Repositories;
using OnlineAlisverisPlatformu.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Business.Operations.User
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtection _protector;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> repository, IDataProtection protector)
        {
            _unitOfWork = unitOfWork;
            _userRepository = repository;
            _protector = protector;

        }
        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower());

            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Email already exists"
                };
            }
            var userEntity = new UserEntity()
            {
                Email = user.Email,
                Password = _protector.Protect(user.Password),
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };
            _userRepository.Add(userEntity);
            try
            {
                await _unitOfWork.SaveChangesAsync();


            }
            catch (Exception)
            {
                throw new Exception("An error occurred while saving the user");
            }
            return new ServiceMessage
            {
                IsSucceed = true,

            };
        }

        public ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user)
        {
            var userEntity = _userRepository.Get(x => x.Email.ToLower() == user.Email.ToLower());
            if (userEntity == null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "User not found"
                };
            }

             var unprotectedpassword = _protector.Unprotect(userEntity.Password);
            if (unprotectedpassword != user.Password)
                {

                
                    return new ServiceMessage<UserInfoDto>
                    {
                        IsSucceed = false,
                        Message = "Password is incorrect"

                    };
            }
            else
                {
                return new ServiceMessage<UserInfoDto>
                    {
                        IsSucceed = true,
                        Data = new UserInfoDto
                        {

                            Email = userEntity.Email,
                            FirstName = userEntity.FirstName,
                            LastName = userEntity.LastName,
                            Role = userEntity.Role,

                        }
                    };
                }
            }

        }
    }



