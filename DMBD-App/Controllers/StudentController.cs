using AutoMapper;
using DMBD.Kernel.DTOs;
using DMBD.Kernel.Model;
using DMBD.Kernel.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMBD_App.Controllers
{
    public class StudentController : Controller
    {
        private readonly IService<Student> _services;

        private readonly IMapper _mapper;


        public StudentController(IService<Student> services,IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {
            var students = await _services.GetAllAsync();

            var studentDto = _mapper.Map<List<StudentDto>>(students.ToList());

            ViewBag.students = new SelectList(studentDto, "Id", "TcNo");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(StudentDto studentDto)

        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(_mapper.Map<Student>(studentDto));
                return RedirectToAction(nameof(Index));
            }
             
            var students = await _services.GetAllAsync();

            var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());

            ViewBag.students = new SelectList(studentsDto, "Id", "Name");
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Student>))]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _services.GetByIdAsync(id);


            var students = await _services.GetAllAsync();

            var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());

            ViewBag.students = new SelectList(studentsDto, "Id", "Name", student.StudentId);

            return View(_mapper.Map<StudentDto>(student));

        }
        [HttpPost]
        public async Task<IActionResult> Update(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                await _services.UpdateAsync(_mapper.Map<Student>(studentDto));
                return RedirectToAction(nameof(Index));
            }

            var students = await _services.GetAllAsync();

            var studentsDto = _mapper.Map<List<StudentDto>>(students.ToList());

            ViewBag.students = new SelectList(studentsDto, "Id", "Name", studentDto.StudentId);

            return View(studentDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            var student = await _services.GetByIdAsync(id);


            await _services.RemoveAsync(student);

            return RedirectToAction(nameof(Index));
        }
    }
}
