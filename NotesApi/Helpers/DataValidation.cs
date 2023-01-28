using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace NotesApi.Helpers
{
    public static class DataValidation
    {

        public static bool CheckData(NoteModel note)
        {
            if (note.Title == null || note.Title.Length < 2)
                throw new AppException("Title was not correct length");
            if(note.Description == null || note.Description.Length < 2)
                throw new AppException("Description was not correct length");
            return true;
        }

    }
}
