USE [PasadenaApp]
GO

/****** Object:  Table [auth].[RolesDeUsuarios]    Script Date: 26/4/2020 17:36:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [auth].[RolesDeUsuarios](
	[UsuarioId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC,
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [auth].[RolesDeUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Rol] FOREIGN KEY([RolId])
REFERENCES [auth].[Roles] ([RolId])
GO

ALTER TABLE [auth].[RolesDeUsuarios] CHECK CONSTRAINT [FK_UsuarioRol_Rol]
GO

ALTER TABLE [auth].[RolesDeUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [auth].[Usuarios] ([UsuarioId])
GO

ALTER TABLE [auth].[RolesDeUsuarios] CHECK CONSTRAINT [FK_UsuarioRol_Usuario]
GO


