public abstract class BaseCharacteristic<T> : Characteristic
{
    public T Value { get; set; }
    
    public BaseCharacteristic(string UUID, T initialValue)
    {
        this.UUID = UUID;
        this.Value = initialValue;
        this.Discovered = false;
        this.Subscribed = false;
    }
}
