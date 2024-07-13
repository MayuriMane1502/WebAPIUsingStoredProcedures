Created table in master database 20 server

CREATE TABLE Customer (
    CustId int,
    CustName varchar(20),
    AcctType varchar(20),
    AcctNo char(12),
    City varchar(255)
);

INSERT INTO Customer
VALUES (1003, 'Ram', 'RF', '120987654321','Mumbai');

select * from Customer

=========================================
Created stored procedure 
-----------------------------------
CREATE PROC Sp_Customer_Add
	@CustId int,
    @CustName varchar(20),
    @AcctType varchar(20),
    @AcctNo char(12),
    @City varchar(255)

AS
BEGIN
Insert Into dbo.Customer
(
	CustId,
	CustName,
	AcctType,
	AcctNo,
	City
)
Values
(
@CustId,
@CustName,
@AcctType,
@AcctNo,
@City
)
END
===================================================
CREATE PROC Sp_Customer_Get
AS
BEGIN
	select * from Customer;
END
==================================================
CREATE PROC Sp_Customer_GetByID(@CustId int)
AS
BEGIN
	select * from Customer where CustId = @CustId;
END
===================================================
CREATE Proc Sp_Customer_Update(@CustId int,
    @CustName varchar(20),
    @AcctType varchar(20),
    @AcctNo char(12),
    @City varchar(255))

AS
BEGIN
	UPDATE Customer SET CustName=@CustName, AcctType=@AcctType, AcctNo=@AcctNo, City=@City where CustId=@CustId;
END
================================================
CREATE PROC Sp_Customer_Delete(@CustId int)
AS
BEGIN
	delete from Customer where CustId = @CustId;
END