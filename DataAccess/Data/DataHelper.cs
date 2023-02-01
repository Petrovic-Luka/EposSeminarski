using Dapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;
using NotesApi.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Data
{
    public static class DataHelper
    
    {
        private static readonly string conn = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lukap\\source\\repos\\EposSeminarski\\DataAccess\\NotesDb.mdf;Integrated Security=True";


        public static async Task<IEnumerable<NoteModel>> NotesGetAllAsync()
        
        {
            using(SqlConnection connection=new SqlConnection(conn))
            {
                connection.Open();
                var notes = await connection.QueryAsync<NoteModel>("spNotesGetAll", commandType: CommandType.StoredProcedure);
                return notes;
            }
        }

        public static async Task<IEnumerable<NoteModel>> NotesGetAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                DynamicParameters p = new();
                p.Add("@Id", id);
                var notes = await connection.QueryAsync<NoteModel>("spGetNote",p, commandType: CommandType.StoredProcedure);
                return notes;
            }
        }

        public static async void NotesDeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                DynamicParameters p = new();
                p.Add("@Id", id, DbType.Int32);
                await connection.QueryAsync("spNote_Delete",p, commandType: CommandType.StoredProcedure);
            }
        }

        public static async void NotesCreateAsync(NoteModel  temp) 
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                DynamicParameters p = new();
                p.Add("@Title", temp.Title);
                p.Add("@Description", temp.Description);
                await connection.QueryAsync("spNote_Insert",p, commandType: CommandType.StoredProcedure);
            }
        }

        public static async void Notesupdate(int id,NoteModel temp)
        {

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                DynamicParameters p = new();
                p.Add("@Id",id);
                p.Add("@Title", temp.Title);
                p.Add("@Description", temp.Description);
                await connection.QueryAsync("spNotes_Update",p, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
