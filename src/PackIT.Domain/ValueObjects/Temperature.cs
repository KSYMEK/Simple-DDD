using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

public record Temperature
{
    public Temperature(double value)
    {
        if (value is < -100 or > 100)
            throw new InvalidTemperatureException(value);

        Value = value;
    }

    public double Value { get; }

    public static implicit operator double(Temperature temperature)
    {
        return temperature.Value;
    }

    public static implicit operator Temperature(short temperature)
    {
        return new(temperature);
    }
}