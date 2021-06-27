using AutoMapper;
using Employee.core;
using EmployeeApi.Models;

namespace EmployeeApi.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeModel, EmployeeRequest>();
                cfg.CreateMap<EmployeeRequest, EmployeeModel>();
            });

            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}