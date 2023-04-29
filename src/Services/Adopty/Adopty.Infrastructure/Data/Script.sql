IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Adopter] (
    [Id] uniqueidentifier NOT NULL,
    [Photo] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [About] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Adopter] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Shelter] (
    [Id] uniqueidentifier NOT NULL,
    [Address] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Shelter] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pet] (
    [Id] uniqueidentifier NOT NULL,
    [Photo] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Age] nvarchar(max) NOT NULL,
    [Size] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [ShelterId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Pet] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pet_Shelter_ShelterId] FOREIGN KEY ([ShelterId]) REFERENCES [Shelter] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Adoption] (
    [Id] uniqueidentifier NOT NULL,
    [AdopterId] uniqueidentifier NOT NULL,
    [PetId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Adoption] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Adoption_Adopter_AdopterId] FOREIGN KEY ([AdopterId]) REFERENCES [Adopter] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Adoption_Pet_PetId] FOREIGN KEY ([PetId]) REFERENCES [Pet] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Adopter_UserId] ON [Adopter] ([UserId]);
GO

CREATE INDEX [IX_Adoption_AdopterId] ON [Adoption] ([AdopterId]);
GO

CREATE UNIQUE INDEX [IX_Adoption_PetId] ON [Adoption] ([PetId]);
GO

CREATE UNIQUE INDEX [IX_Adoption_PetId_AdopterId] ON [Adoption] ([PetId], [AdopterId]);
GO

CREATE INDEX [IX_Pet_ShelterId] ON [Pet] ([ShelterId]);
GO

CREATE UNIQUE INDEX [IX_Shelter_UserId] ON [Shelter] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230424054506_InitialMigration', N'7.0.5');
GO

COMMIT;
GO

