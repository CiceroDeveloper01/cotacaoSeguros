﻿namespace CotacaoSeguroNotification.Interfaces.Errors;

public interface ILevel
{
    string Description { get; }

    string ToString();
}