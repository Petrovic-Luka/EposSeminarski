CREATE PROCEDURE [dbo].[spNotesGetAll]
AS
Begin
	Select Id, Title, Description
	from dbo.[Notes];
end
