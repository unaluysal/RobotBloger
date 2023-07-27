using AutoMapper;
using RobotBloger.Application.Services.BlogServices.Dto;
using RobotBloger.Domain.Entitys;

namespace RobotBloger.Application.Services.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {


          var m1 =  CreateMap<Blog, BlogDto>();
            m1.AfterMap(((s, t) =>

            {


                if (s.BlogType != null)
                {

                    t.BlogTypeDto = new BlogTypeDto();
                    t.BlogTypeDto.Id = s.BlogTypeId;
                    t.BlogTypeDto.Name = s.BlogType.Name;
   
                 



                }
            }));
            CreateMap<BlogDto, Blog>();
            CreateMap<BlogType, BlogTypeDto>();
            CreateMap<BlogTypeDto, BlogType>();
        }
    }
}
