-- MySQL dump 10.13  Distrib 5.7.39, for Win64 (x86_64)
--
-- Host: localhost    Database: maismarinha
-- ------------------------------------------------------
-- Server version	5.7.39-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agendamento` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TipoAtendimento` enum('Solicitado','Confirmado','Atendido','Cancelado') NOT NULL DEFAULT 'Solicitado',
  `Data` date NOT NULL,
  `Hora` datetime NOT NULL,
  `IdPessoa` int(11) NOT NULL,
  `IdServico` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Atendimento_Pessoa1_idx` (`IdPessoa`),
  KEY `IDX_TipoAtendimento` (`TipoAtendimento`),
  KEY `fk_Agendamento_Servico1_idx` (`IdServico`),
  CONSTRAINT `fk_Atendimento_Pessoa1` FOREIGN KEY (`IdPessoa`) REFERENCES `pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendamento`
--

LOCK TABLES `agendamento` WRITE;
/*!40000 ALTER TABLE `agendamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `agendamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agendaservico`
--

DROP TABLE IF EXISTS `agendaservico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agendaservico` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DiaSemana` datetime NOT NULL,
  `HoraInicio` datetime NOT NULL,
  `HoraFim` datetime NOT NULL,
  `Vagas` int(11) NOT NULL,
  `IdServico` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_AgendaServico_Servico1_idx` (`IdServico`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendaservico`
--

LOCK TABLES `agendaservico` WRITE;
/*!40000 ALTER TABLE `agendaservico` DISABLE KEYS */;
/*!40000 ALTER TABLE `agendaservico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(767) NOT NULL,
  `RoleId` varchar(767) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('adaabb2e-9032-4edd-b0f8-e3cd06dc8657','carloshldj@gmail.com','CARLOSHLDJ@GMAIL.COM','carloshldj@gmail.com','CARLOSHLDJ@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEMhHLR84CWf/bFVrd1nYfxz9DRxGhs9zA6AuxdUcbsKyoYVmo2W3cFgak1576UPxGQ==','DX73ASS2MBGCTT4V4PIWQXEJ6EZIPBKR','69645e54-fb23-49f9-b6e0-c899e657745c',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(767) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `capitania`
--

DROP TABLE IF EXISTS `capitania`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `capitania` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Estado` varchar(2) NOT NULL,
  `Cidade` varchar(50) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `Numero` int(11) NOT NULL,
  `MetareaV` varchar(100) NOT NULL,
  `Telefone` varchar(20) NOT NULL,
  `HorarioInicio` datetime NOT NULL,
  `HorarioFim` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IDX_Nome` (`Nome`),
  KEY `IDX_Estado` (`Estado`),
  KEY `IDX_Cidade` (`Cidade`),
  KEY `IDX_MetareaV` (`MetareaV`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `capitania`
--

LOCK TABLES `capitania` WRITE;
/*!40000 ALTER TABLE `capitania` DISABLE KEYS */;
INSERT INTO `capitania` VALUES (1,'Aracaju','SE','Itabaiana','Centro','Maraba',31,'Charlie','79998928252','2022-11-21 00:00:00','2022-11-21 00:00:00');
/*!40000 ALTER TABLE `capitania` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `capitaniaconcurso`
--

DROP TABLE IF EXISTS `capitaniaconcurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `capitaniaconcurso` (
  `IdCapitania` int(11) NOT NULL,
  `IdConcurso` int(11) NOT NULL,
  PRIMARY KEY (`IdCapitania`,`IdConcurso`),
  KEY `fk_Capitania_has_Concurso_Concurso1_idx` (`IdConcurso`),
  KEY `fk_Capitania_has_Concurso_Capitania1_idx` (`IdCapitania`),
  CONSTRAINT `fk_Capitania_has_Concurso_Capitania1` FOREIGN KEY (`IdCapitania`) REFERENCES `capitania` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Capitania_has_Concurso_Concurso1` FOREIGN KEY (`IdConcurso`) REFERENCES `concurso` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `capitaniaconcurso`
--

LOCK TABLES `capitaniaconcurso` WRITE;
/*!40000 ALTER TABLE `capitaniaconcurso` DISABLE KEYS */;
/*!40000 ALTER TABLE `capitaniaconcurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clima`
--

DROP TABLE IF EXISTS `clima`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clima` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MetareaV` varchar(100) NOT NULL,
  `AlertaMar` varchar(200) NOT NULL,
  `AlertaVento` varchar(200) NOT NULL,
  `DescricaoAlertaMar` varchar(500) NOT NULL,
  `DescricaoAlertaVento` varchar(500) NOT NULL,
  `Coordenadas` varchar(100) NOT NULL,
  `HoraEmissao` datetime NOT NULL,
  `Validade` datetime NOT NULL,
  `IdCapitania` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_clima_capitania1_idx` (`IdCapitania`),
  KEY `IDX_MetareaV` (`MetareaV`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clima`
--

LOCK TABLES `clima` WRITE;
/*!40000 ALTER TABLE `clima` DISABLE KEYS */;
/*!40000 ALTER TABLE `clima` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `concurso`
--

DROP TABLE IF EXISTS `concurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `concurso` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Edital` int(11) NOT NULL,
  `DataInicialInscricao` date NOT NULL,
  `DataFinalInscricao` date NOT NULL,
  `DataProva` date NOT NULL,
  `Estado` varchar(2) NOT NULL,
  `Cidade` varchar(50) NOT NULL,
  `Vagas` int(11) NOT NULL,
  `Escolaridade` varchar(50) NOT NULL,
  `Etapas` varchar(50) NOT NULL,
  `AreaTecnica` varchar(50) NOT NULL,
  `LocalInscricao` varchar(100) DEFAULT NULL,
  `ValorInscricao` float NOT NULL DEFAULT '0',
  `LocalProva` varchar(100) NOT NULL,
  `Cargo` varchar(60) NOT NULL,
  `Turma` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IDX_Nome` (`Nome`),
  KEY `IDX_Estado` (`Estado`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `concurso`
--

LOCK TABLES `concurso` WRITE;
/*!40000 ALTER TABLE `concurso` DISABLE KEYS */;
INSERT INTO `concurso` VALUES (1,'Marinheiro',1,'2022-11-03','2022-12-01','2022-12-30','SE','Itabaiana',100,'Ensino Médio Completo','2','Marinheiro','Itabaiana',5000,'Aracaju','Gerencia','1'),(2,'teste',1,'2022-12-13','2022-12-28','2023-01-13','SE','ITABAIANA',50,'Ensino Médio Completo','2','Marinheiro','Itabaiana',5000,'Aracaju','Marinheiro','1'),(3,'Marinheiro - Chefe',1,'2023-01-20','2023-04-20','2023-06-20','SE','Aracaju',40,'Superior','1','N','Escola DR. Jr. Segundo',100,'Aracaju','Marinheiro','1');
/*!40000 ALTER TABLE `concurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `curso`
--

DROP TABLE IF EXISTS `curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `curso` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `DataInicial` date NOT NULL,
  `DataFim` date NOT NULL,
  `QuantidadeVagas` int(11) NOT NULL,
  `Estado` varchar(2) NOT NULL,
  `Cidade` varchar(50) NOT NULL,
  `Requisitos` varchar(200) NOT NULL,
  `DataInicioInscricao` date NOT NULL,
  `DataFimInscricao` date NOT NULL,
  `Duracao` varchar(150) NOT NULL,
  `IdCapitania` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Curso_Capitania1_idx` (`IdCapitania`),
  KEY `IDX_Nome` (`Nome`),
  KEY `IDX_Estado` (`Estado`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curso`
--

LOCK TABLES `curso` WRITE;
/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
INSERT INTO `curso` VALUES (1,'Carlos','2022-09-01','2022-09-15',50,'SE','Itabaiana','Ensino Médio Completo','2022-08-01','2022-08-15','15 Dias',1),(2,'Charles','2022-09-01','2022-09-15',50,'SE','Itabaiana','Ensino Médio Completo','2022-08-03','2022-08-10','15 Dias',1);
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inscricaoconcurso`
--

DROP TABLE IF EXISTS `inscricaoconcurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inscricaoconcurso` (
  `IdConcurso` int(11) NOT NULL,
  `IdPessoa` int(11) NOT NULL,
  `Status` enum('Solicitada','Confirmada','Indeferida','Cancelada') NOT NULL DEFAULT 'Solicitada',
  `DataInscricao` date NOT NULL,
  PRIMARY KEY (`IdConcurso`,`IdPessoa`),
  KEY `fk_Concurso_has_Pessoa_Pessoa1_idx` (`IdPessoa`),
  KEY `fk_Concurso_has_Pessoa_Concurso1_idx` (`IdConcurso`),
  CONSTRAINT `fk_Concurso_has_Pessoa_Concurso1` FOREIGN KEY (`IdConcurso`) REFERENCES `concurso` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Concurso_has_Pessoa_Pessoa1` FOREIGN KEY (`IdPessoa`) REFERENCES `pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inscricaoconcurso`
--

LOCK TABLES `inscricaoconcurso` WRITE;
/*!40000 ALTER TABLE `inscricaoconcurso` DISABLE KEYS */;
/*!40000 ALTER TABLE `inscricaoconcurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inscricaocurso`
--

DROP TABLE IF EXISTS `inscricaocurso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inscricaocurso` (
  `IdPessoa` int(11) NOT NULL,
  `IdCurso` int(11) NOT NULL,
  `Status` enum('Solicitada','Confirmada','Indeferida','Cancelada') NOT NULL DEFAULT 'Solicitada',
  `DataInscricao` date NOT NULL,
  PRIMARY KEY (`IdPessoa`,`IdCurso`),
  KEY `fk_Pessoa_has_Curso_Curso1_idx` (`IdCurso`),
  KEY `fk_Pessoa_has_Curso_Pessoa1_idx` (`IdPessoa`),
  CONSTRAINT `fk_Pessoa_has_Curso_Curso1` FOREIGN KEY (`IdCurso`) REFERENCES `curso` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pessoa_has_Curso_Pessoa1` FOREIGN KEY (`IdPessoa`) REFERENCES `pessoa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inscricaocurso`
--

LOCK TABLES `inscricaocurso` WRITE;
/*!40000 ALTER TABLE `inscricaocurso` DISABLE KEYS */;
/*!40000 ALTER TABLE `inscricaocurso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pessoa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Cpf` varchar(11) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Estado` varchar(2) NOT NULL,
  `Cidade` varchar(50) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Rua` varchar(50) NOT NULL,
  `NumeroEndereco` varchar(15) NOT NULL,
  `CEP` varchar(9) NOT NULL,
  `Complemento` varchar(100) DEFAULT NULL,
  `Telefone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Cpf_UNIQUE` (`Cpf`),
  KEY `IDX_Nome` (`Nome`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'Carlos','07188812322','carloshldj@gmail.com','SE','Itabaiana','Centro','Rua UFS','12','49501000','Casa','79998928252'),(2,'Charles','08811293212','charlesdayan@gmail.com','SE','Aracaju','Industrial','Rua F','11','49501000',NULL,NULL);
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servico`
--

DROP TABLE IF EXISTS `servico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `servico` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Descricao` varchar(150) NOT NULL,
  `IdCapitania` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Servico_Capitania1_idx` (`IdCapitania`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servico`
--

LOCK TABLES `servico` WRITE;
/*!40000 ALTER TABLE `servico` DISABLE KEYS */;
/*!40000 ALTER TABLE `servico` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-23 23:02:11
