using System;

namespace Norbit.Crm.Hodeshenas.TaskThirteen
{
	/// <summary>
	/// Фабрика провайдеров.
	/// </summary>
	public static class DatabaseProviderFactory
	{
		/// <summary>
		/// Фабричный метод, создающий экземпляр провайдера в зависимости от переданного параметра.
		/// </summary>
		/// <param name="providerType">Тип провайдера</param>
		/// <returns>Провайдер</returns>
		public static DatabaseProvider GetProvider(ProviderType providerType)
		{
			switch (providerType)
			{
				case ProviderType.AdoNet:
					return new AdoNetProvider();

				case ProviderType.LinqToDb:
					return new LinqToDbProvider();

				default:
					throw new InvalidOperationException();
			}
		}
	}
}
