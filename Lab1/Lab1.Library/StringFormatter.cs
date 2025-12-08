using SharpLabs.Common;

namespace Lab1.Library
{
	/// <summary>
	/// Класс для форматирования строк с числовыми последовательностями.
	/// </summary>
	public static class StringFormatter
	{
		/// <summary>
		/// Формирует и возвращает строку вида "1, 2, 3, ... N".
		/// </summary>
		/// <param name="n">Положительное целое число, определяющее конец последовательности.</param>
		/// <returns>Строка с последовательностью чисел от 1 до N через запятую.</returns>
		/// <exception cref="ArgumentException">Выбрасывается, если N меньше или равно нулю.</exception>
		public static string FormatNumberSequence(int n)
		{
			Argument.Require(n > 0, "Значение N должно быть положительным числом.");

			var numbers = new string[n];

			for (var i = 0; i < n; i++)
			{
				numbers[i] = (i + 1).ToString();
			}

			return string.Join(", ", numbers);
		}
	}
}

