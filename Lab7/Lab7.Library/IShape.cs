namespace Lab7.Library
{
	/// <summary>
	/// Интерфейс для геометрических фигур.
	/// </summary>
	public interface IShape
	{
		/// <summary>
		/// Получает площадь фигуры.
		/// </summary>
		double Area { get; }

		/// <summary>
		/// Получает периметр фигуры.
		/// </summary>
		double Perimeter { get; }

		/// <summary>
		/// Вычисляет площадь фигуры.
		/// </summary>
		/// <returns>Площадь фигуры.</returns>
		double CalculateArea();

		/// <summary>
		/// Вычисляет периметр фигуры.
		/// </summary>
		/// <returns>Периметр фигуры.</returns>
		double CalculatePerimeter();
	}
}

