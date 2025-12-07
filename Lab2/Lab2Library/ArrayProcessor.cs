namespace Lab2Library
{
	/// <summary>
	/// Предоставляет методы для работы с массивами без использования LINQ и встроенных функций сортировки.
	/// </summary>
	public static class ArrayProcessor
	{
		/// <summary>
		/// Генерирует массив случайных целых чисел.
		/// </summary>
		/// <param name="size">Размер массива.</param>
		/// <param name="minValue">Минимальное значение элемента.</param>
		/// <param name="maxValue">Максимальное значение элемента.</param>
		/// <returns>Массив случайных целых чисел.</returns>
		/// <exception cref="ArgumentException">Выбрасывается, если размер массива или диапазон значений недопустимы.</exception>
		public static int[] GenerateRandomArray(int size, int minValue = 0, int maxValue = 100)
		{
			if (size <= 0)
			{
				throw new ArgumentException("Размер массива должен быть положительным числом.", nameof(size));
			}

			if (minValue >= maxValue)
			{
				throw new ArgumentException("Минимальное значение должно быть меньше максимального.", nameof(minValue));
			}

			var random = new Random();
			var array = new int[size];

			for (var i = 0; i < size; i++)
			{
				array[i] = random.Next(minValue, maxValue);
			}

			return array;
		}

		/// <summary>
		/// Находит минимальное значение в массиве.
		/// </summary>
		/// <param name="array">Массив для поиска.</param>
		/// <returns>Минимальное значение в массиве.</returns>
		/// <exception cref="ArgumentNullException">Выбрасывается, если массив равен null.</exception>
		/// <exception cref="ArgumentException">Выбрасывается, если массив пуст.</exception>
		public static int FindMinimum(int[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array), "Массив не может быть null.");
			}

			if (array.Length == 0)
			{
				throw new ArgumentException("Массив не может быть пустым.", nameof(array));
			}

			var min = array[0];

			for (var i = 1; i < array.Length; i++)
			{
				if (array[i] < min)
				{
					min = array[i];
				}
			}

			return min;
		}

		/// <summary>
		/// Находит максимальное значение в массиве.
		/// </summary>
		/// <param name="array">Массив для поиска.</param>
		/// <returns>Максимальное значение в массиве.</returns>
		/// <exception cref="ArgumentNullException">Выбрасывается, если массив равен null.</exception>
		/// <exception cref="ArgumentException">Выбрасывается, если массив пуст.</exception>
		public static int FindMaximum(int[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array), "Массив не может быть null.");
			}

			if (array.Length == 0)
			{
				throw new ArgumentException("Массив не может быть пустым.", nameof(array));
			}

			var max = array[0];

			for (var i = 1; i < array.Length; i++)
			{
				if (array[i] > max)
				{
					max = array[i];
				}
			}

			return max;
		}

		/// <summary>
		/// Сортирует массив по возрастанию методом пузырьковой сортировки.
		/// </summary>
		/// <param name="array">Массив для сортировки.</param>
		/// <exception cref="ArgumentNullException">Выбрасывается, если массив равен null.</exception>
		public static void SortArray(int[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array), "Массив не может быть null.");
			}

			for (var i = 0; i < array.Length - 1; i++)
			{
				for (var j = 0; j < array.Length - i - 1; j++)
				{
					if (array[j] > array[j + 1])
					{
						var temp = array[j];
						array[j] = array[j + 1];
						array[j + 1] = temp;
					}
				}
			}
		}
	}
}

