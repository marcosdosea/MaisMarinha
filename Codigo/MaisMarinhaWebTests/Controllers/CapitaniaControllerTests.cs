using MaisMarinhaWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Core.Service;
using MaisMarinhaWeb.Mappers;
using Core;
using MaisMarinhaWeb.Models;

namespace MaisMarinhaWeb.Controllers.Tests
{
    [TestClass()]
    public class CapitaniaControllerTests
    {
        private static CapitaniaController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<ICapitaniaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new CapitaniaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestCapitania());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetCapitania());
            mockService.Setup(service => service.Edit(It.IsAny<Capitania>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Capitania>()))
                .Verifiable();
            controller = new CapitaniaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CapitaniaModel>));

            List<CapitaniaModel>? lista = (List<CapitaniaModel>)viewResult.ViewData.Model;
            Assert.AreEqual(2, lista.Count);

        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CapitaniaModel));
            CapitaniaModel capitaniaModel = (CapitaniaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Capitania dos Portos de Sergipe", capitaniaModel.Nome);
            Assert.AreEqual("SE", capitaniaModel.Estado);
            Assert.AreEqual("Aracaju", capitaniaModel.Cidade);
            Assert.AreEqual("São José", capitaniaModel.Bairro);
            Assert.AreEqual("Av. Ivo do Prado", capitaniaModel.Rua);
            Assert.AreEqual(752, capitaniaModel.Numero);
            Assert.AreEqual("Área FOXTROT", capitaniaModel.MetareaV);
            Assert.AreEqual("(79) 3711-1646", capitaniaModel.Telefone);
            Assert.AreEqual(DateTime.Parse("2022/04/23 00:00:00"), capitaniaModel.HorarioInicio);
            Assert.AreEqual(DateTime.Parse("2022/04/24 00:01:00"), capitaniaModel.HorarioFim);



        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewCapitania());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewCapitania());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(1);


            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CapitaniaModel));
            CapitaniaModel capitaniaModel = (CapitaniaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Capitania dos Portos de Sergipe", capitaniaModel.Nome);
            Assert.AreEqual("SE", capitaniaModel.Estado);
            Assert.AreEqual("Aracaju", capitaniaModel.Cidade);
            Assert.AreEqual("São José", capitaniaModel.Bairro);
            Assert.AreEqual("Av. Ivo do Prado", capitaniaModel.Rua);
            Assert.AreEqual(752, capitaniaModel.Numero);
            Assert.AreEqual("Área FOXTROT", capitaniaModel.MetareaV);
            Assert.AreEqual("(79) 3711-1646", capitaniaModel.Telefone);
            Assert.AreEqual(DateTime.Parse("23/04/2022 00:00:00"), capitaniaModel.HorarioInicio);
            Assert.AreEqual(DateTime.Parse("24/04/2022 00:01:00"), capitaniaModel.HorarioFim);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetCapitaniaModel().Id, GetTargetCapitaniaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CapitaniaModel));
            CapitaniaModel capitaniaModel = (CapitaniaModel)viewResult.ViewData.Model;

            Assert.AreEqual("Capitania dos Portos de Sergipe", capitaniaModel.Nome);
            Assert.AreEqual("SE", capitaniaModel.Estado);
            Assert.AreEqual("Aracaju", capitaniaModel.Cidade);
            Assert.AreEqual("São José", capitaniaModel.Bairro);
            Assert.AreEqual("Av. Ivo do Prado", capitaniaModel.Rua);
            Assert.AreEqual(752, capitaniaModel.Numero);
            Assert.AreEqual("Área FOXTROT", capitaniaModel.MetareaV);
            Assert.AreEqual("(79) 3711-1646", capitaniaModel.Telefone);
            Assert.AreEqual(DateTime.Parse("2022/04/23 00:00:00"), capitaniaModel.HorarioInicio);
            Assert.AreEqual(DateTime.Parse("2022/04/24 00:01:00"), capitaniaModel.HorarioFim);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetCapitaniaModel().Id, GetTargetCapitaniaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private CapitaniaModel GetNewCapitania()
        {
            return new CapitaniaModel
            {
                Id = 1,
                Nome = "Capitania dos Portos de Sergipe",
                Estado = "SE",
                Cidade = "Aracaju",
                Bairro = "São José",
                Rua = "Av. Ivo do Prado",
                Numero = 752,
                MetareaV = "Área FOXTROT",
                Telefone = "(79) 3711-1646",
                HorarioInicio = DateTime.Parse("2022/04/23 00:00:00"),
                HorarioFim = DateTime.Parse("2022/04/24 00:01:00")

            };

        }


        private CapitaniaModel GetTargetCapitaniaModel()
        {
            return new CapitaniaModel
            {
                Id = 2,
                Nome = "Capitania dos Portos de Sergipe",
                Estado = "SE",
                Cidade = "Aracaju",
                Bairro = "São José",
                Rua = "Av. Ivo do Prado",
                Numero = 752,
                MetareaV = "Área FOXTROT",
                Telefone = "(79) 3711-1646",
                HorarioInicio = DateTime.Parse("2022/04/23 00:00:00"),
                HorarioFim = DateTime.Parse("2022/04/24 00:01:00")

            };

        }
        private Capitania GetTargetCapitania()
        {
            return new Capitania
            {
                Id = 3,
                Nome = "Capitania dos Portos de Sergipe",
                Estado = "SE",
                Cidade = "Aracaju",
                Bairro = "São José",
                Rua = "Av. Ivo do Prado",
                Numero = 752,
                MetareaV = "Área FOXTROT",
                Telefone = "(79) 3711-1646",
                HorarioInicio = DateTime.Parse("2022/04/23 00:00:00"),
                HorarioFim = DateTime.Parse("2022/04/24 00:01:00")

            };

        }




        private IEnumerable<Capitania> GetTestCapitania()
        {
            return new List<Capitania>
            {

                new Capitania {
                    Id = 1,
                    Nome = "Capitania dos Portos de Sergipe",
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Bairro = "São José",
                    Rua = "Av. Ivo do Prado",
                    Numero = 752,
                    MetareaV = "Área FOXTROT",
                    Telefone = "(79) 3711-1646",
                    HorarioInicio = DateTime.Parse("2022/04/23 00:00:00"),
                    HorarioFim = DateTime.Parse("2022/04/24 00:01:00")
                },

                {
                    new Capitania {
                        Id = 1,
                        Nome = "Capitania dos Portos de Sergipe",
                        Estado = "SE",
                        Cidade = "Aracaju",
                        Bairro = "São José",
                        Rua = "Av. Ivo do Prado",
                        Numero = 752,
                        MetareaV = "Área FOXTROT",
                        Telefone = "(79) 3711-1646",
                        HorarioInicio = DateTime.Parse("2022/04/23 00:00:00"),
                        HorarioFim = DateTime.Parse("2022/04/24 00:01:00")
                    }
                }
            };

        }
    }
}