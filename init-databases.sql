-- Script de inicialização dos bancos de dados
-- Executar em SQL Server Management Studio ou Azure Data Studio

-- Criar database SolutionKitchen_Chef
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SolutionKitchen_Chef')
BEGIN
    CREATE DATABASE SolutionKitchen_Chef;
END

-- Criar database SolutionKitchen_Garcom
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SolutionKitchen_Garcom')
BEGIN
    CREATE DATABASE SolutionKitchen_Garcom;
END

-- Usar database Chef
USE SolutionKitchen_Chef;

-- Criar tabela de Pratos
IF NOT EXISTS (SELECT * FROM information_schema.tables WHERE table_name = 'Pratos')
BEGIN
    CREATE TABLE Pratos (
        Id INT PRIMARY KEY,
        Nome NVARCHAR(255) NOT NULL,
        Descricao NVARCHAR(500)
    );
END

-- Criar tabela de Pedidos
IF NOT EXISTS (SELECT * FROM information_schema.tables WHERE table_name = 'Pedidos')
BEGIN
    CREATE TABLE Pedidos (
        Id INT PRIMARY KEY,
        Quantidade INT,
        PrecoUnitario DECIMAL(10, 2),
        Status NVARCHAR(50) DEFAULT 'Pendente',
        MetodoPagamento INT,
        PessoaNome NVARCHAR(255)
    );
END

-- Usar database Garcom
USE SolutionKitchen_Garcom;

-- Criar tabela de Pratos
IF NOT EXISTS (SELECT * FROM information_schema.tables WHERE table_name = 'Pratos')
BEGIN
    CREATE TABLE Pratos (
        Id INT PRIMARY KEY,
        Nome NVARCHAR(255) NOT NULL,
        Descricao NVARCHAR(500)
    );
END

-- Criar tabela de Pedidos
IF NOT EXISTS (SELECT * FROM information_schema.tables WHERE table_name = 'Pedidos')
BEGIN
    CREATE TABLE Pedidos (
        Id INT PRIMARY KEY,
        Quantidade INT,
        PrecoUnitario DECIMAL(10, 2),
        Status NVARCHAR(50) DEFAULT 'Pendente',
        MetodoPagamento INT,
        PessoaNome NVARCHAR(255)
    );
END

-- Inserir dados de exemplo
USE SolutionKitchen_Chef;

INSERT INTO Pratos (Id, Nome, Descricao) VALUES 
(1, 'Pasta Carbonara', 'Pasta clássica com ovos, queijo e bacon'),
(2, 'Bife à Parmegiana', 'Bife empanado coberto com queijo e molho');

USE SolutionKitchen_Garcom;

INSERT INTO Pratos (Id, Nome, Descricao) VALUES 
(1, 'Pasta Carbonara', 'Pasta clássica com ovos, queijo e bacon'),
(2, 'Bife à Parmegiana', 'Bife empanado coberto com queijo e molho');
