using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        public List<UserDto> GetAll();
    }
}
