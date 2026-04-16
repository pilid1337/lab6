public class Money
{
    private uint rubles;
    private byte kopeks;

    // Конструкторы
    public Money(uint rub, byte kop)
    {
        rubles = rub;
        kopeks = kop;
    }

    public Money(uint rub)
    {
        rubles = rub;
        kopeks = 0;
    }

    public Money(byte kop)
    {
        kopeks = (byte)(kop % 100);
        rubles = (uint)(kop / 100);
    }

    public Money()
    {
        rubles = 0;
        kopeks = 0;
    }

    // Конструктор копирования
    public Money(Money original)
    {
        rubles = original.rubles;
        kopeks = original.kopeks;
    }

    // Свойства
    public uint Rubles
    {
        get { return rubles; }
        set { rubles = value; }
    }

    public byte Kopeks
    {
        get { return kopeks; }
        set
        {
            rubles += (uint)(value / 100);
            kopeks = (byte)(value % 100);    
        }
    }

    // Методы
    public Money SubtractKopecks(uint kopecks)
    {
        // Переводим текущую сумму в копейки
        long totalKopecks = (long)rubles * 100 + kopeks;
        long resultKopecks = totalKopecks - kopecks;
        if (resultKopecks < 0)
        {
            throw new ArgumentOutOfRangeException("Отрицательное кол-во копеек");
        }
        else
        {
            return new Money((uint)(resultKopecks / 100), (byte)(resultKopecks % 100));
        }
    }

    // Перегрузка ToString()
    public override string ToString()
    {
        return $"{rubles} руб. {kopeks} коп.";
    }

    // Унарные операции
    public static Money operator ++(Money original)
    {
        // Добавляем 1 копейку
        long totalKopecks = (long)original.rubles * 100 + original.kopeks;
        long resultKopecks = totalKopecks + 1;
        return new Money((uint)(resultKopecks / 100), (byte)(resultKopecks % 100));
    }

    public static Money operator --(Money original)
    {
        return original.SubtractKopecks(1);
    }

    // Операции приведения типа
    public static explicit operator uint(Money original)
    {
        return original.rubles;
    }

    // Неявное приведение к bool (true, если сумма не равна нулю)
    public static implicit operator bool(Money original)
    {
        return !(original.kopeks == 0 && original.rubles == 0);
    }

    // Бинарные операции
    // Money - uint (левосторонняя)
    public static Money operator -(Money m, uint kopecks)
    {
        return m.SubtractKopecks(kopecks);
    }

    // uint - Money (правосторонняя) – вычитаем денежную сумму из заданного числа копеек
    public static Money operator -(uint kopecks, Money m)
    {
        long totalKopecks = (long)m.rubles * 100 + (long)m.kopeks;
        long resultKopecks = kopecks - totalKopecks;

        if (resultKopecks < 0)
        {
            throw new ArgumentOutOfRangeException("Отрицательное кол-во копеек");
        }
        else
        {
            return new Money((uint)(resultKopecks / 100), (byte)(resultKopecks % 100));
        }
    }

    // Money - Money
    public static Money operator -(Money m1, Money m2)
    {
        long totalKopecks1 = (long)m1.rubles * 100 + m1.kopeks;
        long totalKopecks2 = (long)m2.rubles * 100 + m2.kopeks;
        long resultKopecks = totalKopecks1 - totalKopecks2;

        if (resultKopecks < 0)
        {
            throw new ArgumentOutOfRangeException("Отрицательное кол-во копеек");
        }
        else
        {
            return new Money((uint)(resultKopecks / 100), (byte)(resultKopecks % 100));
        }
    }
}