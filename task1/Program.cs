class Program
{
    static void Main(string[] args)
    {

        // ----- Базовый класс -----
        Console.WriteLine("--- Базовый класс BarPatron ---");
        Console.Write("Введите isSober (true/false): ");
        bool sober = ReadBool();
        Console.Write("Введите isHappy (true/false): ");
        bool happy = ReadBool();

        BarPatron patron = new BarPatron(sober, happy);
        Console.WriteLine($"Создан: {patron}");
        Console.WriteLine($"Импликация (трезвый -> довольный): {patron.Implication()}");

        // Тест конструктора копирования базового
        BarPatron patronCopy = new BarPatron(patron);
        Console.WriteLine($"\nКопия: {patronCopy}");
        Console.Write("Изменим у копии isHappy на противоположное: ");
        patronCopy.IsHappy = !patronCopy.IsHappy;
        Console.WriteLine($"Оригинал: {patron}");
        Console.WriteLine($"Копия после изменения: {patronCopy}");

        // ----- Дочерний класс -----
        Console.WriteLine("\n--- Дочерний класс VipPatron ---");
        Console.Write("Введите isSober для VIP: ");
        bool vipSober = ReadBool();
        Console.Write("Введите isHappy для VIP: ");
        bool vipHappy = ReadBool();
        Console.Write("Введите оставшиеся дни VIP-подписки (целое >=0): ");
        int days = ReadInt();

        VipPatron vip = new VipPatron(vipSober, vipHappy, days);
        Console.WriteLine($"Создан VIP: {vip}");
        Console.WriteLine($"Может войти в VIP-зону? {vip.CanEnterVipLounge()}");

        // Тест методов UseVipDay и ExtendVipSubscription
        Console.WriteLine("\n--- Проверка UseVipDay ---");
        Console.WriteLine($"Используем один день... Осталось: {vip.UseVipDay()}");
        Console.WriteLine($"Ещё раз используем... Осталось: {vip.UseVipDay()}");

        Console.WriteLine("\n--- Проверка ExtendVipSubscription ---");
        Console.Write("На сколько дней продлить подписку? ");
        int extra = ReadInt();
        vip.ExtendVipSubscription(extra);
        Console.WriteLine($"После продления: {vip}");

        // Тест конструктора копирования дочернего
        VipPatron vipCopy = new VipPatron(vip);
        Console.WriteLine($"\nКопия VIP: {vipCopy}");
        Console.Write("На сколько дней продлить подписку копии? ");
        extra = ReadInt();
        vipCopy.ExtendVipSubscription(extra);
        Console.WriteLine($"Оригинал: {vip}");
        Console.WriteLine($"Копия после изменения: {vipCopy}");
    }

    static bool ReadBool()
    {
        while (true)
        {
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "true" || input == "1" || input == "t") return true;
            if (input == "false" || input == "0" || input == "f") return false;
            Console.Write("Ошибка! Введите true/false (1/0): ");
        }
    }

    static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int val) && val >= 0)
                return val;
            Console.Write("Ошибка! Введите неотрицательное целое число: ");
        }
    }
}