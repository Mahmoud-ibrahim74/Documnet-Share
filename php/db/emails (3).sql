-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 04, 2023 at 02:06 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `emails`
--

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `username` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `type` int(11) NOT NULL,
  `IP_Address` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`username`, `password`, `type`, `IP_Address`) VALUES
('1', '1', 3, ''),
('2', '2', 1, ''),
('admin', 'admin', 3, ''),
('عقيد ضياء', '123', 1, ''),
('عقيد محمد', '123', 2, ''),
('قسم الأرشيف', '123', 4, ''),
('قسم التخطيط', '123', 3, ''),
('قسم التنقلات', '123', 3, ''),
('قسم الملفات', '123', 3, '');

-- --------------------------------------------------------

--
-- Table structure for table `mails`
--

CREATE TABLE `mails` (
  `id` int(11) NOT NULL,
  `mail_title` text NOT NULL,
  `user_type` int(11) NOT NULL,
  `username` varchar(256) NOT NULL,
  `date_mail` datetime NOT NULL,
  `isSigned` tinyint(1) NOT NULL,
  `UserSigned` varchar(20) NOT NULL,
  `file_name` text NOT NULL,
  `seen_msg` int(11) NOT NULL,
  `ArchiveSent` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `mails`
--

INSERT INTO `mails` (`id`, `mail_title`, `user_type`, `username`, `date_mail`, `isSigned`, `UserSigned`, `file_name`, `seen_msg`, `ArchiveSent`) VALUES
(96, 'إيماء لكتاب إدارة  المدرعات (فرع شئون الضباط) رقم (1241/3) ', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', 'eb63a753-8cb3-46bc-b428-63f072b92bb3.doc', 1, 1),
(101, 'إيماء لكتاب إدارة  المدرعات\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'a6dead41-4b92-4507-876f-d5a255ff8ca2.doc', 1, 0),
(102, 'إيماء لكتاب ادارة شئون ضباط ق.م\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '7e84d24d-46c2-44c7-8391-073b9089bdf1.doc', 0, 0),
(103, 'إيماءًًًًًً لكتاب إدارة النقل \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'f104f7fd-d49c-4156-a3c0-eacca4a561b8.doc', 0, 0),
(104, '   ايماء لكتاب ادارة الخدمات الطبية  \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '238931cf-48e0-4ac3-838c-f5784924d5cd.doc', 0, 0),
(105, 'إيماء لكتاب إدارة النقل \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '7cebce79-4cdc-44ae-9ebf-669162d4807a.doc', 0, 0),
(106, 'ايماء لكتاب ادارة الخدمات الطبية  \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'cf697416-076c-4d52-874d-cde694737842.doc', 0, 0),
(107, 'إيماء لكتاب إدارة شئون الضباط ق.م\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'c5dd1dd3-99e8-4bc9-9f8c-63da4d3cb7e2.doc', 0, 0),
(108, 'إلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'b93ff20f-291d-45eb-bc03-eb3251a7e769.doc', 0, 0),
(109, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)       \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '29dedf3f-eea2-4a2c-bbc2-4c75073759a1.doc', 0, 0),
(110, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'f84c13f7-bf56-40e7-bfef-9ccaec7bf201.doc', 0, 0),
(111, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '4d12b961-5d68-4c59-8fba-f91322a5b5d4.doc', 0, 0),
(112, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '578395cb-b5b6-46a5-a45d-9fd4bcccc32c.doc', 0, 0),
(113, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  إدارة لوقود (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '437c7395-6ccb-4fd8-8dbd-b8d02d4025ab.doc', 0, 0),
(114, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  ادارة النقل  (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'f310f2fc-d09a-4ec6-b40b-4d52cc28a9b5.doc', 0, 0),
(115, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  إدارة التعيينات  (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '954103c6-6e60-470a-9f1b-710437d937fc.doc', 0, 0),
(116, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  إدارةالوقود (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'c1b033a5-5e40-45e6-95ed-e0e5722debe5.doc', 0, 0),
(117, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  إدارة التعيينات  (فرع شئون ضباط)\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '542a53a5-e8dd-458e-90cb-3e97980342dd.doc', 0, 0),
(118, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  إدارة التعيينات  (فرع شئون ضباط) \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'e81b7079-39ca-47ab-b2c6-0449d25cc033.doc', 0, 0),
(119, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإلـــى /  إدارة التعيينات  (فرع شئون ضباط)  \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '6ff4a8de-83fe-484e-b4c6-8c1166fcd38c.doc', 0, 0),
(120, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nإحصائي العقــوبــات الانضباطية البسيطة \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '3368e969-52fc-4ecf-b301-0c42a6b1d1f4.doc', 0, 0),
(121, 'إلـــى /  إدارة الوقود (فرع شئون ضباط)        \r\nإلـــى /  إدارة الوقود  (فرع شئون ضباط)        \r\n\r\nالإلتزامات التدريبية \r\nلتشكيلات ووحدات الجيش الثانى الميدانى \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'c54a80f0-fcc2-4a39-af9b-ac21ccdbd0d9.doc', 0, 0),
(122, 'كشـف لجنة الوظائف القيادية نشرة يوليو 2023م\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '7c6e8ec0-3890-480f-87e7-75c2d8650dba.doc', 0, 0),
(123, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط) \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'dcc5462b-a8ed-4778-b9a2-181c373e93f3.doc', 0, 0),
(124, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'afcf87e3-cc07-457c-b467-1d87e497b812.doc', 0, 0),
(125, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط)       \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'e42263b3-d53d-43ef-921d-e31c0f770aed.doc', 0, 0),
(126, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)        \r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '226647d8-2da4-4f36-b9dd-30cefd9978c4.doc', 0, 0),
(127, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط)        \r\n\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '58b29ce5-a505-4c46-b3ae-599e231c2849.doc', 0, 0),
(128, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)        \r\n\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', 'ff6795f5-f39e-4070-97dd-c2f7e49b25cd.doc', 0, 0),
(129, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط ج2 ميد)\r\n\r\n', 3, 'قسم التخطيط', '2023-05-01 17:19:08', 0, '', '5aca05b2-78de-4b1f-b1c9-5fe712d7c435.doc', 0, 0),
(131, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط) \r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', '116557eb-ff0e-402a-a242-9fb93b34655f.doc', 1, 1),
(134, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط)ج2\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', 'be538077-9f79-444c-9c94-64cb62282b65.doc', 1, 1),
(135, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط)..\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', '5dc72def-aa46-4b2d-b9f5-5d3fc2b1a7b0.doc', 1, 1),
(136, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط)  ...\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', 'e2100cbe-0520-4a04-883b-c0e5e21a7db2.doc', 1, 1),
(137, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط)  1\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', 'ba57aa02-e81f-45b9-bb55-ed5ed96360b8.doc', 1, 1),
(138, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط) 3\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', '0dfc53a8-9c30-4d08-b1a4-a66d75d9d79d.doc', 1, 1),
(139, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)....\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', '9b52738f-af33-4ce2-88d4-d59475371638.doc', 1, 1),
(140, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)01\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', 'de919260-357b-4fc4-98e1-4f4973d3a7d6.doc', 1, 1),
(141, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)02\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', '6f20f9c7-c798-4f26-9897-d3efe06ed140.doc', 1, 1),
(142, 'إلـــى /  جهاز الرياضه ق.م (قسم  شئون الضباط) \r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', '770a19ae-598a-4a83-a326-6d472a5744ea.doc', 1, 1),
(143, 'إلـــى /  جهاز الرياضه ق.م (قسم  شئون الضباط)\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', '28d70205-9a8a-4e5a-8559-2e116e15cce9.doc', 1, 1),
(144, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 1, 'عقيد محمد', 'e45f8038-4bef-4f47-a4eb-03fc6112db45.doc', 1, 1),
(145, 'إلـــى /  إدارة الأسلحة والذخيرة (فرع شئون ضباط)2', 3, 'قسم التنقلات', '2023-05-03 00:00:00', 1, 'عقيد محمد', 'cf198010-5e72-4e2f-b68c-8293cbce6869.doc', 1, 1),
(146, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط) ج2 ميد\r\n', 3, 'قسم التنقلات', '2023-05-03 10:58:30', 1, 'عقيد محمد', '0051b6bd-a0ca-45f5-ae30-b00b06a44ae3.doc', 1, 1),
(147, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط)10\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '849f6823-b521-44f3-8394-14324cc1fa0f.doc', 1, 0),
(148, 'إلـــى /  ادارة المدرعات (فرع شئون ضباط)12\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'f943c228-2361-4211-ae86-8e818139f004.doc', 0, 0),
(149, 'إلـــى /  ادارة المدرعات (فرع شئون ضباط).1\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'f88cf7c6-dec4-4d19-83c4-9f600cb2225d.doc', 1, 0),
(150, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط) .2\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '60edfa04-0178-4f05-86f4-6d0a4f2381c9.doc', 0, 0),
(151, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط).3\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '3440cc7b-4db7-4862-ac41-f99e0436cd19.doc', 0, 0),
(152, 'إلـــى /  إدارة المدرعات (فرع شئون ضباط).4\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '20f700b3-bf42-4a62-8dba-034400372346.doc', 1, 0),
(156, 'يوميـــــة عددية بتقارير الكفاءة السنوى النموذج(110)ش.ض\r\n', 3, 'قسم التخطيط', '2023-05-01 10:56:44', 0, '', '3b8d82e1-f695-4506-bb41-fd61c64c13a5.doc', 0, 0),
(157, 'يومية عددية خاصة النماذج 121 ش ض المميكن للضباط الاحتياط\r\n', 3, 'قسم التخطيط', '2023-05-01 10:57:28', 0, '', '9a7ef5d1-5aa5-496d-99c5-a0e556f988d6.doc', 0, 0),
(158, 'يومية عددية بقوة شعب / أفرع  قيادة ج 2 ميد\r\n', 3, 'قسم التخطيط', '2023-05-01 10:58:11', 0, '', '7de07ca8-71ac-4514-a1ad-b1aa4a8d6449.doc', 0, 0),
(159, 'يومية تمام ضباط صف وجنود فرع شئون ضباط ج 2 ميد\r\n', 3, 'قسم التخطيط', '2023-05-01 10:58:43', 0, '', '5817d387-b797-4091-95f6-64c238a29175.doc', 0, 0),
(160, '\"يميــــــــــــــــن القســـــــــــــــــم\"\r\n', 3, 'قسم التخطيط', '2023-05-01 10:59:11', 0, '', '8b279523-b6a6-4580-9152-842629eb20f2.doc', 0, 0),
(161, 'إلــى / إدارة المدرعــات (فــرع شئــون الضبــاط) \r\n', 3, 'قسم التخطيط', '2023-05-01 10:59:35', 0, '', 'af8b7910-5412-47bb-ac73-a926c915b078.doc', 0, 0),
(162, 'إلـى / معدل توزيع \r\n', 3, 'قسم التخطيط', '2023-05-01 11:00:02', 0, '', '8e7f77f4-53f4-4350-8950-96f97364ee1b.doc', 0, 0),
(163, 'متأخرات فرع المركبات ج 2 ميد :\r\n', 3, 'قسم التخطيط', '2023-05-01 11:00:33', 0, '', 'fcf52d46-acd4-4afc-a653-188d4fa84f8e.doc', 0, 0),
(164, 'لجنة تقييم وظيفة قائد كتيبة ومايعادلها نشرة يناير 2023م\r\n', 3, 'قسم التخطيط', '2023-05-01 11:01:23', 0, '', 'bbfc611e-0957-43fa-a78b-71bab5c5b61c.docx', 0, 0),
(165, 'كشف باسماء الضباط المنقولين والمنضمين داخل ج2ميد المطلوب لهم نموذج 121 ش ض\r\n', 3, 'قسم التخطيط', '2023-05-01 11:03:40', 0, '', 'e59d94e2-452c-436b-a8bb-7c4512475333.doc', 0, 0),
(166, 'كشف أسماء الضباط الشرفيين ( تحقيق الشخصية العسكرية)\r\n', 3, 'قسم التخطيط', '2023-05-01 11:05:25', 0, '', '887928ac-c610-4b6d-a145-3e04aeabc4a4.doc', 0, 0),
(167, 'إلــــى / ادارة الاسلحة والذخيرة (فرع شئون ضباط)\r\n\r\n', 3, 'قسم التخطيط', '2023-05-01 11:06:27', 0, '', '30d3264e-515d-4d95-9811-bb593b0c0c71.doc', 0, 0),
(168, '                           أمـر تكليـف\r\n', 3, 'قسم التخطيط', '2023-05-01 11:07:18', 0, '', 'b9bd0c55-72e7-4378-b11c-3b805a4a0b0d.doc', 0, 0),
(169, 'براوز\r\n', 3, 'قسم التخطيط', '2023-05-01 11:07:55', 0, '', '7db7e6ce-530b-4cb7-b9b5-d62ff22c44d3.doc', 0, 0),
(170, 'بون بنزين وقود 92\r\n', 3, 'قسم التخطيط', '2023-05-01 11:08:26', 0, '', '678ef866-784f-448c-ae35-17ce4df74fa7.doc', 0, 0),
(171, 'نموذج تسوية الأقدم بالأحدث \r\n', 3, 'قسم التخطيط', '2023-05-01 11:09:08', 0, '', 'a64d7f77-9e27-4fb5-a054-5a3def950ec7.doc', 0, 0),
(172, 'كشف أسماء الضباط الاحتياط ( تحقيق الشخصية العسكرية)\r\n', 3, 'قسم التخطيط', '2023-05-01 11:09:38', 0, '', '5368468c-6b17-4341-bc78-b60301d2d193.doc', 0, 0),
(173, 'مذكرة عرض      (        / 2022)\r\nعلى السيد / قائــد الجيــش الثانــى الميدانــى \r\n', 3, 'قسم التخطيط', '2023-05-01 11:10:20', 0, '', '1599edcb-484f-428a-9fd8-d83f49cf7924.doc', 0, 0),
(174, 'كشــف بأسمـاء الضبـاط العاملين المرشحين للعمل بمهام إضافية \r\n', 3, 'قسم التخطيط', '2023-05-01 11:10:45', 0, '', 'fb6674c1-ac7c-4532-b0cc-e8d9f262ebc5.doc', 0, 0),
(175, 'يومية عددية بمطالب كل مهمة\r\n', 3, 'قسم التخطيط', '2023-05-01 11:12:05', 0, '', '4c4b1809-cc5b-48f5-8a15-d30e3f37c621.doc', 0, 0),
(176, '           \r\n كشـــف بإجمالي مصروفـــات الكانتين عــن شهــر اكتوبر 2021م\r\n', 3, 'قسم التخطيط', '2023-05-01 11:12:39', 0, '', '731649a9-7b7b-402f-a026-4774f14f98d3.doc', 0, 0),
(177, 'مصروفات عن شهر يونيو  2022م\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '4fd2a143-5604-44c2-8e78-90a3972cebb5.doc', 0, 0),
(178, ' كشـــف بإجمالي مصروفـــات الكانتين عــن شهــر يوليو 2022م', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '290e22f0-713b-4623-94db-f71233f8c8a0.doc', 0, 0),
(179, 'مصروفات عن شهر ديسمبر  2021\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'e859ae95-dae0-438e-b4ff-ac3c0c1372ef.doc', 0, 0),
(180, 'مصروفات عن شهر ديسمبر  2021م\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '9b1b592c-349c-4f06-a25a-916444b00615.doc', 0, 0),
(181, 'كشـــف بأسمـــاء ضبـــاط / ضباط صف فـــرع ش.ض وتـــواريـخ\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'dda6342c-6703-4432-b438-9529093c0d37.doc', 0, 0),
(182, 'كشـف باسماء ضبـاط فـرع شئـون ضبـاط ج2ميـد ', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '4a12cfc9-767b-4380-a365-4ba0fd9b05e9.doc', 0, 0),
(183, 'كشف بأسماء الجنود  بفرع شئون ضباط ج2ميد\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'a4600136-f961-4f55-9ee6-6a81a87c4aa6.doc', 0, 0),
(184, 'إمكانيات ومطالب فرع شئون الضباط\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '82553aff-137e-4dce-9516-c71100569e44.doc', 0, 0),
(185, 'تقريربالملاحظات(الإيجابية-السلبية)\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'c58eb133-02a1-40e7-9452-65395f7e3fed.doc', 0, 0),
(186, 'إجراءات لجنة مشتريات /المصروفات للفرع عن شهر يناير 2022م\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '3bc0b2e4-301d-4032-a51c-2d5647f66922.doc', 0, 0),
(187, 'نمــوذج عــرض علــى السيــد/ قائــد الجيــش الثانــى الميدانــى \r\nبشــأن تسويــات الضبــاط الشرفيين نشرة  يناير 2022م\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'ca8298ab-b9bd-4ddc-9c3d-451eaff0090f.doc', 0, 0),
(188, 'كشف بأسماء صف ضباط بفرع شئون ضباط ج2ميد\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '940b0413-6743-4366-8390-9d16b77b8fe3.doc', 0, 0),
(189, 'يوميــة عدديــة بالضبـاط الملحقيـن مــن تشكيــلات الجيــش الثانــى الميدانــى\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'de58def9-0099-48bf-92f4-ee9d0369e6fa.doc', 0, 0),
(190, 'نمــوذج عــرض علــى السيــد/ قائــد الجيــش الثانــى الميدانــى \r\nبشــأن تسويــات الضبــاط العاملين نشــرة يوليو 2022م\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'fbd3b0e4-17dc-46ac-a558-31cd724c89e5.doc', 0, 0),
(191, 'اعتذر عن حضــور رئيس أركان الجيش الثانى الميدانى \r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '308a0170-56f4-46fa-aa4d-63253026e4f9.doc', 0, 0),
(192, 'إلى / المركز الرياضي ج 2 ميد\r\nإلى / المركز الرياضي ج 2 ميد\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '900d0845-c8bb-4c1f-b526-0e0eebec92f4.doc', 0, 0),
(193, 'مقترح تقرير مبررات مرفق بتقرير الكفاءة\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'c796aff7-43e7-452e-ad24-00e41aeb4edd.doc', 0, 0),
(194, 'إيماءً لأمر النقل رقم (116/2021)  الصادر من إدارة شئون ضباط ق.م \r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '7a4da86b-f5cf-4902-b3c2-7ee2026628d2.doc', 0, 0),
(195, 'إيماءً لأمر النقل رقم (124/2021)  الصادر من إدارة شئون ضباط ق.م \r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '85b5d162-7e7b-4a41-80c6-45cdda018a55.doc', 0, 0),
(196, 'إيماء لكتاب قيادة قوات حرس الحدود (فرع شئون الضباط) رقم (86)\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', 'b2e2d2b7-9459-4480-aaf2-9b7f36e2d504.doc', 0, 0),
(197, 'المنقوليــن و المنضمين بشعــب و أفــرع ج2ميــد', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '4f995de4-2318-473e-865c-876f02aca4b4.doc', 0, 0),
(198, 'ايماءً لكتاب ادارة شئون ضباط ق.م رقم(785)\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '27bfeb60-b7fe-4476-8f8d-33fa5ab7f5db.doc', 0, 0),
(199, 'كشف تصوير تحقيق الشخصية العسكرية لضباط ج2ميد نشرة يناير 2021م\r\n', 3, 'قسم التنقلات', '2023-05-03 17:19:08', 0, '', '38b9ec8d-6260-423d-a01e-e508e4977fe1.docx', 0, 0),
(200, 'يومية عددية بالضباط المرشحين للإعارة للمخابرات العامة\r\n', 3, 'قسم الملفات', '2023-05-01 11:34:08', 0, '', 'a41705d5-6d14-447d-9662-303f92b899b3.doc', 0, 0),
(201, 'إقرار لجنة الضباط المحلية رقم 2 لضباط  ج2 ميد (يناير 2023 م)\r\n', 3, 'قسم الملفات', '2023-05-01 11:34:55', 0, '', '0ba20f67-03dd-49c0-b0cc-07eb27275687.doc', 0, 0),
(202, 'شهــــــــــــــــادة إخــــــــــــــــلاء طــــــــــــــــرف ،،،،،\r\n', 3, 'قسم الملفات', '2023-05-01 11:35:37', 0, '', '950ffc84-891a-42c4-b83c-a9f8751fd073.doc', 0, 0),
(203, 'إلـــــى / قيال 3 ميكا / فر 16 ميكا\r\n', 3, 'قسم الملفات', '2023-05-01 11:36:08', 0, '', '381db391-9e93-4b8a-b23e-ccf91a6123f1.doc', 0, 0),
(204, 'شهادة رديف\r\n', 3, 'قسم الملفات', '2023-05-01 11:37:27', 0, '', '1a75d941-8d72-4a05-bee1-572145543a5e.doc', 0, 0),
(205, 'كــارت مهمـــــة\r\n', 3, 'قسم الملفات', '2023-05-01 11:37:50', 0, '', '7dd8255f-0413-424f-bf11-7ec853ad86c3.doc', 0, 0),
(206, 'دفعــــات الإجــــازات للجنــــود خاصــــة فــــرع شئــــون ضبــــاط ج2ميــــد\r\n', 3, 'قسم الملفات', '2023-05-01 11:39:01', 0, '', '9a39f74f-1ec0-4fd1-a5fd-2b41b3a9dffa.doc', 0, 0),
(207, 'يشهد فرع شئون ضباط ج2ميد بأنه قد تم تطعيم قوة الفرع من ( الضباط - ضباط الصف - الجنود) بلقاح كورونا  \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n \r\n وهذه شهادة منا بذلك\r\n', 3, 'قسم الملفات', '2023-05-01 11:39:41', 0, '', 'd393c6de-ee08-4cb6-8346-82093d7d08e0.doc', 0, 0),
(208, ' \r\n\r\nقيادة الجيش الثاني الميداني    فرع شئون الضباط ', 3, 'قسم الملفات', '2023-04-30 00:00:00', 0, '', '404b3aa9-2327-4761-a08a-e7e946597dea.doc', 0, 0),
(209, 'إلـى /فو ج المقر ج2ميد\r\nقادم لكم مندوبنا وذلك لتسليم كشف بأسماء الصف والجنود المسكن خاصة فرع شئون ضباط ج2ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:41:42', 0, '', 'f07f3d90-26e7-47ed-a6eb-77514b5bdb97.doc', 0, 0),
(210, 'بيان إسكان ضباط فرع شئون ضباط ج2ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:42:10', 0, '', 'eb6f8caf-f44a-44c9-bb17-2c93d6296121.doc', 0, 0),
(211, 'إذن صرف\r\n', 3, 'قسم الملفات', '2023-05-01 11:42:45', 0, '', '500570e4-b0a2-46ff-81d2-b00095e0557f.doc', 0, 0),
(212, 'بيان تجميع الجمعيات\r\n', 3, 'قسم الملفات', '2023-05-01 11:43:02', 0, '', '2ab68c32-48c0-4b41-8959-fa6c46ddb93b.doc', 0, 0),
(213, 'دفتر متابعة المأموريات \r\n', 3, 'قسم الملفات', '2023-04-30 00:00:00', 0, '', '5c07b38f-67ff-4a2f-a16a-81f98da9eb3c.doc', 0, 0),
(214, 'كشف أسماء ضباط الصف فرع شئون ضباط ج2 ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:44:14', 0, '', 'b3e51631-8014-4cb8-bc9f-a24b543488c9.doc', 0, 0),
(215, 'إلـى /فو ج المقر ج2ميد\r\nقادم لكم مندوبنا وذلك لتسليم كشف بأسماء الصف والجنود المسكن خاصة فرع شئون ضباط ج2ميد.\r\n', 3, 'قسم الملفات', '2023-05-01 11:44:49', 0, '', 'c018b15a-0b0b-4409-b24b-021a491494cb.doc', 0, 0),
(216, 'كشف بأسماء الجنود المخصصين لصرف التعيين\r\n', 3, 'قسم الملفات', '2023-05-01 11:45:31', 0, '', 'c7736bd2-c53e-4aac-983d-1e9dd5226104.doc', 0, 0),
(217, 'توزيع الجنود قطاعات النظافة الداخلية \r\n\r\n', 3, 'قسم الملفات', '2023-05-01 11:45:52', 0, '', '9d3a432c-8c32-4675-81c3-6ad00021e816.doc', 0, 0),
(218, 'قيادة الجيش الثانى الميدانى\r\n              فرع شئون الضباط\r\n', 3, 'قسم الملفات', '2023-05-01 11:46:53', 0, '', 'a7517839-eb9e-4a4f-ba7e-da7a9edcb041.doc', 0, 0),
(219, 'كشف بأسماء الجنود  الملحقين بفرع شئون ضباط ج2ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:47:32', 0, '', 'c2eaea86-7905-48d8-916b-3aefe37809bf.doc', 0, 0),
(220, 'إستطلاع رأى\r\n', 3, 'قسم الملفات', '2023-05-01 11:47:50', 0, '', 'ac57b599-2673-45b8-bd4d-27ab436c9671.doc', 0, 0),
(221, 'يومية سير محرره من فرع شئون ضباط ج2 \r\n', 3, 'قسم الملفات', '2023-05-01 11:48:53', 0, '', 'c7af139a-6b55-4408-994f-781232f905be.doc', 0, 0),
(222, 'كشف بأسماء صف ضباط بفرع شئون ضباط ج2ميد.\r\n', 3, 'قسم الملفات', '2023-05-01 11:49:53', 0, '', 'ae3b7ac5-8b7a-4900-98ba-c0b1022651ae.doc', 0, 0),
(223, 'كشف باسماء الجنود الملحقين بفرع شئون ضباط ج2 ميـــــــد\r\n', 3, 'قسم الملفات', '2023-05-01 11:51:58', 0, '', '6a2c1081-e9ab-458e-944d-d73d5412014e.doc', 0, 0),
(224, 'إيماء لإشارة شعبة التنظيم والإدارة فاكس بتاريخ 14/9/2022م بشأن كشف بأسمــــــاء الجنود  الملحقين بفرع شئون ضـــــباط ج2ميد.\r\n', 3, 'قسم الملفات', '2023-05-01 11:52:30', 0, '', 'ed895f73-959e-4a0d-8449-3db5c75f184a.doc', 0, 0),
(225, 'يومية سير محرره من فرع شئون ضباط ج2 ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:53:09', 0, '', '875d72ff-c9e2-4e96-b767-a8cab99852ac.doc', 0, 0),
(226, 'كشـــف بإجمالي مصروفـــات الكانتين عــن شهــر يوليو 2022م\r\n', 3, 'قسم الملفات', '2023-05-01 11:53:34', 0, '', 'f60644af-62fa-418d-b3c9-a71ace51ed52.doc', 0, 0),
(227, 'مخطط أجازات ( صف الضباط ) خاصة فرع شئون ضباط ج 2 ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:54:21', 0, '', '20705016-2d6f-40b4-8062-3254f4e2556f.docx', 0, 0),
(228, ' إلى /إدارة شئون ضباط ق م \r\n', 3, 'قسم الملفات', '2023-05-01 11:55:16', 0, '', '804a3a85-e483-436b-8edc-e76158a131c6.doc', 0, 0),
(229, 'كشف أسماء الضباط فرع شئون ضباط ج2 ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:56:07', 0, '', '1aaf3381-1578-40dc-808b-34fbd1d641d4.doc', 0, 0),
(230, 'كشف أسماء الجنود فرع شئون ضباط ج2 ميد\r\n', 3, 'قسم الملفات', '2023-05-01 11:56:34', 0, '', '1f26a371-7a84-4160-99d4-e89a9132c9fb.doc', 0, 0),
(231, 'كشف أسماء ضباط الصف فرع شئون ضباط ج2 ميد.\r\n', 3, 'قسم الملفات', '2023-05-01 11:57:43', 0, '', '2d04e015-3891-4f12-958b-a833fb19ee4a.doc', 0, 0),
(232, 'عنوان الفرقة\r\n', 3, 'قسم التنقلات', '2023-05-03 19:38:30', 0, '', '8ab8daaa-45fd-4d1d-b18c-c0c5df3ff4a8.doc', 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `mails`
--
ALTER TABLE `mails`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `mail_id` (`mail_title`) USING HASH,
  ADD UNIQUE KEY `file_name` (`file_name`) USING HASH,
  ADD UNIQUE KEY `file_name_2` (`file_name`) USING HASH,
  ADD UNIQUE KEY `file_name_3` (`file_name`) USING HASH;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `mails`
--
ALTER TABLE `mails`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=233;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
