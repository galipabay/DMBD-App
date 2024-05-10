using AutoMapper;
using DMBD.Kernel.DTOs;
using DMBD.Kernel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentDto>().ReverseMap();

            CreateMap<Subject, SubjectDto>();
            CreateMap<Subject, SubjectDto>().ReverseMap();

            CreateMap<Files, FilesDto>();
            CreateMap<Files, FilesDto>().ReverseMap();
        }
    }
}
