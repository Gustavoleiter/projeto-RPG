﻿BEGIN TRANSACTION;
GO

ALTER TABLE [Armas] ADD [PersonagemId] int NOT NULL DEFAULT 0;
GO

UPDATE [Armas] SET [PersonagemId] = 6
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 2
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 5
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 7
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 3
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 4
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Personagens] SET [Nome] = N'Gustaf'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuarios] SET [PasswordHash] = 0x4F0C01B337DAD698471FAF0B361469CCBDF6200534344DDF8D60215ED99BE1EA83CD7027D90C15506A168837E9B80BFAFAEDAD27C923A3143AE7096DBD4663C9, [PasswordSalt] = 0xC6E3B15B760A03AFC8038A9588930B3288ED35C569B14EE7B14F5336115906C960859AE261B1B8709A6A126AF8BE1CA1EF4AECE003BC24747A9F8C52492D87282BB288999F65D5640937C0D10CF28D8B9E7EB9DCE8EAC0E4923F4B02E03EC7D0083656BA502E1F00B2F67E999242EDD3B9D2997F447B89736902B2D7720828BF
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_Armas_PersonagemId] ON [Armas] ([PersonagemId]);
GO

ALTER TABLE [Armas] ADD CONSTRAINT [FK_Armas_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230419004509_MigracaoUmParaUm', N'7.0.4');
GO

COMMIT;
GO
