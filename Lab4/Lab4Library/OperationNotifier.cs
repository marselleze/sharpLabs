namespace Lab4Library
{
	/// <summary>
	/// Делегат для однопараметрической операции над целым числом.
	/// </summary>
	/// <param name="value">Число для обработки.</param>
	/// <returns>Результат операции.</returns>
	public delegate int NumberOperation(int value);

	/// <summary>
	/// Делегат для операции над двумя целыми числами.
	/// </summary>
	/// <param name="first">Первое число.</param>
	/// <param name="second">Второе число.</param>
	/// <returns>Результат операции.</returns>
	public delegate int BinaryNumberOperation(int first, int second);

	/// <summary>
	/// Класс, демонстрирующий работу с событиями с аргументами и без.
	/// </summary>
	public class OperationNotifier
	{
		/// <summary>
		/// Событие, сигнализирующее о начале операции (без аргументов).
		/// </summary>
		public event Action? OperationStarted;

		/// <summary>
		/// Событие, сигнализирующее о прогрессе операции (с простым аргументом).
		/// </summary>
		public event EventHandler<int>? OperationProgress;

		/// <summary>
		/// Событие, сигнализирующее о завершении операции (с сообщением).
		/// </summary>
		public event EventHandler<string>? OperationFinished;

		/// <summary>
		/// Запускает демонстрационную операцию и генерирует события.
		/// </summary>
		public void RunOperation()
		{
			OnOperationStarted();

			for (var progress = 0; progress <= 100; progress += 25)
			{
				OnOperationProgress(progress);
			}

			OnOperationFinished("Операция успешно завершена.");
		}

		/// <summary>
		/// Вызывает событие OperationStarted.
		/// </summary>
		protected virtual void OnOperationStarted()
		{
			OperationStarted?.Invoke();
		}

		/// <summary>
		/// Вызывает событие OperationProgress.
		/// </summary>
		/// <param name="progress">Текущее значение прогресса.</param>
		protected virtual void OnOperationProgress(int progress)
		{
			OperationProgress?.Invoke(this, progress);
		}

		/// <summary>
		/// Вызывает событие OperationFinished.
		/// </summary>
		/// <param name="message">Сообщение о результате выполнения.</param>
		protected virtual void OnOperationFinished(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				throw new ArgumentException("Сообщение не должно быть пустым.", nameof(message));
			}

			OperationFinished?.Invoke(this, message);
		}
	}
}


