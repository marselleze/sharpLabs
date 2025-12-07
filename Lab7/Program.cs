using Lab7Library;

namespace Lab7
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №7.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №7");
			Console.WriteLine("Классы Round, User, Employee иерархия и события.");
			Console.WriteLine();

			var exitRequested = false;

			while (!exitRequested)
			{
				Console.WriteLine("Выберите действие:");
				Console.WriteLine("1 - Демонстрация класса Round");
				Console.WriteLine("2 - Создать пользователя User");
				Console.WriteLine("3 - Создать сотрудника Employee и показать иерархию/событие");
				Console.WriteLine("0 - Выход");
				Console.Write("Ваш выбор: ");

				var choice = Console.ReadLine();
				Console.WriteLine();

				switch (choice)
				{
					case "1":
						DemonstrateRound();
						break;
					case "2":
						CreateUser();
						break;
					case "3":
						CreateEmployee();
						break;
					case "0":
						exitRequested = true;
						break;
					default:
						Console.WriteLine("Неизвестный пункт меню.");
						break;
				}

				Console.WriteLine();
			}
		}

		private static void DemonstrateRound()
		{
			Console.WriteLine("=== Класс Round ===");

			var x = ReadDouble("Введите координату X центра: ");
			var y = ReadDouble("Введите координату Y центра: ");
			var radius = ReadPositiveDouble("Введите радиус: ");

			try
			{
				var round = new Round(x, y, radius);
				Console.WriteLine($"Длина окружности: {round.Circumference:F2}");
				Console.WriteLine($"Площадь круга: {round.Area:F2}");

				var pointX = ReadDouble("Введите координату X точки: ");
				var pointY = ReadDouble("Введите координату Y точки: ");
				Console.WriteLine(round.ContainsPoint(pointX, pointY)
					? "Точка находится внутри круга."
					: "Точка находится вне круга.");

				round.Move(1, 1);
				Console.WriteLine($"После сдвига (1,1) центр: ({round.CenterX}; {round.CenterY})");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		private static void CreateUser()
		{
			Console.WriteLine("=== Класс User ===");

			var lastName = ReadRequiredString("Фамилия: ");
			var firstName = ReadRequiredString("Имя: ");
			var middleName = ReadOptionalString("Отчество (можно пропустить): ");
			var birthDate = ReadDate("Дата рождения (дд.ММ.гггг): ");

			try
			{
				var user = new User(lastName, firstName, middleName, birthDate);
				Console.WriteLine("Создан пользователь:");
				Console.WriteLine(user);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		private static void CreateEmployee()
		{
			Console.WriteLine("=== Класс Employee и иерархия ===");

			var lastName = ReadRequiredString("Фамилия: ");
			var firstName = ReadRequiredString("Имя: ");
			var middleName = ReadOptionalString("Отчество (можно пропустить): ");
			var birthDate = ReadDate("Дата рождения (дд.ММ.гггг): ");
			var experience = (int)ReadNonNegativeDouble("Стаж работы (полных лет): ");
			var position = ReadRequiredString("Текущая должность: ");

			try
			{
				var employee = new Employee(lastName, firstName, middleName, birthDate, experience, position);
				employee.PositionChanged += EmployeeOnPositionChanged;

				Console.WriteLine("Создан сотрудник:");
				Console.WriteLine(employee.GetDescription());
				Console.WriteLine(employee.DescribeRole());

				var newPosition = ReadOptionalString("Введите новую должность для демонстрации события (Enter для пропуска): ");

				if (!string.IsNullOrWhiteSpace(newPosition))
				{
					employee.Promote(newPosition);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		private static void EmployeeOnPositionChanged(object? sender, string e)
		{
			if (sender is Employee employee)
			{
				Console.WriteLine($"Событие: сотрудник {employee.FullName} теперь занимает должность \"{e}\".");
			}
		}

		private static string ReadRequiredString(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				var input = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(input))
				{
					return input.Trim();
				}

				Console.WriteLine("Значение не может быть пустым.");
			}
		}

		private static string ReadOptionalString(string prompt)
		{
			Console.Write(prompt);
			return Console.ReadLine() ?? string.Empty;
		}

		private static DateTime ReadDate(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				var input = Console.ReadLine();

				if (DateTime.TryParse(input, out var date))
				{
					return date;
				}

				Console.WriteLine("Некорректная дата. Повторите попытку.");
			}
		}

		private static double ReadDouble(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				var input = Console.ReadLine();

				if (double.TryParse(input, out var value))
				{
					return value;
				}

				Console.WriteLine("Некорректное число. Попробуйте снова.");
			}
		}

		private static double ReadPositiveDouble(string prompt)
		{
			while (true)
			{
				var value = ReadDouble(prompt);

				if (value > 0)
				{
					return value;
				}

				Console.WriteLine("Число должно быть больше нуля.");
			}
		}

		private static double ReadNonNegativeDouble(string prompt)
		{
			while (true)
			{
				var value = ReadDouble(prompt);

				if (value >= 0)
				{
					return value;
				}

				Console.WriteLine("Число не должно быть отрицательным.");
			}
		}
	}
}


