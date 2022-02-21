-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE spUpdate
	-- Add the parameters for the stored procedure here
	@EmployeeId INTEGER , 
   @Name varchar(20),  
   @ProfileImage varchar(20),  
   @Gender varchar(10) , 
   @Department varchar (20),
   @Salary int,
	@StartDate date,
	@Notes varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Update Employee 
   set
   Name=@Name,  
   ProfileImage=ProfileImage,  
   Gender=@Gender, 
   Department=@Department,
   Salary=@Salary,
	StartDate=@StartDate,
	Notes=@Notes
   
   where EmployeeId=@EmployeeId 

    -- Insert statements for procedure here
	
END