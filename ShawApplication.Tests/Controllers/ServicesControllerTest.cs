using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ShawApplication.API;
using ShawApplication.API.Models;
using ShawApplication.API.Controllers;


namespace ShawInterviewExercise.API.Tests.Controllers
{
    [TestClass]
    public class ServicesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ServicesController controller = new ServicesController();

            // Act
            IEnumerable<Show> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ServicesController controller = new ServicesController();

            // Act
            Show result = controller.Get(5);

            // Assert
            Assert.AreEqual("The Blacklist", result.Name);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ServicesController controller = new ServicesController();
            Show show = new Show { Name = "ABC", Description = "Test Description" };
            // Act
            controller.Post(show);

            // Assert
            Show result = controller.Get(6);
            Assert.AreEqual("ABC", result.Name);
        }  

        [TestMethod]
        public void Put()
        {
            // Arrange
            ServicesController controller = new ServicesController();
            List<string> ls = new List<string>();
            ls.Add("2");
            ls.Add("New Name");
            ls.Add("New Description");

            Show show = new Show { Id = 100, Name = "ABCD", Description = "Test Description1" };
            // Act
            controller.Put(ls);

            Show  show2=  controller.Get(2);
            // Assert
            Assert.AreEqual("New Name", show2.Name);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ServicesController controller = new ServicesController();
            List<string> ls = new List<string>();
            ls.Add("1");

            // Act
            controller.Delete(ls);

            Show result = controller.Get(1);

            // Assert
            Assert.IsNull(result); 
             
        }
    }
}
