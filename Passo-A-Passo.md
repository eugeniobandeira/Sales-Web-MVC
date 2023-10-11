## Anotações

# Nivelamento MVC

Model: estrutura dos dados e suas transformações (domain model), também chamado de "o sistema", composto de Entities e Services (relacionados às entidades), repositories são objetos que acessam dados persistentes.
Controllers: receber e tratar as interações do usuário com o sistema.
View: definir a estrutura e comportamento das telas

# Nivelamento Entity Framework

ORM (Object Relational Mapping): permite programar em nivel de objetos e comunicar de forma transparente com um banco de dados relacional.
O que é feito nos objetos, é mapeado no banco de dados relacional automaticamente.

- Principais classes
*DBContext*: é um objeto que encapsula uma sessão com o banco de dados para um determinado modelo de dados (representado por DBSet´s).
	É usado para consultar e salvar entidade no banco de dados.
	Define quais entidades farão parte do modelo de dados do sistema.
	Pode definir várias configurações.
	É uma combinação dos parões Unity of Work e Repository, sendo:
		Unity of work: mantém uma lista de objetos afetados por uma transação e coorderna a escrita e trata possíveis problemas de concorrência.
		Repository: define um objeto capaz de realizar operações de acesso a dados (consultar, salvar, atualizar, deletar) para uma entidade.
		
*DBSet<TEntity>*: representa a coleção de entidades de um dado tipo em um contexto. Tipicamente corresponde a uma tabela do banco de dados.

- Processo para se executar operações no BD: LINQ -> DBSet -> SQL -> BD.

# Providers

São as implementações da comunicação com banco de específicos. Podemos citar o SQL Server, Oracle Database, MySQL, PostgreSQL, SQL Lite.

***************************************************************************************


