namespace ArenaRest.Domain.Entities;

public class Fighter
{
    public string Name { get; private set; }
    public int MaxHp { get; private set; }
    public int CurrentHp { get; private set; }
    public int Strength { get; private set; }
    
    public bool IsDead => CurrentHp == 0;

    public Fighter(string name, int maxhp, int strength)
    {
        Name = name;
        MaxHp = maxhp;
        Strength = strength;
        CurrentHp = maxhp;
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