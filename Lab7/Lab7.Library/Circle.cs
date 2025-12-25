using SharpLabs.Common;

namespace Lab7.Library
{
	/// <summary>
	/// Представляет круг, наследующийся от абстрактного класса Shape.
	/// </summary>
	public class Circle : Shape
	{
		private double _radius;

		/// <summary>
		/// Получает или задает радиус круга. Радиус должен быть положительным.
		/// </summary>
		/// <exception cref="ArgumentException">Выбрасывается при попытке установить неположительное значение.</exception>
		public double Radius
		{
			get => _radius;
			set
			{
				Argument.Require(value > 0, "Радиус должен быть положительным.");
				_radius = value;
			}
		}

		/// <summary>
		/// Получает площадь круга.
		/// </summary>
		public override double Area => Math.PI * _radius * _radius;

		/// <summary>
		/// Получает периметр (длину окружности) круга.
		/// </summary>
		public override double Perimeter => 2 * Math.PI * _radius;

		/// <summary>
		/// Инициализирует новый экземпляр класса Circle.
		/// </summary>
		public Circle()
		{
			_radius = 1;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Circle с указанным радиусом.
		/// </summary>
		/// <param name="radius">Радиус круга.</param>
		/// <exception cref="ArgumentException">Выбрасывается, если радиус неположительный.</exception>
		public Circle(double radius)
		{
			Argument.Require(radius > 0, "Радиус должен быть положительным.");
			_radius = radius;
		}

		/// <summary>
		/// Переопределяет метод GetInfo для круга.
		/// </summary>
		/// <returns>Строковое представление круга.</returns>
		public override string GetInfo()
		{
			return $"{base.GetInfo()}, радиус = {Radius:F2}";
		}
	}
}

