using System.ComponentModel;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;

namespace TodoLIstBULKED.Infrastructure.Providers;

/// <summary>
/// Провайдер для получения описания значений перечисления
/// </summary>
public class EnumDescriptionProvider
{
    private readonly IMemoryCache _memoryCache;
    
    /// <inheritdoc cref="EnumDescriptionProvider"/>
    public EnumDescriptionProvider(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    
    /// <summary>
    /// Получение значения атрибута <see cref="DescriptionAttribute"/>
    /// </summary>
    /// <param name="type">Тип задачи</param>
    public string GetDescription<TEnum>(TEnum type) where TEnum : struct, Enum
    {
        var cachedValue = _memoryCache.Get<string>(type);
        if (!string.IsNullOrWhiteSpace(cachedValue))
            return cachedValue;
        
        var typeInfo = typeof(TEnum);
        var field = typeInfo.GetField(Enum.GetName(type)!);
        var descriptionAttribute = field!.GetCustomAttribute<DescriptionAttribute>();

        var description = descriptionAttribute?.Description ?? string.Empty;

        _memoryCache.Set(type, description);

        return description;
    }
}