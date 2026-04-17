class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Тест конструктора Money(uint rub, byte kop) ---");
        uint rub1 = ReadUInt("Введите рубли: ");
        byte kop1 = ReadByte("Введите копейки: ", 0, 255);
        Money m1 = new Money(rub1, kop1);
        Console.WriteLine($"Создано: {m1}");

        Console.WriteLine("\n--- Тест конструктора Money(uint rub) ---");
        uint rub2 = ReadUInt("Введите рубли: ");
        Money m2 = new Money(rub2);
        Console.WriteLine($"Создано: {m2}");

        Console.WriteLine("\n--- Тест конструктора Money(byte kop) ---");
        byte kop3 = ReadByte("Введите копейки: ", 0, 255);
        Money m3 = new Money(kop3);
        Console.WriteLine($"Создано: {m3}");

        Console.WriteLine("\n--- Тест конструктора Money() ---");
        Money m4 = new Money();
        Console.WriteLine($"Создано: {m4}");

        Console.WriteLine("\n--- Тест конструктора копирования ---");
        Console.WriteLine("Сначала создадим оригинал:");
        uint rubOrig = ReadUInt("Рубли оригинала: ");
        byte kopOrig = ReadByte("Копейки оригинала: ", 0, 255);
        Money original = new Money(rubOrig, kopOrig);
        Money copy = new Money(original);
        Console.WriteLine($"Оригинал: {original}");
        Console.WriteLine($"Копия: {copy}");

        Console.WriteLine("\n--- Тест метода SubtractKopecks ---");
        Console.WriteLine("Исходная сумма (введите):");
        uint rubSub = ReadUInt("Рубли: ");
        byte kopSub = ReadByte("Копейки: ", 0, 255);
        Money moneySub = new Money(rubSub, kopSub);
        Console.Write("Сколько копеек вычесть? ");
        uint kopToSub = ReadUInt("");
        try
        {
            Money result = moneySub.SubtractKopecks(kopToSub);
            Console.WriteLine($"Результат: {result}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\n--- Тест унарных операторов ++ и -- ---");
        Console.WriteLine("Введите сумму:");
        uint rubUn = ReadUInt("Рубли: ");
        byte kopUn = ReadByte("Копейки: ", 0, 255);
        Money unMoney = new Money(rubUn, kopUn);
        Money moneyUp = new Money(unMoney);
        Money moneyDown = new Money(unMoney);
        moneyUp++;
        moneyDown--;
        Console.WriteLine($"Исходная: {unMoney}");
        Console.WriteLine($"++: {moneyUp}");
        Console.WriteLine($"--: {moneyDown}");

        Console.WriteLine("\n--- Тест приведения типов ---");
        Console.WriteLine("Введите сумму:");
        uint rubCast = ReadUInt("Рубли: ");
        byte kopCast = ReadByte("Копейки: ", 0, 255);
        Money castMoney = new Money(rubCast, kopCast);
        uint rubOnly = (uint)castMoney;
        bool isNonZero = castMoney;
        Console.WriteLine($"Явное приведение к uint: {rubOnly}");
        Console.WriteLine($"Неявное приведение к bool: {isNonZero} (сумма {(isNonZero ? "не ноль" : "ноль")})");

        Console.WriteLine("\n--- Тест Money - uint ---");
        Console.WriteLine("Введите уменьшаемое (Money):");
        uint rubLeft = ReadUInt("Рубли: ");
        byte kopLeft = ReadByte("Копейки: ", 0, 255);
        Money left = new Money(rubLeft, kopLeft);
        Console.Write("Введите вычитаемые копейки (uint): ");
        uint subUint = ReadUInt("");
        try
        {
            Money res = left - subUint;
            Console.WriteLine($"{left} - {subUint} коп. = {res}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\n--- Тест uint - Money ---");
        Console.Write("Введите уменьшаемое (копейки, uint): ");
        uint leftUint = ReadUInt("");
        Console.WriteLine("Введите вычитаемое (Money):");
        uint rubRight = ReadUInt("Рубли: ");
        byte kopRight = ReadByte("Копейки: ", 0, 255);
        Money right = new Money(rubRight, kopRight);
        try
        {
            Money res = leftUint - right;
            Console.WriteLine($"{leftUint} коп. - {right} = {res}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\n--- Тест Money - Money ---");
        Console.WriteLine("Первая сумма (уменьшаемое):");
        uint rubA = ReadUInt("Рубли: ");
        byte kopA = ReadByte("Копейки: ", 0, 255);
        Money a = new Money(rubA, kopA);
        Console.WriteLine("Вторая сумма (вычитаемое):");
        uint rubB = ReadUInt("Рубли: ");
        byte kopB = ReadByte("Копейки: ", 0, 255);
        Money b = new Money(rubB, kopB);
        try
        {
            Money res = a - b;
            Console.WriteLine($"{a} - {b} = {res}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static uint ReadUInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (uint.TryParse(Console.ReadLine(), out uint val))
            {
                return val;
            }
            Console.WriteLine("Ошибка! Введите целое неотрицательное число.");
        }
    }

    static byte ReadByte(string prompt, byte min, byte max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (byte.TryParse(Console.ReadLine(), out byte val) && val >= min && val <= max)
            {
                return val;
            }
            Console.WriteLine($"Ошибка! Введите число от {min} до {max}.");
        }
    }
}