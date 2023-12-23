using SQLite;
using Tasr.Library.Models;

namespace Tasr.Library.Services.Impl;

public class MeetingStorage :IMeetingStorage
{
	public const string DbName = "meetingdb.sqlite3";

	public static readonly string MeetingDbPath =
		Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder
				.LocalApplicationData), DbName);

	private  SQLiteAsyncConnection _connection;
	

	private SQLiteAsyncConnection Connection =>
		_connection ??= new SQLiteAsyncConnection(MeetingDbPath);

	public async Task InitalizeDatabase()
    {
        _ = Connection;
        try
        {
            await Connection.CreateTableAsync<Meeting>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
	}

	public async Task<Meeting> GetMeetingAsync(int id) => 
		await Connection.Table<Meeting>().FirstOrDefaultAsync(p => p.Id == id);


	public async Task<List<Meeting>> GetMeetingsAsync() =>
		await Connection.Table<Meeting>().ToListAsync();
	

	public async Task AddMeetingAsync(Meeting meeting)=>
		await Connection.InsertAsync(meeting);


	public async Task DeleteMeetingAsync(int id) =>
		await Connection.DeleteAsync(id);
	public async Task CloseAsync()=>
		await Connection.CloseAsync();
}