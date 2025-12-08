using SharpLabs.Common;

namespace Lab3.Library
{
	/// <summary>
	/// Класс для анализа частоты слов в тексте.
	/// </summary>
	public static class WordFrequencyAnalyzer
	{
		/// <summary>
		/// Подсчитывает частоту встречаемости слов в тексте.
		/// Слова приводятся к нижнему регистру для корректного подсчета.
		/// </summary>
		/// <param name="text">Текст для анализа.</param>
		/// <returns>Словарь, где ключ - слово, значение - частота встречаемости.</returns>
		public static Dictionary<string, int> CountWordFrequency(string text)
		{
			Argument.NotNull(text, "Текст не может быть null.");

			var frequency = new Dictionary<string, int>();

			if (string.IsNullOrWhiteSpace(text))
			{
				return frequency;
			}

			var words = text.Split(new[] { ' ', '.', ',', ';', ':', '!', '?', '\t', '\n', '\r' }, 
				StringSplitOptions.RemoveEmptyEntries);

			foreach (var word in words)
			{
				var cleanWord = word.Trim().ToLowerInvariant();

				if (!string.IsNullOrEmpty(cleanWord))
				{
					if (frequency.ContainsKey(cleanWord))
					{
						frequency[cleanWord]++;
					}
					else
					{
						frequency[cleanWord] = 1;
					}
				}
			}

			return frequency;
		}

		/// <summary>
		/// Выводит результаты анализа частоты слов в консоль.
		/// </summary>
		/// <param name="frequency">Словарь с частотой слов.</param>
		public static void PrintWordFrequency(Dictionary<string, int> frequency)
		{
			Argument.NotNull(frequency, "Словарь не может быть null.");

			Console.WriteLine("Частота слов:");
			Console.WriteLine(new string('-', 40));

			foreach (var pair in frequency)
			{
				Console.WriteLine($"{pair.Key,-20} : {pair.Value}");
			}

			Console.WriteLine(new string('-', 40));
			Console.WriteLine($"Всего уникальных слов: {frequency.Count}");
		}
	}
}

