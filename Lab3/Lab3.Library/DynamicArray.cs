using System.Collections;
using SharpLabs.Common;

namespace Lab3.Library
{
	/// <summary>
	/// Динамический массив с автоматическим расширением емкости.
	/// </summary>
	/// <typeparam name="T">Тип элементов массива.</typeparam>
	public class DynamicArray<T> : IEnumerable<T>, IEquatable<DynamicArray<T>>
	{
		private T[] _items;
		private int _count;
		private const int DefaultCapacity = 8;

		/// <summary>
		/// Получает количество элементов в массиве.
		/// </summary>
		public int Length => _count;

		/// <summary>
		/// Получает текущую емкость массива.
		/// </summary>
		public int Capacity => _items.Length;

		/// <summary>
		/// Получает или устанавливает элемент по указанному индексу.
		/// </summary>
		/// <param name="index">Индекс элемента.</param>
		/// <returns>Элемент по указанному индексу.</returns>
		public T this[int index]
		{
			get
			{
				Argument.Require(index >= 0 && index < _count, $"Индекс должен быть в диапазоне от 0 до {_count - 1}.");
				return _items[index];
			}
			set
			{
				Argument.Require(index >= 0 && index < _count, $"Индекс должен быть в диапазоне от 0 до {_count - 1}.");
				_items[index] = value;
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса DynamicArray с емкостью по умолчанию.
		/// </summary>
		public DynamicArray()
		{
			_items = new T[DefaultCapacity];
			_count = 0;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса DynamicArray с указанной емкостью.
		/// </summary>
		/// <param name="capacity">Начальная емкость массива.</param>
		public DynamicArray(int capacity)
		{
			Argument.Require(capacity > 0, "Емкость должна быть положительным числом.");

			_items = new T[capacity];
			_count = 0;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса DynamicArray из коллекции.
		/// </summary>
		/// <param name="collection">Коллекция элементов для инициализации.</param>
		public DynamicArray(IEnumerable<T> collection)
		{
			Argument.NotNull(collection, "Коллекция не может быть null.");

			var list = new List<T>(collection);
			var capacity = list.Count > 0 ? list.Count : DefaultCapacity;

			_items = new T[capacity];
			_count = 0;

			foreach (var item in list)
			{
				_items[_count++] = item;
			}
		}

		/// <summary>
		/// Добавляет элемент в конец массива.
		/// </summary>
		/// <param name="item">Элемент для добавления.</param>
		public void Add(T item)
		{
			if (_count == _items.Length)
			{
				ExpandCapacity();
			}

			_items[_count++] = item;
		}

		/// <summary>
		/// Добавляет коллекцию элементов в конец массива.
		/// </summary>
		/// <param name="collection">Коллекция элементов для добавления.</param>
		public void AddRange(IEnumerable<T> collection)
		{
			Argument.NotNull(collection, "Коллекция не может быть null.");

			foreach (var item in collection)
			{
				Add(item);
			}
		}

		/// <summary>
		/// Удаляет указанный элемент из массива.
		/// </summary>
		/// <param name="item">Элемент для удаления.</param>
		/// <returns>True, если элемент был найден и удален; иначе False.</returns>
		public bool Remove(T item)
		{
			var index = IndexOf(item);

			if (index >= 0)
			{
				RemoveAt(index);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Вставляет элемент в указанную позицию массива.
		/// </summary>
		/// <param name="index">Позиция для вставки.</param>
		/// <param name="item">Элемент для вставки.</param>
		public void Insert(int index, T item)
		{
			Argument.Require(index >= 0 && index <= _count, $"Индекс должен быть в диапазоне от 0 до {_count}.");

			if (_count == _items.Length)
			{
				ExpandCapacity();
			}

			for (var i = _count; i > index; i--)
			{
				_items[i] = _items[i - 1];
			}

			_items[index] = item;
			_count++;
		}

		/// <summary>
		/// Находит индекс первого вхождения элемента в массиве.
		/// </summary>
		/// <param name="item">Искомый элемент.</param>
		/// <returns>Индекс элемента или -1, если элемент не найден.</returns>
		public int IndexOf(T item)
		{
			for (var i = 0; i < _count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(_items[i], item))
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Удаляет элемент по указанному индексу.
		/// </summary>
		/// <param name="index">Индекс элемента для удаления.</param>
		private void RemoveAt(int index)
		{
			Argument.Require(index >= 0 && index < _count, $"Индекс должен быть в диапазоне от 0 до {_count - 1}.");

			for (var i = index; i < _count - 1; i++)
			{
				_items[i] = _items[i + 1];
			}

			_items[_count - 1] = default!;
			_count--;
		}

		/// <summary>
		/// Расширяет емкость массива вдвое.
		/// </summary>
		private void ExpandCapacity()
		{
			var newCapacity = _items.Length * 2;
			var newItems = new T[newCapacity];

			for (var i = 0; i < _count; i++)
			{
				newItems[i] = _items[i];
			}

			_items = newItems;
		}

		/// <summary>
		/// Возвращает перечислитель для обхода элементов массива.
		/// </summary>
		public IEnumerator<T> GetEnumerator()
		{
			for (var i = 0; i < _count; i++)
			{
				yield return _items[i];
			}
		}

		/// <summary>
		/// Возвращает перечислитель для обхода элементов массива.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Определяет, равен ли данный массив другому массиву.
		/// </summary>
		/// <param name="other">Другой массив для сравнения.</param>
		/// <returns>True, если массивы равны; иначе False.</returns>
		public bool Equals(DynamicArray<T>? other)
		{
			if (other == null)
			{
				return false;
			}

			if (_count != other._count)
			{
				return false;
			}

			for (var i = 0; i < _count; i++)
			{
				if (!EqualityComparer<T>.Default.Equals(_items[i], other._items[i]))
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Определяет, равен ли данный массив другому объекту.
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is DynamicArray<T> other)
			{
				return Equals(other);
			}

			return false;
		}

		/// <summary>
		/// Возвращает хеш-код для данного массива.
		/// </summary>
		public override int GetHashCode()
		{
			var hash = 17;

			for (var i = 0; i < _count; i++)
			{
				hash = hash * 31 + (_items[i]?.GetHashCode() ?? 0);
			}

			return hash;
		}
	}
}

