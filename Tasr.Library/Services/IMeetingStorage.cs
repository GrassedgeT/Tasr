using Tasr.Library.Models;

namespace Tasr.Library.Services;

public interface IMeetingStorage
{
    Task InitalizeDatabase();

    Task<Meeting> GetMeetingAsync(int id);
	Task<List<Meeting>> GetMeetingsAsync();
	Task AddMeetingAsync(Meeting meeting);

	Task DeleteMeetingAsync(int id);
}