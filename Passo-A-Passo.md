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

# Firts Controller and Razor Pages

- Checklist
	Route pattern: Controller / Acção / Id
		- each controller method is mapped to an action
	Natural Templates
	C# block in Razor Page: @{}
	Viewdata dictionary
	Tag Helpers in Razor Pages (Ex.: asp-controller and asp-ation)
	IActionResult -> é uma interface que é um super tipo genérico para todo tipo de ação, só que ele se desdobra em vários tipos especifícos.

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

	*Obs.: view´s name must be equals controller´s name
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
		Association (let´s use ICollection, which metches List, HashSet etc.. *Instantiate*
		Constructors (default and with arguments)
		Custom methods.
	Add DbSet´s in DbContext
	Add-Migration OtherEntities

	Create the classes Seller, SalesRecord, Department and the Enum SaleStatus.

	Relationship: 
	The selles can have multiple SalesRecords, but the sale belongs to only one seller.
	The seller works for only one dept, but the dept can have multiple sellers
