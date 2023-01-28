CREATE PROCEDURE [dbo].[spNotes_Update]
	@Id int,
	@Title nvarchar,
	@Description nvarchar
AS
begin	
	update dbo.[Notes] 
	set Id=@Id,Title=@Title,Description=@Description;
end
