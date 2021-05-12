

using FluentAssertions;
using Question3.DataFromFiles;
using Question3.Models;
using Xunit;

namespace Question3.Tests.DataFromFiles
{
	public class DataSourceTests
	{
		[Theory]
		[InlineData(FileType.File1)]
		[InlineData(FileType.File2)]
		[InlineData(FileType.File3)]
		public void Quelque_soit_la_source_de_données_GetDataFromSource_retourne_un_ClientModel(FileType fileType)
		{
			DataSource ds = new DataSource(fileType);

			var result = ds.GetDataFromSource();

			result.GetType().Should().BeOfType<ClientModel>();
		}

	}
}
