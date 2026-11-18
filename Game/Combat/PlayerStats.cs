namespace MyMAUI.Game.Combat;

public sealed class PlayerStats
{
    public float MaxHealth { get; } = 100;

    public float Health { get; private set; } = 100;

    public bool IsAlive => Health > 0;

    public void Damage(float amount)
    {
        Health = Math.Max(0, Health - amount);
    }

    public void Heal(float amount)
    {
        Health = Math.Min(
            MaxHealth,
            Health + amount
        );
    }

    public void Reset()
    {
        Health = MaxHealth;
    }
}
