USE [PasadenaApp]
GO

/****** Object:  Table [auth].[Usuario]    Script Date: 26/4/2020 17:34:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [auth].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCedula] [nvarchar](20) NULL,
	[Nombres] [nvarchar](100) NULL,
	[Apellidos] [nvarchar](100) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Email] [nvarchar](80) NULL,
	[Contraseña] [nvarchar](100) NULL,
	[CiudadId] [int] NULL,
	[PuntoVentaId] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [auth].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Ciudad] FOREIGN KEY([CiudadId])
REFERENCES [loc].[Ciudades] ([CiudadId])
GO

ALTER TABLE [auth].[Usuarios] CHECK CONSTRAINT [FK_Usuario_Ciudad]
GO

ALTER TABLE [auth].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_PuntoVenta] FOREIGN KEY([PuntoVentaId])
REFERENCES [loc].[PuntosDeVentas] ([PuntoVentaId])
GO

ALTER TABLE [auth].[Usuarios] CHECK CONSTRAINT [FK_Usuario_PuntoVenta]
GO


