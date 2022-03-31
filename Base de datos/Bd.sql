create database activeone
use activeone1
create table cliente(
IdCliente int primary key identity,
NroDni varchar (50),
NombreCliente varchar (50),
Email varchar (50),
Telefono varchar (50),
Direccion varchar (50),
Fechanacimiento date,
Fechainscripcion date,
TemaInteres varchar (50),
estado bit
)

create table cd(
IdCd int primary key identity,
Condicion varchar (50),
Ubicacion varchar (50),
estado bit
)

create table Alquiler(
IdAlquiler int primary key identity,
FechaAkquiler date,
Valor decimal,
Idcliente int,
CONSTRAINT Fkcliente FOREIGN KEY (Idcliente) REFERENCES cliente (Idcliente)
)

create table sancion(
Idsancion int primary key identity,
Tipodesancion varchar (50),
Valor decimal,
Numerodiassancion int,
IdclienteSancion int,
IdAlquilerSancion int,
CONSTRAINT Fkclientesancion FOREIGN KEY (IdclienteSancion) REFERENCES cliente (Idcliente),
CONSTRAINT FkIdAlquilersancion FOREIGN KEY (IdAlquilerSancion) REFERENCES alquiler (IdAlquiler)
)
create table Detallealquiler(
IdDetallealquiler int primary key identity,
Diasdeprestamos int,
Fechadevolucion date,
IdCddetalle int,
IdAlquilerdetalle int,
CONSTRAINT FkCddetalle FOREIGN KEY (IdCddetalle) REFERENCES cd (IdCd),
CONSTRAINT FkAlquilerdetalle FOREIGN KEY (IdAlquilerdetalle) REFERENCES alquiler (IdAlquiler)
)

