using System.Text;
using SharpLabs.Common;

namespace Lab1.Library
{
	/// <summary>
	/// Класс для вывода квадратов из символов.
	/// </summary>
	public static class SquarePrinter
	{
		private const char StarChar = '*';
		private const int MinSquareSize = 1;

		/// <summary>
		/// Выводит на экран квадрат из звездочек со стороной N.
		/// Центральная звездочка отсутствует (только для нечетных N >= 3).
		/// </summary>
		/// <param name="n">Размер стороны квадрата (положительное нечетное число).</param>
		/// <exception cref="ArgumentException">Выбрасывается, если N меньше 1.</exception>
		public static void PrintSquare(int n)
		{
			Argument.Require(n >= MinSquareSize, "Размер квадрата должен быть не менее 1.");

			var square = BuildSquare(n);
			Console.WriteLine(square);
		}

		/// <summary>
		/// Возвращает строковое представление квадрата из звездочек.
		/// </summary>
		/// <param name="n">Размер стороны квадрата.</param>
		/// <returns>Строка с квадратом из звездочек.</returns>
		public static string BuildSquare(int n)
		{
			Argument.Require(n >= MinSquareSize, "Размер квадрата должен быть не менее 1.");

			var result = new StringBuilder();
			var centerRow = n / 2;
			var centerCol = n / 2;

			for (var row = 0; row < n; row++)
			{
				for (var col = 0; col < n; col++)
				{
					if (n >= 3 && n % 2 == 1 && row == centerRow && col == centerCol)
					{
						result.Append(' ');
					}
					else
					{
						result.Append(StarChar);
					}
				}

				if (row < n - 1)
				{
					result.AppendLine();
				}
			}

			return result.ToString();
		}
	}
}

