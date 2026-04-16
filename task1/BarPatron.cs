public class BarPatron
{
    private bool isSober;
    private bool isHappy;

    // Конструктор с параметрами
    public BarPatron(bool sober, bool happy)
    {
        isSober = sober;
        isHappy = happy;
    }

    // Конструктор копирования
    public BarPatron(BarPatron other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        isSober = other.isSober;
        isHappy = other.isHappy;
    }

    // Свойства
    public bool IsSober
    {
        get { return isSober; }
        set { isSober = value; }
    }

    public bool IsHappy
    {
        get { return isHappy; }
        set { isHappy = value; }
    }

    // Метод импликации
    public bool Implication()
    {
        return !isSober || isHappy;
    }

    public override string ToString()
    {
        return $"BarPatron: трезвый={isSober}, довольный={isHappy}";
    }
}

// Дочерний класс: VIP-клиент с оставшимися днями подписки
public class VipPatron : BarPatron
{
    private int remainingVipDays;

    // Конструктор с параметрами
    public VipPatron(bool sober, bool happy, int remainingDays) : base(sober, happy)
    {
        remainingVipDays = remainingDays >= 0 ? remainingDays : 0;
    }

    // Конструктор копирования
    public VipPatron(VipPatron other) : base(other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        remainingVipDays = other.remainingVipDays;
    }

    // Свойство для доступа к дням подписки (можно сделать public)
    public int RemainingVipDays
    {
        get { return remainingVipDays; }
        set { remainingVipDays = value >= 0 ? value : 0; }
    }

    // Метод 1: может войти в VIP-зону (если есть хотя бы один день)
    public bool CanEnterVipLounge()
    {
        return remainingVipDays > 0;
    }

    // Метод 2: использовать один VIP-день
    public int UseVipDay()
    {
        if (remainingVipDays > 0)
            remainingVipDays--;
        return remainingVipDays;
    }

    // Метод 3: продлить подписку на указанное количество дней
    public void ExtendVipSubscription(int days)
    {
        if (days > 0)
            remainingVipDays += days;
    }

    public override string ToString()
    {
        return $"VipPatron: трезвый={IsSober}, довольный={IsHappy}, дней подписки={remainingVipDays}";
    }
}