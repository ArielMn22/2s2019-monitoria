USE Gufos;

SELECT * FROM Tipo_usuario;
SELECT * FROM Usuario;
SELECT * FROM Localizacao;
SELECT * FROM Categoria ORDER BY Titulo ASC;
SELECT * FROM Evento;
SELECT * FROM Presenca;

SELECT E.*, C.*
FROM Evento AS E
JOIN Categoria AS C
ON E.Categoria_id = C.Categoria_id; -- Selecionar Eventos e Categorias

SELECT P.*, U.*, E.*
FROM Presenca P
JOIN Usuario U
ON P.Usuario_id = U.Usuario_id
JOIN Evento E
ON P.Evento_id = E.Evento_id -- Selecionar Eventos, Usuários e Presenças;

SELECT P.*, U.*, E.*, C.*
FROM Presenca P
INNER JOIN Usuario U
ON P.Usuario_id = U.Usuario_id
INNER JOIN Evento E
ON P.Evento_id = E.Evento_id
INNER JOIN Categoria C
ON E.Categoria_id = C.Categoria_id -- Selecionar Presenças, Usuários, Eventos e Categorias;

-- Criando uma VIEW para facilitar a visualização dos dados
GO
CREATE VIEW EVENTOSVIEW AS
	SELECT E.Evento_id AS #, E.Titulo, E.Localizacao_id AS #Localizacao, E.Data_evento, C.Titulo AS Categoria
	FROM EVENTO E
	INNER JOIN CATEGORIA C
	ON E.Categoria_id = C.Categoria_id
GO

SELECT * FROM EVENTOSVIEW
