USE [Pulseem]
GO
/****** Object:  StoredProcedure [dbo].[UpdateClient]    Script Date: 17/08/2023 8:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER PROCEDURE [dbo].[UpdateClient]
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

	BEGIN TRANSACTION; 

    UPDATE Clients SET 
    Cellphone = @Cellphone,
    Email= @Email,
    ClientName=@ClientName,
    EmailStatus= @EmailStatus,
    SmsStatus=@SmsStatus
    WHERE ClientId=@ClientId
	 

		DECLARE @PhoneWithNoPrefix varchar(12) = IIF(LEFT(@Cellphone, 1)='0', SUBSTRING(@Cellphone,2,LEN(@Cellphone)),SUBSTRING(@Cellphone,4,LEN(@Cellphone)))

	    UPDATE Clients SET  
        SmsStatus=@SmsStatus
        WHERE Cellphone LIKE CONCAT('%',@PhoneWithNoPrefix) and ClientId=@ClientId; 

COMMIT TRANSACTION; 
END
