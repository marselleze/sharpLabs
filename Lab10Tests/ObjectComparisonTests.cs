using Lab3Library;
using Xunit;

namespace Lab10Tests
{
	/// <summary>
	/// Тесты для сравнения объектов и проверки корректности Equals/CompareTo.
	/// В качестве примера используются типы из лабораторной работы №3.
	/// </summary>
	public class ObjectComparisonTests
	{
		[Fact]
		public void Persons_WithSameNameAndAge_AreEqual()
		{
			var first = new Person("Иван", 30);
			var second = new Person("Иван", 30);

			Assert.True(first.Equals(second));
			Assert.True(second.Equals(first));
			Assert.Equal(first.GetHashCode(), second.GetHashCode());
		}

		[Fact]
		public void Persons_WithDifferentData_AreNotEqual()
		{
			var first = new Person("Иван", 30);
			var second = new Person("Пётр", 25);

			Assert.False(first.Equals(second));
			Assert.NotEqual(first.GetHashCode(), second.GetHashCode());
		}

		[Fact]
		public void Employee_CompareWithPerson_ReturnsTrue_WhenNameAndAgeMatch()
		{
			var person = new Person("Анна", 28);
			var employee = new Employee("Анна", 28, "Разработчик");

			Assert.True(employee.CompareWithPerson(person));
		}

		[Fact]
		public void Employee_CompareWithPerson_ReturnsFalse_WhenNameOrAgeDiffers()
		{
			var person = new Person("Анна", 28);
			var employee = new Employee("Анна", 30, "Разработчик");

			Assert.False(employee.CompareWithPerson(person));
		}
	}
}


