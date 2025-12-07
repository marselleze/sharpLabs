namespace Lab3Library
{
	/// <summary>
	/// Представляет динамический массив с возможностью автоматического расширения.
	/// </summary>
	/// <typeparam name="T">Тип элементов массива.</typeparam>
	public class DynamicArray<T> : IEnumerable<T>
	{
		private T[] _items;
		private int _count;

		/// <summary>
		/// Получает количество элементов в массиве.
		/// </summary>
		public int Length => _count;

		/// <summary>
		/// Получает ёмкость массива (длина внутреннего массива).
		/// </summary>
		public int Capacity => _items.Length;

		/// <summary>
		/// Инициализирует новый экземпляр класса DynamicArray с ёмкостью по умолчанию 8.
		/// </summary>
		public DynamicArray()
		{
			_items = new T[8];
			_count = 0;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса DynamicArray с указанной начальной ёмкостью.
		/// </summary>
		/// <param name="capacity">Начальная ёмкость массива.</param>
		/// <exception cref="ArgumentException">Выбрасывается, если capacity меньше или равно нулю.</exception>
		public DynamicArray(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentException("Ёмкость должна быть положительным числом.", nameof(capacity));
			}

			_items = new T[capacity];
			_count = 0;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса DynamicArray, копируя элементы из указанной коллекции.
		/// </summary>
		/// <param name="collection">Коллекция элементов для копирования.</param>
		/// <exception cref="ArgumentNullException">Выбрасывается, если collection равен null.</exception>
		public DynamicArray(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException(nameof(collection), "Коллекция не может быть null.");
			}

			var tempArray = new T[8];
			var tempCount = 0;

			foreach (var item in collection)
			{
				if (tempCount >= tempArray.Length)
				{
					var newArray = new T[tempArray.Length * 2];

					for (var i = 0; i < tempArray.Length; i++)
					{
						newArray[i] = tempArray[i];
					}

					tempArray = newArray;
				}

				tempArray[tempCount] = item;
				tempCount++;
			}

			_count = tempCount;
			_items = new T[_count > 0 ? _count : 8];

			for (var i = 0; i < _count; i++)
			{
				_items[i] = tempArray[i];
			}
		}

		/// <summary>
		/// Получает или устанавливает элемент по указанному индексу.
		/// </summary>
		/// <param name="index">Индекс элемента.</param>
		/// <returns>Элемент по указанному индексу.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если индекс выходит за границы массива.</exception>
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= _count)
				{
					throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.");
				}

				return _items[index];
			}
			set
			{
				if (index < 0 || index >= _count)
				{
					throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.");
				}

				_items[index] = value;
			}
		}

		/// <summary>
		/// Добавляет элемент в конец массива.
		/// </summary>
		/// <param name="item">Элемент для добавления.</param>
		public void Add(T item)
		{
			if (_count >= _items.Length)
			{
				ResizeArray(_items.Length * 2);
			}

			_items[_count] = item;
			_count++;
		}

		/// <summary>
		/// Добавляет элементы из указанной коллекции в конец массива.
		/// Расширение массива выполняется только один раз, если необходимо.
		/// </summary>
		/// <param name="collection">Коллекция элементов для добавления.</param>
		/// <exception cref="ArgumentNullException">Выбрасывается, если collection равен null.</exception>
		public void AddRange(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException(nameof(collection), "Коллекция не может быть null.");
			}

			var tempArray = new T[8];
			var tempCount = 0;

			foreach (var item in collection)
			{
				if (tempCount >= tempArray.Length)
				{
					var newArray = new T[tempArray.Length * 2];

					for (var i = 0; i < tempArray.Length; i++)
					{
						newArray[i] = tempArray[i];
					}

					tempArray = newArray;
				}

				tempArray[tempCount] = item;
				tempCount++;
			}

			if (tempCount == 0)
			{
				return;
			}

			var requiredCapacity = _count + tempCount;

			if (requiredCapacity > _items.Length)
			{
				var newCapacity = _items.Length;

				while (newCapacity < requiredCapacity)
				{
					newCapacity *= 2;
				}

				ResizeArray(newCapacity);
			}

			for (var i = 0; i < tempCount; i++)
			{
				_items[_count + i] = tempArray[i];
			}

			_count += tempCount;
		}

		/// <summary>
		/// Удаляет первое вхождение указанного элемента из массива.
		/// </summary>
		/// <param name="item">Элемент для удаления.</param>
		/// <returns>true, если элемент был успешно удалён; иначе false.</returns>
		public bool Remove(T item)
		{
			var index = -1;

			for (var i = 0; i < _count; i++)
			{
				if (Equals(_items[i], item))
				{
					index = i;
					break;
				}
			}

			if (index == -1)
			{
				return false;
			}

			for (var i = index; i < _count - 1; i++)
			{
				_items[i] = _items[i + 1];
			}

			_count--;
			_items[_count] = default(T)!;

			return true;
		}

		/// <summary>
		/// Вставляет элемент по указанному индексу.
		/// </summary>
		/// <param name="index">Индекс, по которому нужно вставить элемент.</param>
		/// <param name="item">Элемент для вставки.</param>
		/// <returns>true, если элемент был успешно вставлен; иначе false.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если индекс выходит за границы массива.</exception>
		public bool Insert(int index, T item)
		{
			if (index < 0 || index > _count)
			{
				throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за границы массива.");
			}

			if (_count >= _items.Length)
			{
				ResizeArray(_items.Length * 2);
			}

			for (var i = _count; i > index; i--)
			{
				_items[i] = _items[i - 1];
			}

			_items[index] = item;
			_count++;

			return true;
		}

		/// <summary>
		/// Изменяет размер внутреннего массива.
		/// </summary>
		/// <param name="newCapacity">Новая ёмкость массива.</param>
		private void ResizeArray(int newCapacity)
		{
			var newItems = new T[newCapacity];

			for (var i = 0; i < _count; i++)
			{
				newItems[i] = _items[i];
			}

			_items = newItems;
		}

		/// <summary>
		/// Возвращает перечислитель, который выполняет итерацию по коллекции.
		/// </summary>
		/// <returns>Перечислитель для коллекции.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			for (var i = 0; i < _count; i++)
			{
				yield return _items[i];
			}
		}

		/// <summary>
		/// Возвращает перечислитель, который выполняет итерацию по коллекции.
		/// </summary>
		/// <returns>Перечислитель для коллекции.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

