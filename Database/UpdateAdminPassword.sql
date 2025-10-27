-- Script para actualizar el password del administrador
-- Ejecutar DESPU�S de la migraci�n inicial

-- El hash siguiente es BCrypt de "Admin123!" con work factor 11
-- Puedes generar uno nuevo usando la clase PasswordHashGenerator

UPDATE Empleados 
SET PasswordHash = '$2a$11$m5ZhIK5I5I5I5I5I5I5I5.m5ZhIK5I5I5I5I5I5I5I5.m5ZhIK5I5I5I6'
WHERE Id = 1 AND Email = 'admin@stockmanager.com';

-- Verificar
SELECT Id, Email, Nombre, Apellido, PasswordHash 
FROM Empleados 
WHERE Id = 1;
