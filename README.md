# TodoListBULKED

TodoListBULKED - это приложение для управления задачами, написанное на C# с использованием .NET Core 8 и Entity Framework Core, PostgreSQL.

## Установка

Чтобы установить и запустить проект, выполните следующие шаги:

### Предварительные требования

Убедитесь, что у вас установлены:

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Клонирование репозитория

Клонируйте репозиторий и перейдите в папку проекта:

```bash
git clone https://github.com/OSUKAL/TodoListBULKED.git
cd TodoListBULKED
```

### Настройка базы данных

1. Откройте файл `TodoListBULKED.API/appsettings.Development.json`.
2. Отредактируйте объект `DatabaseConfig`, указав параметры подключения к вашей базе данных PostgreSQL.

Пример:
   ```json
   {
       "DatabaseConfig": {
           "Host": "localhost",
           "Port": 5432,  // Значение по умолчанию
           "Database": "<database_name>",
           "Username": "<username>",
           "Password": "<password>"
       }
   }
   ```
   Где `<database_name>` название вашей бд, `<username>` имя пользователя postgres, `<password>` пароль пользователя postgres.
   
3. Примените миграции, чтобы создать необходимые таблицы:

```bash
dotnet ef database update --project TodoListBULKED.Data --startup-project TodoListBULKED.API --context TodoListBULKED.Data.Context.AppDbContext
```

### Установка зависимостей

Установите необходимые зависимости:

```bash
dotnet restore
```

## Запуск приложения

После выполнения предыдущих шагов вы можете запустить приложение:

```bash
dotnet run --project TodoListBULKED.API
```

Адрес приложения будет указан в консоли. После перехода необходимо добавить к пути `/swagger/index.html`, чтобы отобразить методы API.

## Технологии

В проекте использованы следующие технологии:

- C#
- .NET Core 8
- Entity Framework Core
- PostgreSQL
- Fluent Results

---
