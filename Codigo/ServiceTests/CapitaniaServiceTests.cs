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
    public class CapitaniaServiceTests
    {
        private MaisMarinhaContext _context;
        private CapitaniaService _capitaniaService;
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
            var capitanias = new List<Capitania>
            {
                new Capitania 
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
                    HorarioInicio = DateTime.Parse("2023/03/03 00:00:00"),
                    HorarioFim = DateTime.Parse("2023/03/03 00:01:00")
                },
                
                new Capitania 
                {
                    Id = 2,
                    Nome = "Capitania dos Portos do Rio de Janeiro",
                    Estado = "RJ",
                    Cidade = "Rio de Janeiro",
                    Bairro = "Enseado do Suá",
                    Rua = "Rua Belmiro Rodrigues da Silva",
                    Numero = 145,
                    MetareaV = "Área CHARLIE",
                    Telefone = "(21) 2104-5319",
                    HorarioInicio = DateTime.Parse("2023/03/03 00:00:00"),
                    HorarioFim = DateTime.Parse("2023/03/03 00:01:00")
                },
                
                new Capitania 
                {
                    Id = 3,
                    Nome = "Capitania dos Portos de Minas Gerais",
                    Estado = "MG",
                    Cidade = "Belo Horizonte",
                    Bairro = "Jardim",
                    Rua = "Av. Raja Gabaglia",
                    Numero = 303,
                    MetareaV = "Área BRAVO",
                    Telefone = "(31) 3567-0769",
                    HorarioInicio = DateTime.Parse("2023/03/03 00:00:00"),
                    HorarioFim = DateTime.Parse("2023/03/03 00:01:00")
                }
            };

            _context.AddRange(capitanias);
            _context.SaveChanges();

            _capitaniaService = new CapitaniaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _capitaniaService.Create(new Capitania
            {
                Id = 4,
                Nome = "Capitania dos Portos da Bahia",
                Estado = "BA",
                Cidade = "Salvador",
                Bairro = "Conceicao",
                Rua = "Rua Av. das Naus",
                Numero = 400,
                MetareaV = "Área ALFA",
                Telefone = "(75) 3411-1646",
                HorarioInicio = DateTime.Parse("2023/03/03 00:00:00"),
                HorarioFim = DateTime.Parse("2023/03/04 00:01:00")
            });
            // Assert
            Assert.AreEqual(4, _capitaniaService.GetAll().Count());
            var capitania = _capitaniaService.Get(4);
            Assert.AreEqual("Capitania dos Portos da Bahia", capitania.Nome);
            Assert.AreEqual("BA", capitania.Estado);
            Assert.AreEqual("Salvador", capitania.Cidade);
            Assert.AreEqual("Conceicao", capitania.Bairro);
            Assert.AreEqual("Rua Av. das Naus", capitania.Rua);
            Assert.AreEqual(400, capitania.Numero);
            Assert.AreEqual("Área ALFA", capitania.MetareaV);
            Assert.AreEqual("(75) 3411-1646", capitania.Telefone);
            Assert.AreEqual(DateTime.Parse("2023/03/03 00:00:00"), capitania.HorarioInicio);
            Assert.AreEqual(DateTime.Parse("2023/03/04 00:01:00"), capitania.HorarioFim);

        }

        [TestMethod()]

        public void DeleteTest()
        {
            // Act
            _capitaniaService.Delete(2);
            // Assert
            Assert.AreEqual(2, _capitaniaService.GetAll().Count());
            var capitania = _capitaniaService.Get(2);
            Assert.AreEqual(null, capitania);

        }
        [TestMethod()]

        public void EditTest()
        {
            {
                //Act
                var capitania = _capitaniaService.Get(3);
                capitania.Nome = "Capitania dos Portos de Minas Gerais";
                capitania.Cidade = "Belo Horizonte";
                _capitaniaService.Edit(capitania);
                //Assert
                capitania = _capitaniaService.Get(3);
                Assert.IsNotNull(capitania);
                Assert.AreEqual("Capitania dos Portos de Minas Gerais", capitania.Nome);
                Assert.AreEqual("Belo Horizonte", capitania.Cidade);

            }

        }
        [TestMethod()]
        public void GetTest()

        {
            // Act
            var capitania = _capitaniaService.Get(1);

            //Assert
            Assert.AreEqual(3, _capitaniaService.GetAll().Count());
            Assert.AreEqual("Capitania dos Portos de Sergipe", capitania.Nome);
            Assert.AreEqual("SE", capitania.Estado);
            Assert.AreEqual("Aracaju", capitania.Cidade);
            Assert.AreEqual("São José", capitania.Bairro);
            Assert.AreEqual("Av. Ivo do Prado", capitania.Rua);
            Assert.AreEqual(752, capitania.Numero);
            Assert.AreEqual("Área FOXTROT", capitania.MetareaV);
            Assert.AreEqual("(79) 3711-1646", capitania.Telefone);
            Assert.AreEqual(DateTime.Parse("2023/03/03 00:00:00"), capitania.HorarioInicio);
            Assert.AreEqual(DateTime.Parse("2023/03/04 00:01:00"), capitania.HorarioFim);

        }
        public void GetAllTest()
        {
            // Act
            var listaCapitanias = _capitaniaService.GetAll();
            // Assert
            Assert.IsNotInstanceOfType(listaCapitanias, typeof(Capitania));
            Assert.IsNotNull(listaCapitanias);
            Assert.AreEqual(3, listaCapitanias.Count());
            Assert.AreEqual(1, listaCapitanias.First().Id);
            Assert.AreEqual("Capitania dos Portos de Minas Gerais", listaCapitanias.First().Nome);
        }

    }
}
