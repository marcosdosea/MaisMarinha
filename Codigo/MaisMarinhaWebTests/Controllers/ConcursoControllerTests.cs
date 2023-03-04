using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using Core.Service;
using Moq;
using MaisMarinhaWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using MaisMarinhaWeb.Models;

namespace MaisMarinhaWeb.Controllers.Tests
{
    [TestClass()]
    public class ConcursoControllerTests
    {
        private static ConcursoController controller;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var mockService = new Mock<IConcursoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ConcursoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestConcurso());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetConcurso());
            mockService.Setup(service => service.Edit(It.IsAny<Concurso>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Concurso>()))
                .Verifiable();
            controller = new ConcursoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ConcursoModel>));

            List<ConcursoModel>? lista = (List<ConcursoModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            //Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConcursoModel));
            ConcursoModel concursoModel = (ConcursoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Concurso Marinheiro", concursoModel.Nome);
            Assert.AreEqual(1, concursoModel.Edital);
            Assert.AreEqual(DateTime.Parse("2023-03-03"), concursoModel.DataInicialInscricao);
            Assert.AreEqual(DateTime.Parse("2023-03-20"), concursoModel.DataFinalInscricao);
            Assert.AreEqual(DateTime.Parse("2023-03-31"), concursoModel.DataProva);
            Assert.AreEqual("SE", concursoModel.Estado);
            Assert.AreEqual("Lagarto", concursoModel.Cidade);
            Assert.AreEqual(50, concursoModel.Vagas);
            Assert.AreEqual("EM", concursoModel.Escolaridade);
            Assert.AreEqual("3", concursoModel.Etapas);
            Assert.AreEqual("Engenharia", concursoModel.AreaTecnica);
            Assert.AreEqual("Capitania dos portos de sergipe", concursoModel.LocalInscricao);
            Assert.AreEqual(50.00F, concursoModel.ValorInscricao);
            Assert.AreEqual("Aracaju", concursoModel.LocalProva);
            Assert.AreEqual("Capitão", concursoModel.Cargo);
            Assert.AreEqual("1", concursoModel.Turma);
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
            var result = controller.Create(GetNewConcurso());

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
            var result = controller.Create(GetNewConcurso());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConcursoModel));
            ConcursoModel concursoModel = (ConcursoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Concurso Marinheiro", concursoModel.Nome);
            Assert.AreEqual(1, concursoModel.Edital);
            Assert.AreEqual(DateTime.Parse("2023-03-03"), concursoModel.DataInicialInscricao);
            Assert.AreEqual(DateTime.Parse("2023-03-20"), concursoModel.DataFinalInscricao);
            Assert.AreEqual(DateTime.Parse("2023-03-31"), concursoModel.DataProva);
            Assert.AreEqual("SE", concursoModel.Estado);
            Assert.AreEqual("Lagarto", concursoModel.Cidade);
            Assert.AreEqual(50, concursoModel.Vagas);
            Assert.AreEqual("EM", concursoModel.Escolaridade);
            Assert.AreEqual("3", concursoModel.Etapas);
            Assert.AreEqual("Engenharia", concursoModel.AreaTecnica);
            Assert.AreEqual("Capitania dos portos de sergipe", concursoModel.LocalInscricao);
            Assert.AreEqual(50.00F, concursoModel.ValorInscricao);
            Assert.AreEqual("Aracaju", concursoModel.LocalProva);
            Assert.AreEqual("Capitão", concursoModel.Cargo);
            Assert.AreEqual("1", concursoModel.Turma);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetConcursoModel().Id, GetTargetConcursoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ConcursoModel));
            ConcursoModel concursoModel = (ConcursoModel)viewResult.ViewData.Model;
            Assert.AreEqual("Concurso Marinheiro", concursoModel.Nome);
            Assert.AreEqual(1, concursoModel.Edital);
            Assert.AreEqual(DateTime.Parse("2023-03-03"), concursoModel.DataInicialInscricao);
            Assert.AreEqual(DateTime.Parse("2023-03-20"), concursoModel.DataFinalInscricao);
            Assert.AreEqual(DateTime.Parse("2023-03-31"), concursoModel.DataProva);
            Assert.AreEqual("SE", concursoModel.Estado);
            Assert.AreEqual("Lagarto", concursoModel.Cidade);
            Assert.AreEqual(50, concursoModel.Vagas);
            Assert.AreEqual("EM", concursoModel.Escolaridade);
            Assert.AreEqual("3", concursoModel.Etapas);
            Assert.AreEqual("Engenharia", concursoModel.AreaTecnica);
            Assert.AreEqual("Capitania dos portos de sergipe", concursoModel.LocalInscricao);
            Assert.AreEqual(50.00F, concursoModel.ValorInscricao);
            Assert.AreEqual("Aracaju", concursoModel.LocalProva);
            Assert.AreEqual("Capitão", concursoModel.Cargo);
            Assert.AreEqual("1", concursoModel.Turma);

        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetConcursoModel().Id,GetTargetConcursoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ConcursoModel GetNewConcurso()
        {
            return new ConcursoModel
            {
                Id = 3,
                Nome = "Concurso Auxiliar Adminstrativo",
                Edital = 1,
                DataInicialInscricao = DateTime.Parse("1892-10-27"),
                DataFinalInscricao = DateTime.Parse("1892-10-29"),
                DataProva = DateTime.Parse("1892-10-31"),
                Estado = "BA",
                Cidade = "Salvador",
                Vagas = 10,
                Escolaridade = "ES",
                Etapas = "1",
                AreaTecnica = "NA",
                LocalInscricao = "Capitania dos portos de Salvador",
                ValorInscricao = 30.00F,
                LocalProva = "Salvador",
                Cargo = "Auxiliar ADM",
                Turma = "1"
            };
        }

        private static Concurso GetTargetConcurso()
        {
            return new Concurso
            {
                Id = 1,
                Nome = "Concurso Marinheiro",
                Edital = 1,
                DataInicialInscricao = DateTime.Parse("2023-03-03"),
                DataFinalInscricao = DateTime.Parse("2023-03-20"),
                DataProva = DateTime.Parse("2023-03-31"),
                Estado = "SE",
                Cidade = "Lagarto",
                Vagas = 50,
                Escolaridade = "EM",
                Etapas = "3",
                AreaTecnica = "Engenharia",
                LocalInscricao = "Capitania dos portos de sergipe",
                ValorInscricao = 50.00F,
                LocalProva = "Aracaju",
                Cargo = "Capitão",
                Turma = "1"
            };
        }

        private ConcursoModel GetTargetConcursoModel()
        {
            return new ConcursoModel
            {
                Id = 2,
                Nome = "Concurso Engenheiro",
                Edital = 1,
                DataInicialInscricao = DateTime.Parse("1892-10-27"),
                DataFinalInscricao = DateTime.Parse("1892-10-29"),
                DataProva = DateTime.Parse("1892-10-31"),
                Estado = "SE",
                Cidade = "Aracaju",
                Vagas = 20,
                Escolaridade = "ES",
                Etapas = "2",
                AreaTecnica = "Exercito",
                LocalInscricao = "Capitania dos portos de sergipe",
                ValorInscricao = 1000.00F,
                LocalProva = "Aracaju",
                Cargo = "Brigadeiro",
                Turma = "2"
            };
        }

        private static IEnumerable<Concurso> GetTestConcurso()
        {
            return new List<Concurso>
           {
               new Concurso
                {
                    Id = 1,
                    Nome = "Concurso Marinheiro",
                    Edital = 1,
                    DataInicialInscricao = DateTime.Parse("2023-03-03"),
                    DataFinalInscricao = DateTime.Parse("2023-03-20"),
                    DataProva = DateTime.Parse("2023-03-31"),
                    Estado = "SE",
                    Cidade = "Lagarto",
                    Vagas = 50,
                    Escolaridade = "EM",
                    Etapas = "3",
                    AreaTecnica = "Engenharia",
                    LocalInscricao = "Capitania dos portos de sergipe",
                    ValorInscricao = 50.00F,
                    LocalProva = "Aracaju",
                    Cargo = "Capitão",
                    Turma = "1"
                },
                new Concurso
                {
                    Id = 2,
                    Nome = "Concurso Engenheiro",
                    Edital = 1,
                    DataInicialInscricao = DateTime.Parse("1892-10-27"),
                    DataFinalInscricao = DateTime.Parse("1892-10-29"),
                    DataProva = DateTime.Parse("1892-10-31"),
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Vagas = 20,
                    Escolaridade = "ES",
                    Etapas = "2",
                    AreaTecnica = "Exercito",
                    LocalInscricao = "Capitania dos portos de sergipe",
                    ValorInscricao = 1000.00F,
                    LocalProva = "Aracaju",
                    Cargo = "Brigadeiro",
                    Turma = "2"
                },
                new Concurso
                {
                    Id = 3,
                    Nome = "Concurso Auxiliar Adminstrativo",
                    Edital = 1,
                    DataInicialInscricao = DateTime.Parse("1892-10-27"),
                    DataFinalInscricao = DateTime.Parse("1892-10-29"),
                    DataProva = DateTime.Parse("1892-10-31"),
                    Estado = "BA",
                    Cidade = "Salvador",
                    Vagas = 10,
                    Escolaridade = "ES",
                    Etapas = "1",
                    AreaTecnica = "NA",
                    LocalInscricao = "Capitania dos portos de Salvador",
                    ValorInscricao = 30.00F,
                    LocalProva = "Salvador",
                    Cargo = "Auxiliar ADM",
                    Turma = "1"
                }
            };

        }
    }
}
