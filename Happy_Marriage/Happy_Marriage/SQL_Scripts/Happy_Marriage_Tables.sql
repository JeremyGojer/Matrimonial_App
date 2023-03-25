DROP DATABASE IF EXISTS happy_marriage;
CREATE DATABASE happy_marriage;
use happy_marriage;

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `userid` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(20) DEFAULT NULL,
  `contactnumber` varchar(20) DEFAULT NULL,
  `role` varchar(30) DEFAULT NULL,
  `joinedon` date DEFAULT NULL,
  `imageurl` text,
  `approvalstatus` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("Jeremy","gojerjeremy@gmail.com","Jeremy","+917019294131","admin","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("IronMan","ironman@avengers.com","Tony","+915345645321","user","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("CaptianAmerica","capam@avengers.com","Steve","+915542579411","user","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("Hulk","hulk@avengers.com","Bruce","+915674834642","user","2021-01-01","/images/Default_Profile_Pic.jpg","Not Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("BlackWidow","widow@avengers.com","Natasha","+916574653546","user","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("Hawkeye","hawkeye@avengers.com","Clint","+912154512154","user","2021-01-01","/images/Default_Profile_Pic.jpg","Rejected");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("Thor","thor@avengers.com","Thor","+914568413256","user","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("ScarletWitch","wanda@avengers.com","Wanda","+916456421364","user","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("DoctorStrange","strange@kamartaj.com","Steven","+914597213546","admin","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("Groot","groot@gog.com","IAmGroot","+9194214823546","user","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl, approvalstatus) VALUES("Witch","wanda@avengers.com","Wanda","+916456421364","user","2021-01-01","/images/Default_Profile_Pic.jpg","Approved");

DROP TABLE IF EXISTS `users_info`;

CREATE TABLE `users_info` (
  `userid` int NOT NULL,
  `firstname` varchar(50) DEFAULT NULL,
  `lastname` varchar(50) DEFAULT NULL,
  `gender` varchar(20) DEFAULT NULL,
  `dateofbirth` date DEFAULT NULL,
  `job` varchar(50) DEFAULT NULL,
  `education` varchar(50) DEFAULT NULL,
  `religion` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`userid`),
  CONSTRAINT `userid1` FOREIGN KEY (`userid`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

INSERT INTO users_info values(1,"Jeremy","Gojer","Male","1996-02-25","Freelancer","Graduate","Christian");
INSERT INTO users_info values(2,"Tony","Stark","Male","1980-08-09","Philantrophist","Post-Graduate or Higher","Atheist");
INSERT INTO users_info values(3,"Steve","Rogers","Male","1920-11-11","Soldier","Undergraduate","Catholic");
INSERT INTO users_info values(4,"Bruce","Banner","Male","1983-05-25","Scientist","Post-Graduate or Higher","Christian");
INSERT INTO users_info values(5,"Natasha","Romanoff","Female","1985-01-19","Assassin","Graduate","N/A");
INSERT INTO users_info values(6,"Clint","Barton","Male","1982-04-08","Circus Performer","Undergraduate","Christian");
INSERT INTO users_info values(7,"Thor","Odinson","Male","0002-02-01","Ruler","Post-Graduate or Higher","Actually a God Himself");
INSERT INTO users_info values(8,"Wanda","Maximoff","Female","1990-03-08","Construction","Undergraduate","Christian");
INSERT INTO users_info values(9,"Steven","Strange","Male","1982-07-17","Surgeon","Post-Graduate or Higher","Christian");
INSERT INTO users_info values(10,"Groot","IAmGroot","Other","1998-04-04","Space Pirate","Uneducated","N/A");
INSERT INTO users_info values(11,"Banda","Vaximoff","Female","1990-03-08","Nurse","Undergraduate","Christian");

DROP TABLE IF EXISTS `users_personal_info`;

CREATE TABLE `users_personal_info` (
  `userid` int NOT NULL,
  `height` double DEFAULT NULL,
  `weight` double DEFAULT NULL,
  `foodtype` varchar(40) DEFAULT NULL,
  `smoking` varchar(20) DEFAULT NULL,
  `alcohol` varchar(20) DEFAULT NULL,
  `bloodgroup` varchar(10) DEFAULT NULL,
  `martialstatus` varchar(40) DEFAULT NULL,
  `annualincome` double DEFAULT NULL,
  PRIMARY KEY (`userid`),
  CONSTRAINT `userid` FOREIGN KEY (`userid`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

INSERT INTO users_personal_info values(1,169,80,"All","No","Occasionally","O +ve","Single",200000);
INSERT INTO users_personal_info values(2,165,72,"All","Yes","Yes","A +ve","Single",20000000000);
INSERT INTO users_personal_info values(3,204,97,"All","No","Occasionally","A -ve","Single",20000000);
INSERT INTO users_personal_info values(4,162,66,"All","No","Occasionally","B +ve","Single",500000000);
INSERT INTO users_personal_info values(5,174,62,"All","Yes","Yes","O +ve","Single",8000000);
INSERT INTO users_personal_info values(6,190,81,"All","Yes","Yes","B +ve","Married",4000000);
INSERT INTO users_personal_info values(7,207,98,"All","No","No","N/A","Single",2000000000000);
INSERT INTO users_personal_info values(8,158,62,"All","No","No","A +ve","Single",200000);
INSERT INTO users_personal_info values(9,172,80,"All","No","Occasionally","A +ve","Single",80000000);
INSERT INTO users_personal_info values(10,240,150,"All","No","No","N/A","Single",200000);
INSERT INTO users_personal_info values(11,158,62,"All","No","No","A +ve","Single",200000);

DROP TABLE IF EXISTS `users_address_info`;

CREATE TABLE `users_address_info` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `country` varchar(50) DEFAULT NULL,
  `state` varchar(50) DEFAULT NULL,
  `district` varchar(50) DEFAULT NULL,
  `city` varchar(50) DEFAULT NULL,
  `pincode` varchar(20) DEFAULT NULL,
  `addressline2` varchar(100) DEFAULT NULL,
  `addressline1` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userid2_idx` (`userid`),
  CONSTRAINT `userid2` FOREIGN KEY (`userid`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

INSERT INTO users_address_info values(1,1,"India","Karnataka","Belgaum","Nipani","591237","Old PB Road","Lafayette Hospital");
INSERT INTO users_address_info values(2,2,"USA","NY","NY","Manhattan","5645521","Central Avenue","Stark Tower");
INSERT INTO users_address_info values(3,3,"USA","NY","NY","Brooklyn","4564231","403-West Lane","Apartment 66");
INSERT INTO users_address_info values(4,4,"India","Bengal","Kolkata","Kolkata","5645121","Near Post Office","2212 ShantiSukh");
INSERT INTO users_address_info values(5,5,"India","Maharashtra","Pune","Pune","411027","Near Babo Roa Bhavan","45, Sangvi Gaon");
INSERT INTO users_address_info values(6,6,"India","Maharashtra","Pune","Marketyard","411037","Gultekdi","Lic Colony");
INSERT INTO users_address_info values(7,7,"India","Maharashtra","Pune","Pune","591237","Budhwar Peth","Laxmi Road");
INSERT INTO users_address_info values(8,8,"India","Maharashtra","Pune","Pune","411011","Behind Rupee Bank","339/b, rasta peth");
INSERT INTO users_address_info values(9,9,"India","Maharashtra","Pune","Kirkee","411003","Bombay Pune Road","Near Merial Police Cho");
INSERT INTO users_address_info values(10,10,"India","Maharashtra","Pune","vanazcorne","411029","Paudroad","7b, anand complex");
INSERT INTO users_address_info values(11,11,"India","Maharashtra","Pune","Pune","411011","Behind Rupee Bank","339/b, rasta peth");

DROP TABLE IF EXISTS `users_other_info`;

CREATE TABLE `users_other_info` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int NOT NULL,
  `property` varchar(30) DEFAULT NULL,
  `value` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

DROP TABLE IF EXISTS users_messages;

CREATE TABLE `users_messages` (
  `messageid` int NOT NULL AUTO_INCREMENT,
  `userid1` int DEFAULT NULL,
  `userid2` int DEFAULT NULL,
  `receivedon` datetime DEFAULT NULL,
  `content` varchar(300) DEFAULT NULL,
  `status` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`messageid`),
  KEY `sendera_idx` (`userid1`),
  KEY `receiverb_idx` (`userid2`),
  CONSTRAINT `receiverb` FOREIGN KEY (`userid2`) REFERENCES `users` (`userid`),
  CONSTRAINT `sendera` FOREIGN KEY (`userid1`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

DROP TABLE IF EXISTS `users_uploads`;

CREATE TABLE `users_uploads` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid` int DEFAULT NULL,
  `imageurl` text,
  `receivedon` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userid5_idx` (`userid`),
  CONSTRAINT `userid5` FOREIGN KEY (`userid`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

DROP TABLE IF EXISTS users_requests;

CREATE TABLE `users_requests` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid1` int DEFAULT NULL,
  `userid2` int DEFAULT NULL,
  `createdon` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userida1_idx` (`userid1`),
  KEY `useridb2_idx` (`userid2`),
  CONSTRAINT `userida1` FOREIGN KEY (`userid1`) REFERENCES `users` (`userid`),
  CONSTRAINT `useridb2` FOREIGN KEY (`userid2`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

DROP TABLE IF EXISTS `users_friendships`;

CREATE TABLE `users_friendships` (
  `id` int NOT NULL AUTO_INCREMENT,
  `userid1` int DEFAULT NULL,
  `userid2` int DEFAULT NULL,
  `createdon` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `usera_idx` (`userid1`),
  KEY `userb_idx` (`userid1`,`userid2`),
  KEY `userb_idx1` (`userid2`),
  CONSTRAINT `usera` FOREIGN KEY (`userid1`) REFERENCES `users` (`userid`),
  CONSTRAINT `userb` FOREIGN KEY (`userid2`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

DROP TABLE IF EXISTS `users_reports`;

CREATE TABLE `users_reports` (
  `id` int NOT NULL AUTO_INCREMENT,
  `reportedon` int DEFAULT NULL,
  `reportedby` int DEFAULT NULL,
  `description` varchar(300) DEFAULT NULL,
  `createdon` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `userid4_idx` (`reportedon`),
  CONSTRAINT `reportedbya` FOREIGN KEY (`reportedon`) REFERENCES `users` (`userid`),
  CONSTRAINT `reportedonb` FOREIGN KEY (`reportedon`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

DROP TABLE IF EXISTS `users_metadata`;

CREATE TABLE `users_metadata` (
  `userid` int DEFAULT NULL,
  `coverpicture` text,
  `isonline` tinyint(1) DEFAULT NULL,
  KEY `userid3_idx` (`userid`),
  CONSTRAINT `userid3` FOREIGN KEY (`userid`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

DROP TABLE IF EXISTS `countries`;

CREATE TABLE `countries` (
  `id` mediumint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `iso3` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `iso2` char(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phonecode` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `capital` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `currency` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `currency_symbol` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tld` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `native` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `region` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `subregion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `timezones` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `translations` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  `latitude` decimal(10,8) DEFAULT NULL,
  `longitude` decimal(11,8) DEFAULT NULL,
  `emoji` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `emojiU` varchar(191) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `flag` tinyint(1) NOT NULL DEFAULT '1',
  `wikiDataId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Rapid API GeoDB Cities',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=251 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci

DROP TABLE IF EXISTS `states`;

CREATE TABLE `states` (
  `id` mediumint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `country_id` mediumint unsigned NOT NULL,
  `country_code` char(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `fips_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `iso2` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `latitude` decimal(10,8) DEFAULT NULL,
  `longitude` decimal(11,8) DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `flag` tinyint(1) NOT NULL DEFAULT '1',
  `wikiDataId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Rapid API GeoDB Cities',
  PRIMARY KEY (`id`),
  KEY `country_region` (`country_id`),
  CONSTRAINT `country_region_final` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4926 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=COMPACT

DROP TABLE IF EXISTS `cities`;

CREATE TABLE `cities` (
  `id` mediumint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `state_id` mediumint unsigned NOT NULL,
  `state_code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `country_id` mediumint unsigned NOT NULL,
  `country_code` char(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `latitude` decimal(10,8) NOT NULL,
  `longitude` decimal(11,8) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT '2014-01-01 06:31:01',
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `flag` tinyint(1) NOT NULL DEFAULT '1',
  `wikiDataId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL COMMENT 'Rapid API GeoDB Cities',
  PRIMARY KEY (`id`),
  KEY `cities_test_ibfk_1` (`state_id`),
  KEY `cities_test_ibfk_2` (`country_id`),
  CONSTRAINT `cities_ibfk_1` FOREIGN KEY (`state_id`) REFERENCES `states` (`id`),
  CONSTRAINT `cities_ibfk_2` FOREIGN KEY (`country_id`) REFERENCES `countries` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=148541 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=COMPACT