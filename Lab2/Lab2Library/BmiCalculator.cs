namespace Lab2Library
{
	/// <summary>
	/// Предоставляет методы для расчёта индекса массы тела (ИМТ).
	/// </summary>
	public static class BmiCalculator
	{
		/// <summary>
		/// Вычисляет индекс массы тела по формуле: ИМТ = масса (кг) / рост (м)².
		/// </summary>
		/// <param name="weight">Масса тела в килограммах.</param>
		/// <param name="height">Рост в метрах.</param>
		/// <returns>Значение индекса массы тела.</returns>
		/// <exception cref="ArgumentException">Выбрасывается, если масса или рост имеют недопустимые значения.</exception>
		public static double CalculateBmi(double weight, double height)
		{
			if (weight <= 0)
			{
				throw new ArgumentException("Масса должна быть положительным числом.", nameof(weight));
			}

			if (height <= 0)
			{
				throw new ArgumentException("Рост должен быть положительным числом.", nameof(height));
			}

			return weight / (height * height);
		}
	}
}

