using AutoMapper;
using DMBD.Api.Filters;
using DMBD.Business.Services;
using DMBD.Kernel.DTOs;
using DMBD.Kernel.Model;
using DMBD.Kernel.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Student> _service;

        public StudentController(IService<Student> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// GET api/students
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var students = await _service.GetAllAsync();
            var studentsDtos = _mapper.Map<List<StudentDto>>(students.ToList());
            return CreateActionResult(CustomResponseDto<List<StudentDto>>.Success(200, studentsDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Student>))]
        // GET /api/students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            var student = await _service.GetByIdAsync(id);
            var studentDto = _mapper.Map<StudentDto>(student);
            return CreateActionResult(CustomResponseDto<StudentDto>.Success(200, studentDto));
        }



        [HttpPost]
        public async Task<IActionResult> Save(StudentDto studentDto)
        {
            var student = await _service.AddAsync(_mapper.Map<Student>(studentDto));
            var studentsDto = _mapper.Map<StudentDto>(student);
            return CreateActionResult(CustomResponseDto<StudentDto>.Success(201, studentsDto));
        }

        /*
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto studentDto)
        {
            await _service.UpdateAsync(_mapper.Map<Student>(studentDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        */
          
        // DELETE api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var student = await _service.GetByIdAsync(id);




            await _service.RemoveAsync(student);

            return CreateActionResult(CustomResponseDto<NoContent>.Success(204));
        }
    }
}
