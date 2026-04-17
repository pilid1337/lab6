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
        get 
        { 
            return _isSober; 
        }
        set 
        { 
            _isSober = value; 
        }
    }

    public bool IsHappy
    {
        get 
        { 
            return _isHappy; 
        }
        set 
        { 
            _isHappy = value; 
        }
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