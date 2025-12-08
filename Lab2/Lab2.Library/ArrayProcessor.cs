using SharpLabs.Common;

namespace Lab2.Library
{
	/// <summary>
	/// Класс для обработки массивов без использования LINQ и встроенных методов сортировки.
	/// </summary>
	public static class ArrayProcessor
	{
		private const int DefaultArraySize = 10;
		private const int MaxRandomValue = 100;

		/// <summary>
		/// Генерирует массив случайных целых чисел.
		/// </summary>
		/// <param name="size">Размер массива.</param>
		/// <returns>Массив случайных чисел.</returns>
		public static int[] GenerateRandomArray(int size = DefaultArraySize)
		{
			Argument.Require(size > 0, "Размер массива должен быть положительным числом.");

			var array = new int[size];
			var random = new Random();

			for (var i = 0; i < size; i++)
			{
				array[i] = random.Next(MaxRandomValue);
			}

			return array;
		}

		/// <summary>
		/// Находит минимальное значение в массиве.
		/// </summary>
		/// <param name="array">Исходный массив.</param>
		/// <returns>Минимальное значение.</returns>
		public static int FindMin(int[] array)
		{
			Argument.NotNull(array, "Массив не может быть null.");
			Argument.Require(array.Length > 0, "Массив не может быть пустым.");

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
		/// <param name="array">Исходный массив.</param>
		/// <returns>Максимальное значение.</returns>
		public static int FindMax(int[] array)
		{
			Argument.NotNull(array, "Массив не может быть null.");
			Argument.Require(array.Length > 0, "Массив не может быть пустым.");

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
		/// Сортирует массив методом пузырьковой сортировки.
		/// </summary>
		/// <param name="array">Массив для сортировки.</param>
		public static void BubbleSort(int[] array)
		{
			Argument.NotNull(array, "Массив не может быть null.");

			var length = array.Length;

			for (var i = 0; i < length - 1; i++)
			{
				for (var j = 0; j < length - i - 1; j++)
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

		/// <summary>
		/// Выводит массив в консоль.
		/// </summary>
		/// <param name="array">Массив для вывода.</param>
		/// <param name="title">Заголовок для вывода.</param>
		public static void PrintArray(int[] array, string title = "Массив")
		{
			Argument.NotNull(array, "Массив не может быть null.");

			Console.WriteLine($"{title}: [{string.Join(", ", array)}]");
		}
	}
}

