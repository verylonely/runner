public struct Stat
{
    private int _value, _maxValue;

    public Stat(int maxValue)
    {
        _maxValue = maxValue;
        _value = _maxValue;
    }

    public Stat(int value, int maxValue) 
    {
        _maxValue = maxValue;
        _value = value;
    }

    public void Increase(int value)
    {
        _value += value;
        if (_value > _maxValue)
            _value = _maxValue;
    }

    public void Decrease(int value)
    {
        _value -= value;
        if (_value < 0)
            _value = 0;
    }

    public int Get()
    {
        return _value;
    }

    public int GetMax()
    {
        return _maxValue;
    }
}

