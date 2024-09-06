using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsViewTemplateDemoCrud.Models;

namespace StudentsViewTemplateDemoCrud.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : Controller
    {
        // GET: Student

        static List<Student> students = new List<Student>()
        {
            new Student(){ Id = 1,
            Name="Allen",
                Age=34,
            Address=new Address(){
                Id=101,
                Country="India",
                State="Goa",
                City="Panjim"
            }
            },
            new Student(){
            Id=2,
            Name="Mary",
                Age=42,
            Address=new Address(){
                Id=102,
                Country="India",
                State="Punjab",
                City="Mohali"
            }
            },

             new Student(){
            Id=3,
            Name="Rosh",
                Age=2,
            Address=new Address(){
                Id=103,
                Country="India",
                State="MadhyaPradesh",
                City="Indore"
            }
            },

              new Student(){
            Id=4,
            Name="Mars",
                Age=33,
            Address=new Address(){
                Id=104,
                Country="Russia",
                State="Sakha Republic",
                City="Moscow"
            }
            },

               new Student(){
            Id=5,
            Name="Lara",
                Age=87,
            Address=new Address(){
                Id=105,
                Country="Spain",
                State="Catalonia",
                City="Barcelona"
            }
            }
    };

        [Route("")] //empty means default
        public ActionResult GetAllStudents()
        {
            var data = students;
            return View(data);
        }

        [Route("{id:int}")]
        public ActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        [Route("address/{id}")]
        public ActionResult GetAddressOfStudentById(int id)
        {
            var studentAddress = students.Where(st => st.Id == id).Select(st => st.Address).FirstOrDefault();
            return View(studentAddress);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound("Student not found");
            }
            return View(student);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id) //post
        {
            var deleteStudent = students.FirstOrDefault(students => students.Id == id);
            if(deleteStudent != null)
            {
                students.Remove(deleteStudent);
               
            }
            return RedirectToAction("GetAllStudents");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(st=>st.Id==id);
            return View(student);

        }
        [HttpPost]
        public ActionResult Edit(Student editStudent)
        {
            
            if (ModelState.IsValid)
            {
                var updateStudent = students.FirstOrDefault(s => s.Id == editStudent.Id);
                if (updateStudent != null)
                {
                    updateStudent.Name = editStudent.Name;
                    updateStudent.Age = editStudent.Age;
                    updateStudent.Address = editStudent.Address;
                }
                return RedirectToAction("GetAllStudents");
            }
            return View(editStudent);


        }
       
        [HttpGet]
        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("GetAllStudents");
            }
            return View(student);

        }

       
        public ActionResult DeleteAddress(int addid) //using post
        {
           
            var studentAddress = students.FirstOrDefault(s=>s.Address!=null && s.Address.Id==addid);
            if(studentAddress == null)
            {
                return HttpNotFound("Address not found");
            }
            
            studentAddress.Address = null;
            return RedirectToAction("GetAllStudents");
        }



        [HttpGet]
        public ActionResult EditAddress(int id)
        {

            var address = students.Where(st => st.Id == id).Select(st => st.Address).FirstOrDefault();
            if (address == null)
            {
                return HttpNotFound("Address not found");
            }

            return View(address);


            //var student = students.Where(st => st.Id == id).FirstOrDefault();
            //return View(student);

        }

        [HttpPost]
        public ActionResult EditAddress(int id, Address updatedAddress)
        {
            var student = students.FirstOrDefault(st => st.Address != null && st.Address.Id == id);
            if (student == null || student.Address == null)
            {
                return HttpNotFound("Student or address not found");
            }
            student.Address.Country = updatedAddress.Country;
            student.Address.State = updatedAddress.State;
            student.Address.City = updatedAddress.City;
            return RedirectToAction("GetAllStudents");


        }






    }
}