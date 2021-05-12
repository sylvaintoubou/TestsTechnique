using Question2.Services;

namespace Question2.ServiceClient
{
	public class ServiceClient
	{
		private readonly IService1 _service1;
		private readonly IService2 _service2;
		private readonly IService3 _service3;
		private readonly IService4 _service4;

		public ServiceClient( IService1 service1,
			IService2 service2,
			IService3 service3,
			IService4 service4)
		{
			_service1 = service1;
			_service2 = service2;
			_service3 = service3;
			_service4 = service4;
		}

		public bool EffectuerTraitement()
		{
			if (!_service4.TraitementEnSucces())
				return false;

			if (!_service3.TraitementEnSucces())
				return false;

			if (!_service4.TraitementEnSucces())
				return false;

			if (!_service2.TraitementEnSucces())
				return false;

			if (!_service1.TraitementEnSucces())
				return false;

			return true;
		}
	}
}
