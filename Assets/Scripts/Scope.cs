using System;
public static class Scope
{
    private static int _value;
    public static int Value
    {
        get => _value;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            _value = value;
            ChangeValue?.Invoke(_value);
        }
    }
    public static event Action<int> ChangeValue;
        
  
}
