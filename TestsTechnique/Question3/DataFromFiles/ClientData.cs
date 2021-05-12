using Question3.Models;

namespace Question3.DataFromFiles
{
	public class ClientData : IClientData
	{
		private ClientModel _client;

		public ClientData(ClientModel client)
		{
			_client = client;
		}

		public ClientModel GetClient()
		{
			return _client;
		}
	}
}
