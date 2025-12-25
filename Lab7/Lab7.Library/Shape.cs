namespace Lab7.Library
{
	/// <summary>
	/// Абстрактный базовый класс для геометрических фигур.
	/// </summary>
	public abstract class Shape : IShape
	{
		/// <summary>
		/// Получает площадь фигуры.
		/// </summary>
		public abstract double Area { get; }

		/// <summary>
		/// Получает периметр фигуры.
		/// </summary>
		public abstract double Perimeter { get; }

		/// <summary>
		/// Вычисляет площадь фигуры. Виртуальный метод, который может быть переопределен в производных классах.
		/// </summary>
		/// <returns>Площадь фигуры.</returns>
		public virtual double CalculateArea()
		{
			return Area;
		}

		/// <summary>
		/// Вычисляет периметр фигуры. Виртуальный метод, который может быть переопределен в производных классах.
		/// </summary>
		/// <returns>Периметр фигуры.</returns>
		public virtual double CalculatePerimeter()
		{
			return Perimeter;
		}

		/// <summary>
		/// Возвращает информацию о фигуре. Виртуальный метод.
		/// </summary>
		/// <returns>Строковое представление фигуры.</returns>
		public virtual string GetInfo()
		{
			return $"Фигура: площадь = {Area:F2}, периметр = {Perimeter:F2}";
		}
	}
}

