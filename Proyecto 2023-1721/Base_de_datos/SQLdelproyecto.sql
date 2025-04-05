CREATE DATABASE ContactosDB;
GO

USE ContactosDB;
GO

CREATE TABLE Contactos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100)
);

-- Insertar datos de ejemplo
INSERT INTO Contactos (Nombre, Telefono, Correo) VALUES
('Juan P�rez', '809-123-4567', 'juan.perez@email.com'),
('Ana G�mez', '829-555-1212', 'ana.gomez@email.com'),
('Carlos Rodr�guez', '849-987-6543', 'carlos.rdz@email.com'),
('Laura Mart�nez', '809-321-7890', 'laura.mtz@email.com'),
('Pedro L�pez', '829-777-8888', 'pedro.lopez@email.com'),
('Mar�a Torres', '849-111-2233', 'maria.torres@email.com');
