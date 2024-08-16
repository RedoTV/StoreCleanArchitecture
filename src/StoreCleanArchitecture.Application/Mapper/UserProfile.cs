using AutoMapper;
using StoreCleanArchitecture.Application.DTOs.User;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserSignInDto, User>();
        CreateMap<UserRegisterDto, User>();
    }
}