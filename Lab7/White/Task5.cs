using System;

public struct Match
{
    // ПРИВАТНЫЕ ПОЛЯ
    private int goals;   // забитые голы
    private int misses;  // пропущенные голы

    // ПУБЛИЧНЫЕ СВОЙСТВА (только для чтения)
    public int Goals => goals;
    public int Misses => misses;

    // СВОЙСТВО - разница забитых и пропущенных
    public int Difference => goals - misses;

    // СВОЙСТВО - очки за матч (по правилам футбола)
    public int Score
    {
        get
        {
            if (goals > misses) return 3;  // победа = 3 очка
            if (goals == misses) return 1; // ничья = 1 очко
            return 0;                       // поражение = 0 очков
        }
    }

    // КОНСТРУКТОР
    public Match(int goals, int misses)
    {
        this.goals = goals;
        this.misses = misses;
    }

    // ВЫВОД результата матча
    public void Print()
    {
        Console.WriteLine($"{goals}:{misses}");  // например "2:1"
    }
}

