using System;


namespace Norbit.Crm.Hodeshenas.TaskFive
{
	/// <summary>
	/// Сортировка массива произвольного типа.
	/// </summary>
	class ArbitraryArraySort
	{
		#region Делегат

		/// <summary>
		/// Содержит указатель на метод ToStringMain.
		/// </summary>
		/// <param name="array">Задаваемый массив</param>
		delegate string ArrayToStringCallback(ref int[] array);

		#endregion

		#region События

		/// <summary>
		/// Начало сортировки.
		/// </summary>
		public event EventHandler<EventArgs> StartSort;

		/// <summary>
		/// Конец сортировки.
		/// </summary>
		public event Action SortEnd;

		/// <summary>
		/// Вызов события StartSort. 
		/// </summary>
		protected virtual void OnSortArrayStart() => StartSort?.Invoke(this, EventArgs.Empty);

		/// <summary>
		/// Вызов события SortEnd.
		/// </summary>
		protected virtual void OnSortArrayEnd() => SortEnd?.Invoke();

		#endregion

		#region Методы

		/// <summary>
		/// Формирует массив в формате string.
		/// </summary>
		/// <returns>Массив в формате string</returns>
		public string ToString(int[] array)
		{

			if (array == null)
			{
				throw new ArgumentNullException("Массив не содержит значений!");
			}

			var delegateArrayToString = new ArrayToStringCallback(ToStringMain);

			return delegateArrayToString(ref array);
		}

		/// <summary>
		/// Главный метод формирования массива в строку.
		/// </summary>
		/// <param name="array">Задаваемый массив</param>
		/// <returns>Результат формирования</returns>
		private string ToStringMain(ref int[] array)
        {
			string stringArray = "{";

			foreach (var value in array)
			{
				stringArray += $"{value} ";
			}

			stringArray += "}";

			return stringArray;
		}

		/// <summary>
		/// Меняет элементы местами.
		/// </summary>
		/// <param name="x">Первый элемент</param>
		/// <param name="y">Второй элемент</param>
		void Swap(ref int x, ref int y)
		{
			var tempValue = x;
			x = y;
			y = tempValue;
		}

		/// <summary>
		/// Сортировка массива.
		/// </summary>
		/// <param name="array">Массив обобщенного типа</param>
		/// <returns>Возвращает отсортированный массив</returns>
		public int[] SortArray(int[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException("Массив не содержит значений!");
			}

			OnSortArrayStart();

			for (var i = 1; i < array.Length; i++)
			{
				for (var j = 0; j < array.Length - i; j++)
				{
					if (array[j] > array[j + 1])
					{
						Swap(ref array[j], ref array[j + 1]);
					}
				}
			}

			OnSortArrayEnd();

			return array;
		}

		#endregion
	}
}
