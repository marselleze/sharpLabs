namespace Lab1Library
{
	/// <summary>
	/// Предоставляет методы для форматирования строк.
	/// </summary>
	public static class StringFormatter
	{
		/// <summary>
		/// Формирует и возвращает строку вида 1, 2, 3, ... N.
		/// </summary>
		/// <param name="n">Положительное число, определяющее верхнюю границу последовательности.</param>
		/// <returns>Строка, содержащая последовательность чисел от 1 до N, разделённых запятыми.</returns>
		/// <exception cref="ArgumentException">Выбрасывается, если n не является положительным числом.</exception>
		public static string FormatNumberSequence(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("N должно быть положительным числом.", nameof(n));
			}

			var numbers = new List<string>();

			for (var i = 1; i <= n; i++)
			{
				numbers.Add(i.ToString());
			}

			return string.Join(", ", numbers);
		}
	}
}

