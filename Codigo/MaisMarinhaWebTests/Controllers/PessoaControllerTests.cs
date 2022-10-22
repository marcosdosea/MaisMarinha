using AutoMapper;
using Core;
using Core.Service;
using MaisMarinhaWeb.Controllers;
using MaisMarinhaWeb.Mappers;
using MaisMarinhaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MaisMarinhaWeb.Controllers.Tests
{
    [TestClass]
    public class PessoaControllerTests
    {
        private static PessoaController controller;
        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPessoas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPessoa());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>())).
                Verifiable();
            controller = new PessoaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaModel>));

            List<PessoaModel>? lista = (List<PessoaModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Marcos Dosea", pessoaModel.Nome);
            Assert.AreEqual("08254335508", pessoaModel.Cpf);
            Assert.AreEqual("teste@academico.ufs.br", pessoaModel.Email);
            Assert.AreEqual("SE", pessoaModel.Estado);
            Assert.AreEqual("Itabaiana", pessoaModel.Cidade);
            Assert.AreEqual("Centro", pessoaModel.Bairro);
            Assert.AreEqual("Rua de Maraba", pessoaModel.Rua);
            Assert.AreEqual("631", pessoaModel.NumeroEndereco);
            Assert.AreEqual("49500403", pessoaModel.Cep);
            Assert.AreEqual("Nada", pessoaModel.Complemento);
            Assert.AreEqual("99082332", pessoaModel.Telefone);
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
            var result = controller.Create(GetNewPessoa());

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
            var result = controller.Create(GetNewPessoa());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Marcos Dosea", pessoaModel.Nome);
            Assert.AreEqual("08254335508", pessoaModel.Cpf);
            Assert.AreEqual("teste@academico.ufs.br", pessoaModel.Email);
            Assert.AreEqual("SE", pessoaModel.Estado);
            Assert.AreEqual("Itabaiana", pessoaModel.Cidade);
            Assert.AreEqual("Centro", pessoaModel.Bairro);
            Assert.AreEqual("Rua de Maraba", pessoaModel.Rua);
            Assert.AreEqual("631", pessoaModel.NumeroEndereco);
            Assert.AreEqual("49500403", pessoaModel.Cep);
            Assert.AreEqual("Nada", pessoaModel.Complemento);
            Assert.AreEqual("99082332", pessoaModel.Telefone);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetPessoaModel().Id, GetTargetPessoaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Marcos Dosea", pessoaModel.Nome);
            Assert.AreEqual("08254335508", pessoaModel.Cpf);
            Assert.AreEqual("teste@academico.ufs.br", pessoaModel.Email);
            Assert.AreEqual("SE", pessoaModel.Estado);
            Assert.AreEqual("Itabaiana", pessoaModel.Cidade);
            Assert.AreEqual("Centro", pessoaModel.Bairro);
            Assert.AreEqual("Rua de Maraba", pessoaModel.Rua);
            Assert.AreEqual("631", pessoaModel.NumeroEndereco);
            Assert.AreEqual("49500403", pessoaModel.Cep);
            Assert.AreEqual("Nada", pessoaModel.Complemento);
            Assert.AreEqual("99082332", pessoaModel.Telefone);

        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetPessoaModel().Id, GetTargetPessoaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private PessoaModel GetTargetPessoaModel()
        {
            return new PessoaModel
            {
                Id = 1,
                Nome = "Marcos Dosea",
                Cpf = "08254335508",
                Email = "teste@academico.ufs.br",
                Estado = "SE",
                Cidade = "Itabaiana",
                Bairro = "Centro",
                Rua = "Rua de Maraba",
                NumeroEndereco = "631",
                Cep = "49500403",
                Complemento = "Nada",
                Telefone = "99082332"

            };
        }


        private PessoaModel GetNewPessoa()
        {
            return new PessoaModel
            {
                Id = 2,
                Nome = "Methanias",
                Cpf = "08254335975",
                Email = "teste1@academico.ufs.br",
                Estado = "SE",
                Cidade = "Itabaiana",
                Bairro = "Centro",
                Rua = "Rua de Maraba",
                NumeroEndereco = "631",
                Cep = "49500403",
                Complemento = "Nada",
                Telefone = "99082332"
            };
        }

        private Pessoa GetTargetPessoa()
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Marcos Dosea",
                Cpf = "08254335508",
                Email = "teste@academico.ufs.br",
                Estado = "SE",
                Cidade = "Itabaiana",
                Bairro = "Centro",
                Rua = "Rua de Maraba",
                NumeroEndereco = "631",
                Cep = "49500403",
                Complemento = "Nada",
                Telefone = "99082332"
            };
        }

        private IEnumerable<Pessoa> GetTestPessoas()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Marcos Dosea",
                    Cpf = "08254335508",
                    Email = "teste@academico.ufs.br",
                    Estado = "SE",
                    Cidade = "Itabaiana",
                    Bairro = "Centro",
                    Rua = "Rua de Maraba",
                    NumeroEndereco = "631",
                    Cep = "49500403",
                    Complemento = "Nada",
                    Telefone = "99082332"
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Methanias",
                    Cpf = "08254335975",
                    Email = "teste1@academico.ufs.br",
                    Estado = "SE",
                    Cidade = "Itabaiana",
                    Bairro = "Centro",
                    Rua = "Rua de Maraba",
                    NumeroEndereco = "631",
                    Cep = "49500403",
                    Complemento = "Nada",
                    Telefone = "99082332"
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Marcos Dosea",
                    Cpf = "08254335508",
                    Email = "teste@academico.ufs.br",
                    Estado = "SE",
                    Cidade = "Itabaiana",
                    Bairro = "Centro",
                    Rua = "Rua de Maraba",
                    NumeroEndereco = "631",
                    Cep = "49500403",
                    Complemento = "Nada",
                    Telefone = "99082332"
                },
            };
        }
    }
}