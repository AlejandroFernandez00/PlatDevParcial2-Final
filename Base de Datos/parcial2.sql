-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-11-2020 a las 15:27:12
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `parcial2`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `serial`
--

CREATE TABLE `serial` (
  `serial_id` int(11) NOT NULL,
  `nombreserial` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `serial`
--

INSERT INTO `serial` (`serial_id`, `nombreserial`) VALUES
(1, 'ESo9uuca'),
(3, 'BBBB-BBBB-BBBB-BBAB'),
(4, 'thnNyCPN'),
(5, 'Rzq2yk2p'),
(6, 'FZ284RzQ'),
(7, 'ZQPHSEW3'),
(8, 'DVug8U7L'),
(9, 'QaP92Sw6'),
(10, 'G9enkVxg'),
(11, 'PhuaHrqm'),
(12, 'BWQFqi8i'),
(13, 'iCuXY5zP'),
(14, 'AAAA-AAAA-AAAA-AAAA'),
(15, 'zFSQHhey'),
(16, 'mzzTNkUy'),
(17, 'bP4WUkTy'),
(18, '2Z8JPBDb'),
(19, 'tqMxeprv');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `usuario_id` int(11) NOT NULL,
  `user` varchar(50) NOT NULL,
  `pass` varchar(355) NOT NULL,
  `serial_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`usuario_id`, `user`, `pass`, `serial_id`) VALUES
(42, 'admin', 'admin', 14);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `serial`
--
ALTER TABLE `serial`
  ADD PRIMARY KEY (`serial_id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`usuario_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `serial`
--
ALTER TABLE `serial`
  MODIFY `serial_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `usuario_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
