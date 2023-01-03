CREATE TABLE Departamento(
	IdDepartamento INT PRIMARY KEY IDENTITY(1,1),
	DescripcionDepartamento VARCHAR(50)
)

CREATE TABLE Puesto(
	IdPuesto INT PRIMARY KEY IDENTITY(1,1),
	DescripcionPuesto VARCHAR(50)
)

CREATE TABLE Empleado(
	IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50),
	IdPuesto INT,
	IdDepartamento INT,
	
	CONSTRAINT FK_PuestoEmpleado FOREIGN KEY (IdPuesto)
    REFERENCES Puesto(IdPuesto),

	CONSTRAINT FK_DepartamentoEmpleado FOREIGN KEY (IdDepartamento)
    REFERENCES Departamento(IdDepartamento)
)
GO

--CREACION DE LAS VISTAS
CREATE VIEW VistaGetAll
AS
	SELECT 
			IdEmpleado
			,Nombre
			,Empleado.IdPuesto
			,Puesto.DescripcionPuesto
			,Empleado.IdDepartamento
			,Departamento.DescripcionDepartamento
	FROM Empleado
INNER JOIN Puesto ON Empleado.IdPuesto=Puesto.IdPuesto
INNER JOIN Departamento ON Empleado.IdDepartamento=Departamento.IdDepartamento
GO

--STORED PROCEDURE
ALTER PROCEDURE EmpleadoGetAll 
@Nombre VARCHAR(50)
AS
	SELECT 
			IdEmpleado
			,Nombre
			,Empleado.IdPuesto
			,Puesto.DescripcionPuesto
			,Empleado.IdDepartamento
			,Departamento.DescripcionDepartamento
	FROM Empleado
INNER JOIN Puesto ON Empleado.IdPuesto=Puesto.IdPuesto
INNER JOIN Departamento ON Empleado.IdDepartamento=Departamento.IdDepartamento
WHERE Empleado.Nombre LIKE '%'+@Nombre+'%' 
GO

CREATE PROCEDURE PuestoGetAll
AS
	SELECT IdPuesto,DescripcionPuesto FROM Puesto
GO

CREATE PROCEDURE DepartamentoGetAll
AS
	SELECT IdDepartamento,DescripcionDepartamento FROM Departamento
GO

CREATE PROCEDURE EmpleadoAdd
@Nombre VARCHAR(50),
@IdPuesto INT,
@IdDepartamento INT
AS
	INSERT INTO Empleado
				(Nombre
				,IdPuesto
				,IdDepartamento)
				VALUES (@Nombre,@IdPuesto,@IdDepartamento)
GO

CREATE PROCEDURE EmpleadoDelete 16
@IdEmpleado INT
AS
DELETE FROM Empleado
      WHERE IdEmpleado=@IdEmpleado
GO


CREATE PROCEDURE EmpleadoGetAllSearch
@Nombre VARCHAR(50)
AS
	SELECT 
			IdEmpleado
			,Nombre
			,Empleado.IdPuesto
			,Puesto.DescripcionPuesto
			,Empleado.IdDepartamento
			,Departamento.DescripcionDepartamento
	FROM Empleado
INNER JOIN Puesto ON Empleado.IdPuesto=Puesto.IdPuesto
INNER JOIN Departamento ON Empleado.IdDepartamento=Departamento.IdDepartamento
GO