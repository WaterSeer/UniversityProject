using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversityProgect.Controllers;
using UniversityProgect.DataModel;
using UniversityProgect.Interfaces;
using UniversityProgect.Models;
using UniversityProgect.Models.ViewModels;

namespace TestUniversity
{
    public class Tests
    {
                
        
        [SetUp]
        //тестирование разбиенмя на страницы
        public void Can_Paginate()
        {
            //setup
            Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
            mock.Setup(m => m.Students).Returns((new Student[]
            {
                new Student { StudentId = 1, FirstName = "Tom", LastName = "Smith" },
                new Student { StudentId = 2, FirstName = "Sara", LastName = "Dower"}
            }).AsQueryable());
            StudentController studentController = new StudentController(mock.Object);
            //act
            StudentsListViewModel result = studentController.List(null, 2).ViewData.Model as StudentsListViewModel;
            //assert           
            Student[] studentArr = result.Students.ToArray();
            Assert.True(studentArr.Length == 2);
            Assert.Equals("Tom", studentArr[0].FirstName);
            Assert.Equals("Sara", studentArr[1].FirstName);
        }

        [Test]
        public void Test1()
        {
            
            
            
            Assert.Pass();
        }
    }
}