using SharpLabs.Common;

namespace Lab8.Library
{
	/// <summary>
	/// Класс для обработки данных с обработкой исключений.
	/// </summary>
	public static class DataProcessor
	{
		/// <summary>
		/// Делит два числа с обработкой исключений.
		/// </summary>
		/// <param name="dividend">Делимое.</param>
		/// <param name="divisor">Делитель.</param>
		/// <returns>Результат деления.</returns>
		/// <exception cref="DivideByZeroException">Выбрасывается при делении на ноль.</exception>
		public static double DivideNumbers(double dividend, double divisor)
		{
			try
			{
				Argument.Require(divisor != 0, "Деление на ноль невозможно.");
				return dividend / divisor;
			}
			catch (ArgumentException ex)
			{
				throw new DivideByZeroException("Ошибка деления: делитель равен нулю.", ex);
			}
		}

		/// <summary>
		/// Парсит строку в число с обработкой исключений.
		/// </summary>
		/// <param name="input">Входная строка.</param>
		/// <returns>Распарсенное число.</returns>
		/// <exception cref="FormatException">Выбрасывается при неверном формате строки.</exception>
		public static int ParseInteger(string input)
		{
			try
			{
				Argument.NotNull(input, "Входная строка не может быть null.");
				return int.Parse(input);
			}
			catch (ArgumentNullException ex)
			{
				throw new FormatException("Ошибка парсинга: входная строка равна null.", ex);
			}
			catch (FormatException ex)
			{
				throw new FormatException($"Ошибка парсинга: неверный формат строки '{input}'.", ex);
			}
			catch (OverflowException ex)
			{
				throw new OverflowException($"Ошибка парсинга: число '{input}' выходит за пределы диапазона int.", ex);
			}
		}

		/// <summary>
		/// Получает элемент массива по индексу с обработкой исключений.
		/// </summary>
		/// <typeparam name="T">Тип элементов массива.</typeparam>
		/// <param name="array">Массив.</param>
		/// <param name="index">Индекс элемента.</param>
		/// <returns>Элемент массива по указанному индексу.</returns>
		/// <exception cref="ArgumentNullException">Выбрасывается, если массив равен null.</exception>
		/// <exception cref="IndexOutOfRangeException">Выбрасывается, если индекс выходит за границы массива.</exception>
		public static T GetArrayElement<T>(T[] array, int index)
		{
			try
			{
				Argument.NotNull(array, "Массив не может быть null.");
				Argument.Require(index >= 0 && index < array.Length, $"Индекс {index} выходит за границы массива.");
				return array[index];
			}
			catch (ArgumentNullException ex)
			{
				throw new ArgumentNullException("Массив не может быть null.", ex);
			}
			catch (ArgumentException ex)
			{
				throw new IndexOutOfRangeException($"Индекс {index} выходит за границы массива длиной {array?.Length ?? 0}.", ex);
			}
		}

		/// <summary>
		/// Выполняет операцию, которая может вызвать исключение.
		/// </summary>
		/// <param name="operation">Номер операции (1-3).</param>
		/// <returns>Результат операции.</returns>
		/// <exception cref="InvalidOperationException">Выбрасывается при неверном номере операции.</exception>
		public static string PerformOperation(int operation)
		{
			try
			{
				return operation switch
				{
					1 => "Операция 1 выполнена успешно.",
					2 => "Операция 2 выполнена успешно.",
					3 => "Операция 3 выполнена успешно.",
					_ => throw new InvalidOperationException($"Неизвестная операция: {operation}")
				};
			}
			catch (InvalidOperationException ex)
			{
				throw new InvalidOperationException($"Ошибка выполнения операции: {ex.Message}", ex);
			}
		}
	}
}

