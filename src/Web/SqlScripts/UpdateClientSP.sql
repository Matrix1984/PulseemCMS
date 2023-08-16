 
CREATE PROCEDURE UpdateClient
	   @Cellphone vARCHAR(12),
      @Email varchar(500),
   @ClientName varchar(100),
    @EmailStatus bit,
    @SmsStatus bit,
     @ClientId bigint 
AS
BEGIN 
	
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

	SET NOCOUNT ON; 

    UPDATE Clients SET 
    Cellphone = @Cellphone,
    Email= @Email,
    ClientName=@ClientName,
    EmailStatus= @EmailStatus,
    SmsStatus=@SmsStatus
    WHERE ClientId=@ClientId

	IF( @SmsStatus = 1)
	BEGIN

		DECLARE @PhoneWithNoPrefix varchar(12) = IIF(LEFT(@Cellphone, 1)='0', SUBSTRING(@Cellphone,2,LEN(@Cellphone)),SUBSTRING(@Cellphone,4,LEN(@Cellphone)))

	    UPDATE Clients SET  
        SmsStatus=1
        WHERE Cellphone LIKE CONCAT('%',@PhoneWithNoPrefix);
    END;

COMMIT TRANSACTION; 
END
GO
