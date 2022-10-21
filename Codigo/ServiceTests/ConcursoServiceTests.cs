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
    public class ConcursoServiceTests
    {
        private MaisMarinhaContext _context;
        private ConcursoService _concursoService;

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

            var concursos = new List<Concurso>
           {
               new Concurso
                {
                    Id = 1,
                    Nome = "Concurso Marinheiro",
                    Edital = 1,
                    DataInicialInscricao = DateTime.Parse("1892-10-27"),
                    DataFinalInscricao = DateTime.Parse("1892-10-29"),
                    DataProva = DateTime.Parse("1892-10-31"),
                    Estado = "SE",
                    Cidade = "Itabaiana",
                    Vagas = 50,
                    Escolaridade = "EM",
                    Etapas = "3",
                    AreaTecnica = "Engneharia",
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


            _context.AddRange(concursos);
            _context.SaveChanges();

            _concursoService = new ConcursoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _concursoService.Create(new Concurso
            {
                Id = 4,
                Nome = "Concurso Recepcionista",
                Edital = 1,
                DataInicialInscricao = DateTime.Parse("1892-10-27"),
                DataFinalInscricao = DateTime.Parse("1892-10-29"),
                DataProva = DateTime.Parse("1892-10-31"),
                Estado = "SE",
                Cidade = "Itabaiana",
                Vagas = 50,
                Escolaridade = "EM",
                Etapas = "3",
                AreaTecnica = "Engneharia",
                LocalInscricao = "Capitania dos portos de sergipe",
                ValorInscricao = 50.00F,
                LocalProva = "Aracaju",
                Cargo = "Capitão",
                Turma = "1"
            });

            // Assert
            Assert.AreEqual(4, _concursoService.GetAll().Count());
            var concurso = _concursoService.Get(4);
            Assert.AreEqual("Concurso Recepcionista", concurso.Nome);
            Assert.AreEqual(1, concurso.Edital);
            Assert.AreEqual(DateTime.Parse("1892-10-27"), concurso.DataInicialInscricao);
            Assert.AreEqual(DateTime.Parse("1892-10-29"), concurso.DataFinalInscricao);
            Assert.AreEqual(DateTime.Parse("1892-10-31"), concurso.DataProva);
            Assert.AreEqual("SE", concurso.Estado);
            Assert.AreEqual("Itabaiana", concurso.Cidade);
            Assert.AreEqual(50, concurso.Vagas);
            Assert.AreEqual("EM", concurso.Escolaridade);
            Assert.AreEqual("3", concurso.Etapas);
            Assert.AreEqual("Engneharia", concurso.AreaTecnica);
            Assert.AreEqual("Capitania dos portos de sergipe", concurso.LocalInscricao);
            Assert.AreEqual(50.00F, concurso.ValorInscricao);
            Assert.AreEqual("Aracaju", concurso.LocalProva);
            Assert.AreEqual("Capitão", concurso.Cargo);
            Assert.AreEqual("1", concurso.Turma);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _concursoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _concursoService.GetAll().Count());
            var concurso = _concursoService.Get(2);
            Assert.AreEqual(null, concurso);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var concurso = _concursoService.Get(3);
            concurso.Nome = "Concurso AX. ADM";
            concurso.DataProva = DateTime.Parse("2022-11-21");
            _concursoService.Edit(concurso);
            //Assert
            concurso = _concursoService.Get(3);
            Assert.IsNotNull(concurso);
            Assert.AreEqual("Concurso AX. ADM", concurso.Nome);
            Assert.AreEqual(DateTime.Parse("2022-11-21"), concurso.DataProva);
        }

        [TestMethod()]
        public void GetTest()
        {
            // Act
            var concurso = _concursoService.Get(1);
            // Assert
            Assert.IsNotNull(concurso);
            Assert.AreEqual("Concurso Marinheiro", concurso.Nome);
            Assert.AreEqual(1, concurso.Edital);
            Assert.AreEqual(DateTime.Parse("1892-10-27"), concurso.DataInicialInscricao);
            Assert.AreEqual(DateTime.Parse("1892-10-29"), concurso.DataFinalInscricao);
            Assert.AreEqual(DateTime.Parse("1892-10-31"), concurso.DataProva);
            Assert.AreEqual("SE", concurso.Estado);
            Assert.AreEqual("Itabaiana", concurso.Cidade);
            Assert.AreEqual(50, concurso.Vagas);
            Assert.AreEqual("EM", concurso.Escolaridade);
            Assert.AreEqual("3", concurso.Etapas);
            Assert.AreEqual("Engneharia", concurso.AreaTecnica);
            Assert.AreEqual("Capitania dos portos de sergipe", concurso.LocalInscricao);
            Assert.AreEqual(50.00F, concurso.ValorInscricao);
            Assert.AreEqual("Aracaju", concurso.LocalProva);
            Assert.AreEqual("Capitão", concurso.Cargo);
            Assert.AreEqual("1", concurso.Turma);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaConcurso = _concursoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaConcurso, typeof(IEnumerable<Concurso>));
            Assert.IsNotNull(listaConcurso);
            Assert.AreEqual(3, listaConcurso.Count());
            Assert.AreEqual(1, listaConcurso.First().Id);
            Assert.AreEqual("Concurso Marinheiro", listaConcurso.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var concursos = _concursoService.GetByNome("Concurso M");
            //Assert
            Assert.IsNotNull(concursos);
            Assert.AreEqual(1, concursos.Count());
            Assert.AreEqual("Concurso Marinheiro", concursos.First().Nome);
        }
    }
}
