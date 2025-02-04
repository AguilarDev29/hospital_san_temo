CREATE DATABASE hospital_san_telmo;
USE hospital_san_telmo;

CREATE TABLE usuario (
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	usuario VARCHAR(50) NOT NULL UNIQUE,
	clave VARCHAR (255) NOT NULL,
	rol VARCHAR(50) NOT NULL DEFAULT 'USUARIO',
	activo BIT NOT NULL DEFAULT 1
	);

CREATE TABLE especialidad(
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	nombre VARCHAR(50) NOT NULL
	);

CREATE TABLE medico (
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	apellido VARCHAR(100) NOT NULL,
	nombre VARCHAR(100) NOT NULL, 
	dni VARCHAR(15) NOT NULL UNIQUE,
	sexo VARCHAR(10) NOT NULL,
	fecha_nac DATE NOT NULL,
	telefono VARCHAR(20) NOT NULL DEFAULT 'NO TIENE',
	email VARCHAR(255) NOT NULL DEFAULT 'NO TIENE',
	id_especialidad INT NOT NULL,
	plus DECIMAL NOT NULL DEFAULT 0,
	activo BIT NOT NULL DEFAULT 1,
	CONSTRAINT fk_especialidad_medico FOREIGN KEY (id_especialidad) REFERENCES especialidad(id)
	);

CREATE TABLE obra_social (
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	nombre VARCHAR(45) NOT NULL,
	descuento DECIMAL(4,1) NOT NULL DEFAULT 0
	);

CREATE TABLE paciente (
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	apellido VARCHAR(100) NOT NULL,
	nombre VARCHAR(100) NOT NULL,
	dni VARCHAR(15) NOT NULL UNIQUE,
	sexo VARCHAR(10) NOT NULL,
	fecha_nac DATE NOT NULL,
	direccion VARCHAR(100) NOT NULL,
	localidad VARCHAR(100) NOT NULL,
	telefono VARCHAR(20) NOT NULL DEFAULT 'NO TIENE',
	email VARCHAR(255) NOT NULL DEFAULT 'NO TIENE',
	activo BIT NOT NULL DEFAULT 1,
	id_obra_social INT,
	CONSTRAINT fk_obra_social FOREIGN KEY (id_obra_social) REFERENCES obra_social(id)
	);

CREATE TABLE horario (
    horario TIME PRIMARY KEY NOT NULL
	);

CREATE TABLE turno (
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	id_paciente INT NOT NULL,
	id_medico INT NOT NULL,
	fecha_turno DATE NOT NULL,
	horario_turno TIME NOT NULL,
	total DECIMAL NOT NULL,
	atendido VARCHAR(2) NOT NULL DEFAULT 'NO',
	cancelado VARCHAR(2) NOT NULL DEFAULT 'NO',
	CONSTRAINT fk_paciente_turno FOREIGN KEY (id_paciente) REFERENCES paciente(id),
	CONSTRAINT fk_medico_turno FOREIGN KEY (id_medico) REFERENCES medico(id),
	CONSTRAINT fk_horario_turno FOREIGN KEY (horario_turno) REFERENCES horario(horario)
	);

CREATE TABLE historia_clinica (
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	id_paciente INT NOT NULL,
	id_medico INT NOT NULL,
	id_turno INT NOT NULL,
	diagnostico TEXT NOT NULL,
	CONSTRAINT fk_paciente_historia_clinica FOREIGN KEY (id_paciente) REFERENCES paciente(id),
	CONSTRAINT fk_medico_historia_clinica FOREIGN KEY  (id_medico) REFERENCES medico(id),
	CONSTRAINT fk_turno_historia_clinica FOREIGN KEY (id_turno) REFERENCES turno(id)
);

CREATE TABLE pago(
	id INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	id_turno INT NOT NULL,
	fecha_pago DATETIME DEFAULT GETDATE(),
	CONSTRAINT fk_turno FOREIGN KEY (id_turno) REFERENCES turno(id)
);

INSERT INTO usuario (usuario, clave, rol) VALUES ('admin', '$2a$12$J2GJ93ur0GRsKBlLpt6g1OJsRfB5rS4n1lC0QNaQzHhV8Uq8g7QNW', 'ADMIN' );
INSERT INTO usuario (usuario, clave) VALUES ('user', '$2a$12$J2GJ93ur0GRsKBlLpt6g1OJsRfB5rS4n1lC0QNaQzHhV8Uq8g7QNW');

INSERT INTO obra_social (nombre, descuento) VALUES ('OSDE',.15),('PAMI',.20),('RED',.10);

INSERT INTO especialidad (nombre) VALUES ('CARDIOLOGIA'), ('PEDIATRIA'), ('NEUROLOGIA'), ('DERMATOLOGIA'), ('GASTROENTEROLOGIA');

INSERT INTO horario (horario) VALUES ('08:00:00');
INSERT INTO horario (horario) VALUES ('08:30:00');
INSERT INTO horario (horario) VALUES ('09:00:00');
INSERT INTO horario (horario) VALUES ('09:30:00');
INSERT INTO horario (horario) VALUES ('10:00:00');
INSERT INTO horario (horario) VALUES ('10:30:00');
INSERT INTO horario (horario) VALUES ('11:00:00');
INSERT INTO horario (horario) VALUES ('11:30:00');
INSERT INTO horario (horario) VALUES ('12:00:00');
INSERT INTO horario (horario) VALUES ('12:30:00');
INSERT INTO horario (horario) VALUES ('13:00:00');
INSERT INTO horario (horario) VALUES ('13:30:00');
INSERT INTO horario (horario) VALUES ('17:00:00');
INSERT INTO horario (horario) VALUES ('17:30:00');
INSERT INTO horario (horario) VALUES ('18:00:00');
INSERT INTO horario (horario) VALUES ('18:30:00');
INSERT INTO horario (horario) VALUES ('19:00:00');
INSERT INTO horario (horario) VALUES ('19:30:00');
INSERT INTO horario (horario) VALUES ('20:00:00');
INSERT INTO horario (horario) VALUES ('20:30:00');


/*INSERT INTO paciente (apellido, nombre, dni, sexo,fecha_nac, direccion, localidad, telefono,email, id_obra_social) VALUES 
  ('Pérez','Juan','12345678','Masculino','1992-04-15','Calle Falsa 123','Buenos Aires','5551234','prueba@mail.com',0),
  ('Gómez','María','87654321','Femenino','1985-07-08','Av. Siempreviva 742','Córdoba','5555678','prueba@mail.com',2),
  ('López','Pedro','23456789','Masculino','2000-01-22','Calle Luna 12','Rosario','5559876','prueba@mail.com', 1),
  ('Rodríguez','Ana','98765432','Femenino','1997-11-03','Av. Sol 34','Mendoza','5553456','prueba@mail.com', 2),
  ('Fernández','Luis','34567890','Masculino','1989-09-27','Calle Estrella 56','Salta','5556789','prueba@mail.com', 0),
  ('Martínez','Laura','87654322','Femenino','1994-06-12','Av. Libertad 78','Tucumán','5554321','prueba@mail.com', 0),
  ('Sánchez','Diego','45678901','Masculino','1991-03-30','Calle Roca 90','La Plata','5558765','prueba@mail.com', 1),
  ('Torres','Sofía','56789012','Femenino','2003-08-19','Av. Paz 101','Neuquén','5552468','prueba@mail.com', 0),
  ('Vega','Andrés','67890123','Masculino','1987-02-25','Calle Libertador 345','San Juan','5551357','prueba@mail.com', 2),
  ('Herrera','Carla','78901234','Femenino','1996-10-05','Av. Mitre 456','Chaco','5559753','prueba@mail.com', 1);

INSERT INTO medico (apellido, nombre, dni, sexo, fecha_nac, telefono, email, id_especialidad, plus) VALUES 
  ('Pérez','Juan','12345678','Masculino','1990-06-17','34575332','prueba@mail.com',0, 8000),
  ('López','Maria','87654321','Femenino','2001-12-14','25235734','prueba@mail.com',1, 5000),
  ('García', 'Carlos','23456789','Masculino','1993-05-09','34745643','prueba@mail.com',2, 10000),
  ('Martínez','Ana','34567890','Femenino','1988-07-21','25745745','prueba@mail.com',3, 5000),
  ('Fernández','Luis','45678901','Masculino','1999-11-30','34686458','prueba@mail.com',4, 6000);
  */