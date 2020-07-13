# Session Notes

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

- Install Entity Framework 6
- Install Mysql.data.entity
- Create Models: Book, Customer
- Create DBContext + DBInitializer 
- Configuration + Migration
- DBInitilization using update-database

- Implement books management (scaffolding trick)

- Implement customer management (scaffolding trick)
