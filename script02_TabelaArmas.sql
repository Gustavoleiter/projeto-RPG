BEGIN TRANSACTION;
GO

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] ON;
INSERT INTO [Armas] ([Id], [Dano], [Nome])
VALUES (1, 100000, N'Excalibur'),
(2, 10000, N'Zanpakto'),
(3, 1000, N'Rifle'),
(4, 250, N'Cutelo'),
(5, 500, N'Glock'),
(6, 50, N'Cajado'),
(7, 150, N'Esmaga-Tama');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] OFF;
GO

UPDATE [Personagens] SET [Classe] = 0, [Defesa] = 0, [Forca] = 0, [Inteligencia] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230404231614_[MigracaoArma]', N'7.0.4');
GO

COMMIT;
GO

