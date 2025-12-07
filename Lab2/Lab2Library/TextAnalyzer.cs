namespace Lab2Library
{
	/// <summary>
	/// Предоставляет методы для анализа текстовых строк.
	/// </summary>
	public static class TextAnalyzer
	{
		/// <summary>
		/// Вычисляет среднюю длину слова во введённой текстовой строке.
		/// Пунктуация не учитывается при подсчёте длины слов.
		/// </summary>
		/// <param name="text">Текстовая строка для анализа.</param>
		/// <returns>Средняя длина слова в символах.</returns>
		/// <exception cref="ArgumentNullException">Выбрасывается, если текст равен null.</exception>
		/// <exception cref="ArgumentException">Выбрасывается, если текст не содержит слов.</exception>
		public static double CalculateAverageWordLength(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException(nameof(text), "Текст не может быть null.");
			}

			var words = new List<string>();
			var currentWord = new System.Text.StringBuilder();

			for (var i = 0; i < text.Length; i++)
			{
				var character = text[i];

				if (char.IsLetterOrDigit(character))
				{
					currentWord.Append(character);
				}
				else if (char.IsSeparator(character) || char.IsWhiteSpace(character) || char.IsPunctuation(character))
				{
					if (currentWord.Length > 0)
					{
						words.Add(currentWord.ToString());
						currentWord.Clear();
					}
				}
			}

			if (currentWord.Length > 0)
			{
				words.Add(currentWord.ToString());
			}

			if (words.Count == 0)
			{
				throw new ArgumentException("Текст не содержит слов.", nameof(text));
			}

			var totalLength = 0;

			foreach (var word in words)
			{
				totalLength += word.Length;
			}

			return (double)totalLength / words.Count;
		}
	}
}

