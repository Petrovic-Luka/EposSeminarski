CREATE PROCEDURE [dbo].[spNote_Delete]
	@id int
As
Begin
	delete
	from dbo.[Notes]
	where Id = id;
end
