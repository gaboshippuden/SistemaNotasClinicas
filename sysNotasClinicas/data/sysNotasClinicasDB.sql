-- =============================================
-- Script de creación: Sistema de Notas Clínicas
-- Ejecutar en SSMS: New Query -> pegar -> F5
-- =============================================
CREATE DATABASE NotasClinicasDB;
GO
USE NotasClinicasDB;
GO

CREATE TABLE Paciente (
    PacienteId  INT IDENTITY(1,1) PRIMARY KEY,
    Nombres     VARCHAR(80) NOT NULL,
    Apellidos   VARCHAR(80) NOT NULL,
    Telefono    VARCHAR(20) NOT NULL
);

CREATE TABLE Medico (
    MedicoId     INT IDENTITY(1,1) PRIMARY KEY,
    Nombres      VARCHAR(80) NOT NULL,
    Apellidos    VARCHAR(80) NOT NULL,
    Especialidad VARCHAR(80) NOT NULL
);

CREATE TABLE NotaClinica (
    NotaClinicaId INT IDENTITY(1,1) PRIMARY KEY,
    PacienteId    INT NOT NULL FOREIGN KEY REFERENCES Paciente(PacienteId),
    MedicoId      INT NOT NULL FOREIGN KEY REFERENCES Medico(MedicoId),
    FechaConsulta DATETIME2 NOT NULL,
    Diagnostico   VARCHAR(500) NOT NULL,
    NotasPaciente VARCHAR(MAX) NULL,
    Estado        VARCHAR(10) NOT NULL DEFAULT 'BORRADOR'
                  CHECK (Estado IN ('BORRADOR','FIRMADA'))
);
GO

-- Datos de prueba
INSERT INTO Paciente (Nombres, Apellidos, Telefono) VALUES ('Juan', 'Pérez', '+56911111111');
INSERT INTO Medico (Nombres, Apellidos, Especialidad) VALUES ('Ana', 'Soto', 'Medicina General');
INSERT INTO NotaClinica (PacienteId, MedicoId, FechaConsulta, Diagnostico, NotasPaciente)
VALUES (1, 1, SYSDATETIME(), 'Resfrío común','Paciente refiere dolor de garganta hace 2 días');
GO

SELECT * FROM NotaClinica;