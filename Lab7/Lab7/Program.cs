using Lab7.Library;

namespace Lab7
{
	/// <summary>
	/// Главный класс консольного приложения Lab7.
	/// </summary>
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			var running = true;

			while (running)
			{
				DisplayMenu();
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						DemonstrateRound();
						break;
					case "2":
						DemonstrateUser();
						break;
					case "3":
						DemonstrateEmployee();
						break;
					case "4":
						DemonstrateShapeHierarchy();
						break;
					case "5":
						DemonstrateEvents();
						break;
					case "6":
						DemonstrateThisAndBase();
						break;
					case "7":
						DemonstrateAccessModifiers();
						break;
					case "0":
						running = false;
						Console.WriteLine("До свидания!");
						break;
					default:
						Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
						break;
				}

				if (running)
				{
					Console.WriteLine("\nНажмите любую клавишу для продолжения...");
					Console.ReadKey();
				}
			}
		}

		private static void DisplayMenu()
		{
			Console.Clear();
			Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 7");
			Console.WriteLine("Объектно-ориентированное программирование\n");
			Console.WriteLine("1. Демонстрация класса Round");
			Console.WriteLine("2. Демонстрация класса User (интерактивный ввод)");
			Console.WriteLine("3. Демонстрация класса Employee");
			Console.WriteLine("4. Иерархия классов (Shape, Rectangle, Circle)");
			Console.WriteLine("5. События");
			Console.WriteLine("6. Использование this и base");
			Console.WriteLine("7. Модификаторы доступа");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		private static void DemonstrateRound()
		{
			Console.Clear();
			Console.WriteLine("Задание 1: Демонстрация класса Round\n");

			Console.WriteLine("Создание круга с центром в (0, 0) и радиусом 5:");
			var round1 = new Round(0, 0, 5);
			Console.WriteLine(round1);
			Console.WriteLine($"Длина окружности: {round1.Circumference:F2}");
			Console.WriteLine($"Площадь: {round1.Area:F2}");

			Console.WriteLine("\nСоздание круга с центром в (10, 20) и радиусом 3.5:");
			var round2 = new Round(10, 20, 3.5);
			Console.WriteLine(round2);

			Console.WriteLine("\nИзменение радиуса через свойство:");
			round2.Radius = 7.5;
			Console.WriteLine(round2);

			Console.WriteLine("\nПопытка установить отрицательный радиус:");
			try
			{
				round2.Radius = -5;
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}

			Console.WriteLine("\nСоздание круга с нулевым радиусом (валидное состояние):");
			var round3 = new Round(0, 0, 0);
			Console.WriteLine(round3);
		}

		private static void DemonstrateUser()
		{
			Console.Clear();
			Console.WriteLine("Задание 2: Демонстрация класса User (интерактивный ввод)\n");

			Console.WriteLine("Введите данные пользователя:");
			Console.Write("Фамилия: ");
			var surname = Console.ReadLine() ?? string.Empty;

			Console.Write("Имя: ");
			var name = Console.ReadLine() ?? string.Empty;

			Console.Write("Отчество: ");
			var patronymic = Console.ReadLine() ?? string.Empty;

			Console.Write("Дата рождения (дд.мм.гггг): ");
			var dateInput = Console.ReadLine();

			if (DateTime.TryParse(dateInput, out var dateOfBirth))
			{
				var user = new User(surname, name, patronymic, dateOfBirth);
				Console.WriteLine("\nИнформация о пользователе:");
				Console.WriteLine(user.ToString());
				Console.WriteLine($"Полное имя: {user.GetFullName()}");
				Console.WriteLine($"Возраст: {user.Age} лет");
			}
			else
			{
				Console.WriteLine("Ошибка: неверный формат даты. Создание пользователя с текущей датой.");
				var user = new User(surname, name, patronymic, DateTime.Today);
				Console.WriteLine("\nИнформация о пользователе:");
				Console.WriteLine(user.ToString());
			}

			Console.WriteLine("\nПример создания пользователя программно:");
			var exampleUser = new User("Иванов", "Иван", "Иванович", new DateTime(1990, 5, 15));
			Console.WriteLine(exampleUser.ToString());
		}

		private static void DemonstrateEmployee()
		{
			Console.Clear();
			Console.WriteLine("Задание 3: Демонстрация класса Employee\n");

			Console.WriteLine("Создание сотрудника:");
			var employee = new Employee(
				"Петров",
				"Петр",
				"Петрович",
				new DateTime(1985, 3, 20),
				10,
				"Инженер-программист"
			);

			Console.WriteLine(employee.ToString());
			Console.WriteLine($"Полное имя: {employee.GetFullName()}");
			Console.WriteLine($"Возраст: {employee.Age} лет");
			Console.WriteLine($"Должность: {employee.Position}");
			Console.WriteLine($"Стаж работы: {employee.WorkExperience} лет");

			Console.WriteLine("\nИзменение должности и стажа:");
			employee.Position = "Старший инженер-программист";
			employee.WorkExperience = 12;
			Console.WriteLine(employee.ToString());

			Console.WriteLine("\nПопытка установить отрицательный стаж:");
			try
			{
				employee.WorkExperience = -5;
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		private static void DemonstrateShapeHierarchy()
		{
			Console.Clear();
			Console.WriteLine("Задание 4: Иерархия классов (Shape, Rectangle, Circle)\n");

			Console.WriteLine("--- Демонстрация интерфейса IShape и абстрактного класса Shape ---\n");

			Console.WriteLine("Создание прямоугольника:");
			var rectangle = new Rectangle(5, 10);
			Console.WriteLine(rectangle.GetInfo());
			Console.WriteLine($"Площадь (через свойство): {rectangle.Area:F2}");
			Console.WriteLine($"Периметр (через свойство): {rectangle.Perimeter:F2}");
			Console.WriteLine($"Площадь (через метод): {rectangle.CalculateArea():F2}");
			Console.WriteLine($"Периметр (через метод): {rectangle.CalculatePerimeter():F2}");

			Console.WriteLine("\nСоздание круга:");
			var circle = new Circle(7);
			Console.WriteLine(circle.GetInfo());
			Console.WriteLine($"Площадь (через свойство): {circle.Area:F2}");
			Console.WriteLine($"Периметр (через свойство): {circle.Perimeter:F2}");
			Console.WriteLine($"Площадь (через метод): {circle.CalculateArea():F2}");
			Console.WriteLine($"Периметр (через метод): {circle.CalculatePerimeter():F2}");

			Console.WriteLine("\n--- Работа с коллекцией фигур через интерфейс IShape ---");
			var shapes = new List<IShape>
			{
				new Rectangle(3, 4),
				new Circle(5),
				new Rectangle(6, 8),
				new Circle(10)
			};

			foreach (var shape in shapes)
			{
				Console.WriteLine($"Фигура: площадь = {shape.Area:F2}, периметр = {shape.Perimeter:F2}");
			}

			Console.WriteLine("\n--- Работа с коллекцией фигур через абстрактный класс Shape ---");
			var shapeObjects = new List<Shape>
			{
				new Rectangle(2, 3),
				new Circle(4),
				new Rectangle(5, 6)
			};

			foreach (var shape in shapeObjects)
			{
				Console.WriteLine(shape.GetInfo());
			}
		}

		private static void DemonstrateEvents()
		{
			Console.Clear();
			Console.WriteLine("Задание 5: Демонстрация событий\n");

			var person = new Person("Иван");

			Console.WriteLine("Подписка на событие NameChanged:");
			person.NameChanged += (sender, message) =>
			{
				Console.WriteLine($"Событие: {message}");
			};

			Console.WriteLine($"Текущее имя: {person.Name}");

			Console.WriteLine("\nИзменение имени на 'Петр':");
			person.Name = "Петр";

			Console.WriteLine("\nИзменение имени на 'Сергей':");
			person.Name = "Сергей";

			Console.WriteLine("\nПопытка установить то же имя (событие не должно сработать):");
			person.Name = "Сергей";

			Console.WriteLine("\nДобавление еще одного обработчика:");
			person.NameChanged += (sender, message) =>
			{
				Console.WriteLine($"Второй обработчик получил: {message}");
			};

			Console.WriteLine("\nИзменение имени на 'Алексей':");
			person.Name = "Алексей";
		}

		private static void DemonstrateThisAndBase()
		{
			Console.Clear();
			Console.WriteLine("Задание 6: Использование this и base\n");

			Console.WriteLine("--- Использование ключевого слова 'this' ---");
			var person = new Person("Мария");
			Console.WriteLine(person.GetThisInfo());

			Console.WriteLine("\n--- Использование ключевого слова 'base' в классе Employee ---");
			var employee = new Employee("Сидоров", "Сидор", "Сидорович", new DateTime(1992, 7, 10), 5, "Разработчик");

			Console.WriteLine("Вызов метода GetFullName() из базового класса User:");
			Console.WriteLine($"Полное имя (через base): {employee.GetFullName()}");

			Console.WriteLine("\nМетод ToString() в Employee использует base.ToString():");
			Console.WriteLine(employee.ToString());

			Console.WriteLine("\n--- Использование base в иерархии Shape ---");
			var rectangle = new Rectangle(4, 5);
			Console.WriteLine("Метод GetInfo() в Rectangle использует base.GetInfo():");
			Console.WriteLine(rectangle.GetInfo());

			var circle = new Circle(6);
			Console.WriteLine("\nМетод GetInfo() в Circle использует base.GetInfo():");
			Console.WriteLine(circle.GetInfo());
		}

		private static void DemonstrateAccessModifiers()
		{
			Console.Clear();
			Console.WriteLine("Задание 7: Модификаторы доступа\n");

			Console.WriteLine("--- Public классы и интерфейсы ---");
			Console.WriteLine("Все классы в библиотеке Lab7.Library имеют модификатор доступа 'public'.");
			Console.WriteLine("Это означает, что они доступны из других сборок.");

			Console.WriteLine("\n--- Internal классы ---");
			Console.WriteLine("Класс Program имеет модификатор доступа 'internal' (по умолчанию для классов).");
			Console.WriteLine("Это означает, что он доступен только внутри сборки Lab7.");

			Console.WriteLine("\n--- Private поля ---");
			Console.WriteLine("Поля в классах имеют модификатор доступа 'private' (например, _radius, _width, _height).");
			Console.WriteLine("Они доступны только внутри самого класса.");

			Console.WriteLine("\n--- Protected методы ---");
			Console.WriteLine("Метод OnNameChanged в классе Person имеет модификатор 'protected'.");
			Console.WriteLine("Он доступен в самом классе и в производных классах.");

			Console.WriteLine("\n--- Public свойства и методы ---");
			Console.WriteLine("Все публичные свойства и методы доступны извне класса.");
			Console.WriteLine("Пример: свойство Radius в классе Circle - public");

			Console.WriteLine("\n--- Интерфейс IShape - public ---");
			Console.WriteLine("Интерфейс IShape имеет модификатор доступа 'public'.");
			Console.WriteLine("Он может быть реализован любым классом в любой сборке.");

			Console.WriteLine("\n--- Абстрактный класс Shape - public ---");
			Console.WriteLine("Абстрактный класс Shape имеет модификатор доступа 'public'.");
			Console.WriteLine("Он может быть унаследован любым классом в любой сборке.");
		}
	}
}

