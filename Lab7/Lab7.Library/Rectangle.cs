using SharpLabs.Common;

namespace Lab7.Library
{
	/// <summary>
	/// Представляет прямоугольник, наследующийся от абстрактного класса Shape.
	/// </summary>
	public class Rectangle : Shape
	{
		private double _width;
		private double _height;

		/// <summary>
		/// Получает или задает ширину прямоугольника. Ширина должна быть положительной.
		/// </summary>
		/// <exception cref="ArgumentException">Выбрасывается при попытке установить неположительное значение.</exception>
		public double Width
		{
			get => _width;
			set
			{
				Argument.Require(value > 0, "Ширина должна быть положительной.");
				_width = value;
			}
		}

		/// <summary>
		/// Получает или задает высоту прямоугольника. Высота должна быть положительной.
		/// </summary>
		/// <exception cref="ArgumentException">Выбрасывается при попытке установить неположительное значение.</exception>
		public double Height
		{
			get => _height;
			set
			{
				Argument.Require(value > 0, "Высота должна быть положительной.");
				_height = value;
			}
		}

		/// <summary>
		/// Получает площадь прямоугольника.
		/// </summary>
		public override double Area => _width * _height;

		/// <summary>
		/// Получает периметр прямоугольника.
		/// </summary>
		public override double Perimeter => 2 * (_width + _height);

		/// <summary>
		/// Инициализирует новый экземпляр класса Rectangle.
		/// </summary>
		public Rectangle()
		{
			_width = 1;
			_height = 1;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Rectangle с указанными параметрами.
		/// </summary>
		/// <param name="width">Ширина прямоугольника.</param>
		/// <param name="height">Высота прямоугольника.</param>
		/// <exception cref="ArgumentException">Выбрасывается, если ширина или высота неположительные.</exception>
		public Rectangle(double width, double height)
		{
			Argument.Require(width > 0, "Ширина должна быть положительной.");
			Argument.Require(height > 0, "Высота должна быть положительной.");

			_width = width;
			_height = height;
		}

		/// <summary>
		/// Переопределяет метод GetInfo для прямоугольника.
		/// </summary>
		/// <returns>Строковое представление прямоугольника.</returns>
		public override string GetInfo()
		{
			return $"{base.GetInfo()}, ширина = {Width:F2}, высота = {Height:F2}";
		}
	}
}

