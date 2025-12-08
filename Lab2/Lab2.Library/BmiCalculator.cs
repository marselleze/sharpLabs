using SharpLabs.Common;

namespace Lab2.Library
{
	/// <summary>
	/// Калькулятор индекса массы тела (ИМТ, BMI).
	/// </summary>
	public static class BmiCalculator
	{
		private const double MinWeight = 0.1;
		private const double MinHeight = 0.1;

		/// <summary>
		/// Вычисляет индекс массы тела (BMI).
		/// </summary>
		/// <param name="weight">Масса тела в килограммах.</param>
		/// <param name="height">Рост в метрах.</param>
		/// <returns>Значение индекса массы тела.</returns>
		/// <exception cref="ArgumentException">Выбрасывается, если масса или рост имеют некорректные значения.</exception>
		public static double CalculateBmi(double weight, double height)
		{
			Argument.Require(weight >= MinWeight, "Масса тела должна быть положительным числом.");
			Argument.Require(height >= MinHeight, "Рост должен быть положительным числом.");

			return weight / (height * height);
		}

		/// <summary>
		/// Возвращает интерпретацию значения ИМТ.
		/// </summary>
		/// <param name="bmi">Значение индекса массы тела.</param>
		/// <returns>Текстовое описание категории веса.</returns>
		public static string GetBmiCategory(double bmi)
		{
			if (bmi < 16.0)
			{
				return "Выраженный дефицит массы тела";
			}

			if (bmi < 18.5)
			{
				return "Недостаточная масса тела";
			}

			if (bmi < 25.0)
			{
				return "Норма";
			}

			if (bmi < 30.0)
			{
				return "Избыточная масса тела";
			}

			if (bmi < 35.0)
			{
				return "Ожирение первой степени";
			}

			if (bmi < 40.0)
			{
				return "Ожирение второй степени";
			}

			return "Ожирение третьей степени";
		}
	}
}

