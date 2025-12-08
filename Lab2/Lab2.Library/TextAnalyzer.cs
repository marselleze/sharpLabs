using SharpLabs.Common;

namespace Lab2.Library
{
	/// <summary>
	/// Класс для анализа текстовых данных.
	/// </summary>
	public static class TextAnalyzer
	{
		/// <summary>
		/// Вычисляет среднюю длину слова во введённой текстовой строке.
		/// Символы пунктуации не учитываются в длине слова.
		/// </summary>
		/// <param name="text">Исходный текст для анализа.</param>
		/// <returns>Средняя длина слова.</returns>
		public static double CalculateAverageWordLength(string text)
		{
			Argument.NotNull(text, "Текст не может быть null.");

			if (string.IsNullOrWhiteSpace(text))
			{
				return 0;
			}

			var words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			var totalLength = 0;
			var wordCount = 0;

			foreach (var word in words)
			{
				var cleanWord = RemovePunctuation(word);

				if (!string.IsNullOrEmpty(cleanWord))
				{
					totalLength += cleanWord.Length;
					wordCount++;
				}
			}

			if (wordCount == 0)
			{
				return 0;
			}

			return (double)totalLength / wordCount;
		}

		/// <summary>
		/// Удаляет знаки пунктуации из слова.
		/// </summary>
		/// <param name="word">Исходное слово.</param>
		/// <returns>Слово без знаков пунктуации.</returns>
		private static string RemovePunctuation(string word)
		{
			var result = string.Empty;

			foreach (var ch in word)
			{
				if (!char.IsPunctuation(ch))
				{
					result += ch;
				}
			}

			return result;
		}
	}
}

