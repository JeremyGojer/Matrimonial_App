DROP DATABASE IF EXISTS happy_marriage;
CREATE DATABASE happy_marriage;
use happy_marriage

DROP TABLE IF EXISTS users;
CREATE TABLE users(userid INT NOT NULL AUTO_INCREMENT, username VARCHAR(50), email VARCHAR(50), password VARCHAR(20), contactnumber VARCHAR(20), role VARCHAR(30), joinedon DATE,imageurl TEXT, PRIMARY KEY(userid));
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("Jeremy","gojerjeremy@gmail.com","Jeremy","+917019294131","admin","2021-01-01","/images/Default_Profile_Pic.jpg");

DROP TABLE IF EXISTS users_info;
CREATE TABLE users_info(userid INT NOT NULL, firstname VARCHAR(50), lastname VARCHAR(50), gender VARCHAR(20), dateofbirth DATE, job VARCHAR(50),education VARCHAR(50), religion VARCHAR(30), PRIMARY KEY(userid));
INSERT INTO users_info values(1,"Jeremy","Gojer","Male","1996-02-25","Freelancer","Graduate","Christian");

DROP TABLE IF EXISTS users_personal_info;
CREATE TABLE users_personal_info(userid INT NOT NULL, height DOUBLE, weight DOUBLE, foodtype VARCHAR(40), smoking VARCHAR(20), alcohol VARCHAR(20), bloodgroup VARCHAR(10), martialstatus VARCHAR(40), annualincome DOUBLE, PRIMARY KEY(userid));
INSERT INTO users_personal_info values(1,169,80,"All","No","Occasionally","O +ve","Single",200000);

DROP TABLE IF EXISTS users_address_info;
CREATE TABLE users_address_info(id INT NOT NULL AUTO_INCREMENT,userid INT NOT NULL, country VARCHAR(50), state VARCHAR(50), district VARCHAR(50), city VARCHAR(50), pincode VARCHAR(20), addressline2 VARCHAR(100), addressline1 VARCHAR(100), PRIMARY KEY(id));
INSERT INTO users_address_info values(1,1,"India","Karnataka","Belgaum","Nipani","591237","Old PB Road","Lafayette Hospital");

DROP TABLE IF EXISTS users_other_info;
CREATE TABLE users_other_info(id INT NOT NULL AUTO_INCREMENT, userid INT NOT NULL, property VARCHAR(30), value VARCHAR(30), PRIMARY KEY(id));

DROP TABLE IF EXISTS users_messages;
CREATE TABLE users_messages(messageid INT NOT NULL AUTO_INCREMENT, userid INT, receivedon DATETIME, content VARCHAR(300), status VARCHAR(30), PRIMARY KEY(messageid));