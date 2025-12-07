namespace Lab1Library
{
	/// <summary>
	/// Предоставляет методы для создания строковых представлений геометрических фигур.
	/// </summary>
	public static class SquarePrinter
	{
		/// <summary>
		/// Создаёт строку, представляющую квадрат из звёздочек со стороной равной N с отсутствующей центральной звёздочкой.
		/// </summary>
		/// <param name="n">Положительное нечётное целое число, определяющее размер стороны квадрата.</param>
		/// <returns>Строка, представляющая квадрат из звёздочек с пустым центром.</returns>
		/// <exception cref="ArgumentException">Выбрасывается, если n не является положительным нечётным числом.</exception>
		public static string CreateSquareWithEmptyCenter(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("N должно быть положительным числом.", nameof(n));
			}

			if (n % 2 == 0)
			{
				throw new ArgumentException("N должно быть нечётным числом.", nameof(n));
			}

			var centerIndex = n / 2;
			var rows = new List<string>();

			for (var row = 0; row < n; row++)
			{
				var rowBuilder = new System.Text.StringBuilder();

				for (var col = 0; col < n; col++)
				{
					if (row == centerIndex && col == centerIndex)
					{
						rowBuilder.Append(" ");
					}
					else
					{
						rowBuilder.Append("*");
					}
				}

				rows.Add(rowBuilder.ToString());
			}

			return string.Join(Environment.NewLine, rows);
		}
	}
}

