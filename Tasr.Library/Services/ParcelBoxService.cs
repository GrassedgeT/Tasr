namespace Tasr.Library.Services;

public class ParcelBoxService : IParcelBoxService
{
	private readonly Dictionary<string, object> _parcelBox = new();
	public string Put(object o)
	{
		var token = Guid.NewGuid().ToString();
		_parcelBox[token] = o;
		return token;
	}

	public object Get(string ticket)
	{
		return _parcelBox.TryGetValue(ticket, out object o) ? o : null;
	}
}