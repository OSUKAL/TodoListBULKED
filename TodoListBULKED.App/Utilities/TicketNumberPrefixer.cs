using TodoLIstBULKED.Infrastructure.Enums;
using TodoLIstBULKED.Infrastructure.Providers;

namespace TodoListBULKED.App.Utilities;

/// <summary>
/// Утилита для работы с номером задачи
/// </summary>
public class TicketNumberUtility
{
    private readonly EnumDescriptionProvider _enumDescriptionProvider;
    
    /// <inheritdoc cref="TicketNumberUtility"/>
    public TicketNumberUtility(EnumDescriptionProvider enumDescriptionProvider)
    {
        _enumDescriptionProvider = enumDescriptionProvider;
    }

    /// <summary>
    /// Добавление типа задачи в виде префикса
    /// </summary>
    /// <param name="type">Тип задачи</param>
    /// <param name="number">Номер задачи</param>
    public string AddTypePrefix(TicketType type, string number)
    {
        var description = _enumDescriptionProvider.GetDescription(type);
        var result = $"{description}-{number}";

        return result;
    }
}