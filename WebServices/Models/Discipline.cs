using LinqToDB.Mapping;
using System;

namespace Norbit.Crm.Hodeshenas.TaskFourteen
{
	/// <summary>
	/// Дисциплина.
	/// </summary>
	public class Discipline
	{
		/// <summary>
		/// Айди дисциплины.
		/// </summary>
		[PrimaryKey]
		public Guid DisciplineId { get; set; }

		/// <summary>
		/// Название дисциплины.
		/// </summary>
		[Column(Name = "Name"), NotNull]
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{DisciplineId} - {Name}";
		}
	}
}