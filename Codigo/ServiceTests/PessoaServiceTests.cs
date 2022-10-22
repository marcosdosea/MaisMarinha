using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class PessoaServiceTests
    {
        private MaisMarinhaContext _context;
        private PessoaService _pessoaService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<MaisMarinhaContext>();
            builder.UseInMemoryDatabase("MaisMarinha");
            var options = builder.Options;

            _context = new MaisMarinhaContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var pessoas = new List<Pessoa>
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
                    Nome = "Charles Dayan",
                    Cpf = "02586713321",
                    Email = "teste02@academico.ufs.br",
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Bairro = "Centro",
                    Rua = "Rua Percilio Andrade",
                    NumeroEndereco = "24",
                    Cep = "49500413",
                    Complemento = "Casa",
                    Telefone = "99984343"
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Carlos",
                    Cpf = "07124515593",
                    Email = "teste03@academico.ufs.br",
                    Estado = "SE",
                    Cidade = "Itabaiana",
                    Bairro = "Centro",
                    Rua = "Rua Francisco Bragança",
                    NumeroEndereco = "501",
                    Cep = "49501590",
                    Complemento = "Proximo ao assai",
                    Telefone = "999051234"
                }
            };


            _context.AddRange(pessoas);
            _context.SaveChanges();

            _pessoaService = new PessoaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _pessoaService.Create(new Pessoa
            {
                Id = 4,
                Nome = "Jorge",
                Cpf = "05266319984",
                Email = "teste04@academico.ufs.br",
                Estado = "SE",
                Cidade = "Itabaiana",
                Bairro = "Sao Cristóvão",
                Rua = "Rua F",
                NumeroEndereco = "S/N",
                Cep = "49501570",
                Complemento = "Frente a praça",
                Telefone = "999842412"
            });

            // Assert
            Assert.AreEqual(4, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(4);
            Assert.AreEqual("Jorge", pessoa.Nome);
            Assert.AreEqual("05266319984", pessoa.Cpf);
            Assert.AreEqual("teste04@academico.ufs.br", pessoa.Email);
            Assert.AreEqual("SE", pessoa.Estado);
            Assert.AreEqual("Itabaiana", pessoa.Cidade);
            Assert.AreEqual("Sao Cristóvão", pessoa.Bairro);
            Assert.AreEqual("Rua F", pessoa.Rua);
            Assert.AreEqual("S/N", pessoa.NumeroEndereco);
            Assert.AreEqual("49501570", pessoa.Cep);
            Assert.AreEqual("Frente a praça", pessoa.Complemento);
            Assert.AreEqual("999842412", pessoa.Telefone);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _pessoaService.Delete(2);
            // Assert
            Assert.AreEqual(2, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(2);
            Assert.AreEqual(null, pessoa);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var pessoa = _pessoaService.Get(3);
            pessoa.Rua = "Rua D";
            pessoa.NumeroEndereco = "300";
            _pessoaService.Edit(pessoa);
            //Assert
            pessoa = _pessoaService.Get(3);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Rua D", pessoa.Rua);
            Assert.AreEqual("300", pessoa.NumeroEndereco);
        }

        [TestMethod()]
        public void GetTest()
        {
            // Act
            var pessoa = _pessoaService.Get(1);
            // Assert
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Marcos Dosea", pessoa.Nome);
            Assert.AreEqual("08254335508", pessoa.Cpf);
            Assert.AreEqual("teste@academico.ufs.br", pessoa.Email);
            Assert.AreEqual("SE", pessoa.Estado);
            Assert.AreEqual("Itabaiana", pessoa.Cidade);
            Assert.AreEqual("Centro", pessoa.Bairro);
            Assert.AreEqual("Rua de Maraba", pessoa.Rua);
            Assert.AreEqual("631", pessoa.NumeroEndereco);
            Assert.AreEqual("49500403", pessoa.Cep);
            Assert.AreEqual("Nada", pessoa.Complemento);
            Assert.AreEqual("99082332", pessoa.Telefone);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPessoa = _pessoaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaPessoa);
            Assert.AreEqual(3, listaPessoa.Count());
            Assert.AreEqual(1, listaPessoa.First().Id);
            Assert.AreEqual("Marcos Dosea", listaPessoa.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var pessoas = _pessoaService.GetAll();
            //Assert
            Assert.IsNotNull(pessoas);
            Assert.AreEqual(3, pessoas.Count());
            Assert.AreEqual("Marcos Dosea", pessoas.First().Nome);
        }
    }
}
