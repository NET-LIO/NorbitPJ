using LinqToDB.Mapping;
using System;

namespace Norbit.Crm.Hodeshenas.TaskFourteen
{
	/// <summary>
	/// Учитель.
	/// </summary>
	[Table(Name = "Teacher")]
	public class Teacher
	{
		/// <summary>
		/// Айди учителя.
		/// </summary>
		[PrimaryKey]
		public Guid TeacherId { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Column(Name = "Surname"), NotNull]
		public string Surname { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Column(Name = "Name"), NotNull]
		public string Name { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		[Column(Name = "Patronymic"), NotNull]
		public string Patronymic { get; set; }

		/// <summary>
		/// Семестр.
		/// </summary>
		[Column(Name = "Semester"), NotNull]
		public int Semester { get; set; }

		/// <summary>
		/// Айди дисциплины.
		/// </summary>
		[Column(Name = "DisciplineId"), NotNull]
		public Guid DisciplineId { get; set; }

		public override string ToString()
		{
			return $"{TeacherId} - {Surname} - {Name} - {Patronymic} - {Semester} - {DisciplineId}";
		}
	}
}
