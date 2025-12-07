using System;

namespace Lab9Library
{
	/// <summary>
	/// Содержит данные о прогрессе копирования файла.
	/// </summary>
	public class CopyProgressEventArgs : EventArgs
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="CopyProgressEventArgs"/>.
		/// </summary>
		/// <param name="progressPercentage">Прогресс копирования в процентах.</param>
		public CopyProgressEventArgs(int progressPercentage)
		{
			if (progressPercentage < 0 || progressPercentage > 100)
			{
				throw new ArgumentOutOfRangeException(
					nameof(progressPercentage),
					"Процент прогресса должен находиться в диапазоне от 0 до 100.");
			}

			ProgressPercentage = progressPercentage;
		}

		/// <summary>
		/// Получает прогресс копирования в процентах.
		/// </summary>
		public int ProgressPercentage { get; }
	}
}


