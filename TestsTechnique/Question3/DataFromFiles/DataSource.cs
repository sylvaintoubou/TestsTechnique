using Question3.Factories;
using Question3.Models;
using System;

namespace Question3.DataFromFiles
{
    public class DataSource
	{
        private IClientData _clientdata;

        public DataSource(FileType fileType)
        {
            IDataFactory factory;

            switch (fileType)
            {
                case FileType.File1:
                    factory = new DataFromFile1();
                    _clientdata = factory.CreateClientData();
                    break;
                case FileType.File2:
                    factory = new DataFromFile2();
                    _clientdata = factory.CreateClientData();
                    break;
                case FileType.File3:
                    factory = new DataFromFile3();
                    _clientdata = factory.CreateClientData();
                    break;
                default:
                    throw new ApplicationException("Source inconnue " + fileType);
            }
        }

        public ClientModel GetDataFromSource()
        {
            return _clientdata.GetClient();
        }
    }
}
