namespace Lab3Library
{
	/// <summary>
	/// Предоставляет методы для демонстрации работы с различными типами коллекций.
	/// </summary>
	public static class CollectionsDemo
	{
		/// <summary>
		/// Демонстрирует работу со списком (List).
		/// </summary>
		public static void DemonstrateList()
		{
			Console.WriteLine("=== Демонстрация List<T> ===");
			var list = new List<int> { 1, 2, 3, 4, 5 };
			Console.WriteLine($"Исходный список: {string.Join(", ", list)}");

			list.Add(6);
			Console.WriteLine($"После Add(6): {string.Join(", ", list)}");

			list.Insert(0, 0);
			Console.WriteLine($"После Insert(0, 0): {string.Join(", ", list)}");

			list.Remove(3);
			Console.WriteLine($"После Remove(3): {string.Join(", ", list)}");

			Console.WriteLine($"Содержит 5: {list.Contains(5)}");
			Console.WriteLine($"Индекс элемента 4: {list.IndexOf(4)}");
			Console.WriteLine();
		}

		/// <summary>
		/// Демонстрирует работу со словарём (Dictionary).
		/// </summary>
		public static void DemonstrateDictionary()
		{
			Console.WriteLine("=== Демонстрация Dictionary<TKey, TValue> ===");
			var dictionary = new Dictionary<string, int>
			{
				{ "один", 1 },
				{ "два", 2 },
				{ "три", 3 }
			};

			Console.WriteLine("Содержимое словаря:");
			foreach (var kvp in dictionary)
			{
				Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
			}

			dictionary["четыре"] = 4;
			Console.WriteLine($"После добавления 'четыре': {dictionary["четыре"]}");

			Console.WriteLine($"Содержит ключ 'два': {dictionary.ContainsKey("два")}");
			Console.WriteLine($"Содержит значение 3: {dictionary.ContainsValue(3)}");

			dictionary.Remove("один");
			Console.WriteLine($"После удаления 'один': количество элементов = {dictionary.Count}");
			Console.WriteLine();
		}

		/// <summary>
		/// Демонстрирует работу с очередью (Queue).
		/// </summary>
		public static void DemonstrateQueue()
		{
			Console.WriteLine("=== Демонстрация Queue<T> ===");
			var queue = new Queue<string>();
			queue.Enqueue("первый");
			queue.Enqueue("второй");
			queue.Enqueue("третий");

			Console.WriteLine($"Количество элементов в очереди: {queue.Count}");

			while (queue.Count > 0)
			{
				var item = queue.Dequeue();
				Console.WriteLine($"Извлечён из очереди: {item}");
			}

			Console.WriteLine($"Количество элементов после извлечения: {queue.Count}");
			Console.WriteLine();
		}

		/// <summary>
		/// Демонстрирует работу со стеком (Stack).
		/// </summary>
		public static void DemonstrateStack()
		{
			Console.WriteLine("=== Демонстрация Stack<T> ===");
			var stack = new Stack<int>();
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);

			Console.WriteLine($"Количество элементов в стеке: {stack.Count}");
			Console.WriteLine($"Верхний элемент (без извлечения): {stack.Peek()}");

			while (stack.Count > 0)
			{
				var item = stack.Pop();
				Console.WriteLine($"Извлечён из стека: {item}");
			}

			Console.WriteLine($"Количество элементов после извлечения: {stack.Count}");
			Console.WriteLine();
		}
	}
}

