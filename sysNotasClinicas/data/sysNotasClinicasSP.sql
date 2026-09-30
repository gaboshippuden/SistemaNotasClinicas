-- =============================================
-- Stored Procedures y Trigger: Sistema de Notas Clínicas
-- Ejecutar en SSMS: New Query -> pegar -> F5
-- (Se puede ejecutar varias veces: CREATE OR ALTER reemplaza lo existente)
-- =============================================
USE NotasClinicasDB;
GO

-- =============================================
-- PACIENTE (alta y listado)
-- =============================================
CREATE OR ALTER PROCEDURE sp_Paciente_Insertar
    @Nombres   VARCHAR(80),
    @Apellidos VARCHAR(80),
    @Telefono  VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Paciente (Nombres, Apellidos, Telefono)
    VALUES (@Nombres, @Apellidos, @Telefono);

    SELECT SCOPE_IDENTITY() AS PacienteId;  -- devuelve el Id creado
END
GO

CREATE OR ALTER PROCEDURE sp_Paciente_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PacienteId, Nombres, Apellidos, Telefono
    FROM Paciente
    ORDER BY Apellidos, Nombres;
END
GO

-- =============================================
-- MEDICO (alta y listado)
-- =============================================
CREATE OR ALTER PROCEDURE sp_Medico_Insertar
    @Nombres      VARCHAR(80),
    @Apellidos    VARCHAR(80),
    @Especialidad VARCHAR(80)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Medico (Nombres, Apellidos, Especialidad)
    VALUES (@Nombres, @Apellidos, @Especialidad);

    SELECT SCOPE_IDENTITY() AS MedicoId;
END
GO

CREATE OR ALTER PROCEDURE sp_Medico_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MedicoId, Nombres, Apellidos, Especialidad
    FROM Medico
    ORDER BY Apellidos, Nombres;
END
GO

-- =============================================
-- NOTA CLINICA (CRUD + Firmar)
-- =============================================

-- RF-01 Crear: la nota siempre nace en BORRADOR
CREATE OR ALTER PROCEDURE sp_NotaClinica_Insertar
    @PacienteId    INT,
    @MedicoId      INT,
    @FechaConsulta DATETIME2,
    @Diagnostico   VARCHAR(500),
    @NotasPaciente VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO NotaClinica (PacienteId, MedicoId, FechaConsulta, Diagnostico, NotasPaciente, Estado)
    VALUES (@PacienteId, @MedicoId, @FechaConsulta, @Diagnostico, @NotasPaciente, 'BORRADOR');

    SELECT SCOPE_IDENTITY() AS NotaClinicaId;
END
GO

-- RF-02 Listar: incluye nombres de paciente y médico para mostrarlos en la grilla
CREATE OR ALTER PROCEDURE sp_NotaClinica_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        n.NotaClinicaId,
        n.PacienteId,
        p.Nombres + ' ' + p.Apellidos AS Paciente,
        n.MedicoId,
        m.Nombres + ' ' + m.Apellidos AS Medico,
        n.FechaConsulta,
        n.Diagnostico,
        n.NotasPaciente,
        n.Estado
    FROM NotaClinica n
    INNER JOIN Paciente p ON p.PacienteId = n.PacienteId
    INNER JOIN Medico   m ON m.MedicoId   = n.MedicoId
    ORDER BY n.FechaConsulta DESC;
END
GO

-- RF-03 Editar: solo si la nota está en BORRADOR (control A.5.33)
CREATE OR ALTER PROCEDURE sp_NotaClinica_Actualizar
    @NotaClinicaId INT,
    @PacienteId    INT,
    @MedicoId      INT,
    @FechaConsulta DATETIME2,
    @Diagnostico   VARCHAR(500),
    @NotasPaciente VARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Estado VARCHAR(10);
    SELECT @Estado = Estado FROM NotaClinica WHERE NotaClinicaId = @NotaClinicaId;

    IF @Estado IS NULL
    BEGIN
        RAISERROR('La nota clínica no existe.', 16, 1);
        RETURN;
    END

    IF @Estado <> 'BORRADOR'
    BEGIN
        RAISERROR('No se puede editar una nota clínica FIRMADA.', 16, 1);
        RETURN;
    END

    UPDATE NotaClinica
    SET PacienteId    = @PacienteId,
        MedicoId      = @MedicoId,
        FechaConsulta = @FechaConsulta,
        Diagnostico   = @Diagnostico,
        NotasPaciente = @NotasPaciente
    WHERE NotaClinicaId = @NotaClinicaId;
END
GO

-- RF-04 Eliminar: solo si la nota está en BORRADOR (control A.5.33)
CREATE OR ALTER PROCEDURE sp_NotaClinica_Eliminar
    @NotaClinicaId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Estado VARCHAR(10);
    SELECT @Estado = Estado FROM NotaClinica WHERE NotaClinicaId = @NotaClinicaId;

    IF @Estado IS NULL
    BEGIN
        RAISERROR('La nota clínica no existe.', 16, 1);
        RETURN;
    END

    IF @Estado = 'FIRMADA'
    BEGIN
        RAISERROR('No se puede eliminar una nota clínica FIRMADA.', 16, 1);
        RETURN;
    END

    DELETE FROM NotaClinica WHERE NotaClinicaId = @NotaClinicaId;
END
GO

-- RF-05 Firmar: solo permite pasar de BORRADOR a FIRMADA
CREATE OR ALTER PROCEDURE sp_NotaClinica_Firmar
    @NotaClinicaId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Estado VARCHAR(10);
    SELECT @Estado = Estado FROM NotaClinica WHERE NotaClinicaId = @NotaClinicaId;

    IF @Estado IS NULL
    BEGIN
        RAISERROR('La nota clínica no existe.', 16, 1);
        RETURN;
    END

    IF @Estado = 'FIRMADA'
    BEGIN
        RAISERROR('La nota clínica ya está FIRMADA.', 16, 1);
        RETURN;
    END

    UPDATE NotaClinica
    SET Estado = 'FIRMADA'
    WHERE NotaClinicaId = @NotaClinicaId;
END
GO

-- =============================================
-- TRIGGER: protege las notas FIRMADAS (control A.5.33)
-- Se ejecuta automáticamente en cada UPDATE o DELETE sobre NotaClinica.
-- Aunque alguien haga un UPDATE o DELETE directo (sin pasar por los SPs),
-- si la nota ya estaba FIRMADA el cambio se revierte.
-- =============================================
CREATE OR ALTER TRIGGER trg_NotaClinica_ProtegerFirmadas
ON NotaClinica
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- "deleted" contiene las filas como estaban ANTES del cambio
    IF EXISTS (SELECT 1 FROM deleted WHERE Estado = 'FIRMADA')
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR('Una nota clínica FIRMADA no se puede modificar ni eliminar.', 16, 1);
    END
END
GO
