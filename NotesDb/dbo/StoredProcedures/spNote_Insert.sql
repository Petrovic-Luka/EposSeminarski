CREATE PROCEDURE [dbo].[spNote_Insert]
	@Title nvarchar,
	@Description nvarchar
AS
begin
	insert into dbo.[Notes] (Title,Description)
	values(@Title,@Description)
end
