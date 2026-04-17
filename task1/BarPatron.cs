public class BarPatron
{
    private bool _isSober;
    private bool _isHappy;

    public BarPatron(bool sober, bool happy)
    {
        _isSober = sober;
        _isHappy = happy;
    }

    public BarPatron(BarPatron other)
    {
        _isSober = other._isSober;
        _isHappy = other._isHappy;
    }

    public bool IsSober
    {
        get { return _isSober; }
        set { _isSober = value; }
    }

    public bool IsHappy
    {
        get { return _isHappy; }
        set { _isHappy = value; }
    }

    public bool Implication()
    {
        return !_isSober || _isHappy;
    }

    public override string ToString()
    {
        return $"BarPatron: трезвый={_isSober}, довольный={_isHappy}";
    }
}

public class VipPatron : BarPatron
{
    private int _remainingVipDays;

    public VipPatron(bool sober, bool happy, int remainingDays) 
    : base(sober, happy)
    {
        _remainingVipDays = remainingDays >= 0 ? remainingDays : 0;
    }

    public VipPatron(VipPatron other) : base(other)
    {
        _remainingVipDays = other._remainingVipDays;
    }

    private int RemainingVipDays
    {
        get { return _remainingVipDays; }
        set { _remainingVipDays = value >= 0 ? value : 0; }
    }

    public bool CanEnterVipLounge()
    {
        return _remainingVipDays > 0;
    }

    public int UseVipDay()
    {
        if (_remainingVipDays > 0)
        {
            _remainingVipDays--;
        }
        return _remainingVipDays;
    }

    public void ExtendVipSubscription(int days)
    {
        _remainingVipDays += days;
    }

    public override string ToString()
    {
        return $"VipPatron: трезвый={IsSober}, довольный={IsHappy}, дней подписки={_remainingVipDays}";
    }
}