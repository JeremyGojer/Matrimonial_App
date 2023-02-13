DROP DATABASE IF EXISTS happy_marriage;
CREATE DATABASE happy_marriage;
use happy_marriage

DROP TABLE IF EXISTS users;
CREATE TABLE users(userid INT NOT NULL AUTO_INCREMENT, username VARCHAR(50), email VARCHAR(50), password VARCHAR(20), contactnumber VARCHAR(20), role VARCHAR(30), joinedon DATE,imageurl TEXT, PRIMARY KEY(userid));
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("Jeremy","gojerjeremy@gmail.com","Jeremy","+917019294131","admin","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("IronMan","ironman@avengers.com","Tony","+915345645321","user","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("CaptianAmerica","capam@avengers.com","Steve","+915542579411","user","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("Hulk","hulk@avengers.com","Bruce","+915674834642","user","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("BlackWidow","widow@avengers.com","Natasha","+916574653546","user","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("Hawkeye","hawkeye@avengers.com","Clint","+912154512154","user","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("Thor","thor@avengers.com","Thor","+914568413256","user","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("ScarletWitch","wanda@avengers.com","Wanda","+916456421364","user","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("DoctorStrange","strange@kamartaj.com","Steven","+914597213546","admin","2021-01-01","/images/Default_Profile_Pic.jpg");
INSERT INTO users(username, email, password, contactnumber, role, joinedon, imageurl) VALUES("Groot","groot@gog.com","IAmGroot","+9194214823546","user","2021-01-01","/images/Default_Profile_Pic.jpg");

DROP TABLE IF EXISTS users_info;
CREATE TABLE users_info(userid INT NOT NULL, firstname VARCHAR(50), lastname VARCHAR(50), gender VARCHAR(20), dateofbirth DATE, job VARCHAR(50),education VARCHAR(50), religion VARCHAR(30), PRIMARY KEY(userid));
INSERT INTO users_info values(1,"Jeremy","Gojer","Male","1996-02-25","Freelancer","Graduate","Christian");
INSERT INTO users_info values(2,"Tony","Stark","Male","1980-08-09","Philantrophist","Post-Graduate and Higher","Atheist");
INSERT INTO users_info values(3,"Steve","Rogers","Male","1920-11-11","Soldier","Undergraduate","Catholic");
INSERT INTO users_info values(4,"Bruce","Banner","Male","1983-05-25","Scientist","Post-Graduate and Higher","Christian");
INSERT INTO users_info values(5,"Natasha","Romanoff","Female","1985-01-19","Assassin","Graduate","N/A");
INSERT INTO users_info values(6,"Clint","Barton","Male","1982-04-08","Circus Performer","Undergraduate","Christian");
INSERT INTO users_info values(7,"Thor","Odinson","Male","0002-02-01","Ruler","Post-Graduate and Higher","Actually a God Himself");
INSERT INTO users_info values(8,"Wanda","Maximoff","Female","1990-03-08","Construction","Undergraduate","Christian");
INSERT INTO users_info values(9,"Steven","Strange","Male","1982-07-17","Surgeon","Post-Graduate and Higher","Christian");
INSERT INTO users_info values(10,"Groot","IAmGroot","Other","1998-04-04","Space Pirate","Uneducated","N/A");

DROP TABLE IF EXISTS users_personal_info;
CREATE TABLE users_personal_info(userid INT NOT NULL, height DOUBLE, weight DOUBLE, foodtype VARCHAR(40), smoking VARCHAR(20), alcohol VARCHAR(20), bloodgroup VARCHAR(10), martialstatus VARCHAR(40), annualincome DOUBLE, PRIMARY KEY(userid));
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

DROP TABLE IF EXISTS users_address_info;
CREATE TABLE users_address_info(id INT NOT NULL AUTO_INCREMENT,userid INT NOT NULL, country VARCHAR(50), state VARCHAR(50), district VARCHAR(50), city VARCHAR(50), pincode VARCHAR(20), addressline2 VARCHAR(100), addressline1 VARCHAR(100), PRIMARY KEY(id));
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

DROP TABLE IF EXISTS users_other_info;
CREATE TABLE users_other_info(id INT NOT NULL AUTO_INCREMENT, userid INT NOT NULL, property VARCHAR(30), value VARCHAR(30), PRIMARY KEY(id));

DROP TABLE IF EXISTS users_messages;
CREATE TABLE users_messages(messageid INT NOT NULL AUTO_INCREMENT, userid INT, receivedon DATETIME, content VARCHAR(300), status VARCHAR(30), PRIMARY KEY(messageid));

DROP TABLE IF EXISTS users_uploads;
CREATE TABLE users_uploads(id INT NOT NULL AUTO_INCREMENT, userid INT, imageurl TEXT, receivedon DATETIME, PRIMARY KEY(id));

DROP TABLE IF EXISTS users_requests;
CREATE TABLE users_requests(id INT NOT NULL AUTO_INCREMENT, userid1 INT, userid2 INT, createdon DATETIME, PRIMARY KEY(id));

DROP TABLE IF EXISTS users_friendships;
CREATE TABLE users_friendships(id INT NOT NULL AUTO_INCREMENT, userid1 INT, userid2 INT, createdon DATETIME, PRIMARY KEY(id));