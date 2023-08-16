CREATE TABLE Clients (
    ClientID bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Cellphone NVARCHAR(12) not null CHECK(LEN(Cellphone)>=10), -- Cellphone can start with 05 (len of 10 – local number) or with 9725 (len of 12 – International number) – it means that 972526292959=0526292959
    Email varchar(500) not null unique, -- Email is unique and can exists only once – It’s a required field. 
	ClientName varchar(100) not null,
    EmailStatus bit not null default(1), -- EmailStatus can have only 2 options – Removed/Active. New Email and New Cellphone will get insert with Active Status
    SmsStatus bit not null default(1) --  SmsStatus can have only 2 options – Removed/Active. New Email and New Cellphone will get insert with Active Status
);

DROP TABLE Clients

 