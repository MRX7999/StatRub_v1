-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jan 21, 2021 at 10:45 AM
-- Server version: 10.3.22-MariaDB-log
-- PHP Version: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `movedb`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories neede in departaments`
--

CREATE TABLE `categories neede in departaments` (
  `Categories needed in departments` int(11) NOT NULL,
  `Full name` varchar(20) DEFAULT NULL,
  `The Department` varchar(20) DEFAULT NULL,
  `vacant places` varchar(20) DEFAULT NULL,
  `Staff worked on the Progect Name` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `categories neede in departaments`
--

INSERT INTO `categories neede in departaments` (`Categories needed in departments`, `Full name`, `The Department`, `vacant places`, `Staff worked on the Progect Name`) VALUES
(1, 'Рубанов Андрей', 'Об. Без.', '45-78', 'Безопасность'),
(2, 'Петр Яндовский', 'Сет. Проект.', '12-89', 'Проектирование'),
(3, 'Зажилин Алексей', 'Подк. Кам.', '76-45', 'Подключение'),
(4, 'Кривец Иван', 'Об. Без.', '13-18', 'Безопасность');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `ID_Category` int(11) NOT NULL,
  `qualification name` varchar(20) DEFAULT NULL,
  `name of the second qualification` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`ID_Category`, `qualification name`, `name of the second qualification`) VALUES
(1, 'Об. Без.', '1'),
(2, 'Сет. Проект.', '3'),
(3, 'Инжен. Анал.', '3'),
(4, 'Сет. Анал.', '4');

-- --------------------------------------------------------

--
-- Table structure for table `contract`
--

CREATE TABLE `contract` (
  `Contract_ID` varchar(20) NOT NULL,
  `Project_ID execution` varchar(20) DEFAULT NULL,
  `Data` datetime DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `Contract` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `contract`
--

INSERT INTO `contract` (`Contract_ID`, `Project_ID execution`, `Data`, `Time`, `Contract`) VALUES
('1', 'Коструирование', '2020-04-09 00:00:00', '1899-12-30 10:02:00', '8-(999)-773-07-64'),
('2', 'Инженерный анализ', '2020-04-18 00:00:00', '1899-12-30 11:48:00', '8-(915)-823-07-64'),
('3', 'Проверка на ошибки', '2020-04-04 00:00:00', '1899-12-30 09:32:00', '8-(999)-145-07-64'),
('4', 'Строительство', '2020-04-11 00:00:00', '1899-12-30 12:49:00', '8-(915)-905-07-64'),
('5', 'Инженерный анализ', '2020-04-25 00:00:00', '1899-12-30 14:09:00', '8-(905)-740-07-64'),
('6', 'Разработка проектной', '2020-04-11 00:00:00', '1899-12-30 16:22:00', '8-(906)-345-07-64'),
('7', 'Проверка на ошибки', '2020-04-01 00:00:00', '1899-12-30 17:45:00', '8-(905)-167-07-64'),
('8', 'Констрирование', '2020-04-20 00:00:00', '1899-12-30 19:21:00', '8-(999)-216-07-64');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `Customer_ID` varchar(20) NOT NULL,
  `Customers` varchar(20) DEFAULT NULL,
  `Customer phone number` varchar(255) DEFAULT NULL,
  `Passport data` varchar(255) DEFAULT NULL,
  `ID_Category` varchar(255) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`Customer_ID`, `Customers`, `Customer phone number`, `Passport data`, `ID_Category`) VALUES
('1', 'Яндовский Данил', '8-(905)-740-07-64', '4516 823-17-64', '45-98'),
('2', 'Яндовский Алексей', '8-(915)-905-07-64', '4516 412-67-89', '45-91'),
('3', 'Ключник Михаил', '8-(915)-823-07-64', '4516 123-22-78', '67-87'),
('4', 'Петр Разумихин', '8-(999)-216-07-64', '4516 789-17-78', '12-78');

-- --------------------------------------------------------

--
-- Table structure for table `equipment list`
--

CREATE TABLE `equipment list` (
  `Worklist List ID` varchar(20) NOT NULL,
  `Name of equipment` varchar(20) DEFAULT NULL,
  `Project_ID execution` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `equipment list`
--

INSERT INTO `equipment list` (`Worklist List ID`, `Name of equipment`, `Project_ID execution`) VALUES
('1', 'Дально мер', '65-98'),
('2', 'Транфарет', '13-64'),
('3', 'Сервер бработки', '56-12'),
('4', 'Переносной компьютер', '12-34');

-- --------------------------------------------------------

--
-- Table structure for table `list of departments`
--

CREATE TABLE `list of departments` (
  `The Department` varchar(18) DEFAULT NULL,
  `Department List ID` varchar(20) NOT NULL,
  `The list of employees in the departments` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `list of departments`
--

INSERT INTO `list of departments` (`The Department`, `Department List ID`, `The list of employees in the departments`) VALUES
('Структурирования', '1024-987', 'Структурирование'),
('Разработки', '123-789', 'Разработка'),
('Инженерного анализ', '321-879', 'Инженерный Анализ'),
('Проектирования', '678-456', 'Проектирование'),
('Маркетинговый', '987-765', 'Маркетинг'),
('555', '55', '55');

-- --------------------------------------------------------

--
-- Table structure for table `ongoing projects and their implementation`
--

CREATE TABLE `ongoing projects and their implementation` (
  `ID_List of services now available` varchar(20) NOT NULL,
  `Cost` decimal(19,4) DEFAULT 0.0000,
  `Contract_ID` varchar(255) DEFAULT NULL,
  `ID_Category` varchar(255) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ongoing projects and their implementation`
--

INSERT INTO `ongoing projects and their implementation` (`ID_List of services now available`, `Cost`, `Contract_ID`, `ID_Category`) VALUES
('1024-456', '218643.0000', '№327', 'Разработка'),
('123-876', '83447.0000', '№654', 'Проектирование'),
('456-871', '102047.0000', '№9487', 'Структурирование'),
('789-987', '83747.0000', '№1034', 'Разработка');

-- --------------------------------------------------------

--
-- Table structure for table `project implementation`
--

CREATE TABLE `project implementation` (
  `Project_ID` varchar(20) NOT NULL,
  `Equipment list` varchar(20) DEFAULT NULL,
  `Services` varchar(255) DEFAULT NULL,
  `Data` datetime DEFAULT NULL,
  `Time` datetime DEFAULT NULL,
  `Cabinets` varchar(20) DEFAULT NULL,
  `Customer` varchar(20) DEFAULT NULL,
  `Project Manager` varchar(20) DEFAULT NULL,
  `Customer_ID` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `project implementation`
--

INSERT INTO `project implementation` (`Project_ID`, `Equipment list`, `Services`, `Data`, `Time`, `Cabinets`, `Customer`, `Project Manager`, `Customer_ID`) VALUES
('123-912', '12', 'Проектирование', '2020-05-13 00:00:00', '1899-12-30 15:45:00', '551', 'ИП \"Кузнецоы\"', 'Сефутушкин К.М', '17-98'),
('138-731', '31', 'Разработка', '2020-04-19 00:00:00', '1899-12-30 16:12:00', '123', 'Притворов Олег', 'Кривец П.Т', '12-83'),
('291-834', '45', 'Анализ', '2020-04-01 00:00:00', '1899-12-30 17:12:00', '654', 'ИП \"Кирилов\"', 'Анальгинов А.Е', '65-45'),
('863-876', '53', 'Постройка', '2020-04-15 00:00:00', '1899-12-30 12:11:00', '245', 'ООО \"Куплиновские\"', 'Сергеева Т.П.', '74-18'),
('55-67', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '76');

-- --------------------------------------------------------

--
-- Table structure for table `project status`
--

CREATE TABLE `project status` (
  `Projects Analysis` varchar(255) DEFAULT NULL,
  `Project_ID execution` varchar(20) NOT NULL,
  `Name` varchar(20) DEFAULT NULL,
  `Description` varchar(20) DEFAULT NULL,
  `Project Name` varchar(20) DEFAULT NULL,
  `Name of service` varchar(20) DEFAULT NULL,
  `Service Amount` decimal(19,4) DEFAULT NULL,
  `Employees slave to the project` varchar(20) DEFAULT NULL,
  `Department List ID` varchar(20) DEFAULT NULL,
  `Project_ID` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `project status`
--

INSERT INTO `project status` (`Projects Analysis`, `Project_ID execution`, `Name`, `Description`, `Project Name`, `Name of service`, `Service Amount`, `Employees slave to the project`, `Department List ID`, `Project_ID`) VALUES
('№671', '1567', 'Разработка П.Д.', 'ул. Петрушкина д. 78', 'ОАО \"Камушкино\"', 'Камушкина Р.П.Д', '9876543.0000', '123', '671-234', '6%'),
('№321', '341', 'Разарботка Проектной', 'П.Д. Дома ул. Мед. 4', '\"Куплинсвкие\"', 'ООО \"Куплиновские\"', '1002341.0000', '12', '456-098', '45%'),
('№781', '6781', 'Анализ Постройки', 'ул. Бирюл. Д. 44', 'ИП \"Кузнецов\"', 'ИП \"Кузнецов\"', '2456789.0000', '56', '987-891', '78%'),
('№341', '9871', 'Структуризация Постр', 'ул. Кирова д 23', 'Структ Д. 56', 'ООО \"Кириловские\"', '1983134.0000', '19', '915-371', '12%');

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `ID_NAME` varchar(20) NOT NULL,
  `Passport data` varchar(255) DEFAULT NULL,
  `Employee Phone Numbers` varchar(255) DEFAULT NULL,
  `Staff` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`ID_NAME`, `Passport data`, `Employee Phone Numbers`, `Staff`) VALUES
('Кирилов И.Л', '4516 789-967', '8-(905)-740-07-64', '12-89'),
('Марселинов Т.Д.', '4516 344-818', '8-(999)-145-07-64', '75-81'),
('Рудакпов К.П', '4516 139-831', '8-(906)-345-07-64', '98-19'),
('Хурялов З.Л', '4516 781-918', '8-(905)-167-07-64', '38-98');

-- --------------------------------------------------------

--
-- Table structure for table `subcontracting organizations`
--

CREATE TABLE `subcontracting organizations` (
  `Contract` varchar(20) NOT NULL,
  `Name organization` varchar(20) DEFAULT NULL,
  `Sub org contract` varchar(20) DEFAULT NULL,
  `Cost` decimal(19,4) DEFAULT 0.0000,
  `Time of ending` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `subcontracting organizations`
--

INSERT INTO `subcontracting organizations` (`Contract`, `Name organization`, `Sub org contract`, `Cost`, `Time of ending`) VALUES
('№456', 'ООО \"Кириловские\"', 'ГУП \"Мос Гор строй\"', '6781873.0000', '2020-06-18 00:00:00'),
('№981', 'ОАО \"Землянкино\"', 'ГУП \"Мос Гор строй\"', '8765920.0000', '2020-04-11 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `sub in a row`
--

CREATE TABLE `sub in a row` (
  `Sub_ID` varchar(20) NOT NULL,
  `Project_ID execution` varchar(20) DEFAULT NULL,
  `Subcontract hire cost` varchar(20) DEFAULT NULL,
  `Projects on which suborder works` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sub in a row`
--

INSERT INTO `sub in a row` (`Sub_ID`, `Project_ID execution`, `Subcontract hire cost`, `Projects on which suborder works`) VALUES
('1831', 'ОАО \"Землянкино\"', '№9871', '14%'),
('6451', 'ГУП \"Мос Проект\"', '№9813', '6%'),
('8713', 'ИП \"Яндовский\"', '№8711', '12%'),
('8761', 'ООО \"Мос строй\"', '№1311', '45%');

-- --------------------------------------------------------

--
-- Table structure for table `switchboard items`
--

CREATE TABLE `switchboard items` (
  `SwitchboardID` int(11) NOT NULL,
  `ItemNumber` int(11) NOT NULL DEFAULT 0,
  `ItemText` varchar(255) DEFAULT NULL,
  `Command` int(11) DEFAULT NULL,
  `Argument` varchar(255) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `switchboard items`
--

INSERT INTO `switchboard items` (`SwitchboardID`, `ItemNumber`, `ItemText`, `Command`, `Argument`) VALUES
(1, 0, 'Главная кнопочная форма', NULL, 'По умолчанию'),
(1, 1, 'Категории', 1, '2'),
(1, 2, 'Контакты', 1, '5'),
(1, 3, 'Сотрудники', 1, '4'),
(1, 4, 'Улуги', 1, '3'),
(1, 5, 'Елестратова сука', 1, '6'),
(2, 0, 'Категории', 0, NULL),
(2, 1, 'Categoris needs in deportamet', 7, 'Categories NID'),
(2, 2, 'Category', 7, 'Category'),
(2, 3, 'Contact', 7, 'Contact'),
(2, 4, 'Customers', 7, 'Customers'),
(2, 5, 'Возврат', 1, '1'),
(3, 0, 'Услуги', 0, NULL),
(3, 1, 'Ongoing Projects ...', 7, 'O P J'),
(3, 2, 'Project implementation', 7, 'PI'),
(3, 3, 'Project Status', 7, 'PS'),
(3, 4, 'Sub organization...', 7, 'Sub Org'),
(3, 5, 'Switch', 7, 'Switch'),
(3, 6, 'The Deportament', 7, 'The D'),
(3, 7, 'Type of Equp...', 7, 'Type'),
(3, 8, 'Возврат', 1, '1'),
(4, 0, 'Сотрудники', 0, NULL),
(4, 1, 'Suff', 7, 'Staff'),
(4, 2, 'Contact', 7, 'Contact'),
(4, 3, 'Возврат', 1, '1'),
(5, 0, 'Контракты', 0, NULL),
(5, 1, 'Equmpent List', 7, 'Equipment List'),
(5, 2, 'List of Deprtametns', 7, 'List of D'),
(5, 3, 'Stuff', 7, 'Staff'),
(5, 4, 'Sub in a Row', 7, 'Sub'),
(5, 5, 'Возврат', 1, '1'),
(6, 0, 'Host', 0, NULL),
(6, 1, 'HUY', 7, '888'),
(6, 2, 'Возврат', 1, '1');

-- --------------------------------------------------------

--
-- Table structure for table `the department`
--

CREATE TABLE `the department` (
  `Department List ID` varchar(20) DEFAULT NULL,
  `Departments` varchar(20) NOT NULL,
  `Staff` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `the department`
--

INSERT INTO `the department` (`Department List ID`, `Departments`, `Staff`) VALUES
('4', '134-556', 'Структурирование'),
('3', '134-765', 'Индексировние'),
('1', '871-891', 'Анализ'),
('2', '991-1023', 'Структуризация');

-- --------------------------------------------------------

--
-- Table structure for table `type of equipment`
--

CREATE TABLE `type of equipment` (
  `ID_Type of equipment` varchar(20) NOT NULL,
  `List_ID` varchar(20) DEFAULT NULL,
  `Not working equipment` varchar(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `type of equipment`
--

INSERT INTO `type of equipment` (`ID_Type of equipment`, `List_ID`, `Not working equipment`) VALUES
('162-1627', '84-81', '-'),
('657-8173', '71-56', '-'),
('731-7471', '17-81', '-'),
('738-7261', '73-18', '-');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(65) CHARACTER SET utf8mb4 NOT NULL,
  `password` varchar(65) CHARACTER SET utf8mb4 NOT NULL,
  `permission` varchar(65) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `permission`) VALUES
(1, 'admin', 'admin', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories neede in departaments`
--
ALTER TABLE `categories neede in departaments`
  ADD PRIMARY KEY (`Categories needed in departments`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`ID_Category`);

--
-- Indexes for table `contract`
--
ALTER TABLE `contract`
  ADD PRIMARY KEY (`Contract_ID`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`Customer_ID`);

--
-- Indexes for table `equipment list`
--
ALTER TABLE `equipment list`
  ADD PRIMARY KEY (`Worklist List ID`);

--
-- Indexes for table `list of departments`
--
ALTER TABLE `list of departments`
  ADD PRIMARY KEY (`Department List ID`);

--
-- Indexes for table `ongoing projects and their implementation`
--
ALTER TABLE `ongoing projects and their implementation`
  ADD PRIMARY KEY (`ID_List of services now available`);

--
-- Indexes for table `project implementation`
--
ALTER TABLE `project implementation`
  ADD PRIMARY KEY (`Project_ID`);

--
-- Indexes for table `project status`
--
ALTER TABLE `project status`
  ADD PRIMARY KEY (`Project_ID execution`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`ID_NAME`);

--
-- Indexes for table `subcontracting organizations`
--
ALTER TABLE `subcontracting organizations`
  ADD PRIMARY KEY (`Contract`);

--
-- Indexes for table `sub in a row`
--
ALTER TABLE `sub in a row`
  ADD PRIMARY KEY (`Sub_ID`);

--
-- Indexes for table `switchboard items`
--
ALTER TABLE `switchboard items`
  ADD PRIMARY KEY (`SwitchboardID`,`ItemNumber`);

--
-- Indexes for table `the department`
--
ALTER TABLE `the department`
  ADD PRIMARY KEY (`Departments`);

--
-- Indexes for table `type of equipment`
--
ALTER TABLE `type of equipment`
  ADD PRIMARY KEY (`ID_Type of equipment`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
