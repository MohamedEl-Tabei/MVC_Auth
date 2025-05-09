using ITI_API_BL;
using ITI_API_BL.DTO.Student;
using ITI_API_BL.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_MVC.Controllers;

public class StudentController : Controller
{
    private readonly IManagerStudent _managerStudent;
    private readonly IMangerDepartment _mangerDepartment;

    public StudentController(IManagerStudent managerStudent, IMangerDepartment mangerDepartment)
    {
        _managerStudent = managerStudent;
        _mangerDepartment = mangerDepartment;
    }
    public IActionResult Index()
    {
        var students = _managerStudent.GetAll();
        return View(students);
    }
    #region Add
    [Authorize]
    [HttpGet]
    public IActionResult Add()
    {
        var departments = _mangerDepartment.GetAll();
        ViewData["departments"] = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
        ViewBag.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
        return View();
    }
    [HttpPost]
    public IActionResult Add(DTOStudentCreate _student)
    {
        if (!ModelState.IsValid)
        {
            var departments = _mangerDepartment.GetAll();
            ViewData["departments"] = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
            ViewBag.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
            return View();
        }

        _managerStudent.Add(_student);
        return RedirectToAction("Index", "Student");
    }
    #endregion
    [Authorize]
    [HttpGet]
    public IActionResult Update(Guid id)
    {
        var departments = _mangerDepartment.GetAll();
        var student = _managerStudent.GetById(id);
        ViewData["departments"] = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
        //ViewBag.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
        return View(student);
    }
    [HttpPost]
    public IActionResult Update(DTOStudentRead _student)
    {
        if (!ModelState.IsValid)
        {
            var departments = _mangerDepartment.GetAll();
            ViewData["departments"] = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
            ViewBag.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
            return View(_student);
        }

        _managerStudent.Update(_student.Id, _student);
        return RedirectToAction("Index", "Student");
    }
}
