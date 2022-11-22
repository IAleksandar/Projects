CREATE DATABASE Restaurant

USE Restaurant

GO
CREATE TABLE [User](
	ID BIGINT primary key,
	[name] NVARCHAR(1000) NOT NULL,
	[type] NVARCHAR(200) CHECK ([type] in ('Admin', 'Waiter')) NOT NULL,
	email NVARCHAR(500) NOT NULL UNIQUE,
	[key] BIGINT NOT NULL,
	[password] NVARCHAR(MAX) NOT NULL,
);

GO
CREATE TABLE Menu_Item(
	ID BIGINT PRIMARY KEY IDENTITY(1,1),
	Category NVARCHAR(100) NOT NULL,
	[Name] NVARCHAR(100),
	Price DECIMAL,
);

GO
CREATE TABLE [Order](
	ID BIGINT PRIMARY KEY,
	ID_User BIGINT FOREIGN KEY REFERENCES [User](ID),
	[Status] NVARCHAR(100) CHECK ([Status] in ('Open', 'Closed')),
	Table_Number INT
);

GO
CREATE TABLE Order_Item(
	ID BIGINT PRIMARY KEY IDENTITY(1,1),
	ID_Order BIGINT FOREIGN KEY REFERENCES [Order](ID),
	ID_Menu_Item BIGINT FOREIGN KEY REFERENCES Menu_Item(ID)
)

INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Appetaisers', 'Nachos', 250.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Appetaisers', 'Nachos with cheddar', 300.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Salads', 'Cesar', 280.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Salads', 'Rucola', 230.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Salads', 'Tzatziki', 320.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Salads', 'Tuna', 250.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Pizzas', 'Margarita', 230.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Pizzas', 'Napolitana', 250.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Pizzas', 'Vegetariana', 320.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Pizzas', 'Diavolo', 350.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Pizzas', 'Tuna', 350.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Pizzas', 'Prsuto', 420.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Burgers', 'Hamburger', 250.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Burgers', 'CheeseBurger', 280.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Burgers', 'Chedar CheeseBurger', 300.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Burgers', 'Double Hamburger', 320.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Burgers', 'Double Chedar CheeseBurger', 350.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Burgers', 'Chicken Burger', 300.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Deserts', 'Fruit Cheesecake', 200.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Deserts', 'Chocolate Cheesecake', 200.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Deserts', 'Tiramisu', 180.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Deserts', 'Lava Cake', 250.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Deserts', 'Apple Pie', 150.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Coffee', 'Esspreso', 60.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Coffee', 'Machiato', 80.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Coffee', 'Cappucino', 100.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Coffee', 'Frappe', 120.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Coffee', 'Late', 150.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Non Alcoholic Drinks', 'Still water', 70.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Non Alcoholic Drinks', 'Sparkling water', 70.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Non Alcoholic Drinks', 'Orange Juice', 90.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Non Alcoholic Drinks', 'Peach juice', 90.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Non Alcoholic Drinks', 'Orange', 120.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Non Alcoholic Drinks', 'Lemon', 120.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Non Alcoholic Drinks', 'Apple', 150.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Tea', 'Nane', 80.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Tea', 'Cammile', 80.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Tea', 'Black Tea', 80.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Tea', 'Jasmin', 120.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Tea', 'Rooiboss', 120.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Alcoholic Drinks', 'Capmari', 180.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Alcoholic Drinks', 'Jeger', 120.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Alcoholic Drinks', 'Vodka', 100.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Alcoholic Drinks', 'Malibu', 200.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Alcoholic Drinks', 'Khalua', 150.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Alcoholic Drinks', 'Curvazie', 350.00)
INSERT INTO Menu_Item(Category, [Name], Price)
VALUES ('Alcoholic Drinks', 'Cognac', 120.00)

GO
CREATE PROCEDURE Sign_Up(
	@ID BIGINT,
	@name NVARCHAR(1000),
	@type NVARCHAR(200),
	@email NVARCHAR(500),
	@key BIGINT,
	@password NVARCHAR(MAX)
)
AS
BEGIN
	SET NOCOUNT ON
		INSERT INTO [User] (ID, [name], [type], email, [key], [password])
		VALUES	(@ID, @name, @type, @email, @key, @password)
	SET NOCOUNT OFF
END

GO
CREATE PROCEDURE Begin_Order(
	@ID BIGINT,
    @ID_User BIGINT,
	@Table_num INT
)
AS
BEGIN
	SET NOCOUNT ON
		INSERT INTO [Order] (ID, ID_User, [Status], Table_Number)
		VALUES	(@ID, @ID_User, 'Open', @Table_num)
	SET NOCOUNT OFF
END

GO
CREATE PROCEDURE Add_Item_Order(
	@ID_Order BIGINT,
	@ID_Menu_Item BIGINT
)
AS
BEGIN
	SET NOCOUNT ON
		INSERT INTO Order_Item(ID_Order, ID_Menu_Item)
		VALUES	(@ID_Order, @ID_Menu_Item)
	SET NOCOUNT OFF
END


GO
CREATE PROCEDURE Update_Order(
	@Table_num INT
)
AS
BEGIN
	SET NOCOUNT ON
		Update [Order] 
			SET [Status] = 'Closed'
			WHERE Table_Number = @Table_num AND [Status] = 'Open'
	SET NOCOUNT OFF
END