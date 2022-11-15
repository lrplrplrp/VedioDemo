using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreeRedis;
using Simpie.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Core;
using Video.Application.Contract.Base;
using Video.Application.Contract.UserInfos;
using Video.Application.Contract.UserInfos.Dtos;
using Video.Application.Manage;
using Video.Domain.Shared;
using Video.Domain.Users;

namespace Video.Application.UserInfos
{
    public class UserInfoService:IUserInfoService
    {
        private readonly IMapper _mapper;
        private readonly RedisClient _redisClient;
        private readonly IUserInfoRepository _userInfoRepository;

        private readonly CurrentManage _currentManage;

        private readonly IUnitOfWork _unitOfWork;

        public UserInfoService(IMapper mapper, RedisClient redisClient, IUserInfoRepository userInfoRepository, CurrentManage currentManage, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _redisClient = redisClient;
            _userInfoRepository = userInfoRepository;
            _currentManage = currentManage;
            _unitOfWork = unitOfWork;
        }

        public async Task DeletesAsync(IEnumerable<Guid> ids)
        {
            await _userInfoRepository.DeleteAsync(ids);
        }

        public async Task StatusAsync(IEnumerable<Guid> ids,bool status=true)
        {
            await _userInfoRepository.StatusAsync(ids,status);
        }

        /// inheritdoc
        public async Task<UserInfoRoleDto> GetAsync()
        {
            var data =await _userInfoRepository.GetAsync(_currentManage.GetId());
            var dto=_mapper.Map<UserInfoRoleDto>(data);
            return dto;
        }
        /// inheritdoc
        public async Task<PageResultDto<UserInfoDto>> GetListAsync(GetListInput input)
        {
            var data=await _userInfoRepository.GetListAsync(input.Keywords,input.StartTime,input.EndTime,input.SkipCount,
            input.MaxResultCount);
            var count=await _userInfoRepository.GetCountAsync(input.Keywords,input.StartTime,input.EndTime);
            var dto =_mapper.Map<List<UserInfoDto>>(data);
            return new PageResultDto<UserInfoDto>(count,dto);
        }

        /// inheritdoc
        public async Task<UserInfoRoleDto> LoginAsync(LoginInput loginInput)
        {
            var data=await _userInfoRepository.GetUserInfoRoleView(loginInput.Username,loginInput.Password);
            var dto=_mapper.Map<UserInfoRoleDto>(data);
            return dto;
        }
        /// inheritdoc
        public async Task<UserInfoRoleDto> RegisterAsync(RegisterInput registerInput)
        {
            
            var code=await _redisClient.GetAsync<string>($"{CodeType.Register}:{registerInput.UserName}");

            if(code!=registerInput.Code){
                throw new BusinessException("验证码错误");
            }

            if(await _userInfoRepository.isExistAsync(x=>x.UserName==registerInput.UserName)){
                throw new BusinessException("用户名已存在！");
            }

            var data=_mapper.Map<UserInfo>(registerInput);

            data=await _userInfoRepository.InsertAsync(data);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserInfoRoleDto>(data);
            
        }
        /// inheritdoc
        public async Task UpdateAsync(UpdateUserInfoInput input)
        {
            var userInfo=await _userInfoRepository.FirstOfDefaultAsync(x=>x.id==_currentManage.GetId());

            if(userInfo==null){
                throw new BusinessException("用户信息不存在");
            }

            userInfo.Name=input.Name;
            userInfo.Avatar=input.Avatar;
            userInfo.Password=input.Password;

            await _userInfoRepository.UpdateAsync(userInfo);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}