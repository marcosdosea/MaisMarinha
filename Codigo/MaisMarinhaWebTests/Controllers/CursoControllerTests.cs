using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaisMarinhaWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Moq;
using AutoMapper;
using MaisMarinhaWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using MaisMarinhaWeb.Models;

namespace MaisMarinhaWeb.Controllers.Tests
{
    [TestClass()]
    public class CursoControllerTests
    {
        private static CursoController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<ICursoService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new CursoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestCurso);
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetCurso());
            mockService.Setup(service => service.Edit(It.IsAny<Curso>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Curso>()))
                .Verifiable();
            controller = new CursoController(mockService.Object, mapper);
        }

      

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CursoModel>));

            List<CursoModel>? lista = (List<CursoModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CursoModel));
            CursoModel cursoModel = (CursoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Curso Aquaviário", cursoModel.Nome);
            Assert.AreEqual(DateTime.Parse("05/03/2023 08:00:00"), cursoModel.DataInicial);
            Assert.AreEqual(DateTime.Parse("16/03/2023 16:00:00"), cursoModel.DataFim);
            Assert.AreEqual(50, cursoModel.QuantidadeVagas);
            Assert.AreEqual("SE", cursoModel.Estado);
            Assert.AreEqual("Aracaju", cursoModel.Cidade);
            Assert.AreEqual("Ensino médio completo", cursoModel.Requisitos);
            Assert.AreEqual(DateTime.Parse("07/01/2023 00:01:00"), cursoModel.DataInicioInscricao);
            Assert.AreEqual(DateTime.Parse("09/01/2023 17:00:00"), cursoModel.DataFimInscricao);
            Assert.AreEqual(1, cursoModel.IdCapitania);
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
            var result = controller.Create(GetNewCurso());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewCurso());

            // Assert
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CursoModel));
            CursoModel cursoModel = (CursoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Curso Aquaviário", cursoModel.Nome);
            Assert.AreEqual(DateTime.Parse("05/12/2022 08:00:00"), cursoModel.DataInicial);
            Assert.AreEqual(DateTime.Parse("16/12/2022 16:00:00"), cursoModel.DataFim);
            Assert.AreEqual(10, cursoModel.QuantidadeVagas);
            Assert.AreEqual("SE", cursoModel.Estado);
            Assert.AreEqual("Aracaju", cursoModel.Cidade);
            Assert.AreEqual("Ensino médio completo", cursoModel.Requisitos);
            Assert.AreEqual(DateTime.Parse("07/11/2022 00:01:00"), cursoModel.DataInicioInscricao);
            Assert.AreEqual(1, cursoModel.IdCapitania);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetCursoModel().Id, GetTargetCursoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetCursoModel().Id, GetTargetCursoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CursoModel));
            CursoModel cursoModel = (CursoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Curso Aquaviário", cursoModel.Nome);
            Assert.AreEqual(DateTime.Parse("05/12/2022 08:00:00"), cursoModel.DataInicial);
            Assert.AreEqual(DateTime.Parse("16/12/2022 16:00:00"), cursoModel.DataFim);
            Assert.AreEqual(10, cursoModel.QuantidadeVagas);
            Assert.AreEqual("SE", cursoModel.Estado);
            Assert.AreEqual("Aracaju", cursoModel.Cidade);
            Assert.AreEqual("Ensino médio completo", cursoModel.Requisitos);
            Assert.AreEqual(DateTime.Parse("07/11/2022 00:01:00"), cursoModel.DataInicioInscricao);
            Assert.AreEqual(1, cursoModel.IdCapitania);
        }

        private CursoModel GetNewCurso()
        {
            return new CursoModel
            {
                Id = 1,
                Nome = "Curso Aquaviário",
                DataInicial = DateTime.Parse("05/12/2022 08:00:00"),
                DataFim = DateTime.Parse("16/12/2022 16:00:00"),
                QuantidadeVagas = 10,
                Estado = "SE",
                Cidade = "Aracaju",
                Requisitos = "Ensino médio completo",
                DataInicioInscricao = DateTime.Parse("06/12/2022 00:01:00"),
                DataFimInscricao = DateTime.Parse("09/12/2022 17:00:00"),
                IdCapitania = 1
            };
        }

        private CursoModel GetTargetCursoModel()
        {
            return new CursoModel
            {
                Id = 2,
                Nome = "Curso Aquaviário",
                DataInicial = DateTime.Parse("05/12/2022 08:00:00"),
                DataFim = DateTime.Parse("16/12/2022 16:00:00"),
                QuantidadeVagas = 10,
                Estado = "SE",
                Cidade = "Aracaju",
                Requisitos = "Ensino médio completo",
                DataInicioInscricao = DateTime.Parse("07/11/2022 00:01:00"),
                DataFimInscricao = DateTime.Parse("11/11/2022 17:00:00"),
                IdCapitania = 1
            };
        }

        private Curso GetTargetCurso()
        {
            return new Curso
            {
                Id = 1,
                Nome = "Curso Aquaviário",
                DataInicial = DateTime.Parse("05/12/2022 08:00:00"),
                DataFim = DateTime.Parse("16/12/2022 16:00:00"),
                QuantidadeVagas = 10,
                Estado = "SE",
                Cidade = "Aracaju",
                Requisitos = "Ensino médio completo",
                DataInicioInscricao = DateTime.Parse("07/11/2022 00:01:00"),
                DataFimInscricao = DateTime.Parse("11/11/2022 17:00:00"),
                IdCapitania = 1
            };
        }

        private IEnumerable<Curso> GetTestCurso()
        {
            return new List<Curso>
            {
                new Curso
                {
                    Id = 1,
                    Nome = "Curso Aquaviário",
                    DataInicial = DateTime.Parse("05/12/2022 08:00:00"),
                    DataFim = DateTime.Parse("16/12/2022 16:00:00"),
                    QuantidadeVagas = 10,
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Requisitos = "Ensino médio completo",
                    DataInicioInscricao = DateTime.Parse("07/11/2022 00:01:00"),
                    DataFimInscricao = DateTime.Parse("11/11/2022 17:00:00"),
                    IdCapitania = 1
                },

                new Curso
                {
                    Id = 2,
                    Nome = "Curso Aquaviário",
                    DataInicial = DateTime.Parse("05/12/2022 08:00:00"),
                    DataFim = DateTime.Parse("16/12/2022 16:00:00"),
                    QuantidadeVagas = 9,
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Requisitos = "Ensino médio completo",
                    DataInicioInscricao = DateTime.Parse("07/11/2022 00:01:00"),
                    DataFimInscricao = DateTime.Parse("11/11/2022 17:00:00"),
                    IdCapitania = 1
                }
            };
        }
    }
}
