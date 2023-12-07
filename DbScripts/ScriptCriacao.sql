-- 1- Criar o Banco
CREATE DATABASE programacao_do_zero;

-- 2- Usar o banco (ex. programacao_do_zero)
USE programacao_do_zero;

-- 3- Criar tabela usuário
CREATE TABLE usuario (
    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    sobrenome VARCHAR(150) NOT NULL,
    telefone VARCHAR(15) NOT NULL,
    email VARCHAR(50) NOT NULL,
    genero VARCHAR(20) NOT NULL,
    senha VARCHAR(30) NOT NULL,
    usuarioGuid VARCHAR(36) NOT NULL,
    PRIMARY KEY (id)
);

-- 3.1- Criar tabela Endereço
CREATE TABLE endereco (
    id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
    cidade VARCHAR(250) NOT NULL,
    complemento VARCHAR(150) NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY (id) 
);

--3.2- Criar tabela Produto
CREATE TABLE produto (
    id INT NOT NULL AUTO_INCREMENT,
    nomeProduto VARCHAR(180) NOT NULL,
    codigoProduto VARCHAR(30) NOT NULL,
    precoProduto VARCHAR(6) NOT NULL,
    quantEstoque VARCHAR(32) NOT NULL,
    prodGuid VARCHAR(36) NOT NULL,
    PRIMARY KEY (id)
);

-- Alterar uma tabel (ex. tabela usuário)
ALTER TABLE usuario ADD usuarioGuid VARCHAR(36) NOT NULL;

-- 4- Relacionar as tabelas usuario e endereco
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- 5- Linkar as tabelas endereço com a usuário por uma chave estrangeira "FK_usuario" (coluna na tabela
-- endereco) referenciada na coluna usuario id na tabela usuario
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- 6- Inserir Usuário na tabela usuario
INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha)
VALUES ('Rafael', 'Grigolo', '(11) 96525-0808', 'rafaeleliasgri@gmail.com', 'Masculino', 'teste123');

-- 6.1- Inserir um segundo usuário
INSERT INTO usuario(nome, sobrenome, telefone, email, genero, senha)
VALUES ('Robert', 'Paulson', '(03) 97425-0195', 'paulsonrobert241@gmail.com', 'Masculino', 'teste123');

-- 7- Exibir todos os dados de uma tabela (ex. tabela usuário)
SELECT * FROM usuario;

-- 7.1 - Exibir apenas uma linha de uma tabela (ex. tabela usuário)
SELECT * FROM usuario WHERE email = 'rafaeleliasgri@gmail.com';
--OBS.: O comando WHERE pode ser um campo de qualquer coluna (no caso foi a coluna e-mail)

-- 8- Alterar campo na linha da tabela
UPDATE usuario SET telefone = '11 966648790' WHERE id = 2;

-- 9- Excluir linha toda da tabela
DELETE FROM usuario WHERE id = 2; 

-- 9.1 Excluir várias linhas da tabela
DELETE FROM usuario WHERE id IN (2,3); 

-- 9.2 Outra forma de excluir várias linhas da tabela
DELETE FROM usuario WHERE id > 2;
--OBS.: Deleta todas as linhas acima do id 2

--9.3 Apagar tudo da tabela (ex. tabela usuario)
DELETE FROM usuario WHERE id > 0;

/* To rename a column in MySQL the following syntax is used:*/
ALTER TABLE produto RENAME COLUMN quantEstoque TO quantidadeEstoque;






