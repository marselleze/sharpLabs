using Lab3Library;
using Xunit;

namespace Lab10Tests
{
	/// <summary>
	/// Содержит набор тестов для проверки работы динамического массива.
	/// </summary>
	public class DynamicArrayTests
	{
		[Fact]
		public void Add_IncreasesLengthAndStoresElements()
		{
			var array = new DynamicArray<int>();

			array.Add(10);
			array.Add(20);
			array.Add(30);

			Assert.Equal(3, array.Length);
			Assert.Equal(10, array[0]);
			Assert.Equal(20, array[1]);
			Assert.Equal(30, array[2]);
		}

		[Fact]
		public void Add_ResizesInternalArrayWhenCapacityExceeded()
		{
			var array = new DynamicArray<int>(2);

			array.Add(1);
			array.Add(2);
			array.Add(3);
			array.Add(4);

			Assert.Equal(4, array.Length);
			Assert.True(array.Capacity >= 4);
		}

		[Fact]
		public void Remove_RemovesFirstOccurrenceAndReturnsTrue()
		{
			var array = new DynamicArray<string>();

			array.Add("A");
			array.Add("B");
			array.Add("C");

			var removed = array.Remove("B");

			Assert.True(removed);
			Assert.Equal(2, array.Length);
			Assert.Equal("A", array[0]);
			Assert.Equal("C", array[1]);
		}

		[Fact]
		public void Remove_ReturnsFalse_WhenItemNotFound()
		{
			var array = new DynamicArray<int>();

			array.Add(1);
			array.Add(2);

			var removed = array.Remove(3);

			Assert.False(removed);
			Assert.Equal(2, array.Length);
		}

		[Fact]
		public void Insert_InsertsElementAtSpecifiedIndex()
		{
			var array = new DynamicArray<int>();

			array.Add(1);
			array.Add(3);

			var result = array.Insert(1, 2);

			Assert.True(result);
			Assert.Equal(3, array.Length);
			Assert.Equal(1, array[0]);
			Assert.Equal(2, array[1]);
			Assert.Equal(3, array[2]);
		}

		[Fact]
		public void Indexer_Get_ThrowsOnInvalidIndex()
		{
			var array = new DynamicArray<int>();

			array.Add(1);

			Assert.Throws<ArgumentOutOfRangeException>(() => _ = array[-1]);
			Assert.Throws<ArgumentOutOfRangeException>(() => _ = array[1]);
		}

		[Fact]
		public void AddRange_AppendsAllElements()
		{
			var array = new DynamicArray<int>();

			array.Add(1);
			array.AddRange(new[] { 2, 3, 4 });

			Assert.Equal(4, array.Length);
			Assert.Equal(new[] { 1, 2, 3, 4 }, array.ToArray());
		}

		[Fact]
		public void Enumerator_IteratesOverAllElements()
		{
			var array = new DynamicArray<int>();

			array.Add(5);
			array.Add(10);
			array.Add(15);

			var result = new List<int>();

			foreach (var value in array)
			{
				result.Add(value);
			}

			Assert.Equal(new[] { 5, 10, 15 }, result);
		}
	}
}


