-- create schema creed;

-- create statements
/*CREATE TABLE Book (
	BookId int auto_increment PRIMARY KEY,
    Title varchar(200),
    SerialNumber varchar(200),
    Author varchar(200),
    Publisher varchar(200)
);*/

/*CREATE TABLE Customer (
	CustomerId int auto_increment PRIMARY KEY,
    Name varchar(200),
    Address varchar(200),
    Contact varchar(200)
)*/

/*CREATE TABLE BorrowHistory (
	BorrowHistoryId int auto_increment PRIMARY KEY,
    BookId int NOT NULL,
    CustomerId int NOT NULL,
    BorrowDate DATETIME NOT NULL,
    ReturnDate DATETIME,
    FOREIGN KEY(BookId) REFERENCES book(BookId),
    FOREIGN KEY(CustomerId) REFERENCES customer(CustomerId)
)*/

-- insert statements
/*INSERT INTO book(Title, SerialNumber, Author, Publisher) VALUES 
('Book1','ABCD1','Author','Pub'),
('Book2','ABCD2','Author','Pub'),
('Book3','ABCD3','Author','Pub'),
('Book4','ABCD4','Author','Pub'),
('Book5','ABCD5','Author','Pub');

INSERT INTO customer(Name, Address, Contact) VALUES
('Customer1','Add1','000'),
('Customer2','Add2','000'),
('Customer3','Add3','000'),
('Customer4','Add4','000'),
('Customer5','Add5','000');*/

-- select statement
-- Select * from book;
-- select * from customer;

-- RUD procedures
-- book
/*DELIMITER //
CREATE PROCEDURE GetAllBooks()
BEGIN
	Select * from book;
END //

DELIMITER ;*/

/*DELIMITER //
CREATE PROCEDURE GetBook(book_id INT)
BEGIN
	Select * from book where BookId = book_id;
END //

DELIMITER ;*/

-- update proc of book

-- delete proc of book

-- Customer
/*DELIMITER //
CREATE PROCEDURE GetAllCustomers()
BEGIN
	Select * from customer;
END //

DELIMITER ;*/

/*DELIMITER //
CREATE PROCEDURE GetCustomer(customer_id INT)
BEGIN
	Select * from customer where CustomerId = customer_id;
END //

DELIMITER ;*/

-- update proc of customer

-- delete proc of customer

-- borrow histories
/*DELIMITER //
CREATE PROCEDURE GetAllBorrowHistories()
BEGIN
	select BorrowHistoryId, borrowhistory.BookId, 
    borrowhistory.CustomerId, 
	Title, 
    BorrowDate, ReturnDate, Name
    from borrowhistory
    INNER JOIN book
    ON borrowhistory.BookId = book.BookId
    INNER JOIN customer
    ON borrowhistory.CustomerId = customer.CustomerId;
END //

DELIMITER ;*/

/*DELIMITER //
CREATE PROCEDURE BorrowBook(book_id INT, customer_id INT, borrow_date DATETIME)
BEGIN
	INSERT INTO borrowhistory(BookId, CustomerId, BorrowDate)
    VALUES (book_id, customer_id, borrow_date);
END //

DELIMITER ; */

/*DELIMITER //
CREATE PROCEDURE ReturnBook(borrow_history_id INT)
BEGIN
	UPDATE borrowhistory
    SET ReturnDate = NOW()
    where BorrowHistoryId = borrow_history_id;
END //

DELIMITER ;*/
