namespace ArenaRest.Domain.Entities;

public class Fighter
{
    public string Name { get; private set; }
    public int MaxHp { get; private set; }
    public int CurrentHp { get; private set; }
    public int Strength { get; private set; }
    
    public bool IsDead => CurrentHp == 0;

    public Fighter(string name, int maxHp, int strength)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
        MaxHp = maxHp <= 0 ? throw new ArgumentNullException(nameof(maxHp)) : maxHp;
        Strength = strength <= 0 ? throw new ArgumentNullException(nameof(strength)) : strength;
        CurrentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        CurrentHp = Math.Max(0, CurrentHp - amount);
    }
    
    public void Attack(Fighter target)
    {
        target.TakeDamage(this.Strength);
    }
}