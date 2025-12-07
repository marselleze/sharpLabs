namespace Lab4Library
{
	/// <summary>
	/// Делегат сравнения двух элементов.
	/// </summary>
	/// <typeparam name="T">Тип сравниваемых элементов.</typeparam>
	/// <param name="first">Первый элемент.</param>
	/// <param name="second">Второй элемент.</param>
	/// <returns>true, если первый элемент должен располагаться перед вторым; иначе false.</returns>
	public delegate bool ComparisonRule<in T>(T first, T second);

	/// <summary>
	/// Аргументы события завершения сортировки.
	/// </summary>
	public class SortCompletedEventArgs : EventArgs
	{
		/// <summary>
		/// Получает количество сравнений, выполненных при сортировке.
		/// </summary>
		public int ComparisonsCount { get; }

		/// <summary>
		/// Получает количество обменов элементов, выполненных при сортировке.
		/// </summary>
		public int SwapsCount { get; }

		/// <summary>
		/// Инициализирует новый экземпляр класса SortCompletedEventArgs.
		/// </summary>
		/// <param name="comparisonsCount">Количество сравнений.</param>
		/// <param name="swapsCount">Количество обменов.</param>
		public SortCompletedEventArgs(int comparisonsCount, int swapsCount)
		{
			if (comparisonsCount < 0)
			{
				throw new ArgumentException("Количество сравнений не может быть отрицательным.", nameof(comparisonsCount));
			}

			if (swapsCount < 0)
			{
				throw new ArgumentException("Количество обменов не может быть отрицательным.", nameof(swapsCount));
			}

			ComparisonsCount = comparisonsCount;
			SwapsCount = swapsCount;
		}
	}

	/// <summary>
	/// Универсальный сортировщик массивов, использующий делегат сравнения.
	/// </summary>
	/// <typeparam name="T">Тип элементов массива.</typeparam>
	public class GenericArraySorter<T>
	{
		/// <summary>
		/// Событие, сигнализирующее о завершении сортировки.
		/// </summary>
		public event EventHandler<SortCompletedEventArgs>? SortCompleted;

		/// <summary>
		/// Сортирует указанный массив на месте, используя переданный делегат сравнения.
		/// </summary>
		/// <param name="items">Массив для сортировки.</param>
		/// <param name="comparisonRule">Делегат, определяющий порядок элементов.</param>
		/// <exception cref="ArgumentNullException">Выбрасывается, если items или comparisonRule равны null.</exception>
		public void Sort(T[] items, ComparisonRule<T> comparisonRule)
		{
			if (items == null)
			{
				throw new ArgumentNullException(nameof(items), "Массив не может быть null.");
			}

			if (comparisonRule == null)
			{
				throw new ArgumentNullException(nameof(comparisonRule), "Делегат сравнения не может быть null.");
			}

			var comparisons = 0;
			var swaps = 0;

			for (var i = 0; i < items.Length - 1; i++)
			{
				for (var j = 0; j < items.Length - 1 - i; j++)
				{
					comparisons++;

					if (comparisonRule(items[j + 1], items[j]))
					{
						var temp = items[j];
						items[j] = items[j + 1];
						items[j + 1] = temp;
						swaps++;
					}
				}
			}

			OnSortCompleted(new SortCompletedEventArgs(comparisons, swaps));
		}

		/// <summary>
		/// Вызывает событие SortCompleted.
		/// </summary>
		/// <param name="e">Аргументы события.</param>
		protected virtual void OnSortCompleted(SortCompletedEventArgs e)
		{
			SortCompleted?.Invoke(this, e);
		}
	}
}


