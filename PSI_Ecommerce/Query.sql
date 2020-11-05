/*
Created: 01/11/2020
Modified: 01/11/2020
Model: Microsoft SQL Server 2017
Database: MS SQL Server 2017
*/


-- Create tables section -------------------------------------------------

-- Table Usuario

CREATE TABLE [Usuario]
(
 [IdUsuario] Smallint NOT NULL,
 [Nome] Char(20) DEFAULT Nome NOT NULL,
 [Senha] Char(20) NOT NULL,
 [Email] Char(20) NOT NULL,
 [Username] Char(20) NOT NULL
)
go

-- Add keys for table Usuario

ALTER TABLE [Usuario] ADD CONSTRAINT [PK_Usuario] PRIMARY KEY ([IdUsuario])
go

ALTER TABLE [Usuario] ADD CONSTRAINT [IdUsuario] UNIQUE CLUSTERED ([IdUsuario])
go

ALTER TABLE [Usuario] ADD CONSTRAINT [Email] UNIQUE CLUSTERED ([Email])
go

ALTER TABLE [Usuario] ADD CONSTRAINT [Username] UNIQUE CLUSTERED ([Username])
go

-- Table Contato

CREATE TABLE [Contato]
(
 [IdContato] Smallint NOT NULL,
 [IdUsuario] Smallint NOT NULL,
 [Telefone] Char(20) NOT NULL
)
go

-- Add keys for table Contato

ALTER TABLE [Contato] ADD CONSTRAINT [PK_Contato] PRIMARY KEY ([IdContato],[IdUsuario])
go

ALTER TABLE [Contato] ADD CONSTRAINT [IdContato] UNIQUE CLUSTERED ([IdContato])
go

-- Table Anuncio

CREATE TABLE [Anuncio]
(
 [IdAnuncio] Smallint NOT NULL,
 [IdUsuario] Smallint NOT NULL,
 [Titulo] Char(20) NOT NULL,
 [Valor] Decimal(10,2) NOT NULL,
 [Descricao] Text NULL
)
go

-- Add keys for table Anuncio

ALTER TABLE [Anuncio] ADD CONSTRAINT [PK_Anuncio] PRIMARY KEY ([IdAnuncio],[IdUsuario])
go

ALTER TABLE [Anuncio] ADD CONSTRAINT [IdAnuncio] UNIQUE CLUSTERED ([IdAnuncio])
go

-- Table Avaliacao

CREATE TABLE [Avaliacao]
(
 [IdAnuncio] Smallint NOT NULL,
 [IdUsuario] Smallint NOT NULL,
 [Descricao] Text NOT NULL,
 [Nota] Smallint NOT NULL
)
go

-- Add keys for table Avaliacao

ALTER TABLE [Avaliacao] ADD CONSTRAINT [PK_Avaliacao] PRIMARY KEY ([IdAnuncio],[IdUsuario])
go

-- Table Foto

CREATE TABLE [Foto]
(
 [IdFoto] Smallint NOT NULL,
 [IdAnuncio] Smallint NOT NULL,
 [IdUsuario] Smallint NOT NULL,
 [Imagem] Image NOT NULL
)
go

-- Add keys for table Foto

ALTER TABLE [Foto] ADD CONSTRAINT [PK_Foto] PRIMARY KEY ([IdFoto],[IdAnuncio],[IdUsuario])
go

ALTER TABLE [Foto] ADD CONSTRAINT [IdFoto] UNIQUE CLUSTERED ([IdFoto])
go

-- Table Comentario

CREATE TABLE [Comentario]
(
 [IdComentario] Smallint NOT NULL,
 [IdAnuncio] Smallint NOT NULL,
 [IdUsuario] Smallint NOT NULL,
 [FK_IdComentario] Smallint NULL,
 [FK_IdAnuncio] Smallint NULL,
 [FK_IdUsuario] Smallint NULL,
 [Texto] Text NOT NULL
)
go

-- Create indexes for table Comentario

CREATE INDEX [IX_Relationship6] ON [Comentario] ([FK_IdComentario],[FK_IdAnuncio],[FK_IdUsuario])
go

-- Add keys for table Comentario

ALTER TABLE [Comentario] ADD CONSTRAINT [PK_Comentario] PRIMARY KEY ([IdComentario],[IdAnuncio],[IdUsuario])
go

ALTER TABLE [Comentario] ADD CONSTRAINT [IdComentario] UNIQUE CLUSTERED ([IdComentario])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [Contato] ADD CONSTRAINT [] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario] ([IdUsuario]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Anuncio] ADD CONSTRAINT [] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario] ([IdUsuario]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Avaliacao] ADD CONSTRAINT [Relationship3] FOREIGN KEY ([IdAnuncio], [IdUsuario]) REFERENCES [Anuncio] ([IdAnuncio], [IdUsuario]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Foto] ADD CONSTRAINT [] FOREIGN KEY ([IdAnuncio], [IdUsuario]) REFERENCES [Anuncio] ([IdAnuncio], [IdUsuario]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Comentario] ADD CONSTRAINT [] FOREIGN KEY ([IdAnuncio], [IdUsuario]) REFERENCES [Anuncio] ([IdAnuncio], [IdUsuario]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Comentario] ADD CONSTRAINT [Relationship6] FOREIGN KEY ([FK_IdComentario], [FK_IdAnuncio], [FK_IdUsuario]) REFERENCES [Comentario] ([IdComentario], [IdAnuncio], [IdUsuario]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




