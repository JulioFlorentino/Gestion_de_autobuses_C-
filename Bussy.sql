
CREATE DATABASE BUSSYDB
drop database BUSSYDB 
USE BUSSYDB

--------------------------------------------------------------------------------------------------------------------------
CREATE TABLE USERLOGIN 
(
	User_email VARCHAR(30),
	User_password VARCHAR(20)

);

SELECT * FROM USERLOGIN

CREATE PROCEDURE LOGIN_U 
@USER_EMAIL VARCHAR(30),
@USER_PASSWORD VARCHAR(20)
AS
BEGIN
SELECT * FROM USERLOGIN 
WHERE User_email = @USER_EMAIL AND User_password = USER_PASSWORD;
END;
GO
----------------------------------------------------------------------------------------------------------------------------

DROP TABLE USER_INFO
CREATE TABLE USER_INFO(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	First_name VARCHAR(15),
	Last_name  VARCHAR(15),
	cedula VARCHAR(15),
	Hire_date VARCHAR(10)
	
);


--procedure for call the user data
CREATE OR ALTER PROCEDURE SP_USER_INFO
	@First_name VARCHAR(15),
	@Last_name  VARCHAR(15),
	@cedula VARCHAR(15),
	@Hire_date VARCHAR(10)
	AS
		BEGIN 
			SELECT * FROM USER_INFO
		END;
	GO


--procedure for delete a driver
CREATE PROCEDURE SP_DELETE_USER
@ID INT
AS
	BEGIN
	DELETE FROM USER_INFO WHERE ID = @ID
	END
GO

--procedure for insert data in the table
drop procedure SP_INSERT_DRIVER
CREATE OR ALTER PROCEDURE SP_INSERT_DRIVER
	@SP_First_name VARCHAR(15),
	@SP_Last_name  VARCHAR(15),
	@SP_cedula VARCHAR(15),
	@SP_Hire_date VARCHAR(10)
	
	
	AS
		BEGIN
			INSERT INTO USER_INFO(First_name,Last_name,cedula,Hire_date)
				VALUES(@SP_First_name, @SP_Last_name, @SP_cedula, @SP_Hire_date)
		END;
		GO

--procedure for insert credentials
CREATE OR ALTER PROCEDURE SP_INSERT_CREDENTIALS 
@SP_User_email VARCHAR(30),
@SP_User_password VARCHAR(20)
AS
	BEGIN
	IF NOT EXISTS (SELECT 1 FROM USERLOGIN
		WHERE User_email = @SP_User_email)

		INSERT INTO USERLOGIN(User_email, User_password)
			VALUES(@SP_User_email, @SP_User_password)
	END;
	GO

DROP PROCEDURE SP_UPDATE_DRIVER
CREATE OR ALTER PROCEDURE SP_UPDATE_DRIVER
	@ID INT,
    @SP_First_name VARCHAR(15),
	@SP_Last_name  VARCHAR(15),
	@SP_cedula VARCHAR(15),
	@SP_Hire_date VARCHAR(10)
AS
BEGIN
    UPDATE USER_INFO
    SET 
		@ID = @ID,
		First_name = @SP_First_name,
        Last_name = @SP_Last_name,
        cedula = @SP_cedula,
		Hire_date = @SP_Hire_date
		WHERE ID = @ID;
END;
GO
----------------------------------------------------------------------------------------------------------------------------






INSERT INTO USERLOGIN 
VALUES ('Admin', 'Admin');

INSERT INTO USER_INFO (First_name, Last_name, cedula, Hire_date)
VALUES 
('Carlos', 'Gomez', '123456789', '2024-01-10'),
('Maria', 'Lopez', '987654321', '2023-05-15'),
('Juan', 'Martinez', '456123789', '2022-07-20'),
('Ana', 'Fernandez', '321654987', '2021-09-25'),
('Pedro', 'Sanchez', '741852963', '2020-11-30'),
('Luis', 'Ramirez', '852963741', '2019-02-12'),
('Elena', 'Torres', '369258147', '2018-04-18'),
('Ricardo', 'Vargas', '159753486', '2017-06-22'),
('Laura', 'Diaz', '753159846', '2016-08-29'),
('Sergio', 'Ortega', '258147369', '2015-10-14'),
('Jessica', 'Mendez', '147258369', '2014-12-19'),
('Oscar', 'Reyes', '951753852', '2013-03-05'),
('Valeria', 'Cruz', '852741963', '2012-05-10'),
('Javier', 'Morales', '753963852', '2011-07-15'),
('Gabriela', 'Herrera', '159357486', '2010-09-20'),
('Fernando', 'Medina', '357159486', '2009-11-25'),
('Adriana', 'Jimenez', '951357852', '2008-02-01'),
('Pablo', 'Guerrero', '357951486', '2007-04-07'),
('Rosa', 'Castro', '753357951', '2006-06-12'),
('Esteban', 'Rojas', '852159357', '2005-08-17'),
('Luisa', 'Molina', '357852159', '2004-10-22'),
('Alejandro', 'Paredes', '753258147', '2003-12-27'),
('Carolina', 'Navarro', '951258147', '2002-03-03'),
('David', 'Suarez', '159852357', '2001-05-08'),
('Natalia', 'Rivas', '357159258', '2000-07-13'),
('Rodrigo', 'Espinoza', '852357159', '1999-09-18'),
('Silvia', 'Aguilar', '159753258', '1998-11-23'),
('Martín', 'Guzman', '357951852', '1997-02-28'),
('Monica', 'Salazar', '753159357', '1996-04-04'),
('Raúl', 'Dominguez', '951357159', '1995-06-09'),
('Patricia', 'Peralta', '852753159', '1994-08-14'),
('Julio', 'Mejia', '159357852', '1993-10-19'),
('Isabel', 'Luna', '357852753', '1992-12-24'),
('Francisco', 'Avila', '951852357', '1991-03-01'),
('Beatriz', 'Rojas', '852357951', '1990-05-06'),
('Daniel', 'Soto', '159753456', '1989-07-11'),
('Ximena', 'Chavez', '753159456', '1988-09-16'),
('Hugo', 'Lozano', '951357456', '1987-11-21'),
('Clara', 'Delgado', '852753456', '1986-02-26'),
('Roberto', 'Ibarra', '357852753', '1985-04-03');
