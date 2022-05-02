-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 02-Maio-2022 às 07:28
-- Versão do servidor: 10.4.21-MariaDB
-- versão do PHP: 8.0.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `cda`
--
CREATE DATABASE IF NOT EXISTS `cda` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `cda`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `criminalcode`
--

CREATE TABLE `criminalcode` (
  `Id_CriminalCode` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `Penalty` decimal(10,0) NOT NULL,
  `PrisonTime` int(11) NOT NULL,
  `StatusID` int(11) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `CreateUserID` int(11) NOT NULL,
  `UpdateUserID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `criminalcode`
--

INSERT INTO `criminalcode` (`Id_CriminalCode`, `Name`, `Description`, `Penalty`, `PrisonTime`, `StatusID`, `CreateDate`, `UpdateDate`, `CreateUserID`, `UpdateUserID`) VALUES
(1, 'Infração Transito', 'Ultrapassar o sinal vermelho', '1', 20, 1, '2022-05-02 05:18:41', NULL, 1, NULL),
(2, 'Tentativa de Homicidio', 'Tentativa de Homicidio', '1', 20, 1, '2022-05-02 05:18:41', NULL, 1, NULL),
(3, 'Charlatanismo', '', '1', 20, 1, '2022-05-02 05:18:41', NULL, 1, NULL),
(4, 'Incitação ao crime', '', '1', 20, 1, '2022-05-02 05:18:41', NULL, 1, NULL),
(5, 'Falsificação de documento particular', '', '1', 20, 1, '2022-05-02 05:18:41', NULL, 1, NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `status`
--

CREATE TABLE `status` (
  `Id_Status` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `status`
--

INSERT INTO `status` (`Id_Status`, `Name`) VALUES
(1, 'Ativo'),
(2, 'Inativo');

-- --------------------------------------------------------

--
-- Estrutura da tabela `user`
--

CREATE TABLE `user` (
  `Id_User` int(11) NOT NULL,
  `UserName` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `user`
--

INSERT INTO `user` (`Id_User`, `UserName`, `Password`) VALUES
(1, 'cda', 'cda');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `criminalcode`
--
ALTER TABLE `criminalcode`
  ADD PRIMARY KEY (`Id_CriminalCode`),
  ADD KEY `CriminalCode_fk0` (`StatusID`),
  ADD KEY `CriminalCode_fk1` (`CreateUserID`),
  ADD KEY `CriminalCode_fk2` (`UpdateUserID`);

--
-- Índices para tabela `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`Id_Status`);

--
-- Índices para tabela `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id_User`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `criminalcode`
--
ALTER TABLE `criminalcode`
  MODIFY `Id_CriminalCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `status`
--
ALTER TABLE `status`
  MODIFY `Id_Status` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `user`
--
ALTER TABLE `user`
  MODIFY `Id_User` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `criminalcode`
--
ALTER TABLE `criminalcode`
  ADD CONSTRAINT `CriminalCode_fk0` FOREIGN KEY (`StatusID`) REFERENCES `status` (`Id_Status`),
  ADD CONSTRAINT `CriminalCode_fk1` FOREIGN KEY (`CreateUserID`) REFERENCES `user` (`Id_User`),
  ADD CONSTRAINT `CriminalCode_fk2` FOREIGN KEY (`UpdateUserID`) REFERENCES `user` (`Id_User`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
