public class Money
{
    private uint _rubles;
    private byte _kopeks;

    // Конструкторы
    public Money(uint rub, byte kop)
    {
        _rubles = rub + (uint)(kop / 100);
        _kopeks = (byte)(kop % 100);
        
    }

    public Money(uint rub)
    {
        _rubles = rub;
        _kopeks = 0;
    }

    public Money(byte kop)
    {
        _kopeks = (byte)(kop % 100);
        _rubles = (uint)(kop / 100);
    }

    public Money()
    {
        _rubles = 0;
        _kopeks = 0;
    }

    public Money(Money original)
    {
        _rubles = original._rubles;
        _kopeks = original._kopeks;
    }

    public uint Rubles
    {
        get { return _rubles; }
        set { _rubles = value; }
    }

    public byte Kopeks
    {
        get { return _kopeks; }
        set
        {
            _rubles += (uint)(value / 100);
            _kopeks = (byte)(value % 100);    
        }
    }

    public Money SubtractKopecks(uint kopecks)
    {
        long totalKopecks = (long)_rubles * 100 + _kopeks;
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

    public override string ToString()
    {
        return $"{_rubles} руб. {_kopeks} коп.";
    }

    public static Money operator ++(Money original)
    {
        long totalKopecks = (long)original._rubles * 100 + original._kopeks;
        long resultKopecks = totalKopecks + 1;
        return new Money((uint)(resultKopecks / 100), (byte)(resultKopecks % 100));
    }

    public static Money operator --(Money original)
    {
        return original.SubtractKopecks(1);
    }

    public static explicit operator uint(Money original)
    {
        return original._rubles;
    }

    public static implicit operator bool(Money original)
    {
        return !(original._kopeks == 0 && original._rubles == 0);
    }

    public static Money operator -(Money m, uint kopecks)
    {
        return m.SubtractKopecks(kopecks);
    }

    public static Money operator -(uint kopecks, Money m)
    {
        long totalKopecks = (long)m._rubles * 100 + (long)m._kopeks;
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

    public static Money operator -(Money m1, Money m2)
    {
        long totalKopecks1 = (long)m1._rubles * 100 + m1._kopeks;
        long totalKopecks2 = (long)m2._rubles * 100 + m2._kopeks;
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