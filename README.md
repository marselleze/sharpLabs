# SharpLabs - Лабораторные работы по C#

Проект содержит реализацию 5 лабораторных работ по программированию на C# с использованием .NET 9.

## Структура проекта

```
SharpLabs/
├── SharpLabs.sln                    # Единое решение
├── SharpLabs.Common/                # Общая библиотека
│   └── Argument.cs                  # Валидация аргументов
├── Lab1/
│   ├── Lab1.Library/                # Библиотека классов
│   │   ├── StringFormatter.cs
│   │   └── SquarePrinter.cs
│   └── Lab1/                        # Консольное приложение
│       └── Program.cs
├── Lab2/
│   ├── Lab2.Library/
│   │   ├── BmiCalculator.cs
│   │   ├── ArrayProcessor.cs
│   │   ├── TextAnalyzer.cs
│   │   └── MemoryTypeDemo.cs
│   └── Lab2/
│       └── Program.cs
├── Lab3/
│   ├── Lab3.Library/
│   │   ├── WordFrequencyAnalyzer.cs
│   │   ├── DynamicArray.cs
│   │   └── ObjectComparison.cs
│   └── Lab3/
│       └── Program.cs
├── Lab4/
│   ├── Lab4.Library/
│   │   ├── GenericArraySorter.cs
│   │   └── OperationNotifier.cs
│   └── Lab4/
│       └── Program.cs
└── Lab5/
    ├── Lab5.Library/
    │   ├── Student.cs
    │   └── JsonStorage.cs
    └── Lab5/
        ├── Program.cs
        └── App.config
```

## Требования

- .NET 9 SDK
- Windows, Linux или macOS

## Сборка и запуск

### Сборка всего решения

```bash
dotnet build SharpLabs.sln
```

### Запуск отдельных лабораторных работ

```bash
# Лабораторная работа 1
dotnet run --project Lab1/Lab1/Lab1.csproj

# Лабораторная работа 2
dotnet run --project Lab2/Lab2/Lab2.csproj

# Лабораторная работа 3
dotnet run --project Lab3/Lab3/Lab3.csproj

# Лабораторная работа 4
dotnet run --project Lab4/Lab4/Lab4.csproj

# Лабораторная работа 5
dotnet run --project Lab5/Lab5/Lab5.csproj
```

## Описание лабораторных работ

### Лабораторная работа 1: Использование среды разработки

**Задачи:**
1. Форматирование числовой последовательности (1, 2, 3, ... N)
2. Вывод квадрата из звездочек с отсутствующей центральной звездочкой

**Классы:**
- `StringFormatter` - работа со строками
- `SquarePrinter` - вывод графики в консоль

### Лабораторная работа 2: Типы данных в .NET

**Задачи:**
1. Калькулятор индекса массы тела (BMI)
2. Генерация и обработка массивов без использования LINQ
3. Анализ средней длины слова в тексте
4. Демонстрация типов значений и ссылочных типов (struct, ref, out, GC)

**Классы:**
- `BmiCalculator` - расчет индекса массы тела
- `ArrayProcessor` - работа с массивами
- `TextAnalyzer` - анализ текстовых данных
- `MemoryTypeDemo` - демонстрация работы с памятью
- `PersonData` - структура для демонстрации типов значений

### Лабораторная работа 3: Коллекции, сравнение объектов

**Задачи:**
1. Подсчет частоты слов в тексте
2. Реализация динамического массива с автоматическим расширением емкости
3. Демонстрация сравнения объектов разных типов

**Классы:**
- `WordFrequencyAnalyzer` - анализ частоты слов
- `DynamicArray<T>` - собственная реализация динамического массива
- `SampleClass` - пример класса с реализацией сравнения
- `ObjectComparison` - демонстрация сравнения объектов

### Лабораторная работа 4: Делегаты и события

**Задачи:**
1. Сортировка массивов через делегат сравнения
2. Реализация событий для уведомления о ходе выполнения
3. Демонстрация различных типов делегатов
4. Использование лямбда-выражений

**Классы:**
- `ComparisonDelegate<T>` - делегат для сравнения
- `ArraySorter` - статический класс с методами сортировки
- `GenericArraySorter<T>` - класс с событиями
- `OperationNotifier` - класс для демонстрации событий
- `DelegateExamples` - примеры использования делегатов

### Лабораторная работа 5: Работа с XML, JSON и сериализация

**Задачи:**
1. Сериализация объектов в JSON
2. Десериализация объектов из JSON
3. Работа с конфигурационным файлом App.config

**Классы:**
- `Student` - модель данных студента
- `JsonStorage` - работа с JSON
- `App.config` - конфигурация приложения

## Соблюдение стандартов кодирования

Все классы разработаны с соблюдением корпоративного C# CodeStyle:

- ✅ **Naming Conventions**: PascalCase для публичных членов, _camelCase для приватных полей
- ✅ **XML Documentation**: Все публичные методы документированы на русском языке
- ✅ **Argument Validation**: Валидация через класс `Argument` из `SharpLabs.Common`
- ✅ **Code Layout**: Использование табуляции, правильное размещение фигурных скобок
- ✅ **Events**: Именование без префикса "On"
- ✅ **Delegates**: Правильные суффиксы EventHandler/Callback
- ✅ **No Magic Numbers**: Использование именованных констант
- ✅ **Null Safety**: Использование nullable reference types (.NET 9)

## Архитектура проекта

### Общая библиотека SharpLabs.Common

Содержит класс `Argument` для валидации входных параметров, используемый всеми лабораторными работами.

### Независимые лабораторные работы

Каждая лабораторная работа состоит из:
- **Lab[N].Library** - библиотека классов с бизнес-логикой
- **Lab[N]** - консольное приложение с интерактивным меню

Все лабораторные независимы друг от друга и могут запускаться отдельно.

## Зависимости проектов

```
SharpLabs.Common (независимая)
    ↑
Lab[N].Library → SharpLabs.Common
    ↑
Lab[N] → Lab[N].Library
```

## Особенности реализации

### Без использования запрещенных инструментов

- ❌ Не используются LINQ запросы в Lab2 (ArrayProcessor)
- ❌ Не используются Array.Sort, IComparable в Lab4
- ✅ Все сортировки реализованы вручную
- ✅ Поиск min/max реализован через циклы

### Используемые технологии

- **.NET 9** - последняя версия платформы
- **System.Text.Json** - JSON-сериализация
- **System.Configuration.ConfigurationManager** - работа с App.config
- **Nullable Reference Types** - повышенная безопасность

## Примеры использования

### Пример 1: Форматирование последовательности (Lab1)

```csharp
var result = StringFormatter.FormatNumberSequence(7);
// Результат: "1, 2, 3, 4, 5, 6, 7"
```

### Пример 2: Динамический массив (Lab3)

```csharp
var array = new DynamicArray<int>();
array.Add(1);
array.AddRange(new[] { 2, 3, 4, 5 });
foreach (var item in array)
{
    Console.WriteLine(item);
}
```

### Пример 3: Сортировка с событиями (Lab4)

```csharp
var sorter = new GenericArraySorter<int>();
sorter.SortCompleted += (sender, e) =>
{
    Console.WriteLine("Сортировка завершена!");
};
ComparisonDelegate<int> comparer = (a, b) => a.CompareTo(b);
sorter.Sort(numbers, comparer);
```

### Пример 4: JSON сериализация (Lab5)

```csharp
var student = new Student(1, "Иван", "Иванов", 20, 4.5);
JsonStorage.SaveToJson(student, "student.json");
var loaded = JsonStorage.LoadFromJson<Student>("student.json");
```

## Автор

Проект создан в соответствии с требованиями лабораторных работ по курсу C# программирования.

## Лицензия

Учебный проект.
