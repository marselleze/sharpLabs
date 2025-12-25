namespace Lab7.Library
{
	/// <summary>
	/// Представляет человека с событиями для демонстрации работы с событиями.
	/// </summary>
	public class Person
	{
		private string _name = string.Empty;

		/// <summary>
		/// Событие, возникающее при изменении имени.
		/// </summary>
		public event EventHandler<string>? NameChanged;

		/// <summary>
		/// Получает или задает имя человека.
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					var oldName = _name;
					_name = value;
					OnNameChanged(oldName, _name);
				}
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Person.
		/// </summary>
		public Person()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Person с указанным именем.
		/// </summary>
		/// <param name="name">Имя человека.</param>
		public Person(string name)
		{
			_name = name;
		}

		/// <summary>
		/// Вызывает событие NameChanged.
		/// </summary>
		/// <param name="oldName">Старое имя.</param>
		/// <param name="newName">Новое имя.</param>
		protected virtual void OnNameChanged(string oldName, string newName)
		{
			NameChanged?.Invoke(this, $"Имя изменено с '{oldName}' на '{newName}'");
		}

		/// <summary>
		/// Демонстрирует использование ключевого слова this.
		/// </summary>
		/// <returns>Информация о текущем объекте.</returns>
		public string GetThisInfo()
		{
			return $"Текущий объект: {this.GetType().Name}, имя: {this.Name}";
		}
	}
}

