using System;

public abstract class Property
{
    public abstract Type type
    {
        get;
    }

    public abstract Object defaultValue
    {
        get;

        set;
    }

    public abstract string name
    {
        get;
    }

}

