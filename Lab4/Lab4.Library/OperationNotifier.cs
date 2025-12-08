namespace Lab4.Library
{
	/// <summary>
	/// Аргументы события операции с данными.
	/// </summary>
	public class OperationEventArgs : EventArgs
	{
		/// <summary>
		/// Название операции.
		/// </summary>
		public string OperationName { get; }

		/// <summary>
		/// Время выполнения операции.
		/// </summary>
		public DateTime Timestamp { get; }

		/// <summary>
		/// Дополнительная информация об операции.
		/// </summary>
		public string Message { get; }

		/// <summary>
		/// Инициализирует новый экземпляр класса OperationEventArgs.
		/// </summary>
		public OperationEventArgs(string operationName, string message)
		{
			OperationName = operationName;
			Message = message;
			Timestamp = DateTime.Now;
		}
	}

	/// <summary>
	/// Класс для демонстрации работы с событиями и делегатами.
	/// </summary>
	public class OperationNotifier
	{
		/// <summary>
		/// Событие, возникающее при начале операции.
		/// </summary>
		public event EventHandler<OperationEventArgs>? OperationStarting;

		/// <summary>
		/// Событие, возникающее при завершении операции.
		/// </summary>
		public event EventHandler<OperationEventArgs>? OperationCompleted;

		/// <summary>
		/// Событие, возникающее при ошибке в процессе операции.
		/// </summary>
		public event EventHandler<OperationEventArgs>? OperationFailed;

		/// <summary>
		/// Выполняет операцию с уведомлением подписчиков о ходе выполнения.
		/// </summary>
		/// <param name="operationName">Название операции.</param>
		/// <param name="action">Действие для выполнения.</param>
		public void ExecuteOperation(string operationName, Action action)
		{
			try
			{
				OnOperationStarting(new OperationEventArgs(operationName, "Операция начата"));

				action?.Invoke();

				OnOperationCompleted(new OperationEventArgs(operationName, "Операция успешно завершена"));
			}
			catch (Exception ex)
			{
				OnOperationFailed(new OperationEventArgs(operationName, $"Ошибка: {ex.Message}"));
			}
		}

		/// <summary>
		/// Вызывает событие начала операции.
		/// </summary>
		protected virtual void OnOperationStarting(OperationEventArgs e)
		{
			OperationStarting?.Invoke(this, e);
		}

		/// <summary>
		/// Вызывает событие завершения операции.
		/// </summary>
		protected virtual void OnOperationCompleted(OperationEventArgs e)
		{
			OperationCompleted?.Invoke(this, e);
		}

		/// <summary>
		/// Вызывает событие ошибки операции.
		/// </summary>
		protected virtual void OnOperationFailed(OperationEventArgs e)
		{
			OperationFailed?.Invoke(this, e);
		}
	}

	/// <summary>
	/// Класс для демонстрации различных типов делегатов.
	/// </summary>
	public static class DelegateExamples
	{
		/// <summary>
		/// Делегат-callback для операций обработки данных.
		/// </summary>
		public delegate void ProcessCallback(string message);

		/// <summary>
		/// Демонстрирует использование Action делегата.
		/// </summary>
		public static void DemonstrateAction()
		{
			Action<string> printMessage = message => Console.WriteLine($"Action: {message}");
			printMessage("Пример использования Action");
		}

		/// <summary>
		/// Демонстрирует использование Func делегата.
		/// </summary>
		public static void DemonstrateFunc()
		{
			Func<int, int, int> add = (a, b) => a + b;
			var result = add(5, 3);
			Console.WriteLine($"Func результат: {result}");
		}

		/// <summary>
		/// Демонстрирует использование пользовательского делегата.
		/// </summary>
		public static void DemonstrateCustomDelegate()
		{
			ProcessCallback callback = message => Console.WriteLine($"Callback: {message}");
			callback("Пример пользовательского делегата");
		}

		/// <summary>
		/// Демонстрирует использование лямбда-выражений.
		/// </summary>
		public static void DemonstrateLambda()
		{
			var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			Console.WriteLine("Демонстрация лямбда-выражений:");

			var evenNumbers = Array.FindAll(numbers, n => n % 2 == 0);
			Console.WriteLine($"Четные числа: {string.Join(", ", evenNumbers)}");

			var squaredNumbers = Array.ConvertAll(numbers, n => n * n);
			Console.WriteLine($"Квадраты чисел: {string.Join(", ", squaredNumbers)}");

			var sum = Array.FindAll(numbers, n => n > 5)
				.Aggregate(0, (acc, n) => acc + n);
			Console.WriteLine($"Сумма чисел больше 5: {sum}");
		}
	}
}

