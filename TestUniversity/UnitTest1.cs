using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using System.Linq;
using UniversityProgect.Controllers;
using UniversityProgect.Models.ViewModels;
using UniversityProject.Domain.Core;
using UniversityProject.Domain.Interfaces;

namespace TestUniversity
{
    public class Tests
    {
        StudentController _studentController;
        CourseController _courseController;
        GroupController _groupController;
        Mock<IStudentRepository> _studentMock;
        Mock<ICourseRepository> _courseMock;
        Mock<IGroupRepository> _groupMock;
        Mock<ITempDataDictionary> _tempDataMock;
        Student _student;
        Course _course;
        Group _groupForDelete;

        [SetUp]
        public void SetUp()
        {
            _tempDataMock = new Mock<ITempDataDictionary>();

            _studentMock = new Mock<IStudentRepository>();
            _student = new Student { StudentId = 2, FirstName = "Sara", LastName = "Dower", GroupId = 2 };
            _studentMock.Setup(m => m.Students).Returns((new Student[]
            {
                new Student { StudentId = 1, FirstName = "Tom", LastName = "Smith", GroupId = 1 },
                _student,
                new Student { StudentId = 3, FirstName = "John", LastName = "Archer", GroupId = 1 }
            }).AsQueryable());
            _studentController = new StudentController(_studentMock.Object)
            {
                TempData = _tempDataMock.Object
            };

            _courseMock = new Mock<ICourseRepository>();
            _course = new Course { CourseId = 2, Name = "course2", Description = "BBDescription" };
            _courseMock.Setup(c => c.Courses).Returns((new Course[] {
                new Course { CourseId = 1, Name = "course1", Description = "AADescription" },
                _course,
                new Course { CourseId = 3, Name = "course3", Description = "CCDescription" }
            }).AsQueryable());
            _courseController = new CourseController(_courseMock.Object)
            {
                TempData = _tempDataMock.Object
            };

            _groupMock = new Mock<IGroupRepository>();
            _groupForDelete = new Group { GroupId = 3, Name = "group2", CourseId = 2 };
            
            _groupMock.Setup(m => m.Groups).Returns((new Group[] {
                new Group{GroupId = 1, Name = "group1", CourseId = 1},
                _groupForDelete,
                new Group{GroupId = 2, Name = "group3", CourseId = 1}
            }).AsQueryable());
            _groupController = new GroupController(_groupMock.Object, _studentMock.Object)
            {
                TempData = _tempDataMock.Object
            };
        }

        [Test]
        //тестирование разбиенмя на страницы
        public void Can_Paginate()
        {
            _studentController.PageSize = 2;
            StudentsListViewModel result = _studentController.List(null, 2).ViewData.Model as StudentsListViewModel;
            Assert.True(result.Students.Count() == 1);
            Assert.AreEqual("John", result.Students.First().FirstName);            
        }


        /// <summary>
        /// Student Controller
        /// </summary>
        /// 

        [Test]
        public void CanFilterStudents()
        {
            StudentsListViewModel result = _studentController.List(1).ViewData.Model as StudentsListViewModel;
            Assert.True(result.Students.Count() == 2);
            Assert.True(result.Students.First().FirstName == "Tom" && result.Students.First().LastName == "Smith");
        }

        [Test]
        public void CanSaveStudentValidChanges()
        {
            Student student = new Student()
            {
                StudentId = 1,
                GroupId = 1,
                FirstName = "Todd",
                LastName = "Smith"
            };
            IActionResult result = _studentController.Edit(student);
            _studentMock.Verify(m => m.SaveStudent(student));
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.AreEqual("List", (result as RedirectToActionResult).ActionName);
        }

        [Test]
        public void CannotSaveStudentInvalidChanges()
        {
            Student student = new Student()
            {
                StudentId = 1,
                GroupId = 1,
                FirstName = "Todd",
                LastName = "Smith"
            };
            _studentController.ModelState.AddModelError("error", "error");
            IActionResult result = _studentController.Edit(student);
            _studentMock.Verify(m => m.SaveStudent(It.IsAny<Student>()), Times.Never());
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void CanDeleteValidStudent()
        {
            _studentController.DeleteStudent(2);
            _studentMock.Verify(s => s.DeleteStudent((int)_student.StudentId));
        }


        /// <summary>
        /// CourseController
        /// </summary>
        /// 

        [Test]
        public void CanSaveCourseValidChanges()
        {
            Course course = new Course()
            {
                CourseId = 1,
                Name = "Course1",
                Description = "Description",
            };
            IActionResult result = _courseController.Edit(course);
            _courseMock.Verify(m => m.SaveCourse(course));
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.AreEqual("List", (result as RedirectToActionResult).ActionName);
        }

        [Test]
        public void CannotSaveCourseInvalidChanges()
        {
            Course course = new Course()
            {
                CourseId = 1,
                Name = "Course1",
                Description = "Description",
            };
            _courseController.ModelState.AddModelError("error", "error");
            IActionResult result = _courseController.Edit(course);
            _courseMock.Verify(m => m.SaveCourse(It.IsAny<Course>()), Times.Never());
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void CanDeleteValidCourse()
        {
            _courseController.DeleteCourse(2);
            _courseMock.Verify(s => s.DeleteCourse((int)_course.CourseId));
        }
        
        /// <summary>
        /// Group Controller
        /// </summary>
        /// 
        [Test]
        public void CanFilterGroups()
        {
            GroupListViewModel result = _groupController.List(1).ViewData.Model as GroupListViewModel;
            Assert.True(result.Groups.Count() == 2);
            Assert.True(result.Groups.First().Name == "group1");
        }

        [Test]
        public void CanSaveGroupValidChanges()
        {
            Group group = new Group()
            {
                GroupId = 1,
                Name = "Group1",
            };
            IActionResult result = _groupController.Edit(group);
            _groupMock.Verify(m => m.SaveGroup(group));
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.AreEqual("List", (result as RedirectToActionResult).ActionName);
        }
        [Test]
        public void CannotSaveGroupInvalidChanges()
        {
            Group group = new Group()
            {
                GroupId = 1,
                Name = "Group1",
            };
            _groupController.ModelState.AddModelError("error", "error");
            IActionResult result = _groupController.Edit(group);
            _groupMock.Verify(m => m.SaveGroup(It.IsAny<Group>()), Times.Never());
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void CanDeleteValidGroup()
        {
            _groupController.DeleteGroup(3);
            _groupMock.Verify(s => s.DeleteGroup((int)_groupForDelete.GroupId));
        }
    }
}