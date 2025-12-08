using SharpLabs.Common;

namespace Lab4.Library
{
	/// <summary>
	/// Делегат для сравнения двух элементов.
	/// </summary>
	/// <typeparam name="T">Тип сравниваемых элементов.</typeparam>
	/// <param name="first">Первый элемент.</param>
	/// <param name="second">Второй элемент.</param>
	/// <returns>Отрицательное число, если first меньше second; 0, если равны; положительное, если first больше second.</returns>
	public delegate int ComparisonDelegate<T>(T first, T second);

	/// <summary>
	/// Аргументы события прогресса сортировки.
	/// </summary>
	public class SortProgressEventArgs : EventArgs
	{
		/// <summary>
		/// Процент выполнения сортировки.
		/// </summary>
		public int ProgressPercentage { get; }

		/// <summary>
		/// Количество выполненных сравнений.
		/// </summary>
		public int ComparisonsCount { get; }

		/// <summary>
		/// Инициализирует новый экземпляр класса SortProgressEventArgs.
		/// </summary>
		public SortProgressEventArgs(int progressPercentage, int comparisonsCount)
		{
			ProgressPercentage = progressPercentage;
			ComparisonsCount = comparisonsCount;
		}
	}

	/// <summary>
	/// Класс для сортировки массивов произвольного типа с поддержкой событий.
	/// </summary>
	/// <typeparam name="T">Тип элементов массива.</typeparam>
	public class GenericArraySorter<T>
	{
		private int _comparisonsCount;

		/// <summary>
		/// Событие, возникающее после завершения сортировки.
		/// </summary>
		public event EventHandler? SortCompleted;

		/// <summary>
		/// Событие, возникающее в процессе сортировки для отображения прогресса.
		/// </summary>
		public event EventHandler<SortProgressEventArgs>? SortProgress;

		/// <summary>
		/// Сортирует массив с использованием указанного делегата сравнения.
		/// </summary>
		/// <param name="array">Массив для сортировки.</param>
		/// <param name="comparer">Делегат для сравнения элементов.</param>
		public void Sort(T[] array, ComparisonDelegate<T> comparer)
		{
			Argument.NotNull(array, "Массив не может быть null.");
			Argument.NotNull(comparer, "Делегат сравнения не может быть null.");

			_comparisonsCount = 0;
			QuickSort(array, 0, array.Length - 1, comparer);

			OnSortCompleted();
		}

		/// <summary>
		/// Реализация быстрой сортировки (QuickSort).
		/// </summary>
		private void QuickSort(T[] array, int left, int right, ComparisonDelegate<T> comparer)
		{
			if (left < right)
			{
				var pivotIndex = Partition(array, left, right, comparer);
				QuickSort(array, left, pivotIndex - 1, comparer);
				QuickSort(array, pivotIndex + 1, right, comparer);

				var progress = (int)((double)(right - left + 1) / array.Length * 100);
				OnSortProgress(new SortProgressEventArgs(progress, _comparisonsCount));
			}
		}

		/// <summary>
		/// Разделяет массив на две части относительно опорного элемента.
		/// </summary>
		private int Partition(T[] array, int left, int right, ComparisonDelegate<T> comparer)
		{
			var pivot = array[right];
			var i = left - 1;

			for (var j = left; j < right; j++)
			{
				_comparisonsCount++;

				if (comparer(array[j], pivot) <= 0)
				{
					i++;
					Swap(array, i, j);
				}
			}

			Swap(array, i + 1, right);
			return i + 1;
		}

		/// <summary>
		/// Обменивает два элемента в массиве.
		/// </summary>
		private void Swap(T[] array, int i, int j)
		{
			var temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}

		/// <summary>
		/// Вызывает событие завершения сортировки.
		/// </summary>
		protected virtual void OnSortCompleted()
		{
			SortCompleted?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Вызывает событие прогресса сортировки.
		/// </summary>
		protected virtual void OnSortProgress(SortProgressEventArgs e)
		{
			SortProgress?.Invoke(this, e);
		}
	}

	/// <summary>
	/// Статический класс с методами сортировки без использования встроенных средств.
	/// </summary>
	public static class ArraySorter
	{
		/// <summary>
		/// Сортирует массив с использованием делегата сравнения.
		/// </summary>
		/// <typeparam name="T">Тип элементов массива.</typeparam>
		/// <param name="array">Массив для сортировки.</param>
		/// <param name="comparer">Делегат для сравнения элементов.</param>
		public static void Sort<T>(T[] array, ComparisonDelegate<T> comparer)
		{
			Argument.NotNull(array, "Массив не может быть null.");
			Argument.NotNull(comparer, "Делегат сравнения не может быть null.");

			for (var i = 0; i < array.Length - 1; i++)
			{
				for (var j = 0; j < array.Length - i - 1; j++)
				{
					if (comparer(array[j], array[j + 1]) > 0)
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

