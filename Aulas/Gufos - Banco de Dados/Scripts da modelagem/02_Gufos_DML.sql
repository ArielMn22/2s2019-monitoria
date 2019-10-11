USE Gufos;

INSERT INTO Tipo_usuario	(Titulo)
VALUES						('Administrador'),
							('Aluno');

INSERT INTO Usuario			(Nome, Email, Senha, Tipo_usuario_id)
VALUES						('Administrador','adm@adm.com','123',1),
							('Paulo','paulo@email.com','123',2),
							('Priscila','priscila@email.com','123',2),
							('Ariel','ariel@email.com','123',2);

INSERT INTO Localizacao		(CNPJ, Razao_social, Endereco)
VALUES						('12345678912345','Escola SENAI de Informatica','Al. Barão de Limeira, 539');

INSERT INTO Categoria		(Titulo)
VALUES						('Desenvolvimento'),
							('HTML + CSS'),
							('Marketing');

INSERT INTO Evento			(Titulo, Categoria_id, Acesso_livre, Data_evento, Localizacao_id)
VALUES						('C#',2,0,'2019-08-06T18:00:00',1),
							('Estrutura Semântica',2,1,'2019-08-07T19:00:00',1);

INSERT INTO Presenca		(Evento_id, Usuario_id, Status)
VALUES						(1,2,'AGUARDANDO'),
							(1,3,'CONFIRMADO')

UPDATE Evento SET Categoria_id = 1 WHERE Evento_id = 1;