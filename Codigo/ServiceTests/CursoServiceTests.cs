using Core;
using Core.Service;
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
    public class CursoServiceTests
    {
        private MaisMarinhaContext _context;
        private CursoService _cursoService;

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

            var cursos = new List<Curso>
           {
               new Curso
                {
                    Id = 1,
                    Nome = "Curso Aquaviário",
                    DataInicial = DateTime.Parse("05/03/2023 08:00:00"),
                    DataFim = DateTime.Parse("16/03/2023 16:00:00"),
                    QuantidadeVagas = 50,
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Requisitos = "Ensino médio completo",
                    DataInicioInscricao = DateTime.Parse("07/01/2023 00:01:00"),
                    DataFimInscricao = DateTime.Parse("09/01/2023 17:00:00"),
                    IdCapitania = 1
                },
                new Curso
                {
                    Id = 2,
                    Nome = "Curso Aquaviário - Pescador",
                    DataInicial = DateTime.Parse("05/12/2022 08:00:00"),
                    DataFim = DateTime.Parse("16/12/2022 16:00:00"),
                    QuantidadeVagas = 10,
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Requisitos = "Ensino fundamental completo",
                    DataInicioInscricao = DateTime.Parse("06/12/2022 00:01:00"),
                    DataFimInscricao = DateTime.Parse("09/12/2022 17:00:00"),
                    IdCapitania = 1
                },
                new Curso
                {
                    Id = 3,
                    Nome = "Curso Aquaviário - Marinheiro",
                    DataInicial = DateTime.Parse("05/12/2022 08:00:00"),
                    DataFim = DateTime.Parse("16/12/2022 16:00:00"),
                    QuantidadeVagas = 10,
                    Estado = "SE",
                    Cidade = "Aracaju",
                    Requisitos = "Ensino médio completo",
                    DataInicioInscricao = DateTime.Parse("06/12/2022 00:01:00"),
                    DataFimInscricao = DateTime.Parse("09/12/2022 17:00:00"),
                    IdCapitania = 1
                }
            };


            _context.AddRange(cursos);
            _context.SaveChanges();

            _cursoService = new CursoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _cursoService.Create(new Curso
            {
                Id = 4,
                Nome = "Curso de Aperfeiçoamento para Contramestre",
                DataInicial = DateTime.Parse("05/01/2023 08:00:00"),
                DataFim = DateTime.Parse("20/01/2023 16:00:00"),
                QuantidadeVagas = 5,
                Estado = "SE",
                Cidade = "Aracaju",
                Requisitos = "Ensino médio completo",
                DataInicioInscricao = DateTime.Parse("07/11/2022 00:01:00"),
                DataFimInscricao = DateTime.Parse("09/11/2022 17:00:00"),
                IdCapitania = 1
            });

            // Assert
            Assert.AreEqual(4, _cursoService.GetAll().Count());
            var curso = _cursoService.Get(4);
            Assert.AreEqual("Curso de Aperfeiçoamento para Contramestre", curso.Nome);
            Assert.AreEqual(DateTime.Parse("05/01/2023 08:00:00"), curso.DataInicial);
            Assert.AreEqual(DateTime.Parse("20/01/2023 16:00:00"), curso.DataFim);
            Assert.AreEqual(5, curso.QuantidadeVagas);
            Assert.AreEqual("SE", curso.Estado);
            Assert.AreEqual("Aracaju", curso.Cidade);
            Assert.AreEqual("Ensino médio completo", curso.Requisitos);
            Assert.AreEqual(DateTime.Parse("07/11/2022 00:01:00"), curso.DataInicioInscricao);
            Assert.AreEqual(1, curso.IdCapitania);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _cursoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _cursoService.GetAll().Count());
            var curso = _cursoService.Get(2);
            Assert.AreEqual(null, curso);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var curso = _cursoService.Get(3);
            curso.Nome = "Curso de Aperfeiçoamento para Contramestre";
            curso.DataFim = DateTime.Parse("20/01/2023 16:00:00");
            _cursoService.Edit(curso);

            //Assert
            curso = _cursoService.Get(3);
            Assert.IsNotNull(curso);
            Assert.AreEqual("Curso de Aperfeiçoamento para Contramestre", curso.Nome);
            Assert.AreEqual(DateTime.Parse("20/01/2023 16:00:00"), curso.DataFim);
        }

        [TestMethod()]
        public void GetTest()
        {
            // Act
            var curso = _cursoService.Get(1);
            // Assert
            Assert.IsNotNull(curso);
            Assert.AreEqual("Curso Aquaviário", curso.Nome);
            Assert.AreEqual(DateTime.Parse("05/03/2023 08:00:00"), curso.DataInicial);
            Assert.AreEqual(DateTime.Parse("16/03/2023 16:00:00"), curso.DataFim);
            Assert.AreEqual(50, curso.QuantidadeVagas);
            Assert.AreEqual("SE", curso.Estado);
            Assert.AreEqual("Aracaju", curso.Cidade);
            Assert.AreEqual("Ensino médio completo", curso.Requisitos);
            Assert.AreEqual(DateTime.Parse("07/01/2023 00:01:00"), curso.DataInicioInscricao);
            Assert.AreEqual(DateTime.Parse("09/01/2023 17:00:00"), curso.DataFimInscricao);
            Assert.AreEqual(1, curso.IdCapitania);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaCurso = _cursoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaCurso, typeof(IEnumerable<Curso>));
            Assert.IsNotNull(listaCurso);
            Assert.AreEqual(3, listaCurso.Count());
            Assert.AreEqual(1, listaCurso.First().Id);
            Assert.AreEqual("Curso Aquaviário", listaCurso.First().Nome);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var cursos = _cursoService.GetAll();
            //Assert
            Assert.IsNotNull(cursos);
            Assert.AreEqual(3, cursos.Count());
            Assert.AreEqual("Curso Aquaviário", cursos.First().Nome);
        }
    }
}
