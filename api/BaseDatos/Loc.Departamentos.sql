USE [PasadenaApp]
GO

/****** Object:  Table [loc].[Departamentos]    Script Date: 26/4/2020 17:28:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [loc].[Departamentos](
	[DepartamentoId] [int] IDENTITY(1,1) NOT NULL,
	[DepartamentoNombre] [nvarchar](100) NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[DepartamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


