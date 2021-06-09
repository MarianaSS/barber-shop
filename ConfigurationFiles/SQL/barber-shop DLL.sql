drop database BarberShop
create database BarberShop
use BarberShop

CREATE TABLE [Customer] (
  [id_customer] int PRIMARY KEY IDENTITY(1, 1),
  [cpf_customer] char(11) UNIQUE NOT NULL,
  [name_customer] varchar(50) NOT NULL,
  [birth_customer] date NOT NULL,
  [phone_customer] varchar(50) NOT NULL
)
GO

CREATE TABLE [Employee] (
  [id_employee] int PRIMARY KEY IDENTITY(1, 1),
  [cpf_employee] char(11) UNIQUE NOT NULL,
  [name_employee] varchar(50) NOT NULL,
  [username_employee] varchar(50) NOT NULL,
  [password_employee] varchar(50) NOT NULL,
  [salt_hash_password_employee] varchar(50) NOT NULL,
  [login_attempts] int DEFAULT (0)
)
GO

CREATE TABLE [Employee_barber] (
  [id_employee_barber] int PRIMARY KEY IDENTITY(1, 1),
  [id_employee] int,
  [salary_employee_barber] decimal(4,2)
  FOREIGN KEY ([id_employee]) REFERENCES [Employee] ([id_employee])
)
GO

CREATE TABLE [Appointment] (
  [id_appointment] int PRIMARY KEY IDENTITY(1, 1),
  [id_customer] int,
  [appointment_date_time] nvarchar(255)
  FOREIGN KEY ([id_customer]) REFERENCES [Customer] ([id_customer])
)
GO

CREATE TABLE [Payment] (
  [id_payment] int PRIMARY KEY IDENTITY(1, 1),
  [type_payment] varchar(50) NOT NULL
)
GO

CREATE TABLE [Shop] (
  [id_shop] int PRIMARY KEY IDENTITY(1, 1),
  [name_shop] varchar(20) UNIQUE NOT NULL,
  [street_shop] varchar(50) NOT NULL,
  [number_shop] int NOT NULL,
  [city_shop] varchar(50) NOT NULL,
  [state_shop] varchar(50) NOT NULL
)
GO

CREATE TABLE [ServiceInfo] (
  [id_service] int PRIMARY KEY IDENTITY(1, 1),
  [name_service] varchar(50) NOT NULL,
  [description_service] varchar(100) NOT NULL,
  [value_service] decimal(5,2) NOT NULL
)
GO

CREATE TABLE [OrderInfo] (
  [id_order_info] int PRIMARY KEY IDENTITY(1, 1),
  [id_customer] int,
  [id_employee] int,
  [id_shop] int,
  [order_date] datetime NOT NULL
  FOREIGN KEY ([id_customer]) REFERENCES [Customer] ([id_customer]),
  FOREIGN KEY ([id_employee]) REFERENCES [Employee] ([id_employee]),
  FOREIGN KEY ([id_shop]) REFERENCES [Shop] ([id_shop])
)
GO

CREATE TABLE [Product] (
  [id_product] int PRIMARY KEY IDENTITY(1, 1),
  [name_product] varchar(20),
  [description_product] varchar(50),
  [price_product] decimal(3,2)
)
GO

CREATE TABLE [Bar] (
  [id_bar] int PRIMARY KEY IDENTITY(1, 1),
  [name_bar] varchar(20)
)
GO

CREATE TABLE [Drink] (
  [id_drink] int PRIMARY KEY IDENTITY(1, 1),
  [id_bar] int,
  [description_drink] varchar(50),
  [price_drink] decimal(3,2)
  FOREIGN KEY ([id_bar]) REFERENCES [Bar] ([id_bar])
)
GO

CREATE TABLE [CashOffice] (
  [id_cash_office] int PRIMARY KEY IDENTITY(1, 1),
  [amount_cash] decimal(5,2)
)
GO

CREATE TABLE [Tool] (
  [id_tool] int PRIMARY KEY IDENTITY(1, 1),
  [name_tool] varchar(20),
  [quantity_available_tool] int
)
GO

CREATE TABLE [Equipment] (
  [id_equipment] int PRIMARY KEY IDENTITY(1, 1),
  [name_equipment] varchar(20),
  [quantity_available_equipment] int
)
GO

CREATE TABLE [OrderPayment] (
  [id_order_payment] int PRIMARY KEY IDENTITY(1, 1),
  [id_payment] int,
  [id_order_info] int,
  [id_drink] int
  FOREIGN KEY ([id_payment]) REFERENCES [Payment] ([id_payment]),
  FOREIGN KEY ([id_order_info]) REFERENCES [OrderInfo] ([id_order_info]),
  FOREIGN KEY ([id_drink]) REFERENCES [Drink] ([id_drink])
)
GO

CREATE TABLE [OrderServices] (
  [id_order_services] int PRIMARY KEY IDENTITY(1, 1),
  [id_order_info] int,
  [id_service] int,
  [id_product] int
  FOREIGN KEY ([id_order_info]) REFERENCES [OrderInfo] ([id_order_info]),
  FOREIGN KEY ([id_service]) REFERENCES [ServiceInfo] ([id_service]),
  FOREIGN KEY ([id_product]) REFERENCES [Product] ([id_product])
)
GO

CREATE TABLE [Inventory] (
  [id_inventory] int PRIMARY KEY IDENTITY(1, 1),
  [id_shop] int,
  [id_equipment] int,
  [id_tool] int,
  [id_cash_office] int
  FOREIGN KEY ([id_equipment]) REFERENCES [Equipment] ([id_equipment]),
  FOREIGN KEY ([id_tool]) REFERENCES [Tool] ([id_tool]),
  FOREIGN KEY ([id_cash_office]) REFERENCES [CashOffice] ([id_cash_office]),
  FOREIGN KEY ([id_shop]) REFERENCES [Shop] ([id_shop])
)
GO