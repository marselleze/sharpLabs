using System;
using System.IO;

namespace Lab9Library
{
	/// <summary>
	/// Реализует блочное побайтовое копирование файла с уведомлением о прогрессе.
	/// </summary>
	public class BlockFileCopier
	{
		/// <summary>
		/// Событие, возникающее при старте копирования.
		/// </summary>
		public event EventHandler? CopyStarted;

		/// <summary>
		/// Событие, возникающее при завершении копирования.
		/// </summary>
		public event EventHandler? CopyCompleted;

		/// <summary>
		/// Событие, возникающее при изменении прогресса копирования.
		/// </summary>
		public event EventHandler<CopyProgressEventArgs>? CopyProgressChanged;

		/// <summary>
		/// Выполняет побайтовое блочное копирование файла.
		/// </summary>
		/// <param name="sourceFilePath">Путь к исходному файлу.</param>
		/// <param name="destinationFilePath">Путь к конечному файлу.</param>
		/// <param name="blockSize">Размер блока чтения/записи в байтах.</param>
		public void Copy(string sourceFilePath, string destinationFilePath, int blockSize)
		{
			ValidateArguments(sourceFilePath, destinationFilePath, blockSize);

			if (!File.Exists(sourceFilePath))
			{
				throw new FileNotFoundException("Исходный файл не найден.", sourceFilePath);
			}

			OnCopyStarted();

			using (var sourceStream = new FileStream(
				       sourceFilePath,
				       FileMode.Open,
				       FileAccess.Read,
				       FileShare.Read))
			using (var destinationStream = new FileStream(
				       destinationFilePath,
				       FileMode.Create,
				       FileAccess.Write,
				       FileShare.None))
			{
				var totalBytes = sourceStream.Length;
				var buffer = new byte[blockSize];
				long copiedBytes = 0;
				var lastReportedProgress = -1;

				int bytesRead;

				while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					destinationStream.Write(buffer, 0, bytesRead);
					copiedBytes += bytesRead;

					if (totalBytes > 0)
					{
						var progress = (int)(copiedBytes * 100 / totalBytes);

						if (progress != lastReportedProgress)
						{
							lastReportedProgress = progress;
							OnCopyProgressChanged(progress);
						}
					}
				}
			}

			EnsureFilesAreIdentical(sourceFilePath, destinationFilePath);

			OnCopyCompleted();
		}

		private static void ValidateArguments(string sourceFilePath, string destinationFilePath, int blockSize)
		{
			if (string.IsNullOrWhiteSpace(sourceFilePath))
			{
				throw new ArgumentException("Путь к исходному файлу не должен быть пустым.", nameof(sourceFilePath));
			}

			if (string.IsNullOrWhiteSpace(destinationFilePath))
			{
				throw new ArgumentException("Путь к конечному файлу не должен быть пустым.", nameof(destinationFilePath));
			}

			if (blockSize <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(blockSize), "Размер блока должен быть положительным.");
			}
		}

		private static void EnsureFilesAreIdentical(string sourceFilePath, string destinationFilePath)
		{
			using (var sourceStream = new FileStream(
				       sourceFilePath,
				       FileMode.Open,
				       FileAccess.Read,
				       FileShare.Read))
			using (var destinationStream = new FileStream(
				       destinationFilePath,
				       FileMode.Open,
				       FileAccess.Read,
				       FileShare.Read))
			{
				if (sourceStream.Length != destinationStream.Length)
				{
					throw new InvalidOperationException("Файлы имеют разный размер и не являются идентичными.");
				}

				var bufferSize = 4096;
				var sourceBuffer = new byte[bufferSize];
				var destinationBuffer = new byte[bufferSize];

				int sourceRead;

				while ((sourceRead = sourceStream.Read(sourceBuffer, 0, sourceBuffer.Length)) > 0)
				{
					var destinationRead = destinationStream.Read(destinationBuffer, 0, destinationBuffer.Length);

					if (sourceRead != destinationRead)
					{
						throw new InvalidOperationException("Файлы имеют разный размер блока и не являются идентичными.");
					}

					for (var i = 0; i < sourceRead; i++)
					{
						if (sourceBuffer[i] != destinationBuffer[i])
						{
							throw new InvalidOperationException("Содержимое файлов отличается, файлы не идентичны побайтно.");
						}
					}
				}
			}
		}

		private void OnCopyStarted()
		{
			CopyStarted?.Invoke(this, EventArgs.Empty);
		}

		private void OnCopyCompleted()
		{
			CopyCompleted?.Invoke(this, EventArgs.Empty);
		}

		private void OnCopyProgressChanged(int progress)
		{
			var handler = CopyProgressChanged;

			if (handler != null)
			{
				var args = new CopyProgressEventArgs(progress);
				handler(this, args);
			}
		}
	}
}


