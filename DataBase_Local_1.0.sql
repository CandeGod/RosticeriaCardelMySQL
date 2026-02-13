-- base de datos local
create database rosticeriacardel;

use rosticeriacardel;

CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    Activo BOOLEAN NOT NULL DEFAULT 1, 
    Sincronizado BOOLEAN NOT NULL DEFAULT 0,
    Imagen LONGBLOB NULL 
);


-- Tabla para Variaciones de Productos
CREATE TABLE Variaciones (
    IdVariacion INT PRIMARY KEY AUTO_INCREMENT,
    IdProducto INT NOT NULL, -- Relacionado al producto base (ejemplo: Pollo)
    NombreVariacion VARCHAR(100) NOT NULL, -- Nombre de la variación (ejemplo: Pollo Chiltepín)
    Precio DECIMAL(10, 2) NOT NULL, -- Precio específico de la variación
    Activo BOOLEAN NOT NULL DEFAULT 1, -- Si la variación está activa
    Sincronizado BOOLEAN NOT NULL DEFAULT 0,
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);


-- Tabla de Ventas
CREATE TABLE Ventas (
    IdVenta INT PRIMARY KEY AUTO_INCREMENT,
    Fecha DATETIME NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    MontoPagado DECIMAL(10, 2) NOT NULL,
    Sincronizado BOOLEAN NOT NULL DEFAULT 0,
    Cambio DECIMAL(10, 2) NOT NULL
);

-- Tabla Detalle de Venta (para los productos vendidos en cada venta)
CREATE TABLE DetalleVenta (
    IdDetalle INT PRIMARY KEY AUTO_INCREMENT,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    IdVariacion INT NULL, -- Relacionado con la variación vendida (puede ser NULL si no tiene variaciones)
    Cantidad DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    Sincronizado BOOLEAN NOT NULL DEFAULT 0,
    FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta),
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto),
    FOREIGN KEY (IdVariacion) REFERENCES Variaciones(IdVariacion)
);

-- Tabla de Corte de Caja
CREATE TABLE CorteCaja (
    IdCorte INT PRIMARY KEY AUTO_INCREMENT,
    Fecha DATETIME NOT NULL,
    MontoInicial DECIMAL(10, 2) NOT NULL,
    TotalVentas DECIMAL(10,2) NOT NULL DEFAULT 0, -- campo nuevo
    TotalGastos DECIMAL(10,2) NOT NULL DEFAULT 0, -- campo nuevo
    MontoFinal DECIMAL(10, 2) NOT NULL,
    Estado VARCHAR(20) DEFAULT 'ACTIVO',
    Sincronizado BOOLEAN NOT NULL DEFAULT 0
);

-- aun esta por validar esta tabla: 
CREATE TABLE Gastos (
    IdGasto INT PRIMARY KEY AUTO_INCREMENT,
    IdCorte INT NOT NULL,           -- Relación con el corte de caja
    Concepto VARCHAR(200) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    Sincronizado BOOLEAN NOT NULL DEFAULT 0,
    FOREIGN KEY (IdCorte) REFERENCES CorteCaja(IdCorte)
);

select * from CorteCaja;
select * from Ventas;
select * from DetalleVenta;
select * from Gastos;
select * from Productos;
select * from Variaciones;

												drop table DetalleVenta;
												drop table Ventas;
												drop table Gastos;
												drop table CorteCaja;
												drop table Variaciones;
												drop table Productos;


-- 1. antes de iniciar el proyecto por primera vez se necesita borrar los datos de la base de datos local y de la nube
-- 2. crear las tablas en ambas bases de datos
/* 3. agregar desde el programa o desde la base de datos el primer producto el cual debe de ser el POLLO, siempre debe de tener el ID 1
       (si es desde el programa se agrega automaticamente en la bd en la nube, si no agregar en la nube manualmente) */
-- 4. agregar las variaciones con el script de abajo en ambas bd
-- 5. verificar que el precio del pollo y variaciones sea el mismo, actualmente solo se puede actualizar desde la bd

insert into Variaciones (IdVariacion, IdProducto, NombreVariacion, Precio, Activo)
values (1, 1, 'Natural', 180, 1),
(2, 1, 'Adobado', 180, 1),
(3, 1, 'Chiltepín', 180, 1);

-- Datos para la base de datos local

insert into Variaciones (IdVariacion, IdProducto, NombreVariacion, Precio, Activo)
values (1, 1, 'Natural', 180, 1),
(2, 1, 'Adobado', 180, 1),
(3, 1, 'Chiltepin', 180, 1);

UPDATE Variaciones
SET Precio = 200
WHERE IdVariacion = 1;






-- ------------------------------------------------base de datos en la nube ----------------------------------------------


CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    Activo BOOLEAN NOT NULL DEFAULT 1, 
    Imagen LONGBLOB NULL 
);


-- Tabla para Variaciones de Productos
CREATE TABLE Variaciones (
    IdVariacion INT PRIMARY KEY AUTO_INCREMENT,
    IdProducto INT NOT NULL, -- Relacionado al producto base (ejemplo: Pollo)
    NombreVariacion VARCHAR(100) NOT NULL, -- Nombre de la variación (ejemplo: Pollo Chiltepín)
    Precio DECIMAL(10, 2) NOT NULL, -- Precio específico de la variación
    Activo BOOLEAN NOT NULL DEFAULT 1, -- Si la variación está activa
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);


-- Tabla de Ventas
CREATE TABLE Ventas (
    IdVenta INT PRIMARY KEY AUTO_INCREMENT,
    Fecha DATETIME NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    MontoPagado DECIMAL(10, 2) NOT NULL,
    Cambio DECIMAL(10, 2) NOT NULL
);

-- Tabla Detalle de Venta (para los productos vendidos en cada venta)
CREATE TABLE DetalleVenta (
    IdDetalle INT PRIMARY KEY AUTO_INCREMENT,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    IdVariacion INT NULL, -- Relacionado con la variación vendida (puede ser NULL si no tiene variaciones)
    Cantidad DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta),
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto),
    FOREIGN KEY (IdVariacion) REFERENCES Variaciones(IdVariacion)
);

-- Tabla de Corte de Caja
CREATE TABLE CorteCaja (
    IdCorte INT PRIMARY KEY AUTO_INCREMENT,
    Fecha DATETIME NOT NULL,
    MontoInicial DECIMAL(10, 2) NOT NULL,
    TotalVentas DECIMAL(10,2) NOT NULL DEFAULT 0, -- campo nuevo
    TotalGastos DECIMAL(10,2) NOT NULL DEFAULT 0, -- campo nuevo
    MontoFinal DECIMAL(10, 2) NOT NULL,
    Estado VARCHAR(20) DEFAULT 'ACTIVO'
);

-- aun esta por validar esta tabla: 
CREATE TABLE Gastos (
    IdGasto INT PRIMARY KEY AUTO_INCREMENT,
    IdCorte INT NOT NULL,           -- Relación con el corte de caja
    Concepto VARCHAR(200) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    Sincronizado BOOLEAN NOT NULL DEFAULT 0,
    FOREIGN KEY (IdCorte) REFERENCES CorteCaja(IdCorte)
);
