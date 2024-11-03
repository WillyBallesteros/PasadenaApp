USE [PasadenaApp]
GO

/****** Object:  Table [loc].[Ciudad]    Script Date: 26/4/2020 17:29:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [loc].[Ciudades](
	[CiudadId] [int] IDENTITY(1,1) NOT NULL,
	[DepartamentoId] [int] NULL,
	[CiudadNombre] [nvarchar](100) NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CiudadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [loc].[Ciudades]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad_Departamento] FOREIGN KEY([DepartamentoId])
REFERENCES [loc].[Departamentos] ([DepartamentoId])
GO

ALTER TABLE [loc].[Ciudades] CHECK CONSTRAINT [FK_Ciudad_Departamento]
GO
