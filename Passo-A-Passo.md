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

# Firts Controller and Razor Pages

- Checklist
	Route pattern: Controller / Ac��o / Id
		- each controller method is mapped to an action
	Natural Templates
	C# block in Razor Page: @{}
	Viewdata dictionary
	Tag Helpers in Razor Pages (Ex.: asp-controller and asp-ation)
	IActionResult -> � uma interface que � um super tipo gen�rico para todo tipo de a��o, s� que ele se desdobra em v�rios tipos especif�cos.

	Type and method Builder
	ViewResult --> View
	PartialResult --> PartialView
	ContentResult --> Content
	RedirectResult --> Redirect
	RedirectToRouteResult --> RedirectToAction (Ex.: "Index", "Home", new { page = 1, sortBy = price }))
	JsonResult --> Json
	FileResult --> File
	HttpNotFoundResult --> HttpNotFound
	EmptyResult --> -

# Firts MVC - Department

- Checklist
	Create new folder ViewModels e move ErrorViewModel (including namespace)
		- ctrl + shift = b to fix references
	Create class Models/Department
	Create controller: MVC Controller Empty
		- Name: DepartmentsController
		- Instantiate a List<Department> and reurn it as View method parameter.

	*Obs.: view�s name must be equals controller�s name
	Create new folder Views/Departments --> Add --> View
		View name: Index
		Template: List
		Model class: Department
		Change title to Departmets
		Notice:
			@Model definition
			intelisense for model
			Helper methods
			@foreach block

**********************************************************************

# Deleting Department View and Controller

- Checklist
	Delete Controller
	Delete folder Views/Departments

# CRUD Scaffolding

- Right button Controllers --> Add --> New Scaffolded Item
	MVC controller with views, using Entity Framework
	Model class: Department
	Data context class: + and accept the name
	Views (options): all three
	Controller name: DepartmentsController

# MySQL Adaptation and First Migration

- Checklist
	Em appsettings.json, set connection string:
		"server=localhost;userid=root;password=1234;database=saleswebmvcappdb"
	
	At Program.cs, fix DBContext definition for dependency injection system:
	services.AddDbContext<SalesWebMVCAppContext>(options => options.UseMySql(Configuration
		.GetConnectionString("SalesWebMvcAppContext"), builder => builder.MigrationsAssembly("SalesWebMvcApp")));

	Install MySQL provider:
		Open Nuget Package Manager Console
		Install-Package Pomelo.EntityFrameworkCore.MySQL

	Create first migration --> Pacakge Manager -> Add-Migration Initial, right after... Update-Database

*********************************************************************************

# Changing Theme 
- Checklist
	Go to bootswatch
	Choose theme
	Download bootstrap.css
		Rename the file
		Save file in wwwroot/lib/bootstrap/dist/css
	Open _Layout.cshtml
		Update bootstrap reference

********************************************************************************

# Other Entities and Second Migration
- Checklist

	Implement domain model
		Basic atttributes
		Association (let�s use ICollection, which metches List, HashSet etc.. *Instantiate*
		Constructors (default and with arguments)
		Custom methods.
	Add DbSet�s in DbContext
	Add-Migration OtherEntities

	Create the classes Seller, SalesRecord, Department and the Enum SaleStatus.

	Relationship: 
	The selles can have multiple SalesRecords, but the sale belongs to only one seller.
	The seller works for only one dept, but the dept can have multiple sellers
