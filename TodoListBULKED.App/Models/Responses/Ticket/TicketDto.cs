﻿using System.Text.Json.Serialization;
using TodoLIstBULKED.Infrastructure.Enums;

namespace TodoListBULKED.App.Models.Responses.Ticket;

/// <summary>
/// Данные задачи
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
/// <param name="Number">Номер</param>
/// <param name="Type">Тип</param>
/// <param name="CreationDate">Дата создания</param>
/// <param name="Creator">Данные создателя</param>
/// <param name="Performer">Данные исполнителя</param>
/// <param name="State">Состояние</param>
/// <param name="Priority">Приоритет</param>
/// <param name="Description">Описание</param>
public record TicketDto(
    [property: JsonPropertyName("id")]
    Guid Id,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("number")]
    string Number,
    [property: JsonPropertyName("type")]
    TicketType Type,
    [property: JsonPropertyName("creationDate")]
    DateTime CreationDate,
    [property: JsonPropertyName("creator")]
    TicketUserDto Creator,
    [property: JsonPropertyName("performer")]
    TicketUserDto Performer,
    [property: JsonPropertyName("state")]
    TicketState State,
    [property: JsonPropertyName("priority")]
    TicketPriority Priority,
    [property: JsonPropertyName("description")]
    string Description
);