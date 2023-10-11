## Anota��es

# Nivelamento MVC

Model: estrutura dos dados e suas transforma��es (domain model), tamb�m chamado de "o sistema", composto de Entities e Services (relacionados �s entidades), repositories s�o objetos que acessam dados persistentes.
Controllers: receber e tratar as intera��es do usu�rio com o sistema.
View: definir a estrutura e comportamento das telas

# Nivelamento Entity Framework

ORM (Object Relational Mapping): permite programar em nivel de objetos e comunicar de forma transparente com um banco de dados relacional.
O que � feito nos objetos, � mapeado no banco de dados relacional automaticamente.

- Principais classes
*DBContext*: � um objeto que encapsula uma sess�o com o banco de dados para um determinado modelo de dados (representado por DBSet�s).
	� usado para consultar e salvar entidade no banco de dados.
	Define quais entidades far�o parte do modelo de dados do sistema.
	Pode definir v�rias configura��es.
	� uma combina��o dos par�es Unity of Work e Repository, sendo:
		Unity of work: mant�m uma lista de objetos afetados por uma transa��o e coorderna a escrita e trata poss�veis problemas de concorr�ncia.
		Repository: define um objeto capaz de realizar opera��es de acesso a dados (consultar, salvar, atualizar, deletar) para uma entidade.
		
*DBSet<TEntity>*: representa a cole��o de entidades de um dado tipo em um contexto. Tipicamente corresponde a uma tabela do banco de dados.

- Processo para se executar opera��es no BD: LINQ -> DBSet -> SQL -> BD.

# Providers

S�o as implementa��es da comunica��o com banco de espec�ficos. Podemos citar o SQL Server, Oracle Database, MySQL, PostgreSQL, SQL Lite.

***************************************************************************************


