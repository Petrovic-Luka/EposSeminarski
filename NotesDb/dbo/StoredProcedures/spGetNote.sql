CREATE PROCEDURE [dbo].[spGetNote]
	@id int
As
Begin
	Select Id, Title, Description
	from dbo.[Notes]
	where Id = id;
end