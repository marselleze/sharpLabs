using SharpLabs.Common;

namespace Lab7.Library
{
	/// <summary>
	/// Представляет круг с заданными координатами центра и радиусом.
	/// </summary>
	public class Round
	{
		private double _x;
		private double _y;
		private double _radius;

		/// <summary>
		/// Получает или задает координату X центра круга.
		/// </summary>
		public double X
		{
			get => _x;
			set => _x = value;
		}

		/// <summary>
		/// Получает или задает координату Y центра круга.
		/// </summary>
		public double Y
		{
			get => _y;
			set => _y = value;
		}

		/// <summary>
		/// Получает или задает радиус круга. Радиус всегда должен быть неотрицательным.
		/// </summary>
		/// <exception cref="ArgumentException">Выбрасывается при попытке установить отрицательное значение.</exception>
		public double Radius
		{
			get => _radius;
			set
			{
				Argument.Require(value >= 0, "Радиус не может быть отрицательным.");
				_radius = value;
			}
		}

		/// <summary>
		/// Получает длину окружности.
		/// </summary>
		public double Circumference
		{
			get => 2 * Math.PI * _radius;
		}

		/// <summary>
		/// Получает площадь круга.
		/// </summary>
		public double Area
		{
			get => Math.PI * _radius * _radius;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Round с центром в начале координат и нулевым радиусом.
		/// </summary>
		public Round()
		{
			_x = 0;
			_y = 0;
			_radius = 0;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Round с указанными параметрами.
		/// </summary>
		/// <param name="x">Координата X центра круга.</param>
		/// <param name="y">Координата Y центра круга.</param>
		/// <param name="radius">Радиус круга. Должен быть неотрицательным.</param>
		/// <exception cref="ArgumentException">Выбрасывается, если радиус отрицательный.</exception>
		public Round(double x, double y, double radius)
		{
			_x = x;
			_y = y;
			Argument.Require(radius >= 0, "Радиус не может быть отрицательным.");
			_radius = radius;
		}

		/// <summary>
		/// Возвращает строковое представление круга.
		/// </summary>
		public override string ToString()
		{
			return $"Круг: центр ({X:F2}, {Y:F2}), радиус = {Radius:F2}, длина окружности = {Circumference:F2}, площадь = {Area:F2}";
		}
	}
}

