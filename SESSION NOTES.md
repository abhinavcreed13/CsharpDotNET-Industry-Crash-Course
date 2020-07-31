# Session Notes

## Outline: PhoneBook Console App (Backend + ADO.NET framework)

- BACKEND:
	1. SQL Server Intro - SSMS
	2. Phonebook Application DB Setup
	3. SQL DDL queries - Create, drop, Insert
	4. SQL DML queries - Select/Update/Delete
	5. Stored Procedures - SelectAll/SelectSome

- MIDDLEWARE (CONSOLE APPLICATION):
	1. Visual Studio Intro
	2. Connecting to SQL Server using C#
	3. Fetch records using query (online mode)
	4. Fetch records using query (offline mode)
	5. Fetch records using stored procedure - AllUsers/ParticularUser
	6. Making Code Modular - Config, Interface, Class
	7. Github Integration (Extra time if possible)

## OUTLINE (Phonebook UI App)

- SQL Server - Foreign keys, Join statements

- C# Modularity - Class libraries
	- DataAccessLayer (DAL)

- ASP.NET MVC concepts
	- Request, Response Lifecycle
	- Routing, Controllers, Views
	- Razor pages
	- Models
	- Rendering Views with dummy data

- ASP.NET MVC with SQL Server
	- Getting data with DAL layer
	- Offline manipulation of data
	- Rendering Views with data
	- Manipulating data in Razor pages

- ASP.NET MVC with HTML helpers (CRUD)
	- Insert operation on UserData
	- Redirection + Partial Pages
	- Update operation on UserData (Homework 1)
	- Delete operation on UserData (Homework 2)
	- Multiple Page Design
	- New Page + Controller + Routing
	- Insert Operation on UserPhoneBook (HW 3)
	- Update Operation (Homework 4)
	- Delete Operation (Homework 5)

## OUTLINE (ASP.NET MVC 5 + Entity Framework 6)
### (Library Management UI Application)

- ASP.NET MVC with Entity Framework Intro
	- Entity Framework Basics
	- Installation
	- Configuration
	- DBContext + Data Initialization
	- C# concepts - Inheritance + overridding
- Implementing Books Management
	- Integrating with entity framework
	- Create operation
	- Details operation
	- @HTML helpers concepts
	- ValidationMessage, EditorFor
	- ClassAttributes, Routing object values
	- Update operation - EntityState + Bind
	- Delete operation (HW1)
	
- Implementing Customer Management
	- Model + CRUD scaffolding
	- C# Delegates concept + Lambda expressions

- ASP.NET MVC EF relationship + Navigation props
	- Borrow History Model + CRUD scaffolding
	- Enable code-first migrations

- ASP.NET Eager Loading + Projections
	- Book Availability - Include() + Book Actions

- ASP.NET EF 6 App Completion
	- Borrow book
	- Return book


## Library Management UI Application + MySQL DAL

- Installing MySQL community edition
	- Installing MySQL workbench

- Create your MySQL scheme
	- Create Statement: 
		- Book, Customer, BorrowHistory
	- Insert statement: Book, Customer
	- Stored Procedures
		- GetAll, Get for Book, Customer
		- Create, Update, delete
			- Book, Customer (HW)

- Connecting MySQL with C# DAL layer
	- Installing MySql.Data package
	- C# Concept: Generic Function + Constraint
	- ConnectionString MySQL: throw, throw ex
	- Books Management
		- GetAllBooks UI
		- Get details of a book: 
			- TempData + LINQ / MySQL Proc
		- Create/Edit/Delete book (HW)
	- Customer Management
		- GetAllCustomers, GetCustomer
		- Create/Edit/Delete customer (HW)
	- Borrow Histories
		- Book Availability: Borrow, Return
		- Borrow Action + GetAllBorrowHistories
		- Return Action
		- Fixing Borrow History Main Page Titles

## Library Management UI Application + MySQL EF 6

- Installation & Configuration
	- Install Entity Framework 6
	- Install Mysql.data.entity
	- Create Models: Book, Customer
	- Create DBContext + DBInitializer 
	- Configuration + Migration
	- DBInitilization using update-database

- Implement books management (scaffolding trick)

- Implement customer management (scaffolding trick)

- Implement Borrow Histories
	- Update-database + Avoid Seed
	- Book Availability
	- Scaffolding Trick
	- Borrow Book
	- Return Book

## OUTLINE - Movie Price Tracker Application + REST API

- Planning the application
- Create The Movie DB account
	- Register for APIkey
	- Test example api using postman with APIkey
- Create MoviePriceTrackerRestAPI Project
	- Create testapi with dummy data
	- Consuming MovieDB Rest API in C#
		- HttpClient
		- RestSharp + JSON Model
	- URLBuilder + MovieDbWrapper (Configurable)
	- MovieDetailsAPI with configurable id
- Create MoviePriceTrackerWebClient (MVC 5)
	- Consume MoviePriceTrackerRestAPI
	- Fixing poster path + Details View
	- Custom configurations - ApiUrls + Getter/Setter
- Adding Movie Search View
	- Create Search Movie API
	- Consuming API with HttpPost + Results
	- Improving UI
- Modifying API to include movie id
- Track Movie Price
	- Adding dynamic UI update - javascript + jquery
	- Adding movie to track price
		- Create TrackMovie Api
		- Using ajax to hit API from JS
		- Adding random price from API
	- Show tracking in search results
	- Remove tracking
		- Using Javascript
		- Using MVC route


## OUTLINE (Mobile Shopping Application - SPA)

- Planning your application
- Using SPA using VS template
	- Understanding structure
	- Understanding routing + viewmodels (knockout)
	- Disabling Authentication on Home Page
	- Adding DataApiController + Connecting with UI
- Generating Mobile Phone Data (.NET CORE 3)
	- Connecting flexi API + getting data + random price
	- Connecting EntityFrameworkCore
	- Dumping data to SQL server
- Enhancing Application with data
	- Connecting EF6 with UI 
		- Code-First pattern (won't work!)
		- Database-First pattern
	- Create + Test GetPhoneData API
	- AJAX + ko 'foreach' binding (dynamic!)
	- Add to cart button with ko 'attr' binding
- Dynamic Shopping Cart



