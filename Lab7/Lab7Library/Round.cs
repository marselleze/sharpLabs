namespace Lab7Library
{
	/// <summary>
	/// Представляет окружность с указанным центром и радиусом.
	/// </summary>
	public class Round
	{
		private double _radius;

		/// <summary>
		/// Координата X центра.
		/// </summary>
		public double CenterX { get; private set; }

		/// <summary>
		/// Координата Y центра.
		/// </summary>
		public double CenterY { get; private set; }

		/// <summary>
		/// Радиус окружности.
		/// </summary>
		public double Radius
		{
			get => _radius;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Радиус должен быть положительным.", nameof(value));
				}

				_radius = value;
			}
		}

		/// <summary>
		/// Длина окружности.
		/// </summary>
		public double Circumference => 2 * Math.PI * Radius;

		/// <summary>
		/// Площадь круга.
		/// </summary>
		public double Area => Math.PI * Math.Pow(Radius, 2);

		/// <summary>
		/// Инициализирует новый экземпляр класса Round.
		/// </summary>
		/// <param name="centerX">Координата X центра.</param>
		/// <param name="centerY">Координата Y центра.</param>
		/// <param name="radius">Радиус круга.</param>
		public Round(double centerX, double centerY, double radius)
		{
			CenterX = centerX;
			CenterY = centerY;
			Radius = radius;
		}

		/// <summary>
		/// Перемещает круг на указанные смещения.
		/// </summary>
		/// <param name="deltaX">Смещение по оси X.</param>
		/// <param name="deltaY">Смещение по оси Y.</param>
		public void Move(double deltaX, double deltaY)
		{
			CenterX += deltaX;
			CenterY += deltaY;
		}

		/// <summary>
		/// Проверяет, находится ли точка внутри круга.
		/// </summary>
		/// <param name="x">Координата X точки.</param>
		/// <param name="y">Координата Y точки.</param>
		/// <returns>true, если точка находится внутри круга.</returns>
		public bool ContainsPoint(double x, double y)
		{
			var distance = Math.Sqrt(Math.Pow(x - CenterX, 2) + Math.Pow(y - CenterY, 2));
			return distance <= Radius;
		}
	}
}


