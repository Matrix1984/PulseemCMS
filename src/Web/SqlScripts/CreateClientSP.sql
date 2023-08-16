 
CREATE PROCEDURE CreateClient
    @Cellphone varchar(12),
    @Email varchar(500), 
	@ClientName varchar(100),
	@Id bigint OUTPUT
AS
BEGIN 
 
	 IF EXISTS (SELECT 1 from Clients WHERE Email = @Email) 
    	 RETURN -1; -- Email already exists status.  

		DECLARE @ExistingCellphoneStatus bit = (SELECT top 1 SmsStatus FROM Clients WHERE Cellphone = @Cellphone); --- If you add a cellphone that exists in the DB, it should inherit its sms status

		INSERT INTO Clients (Cellphone, ClientName, Email, SmsStatus)  
		VALUES (@Cellphone,@ClientName ,  @Email, (SELECT IIF(@ExistingCellphoneStatus is not null, @ExistingCellphoneStatus, 1)))
 
		 SET @Id=SCOPE_IDENTITY();

		 RETURN 0;
END 

 DROP PROCEDURE CreateClient