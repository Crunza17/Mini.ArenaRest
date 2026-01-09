namespace ArenaRest.Domain.Entities;

public class Battle
{
    public Guid Id { get; private set; }
    public Fighter Player { get; private set; }
    public Fighter Enemy { get; private set; }
    
    public Battle(Fighter player, Fighter enemy)
    {
        Id = Guid.NewGuid();
        Player = player ?? throw new ArgumentNullException(nameof(player));
        Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
    }
    
    public void ExecuteTurn()
    {
        Player.Attack(Enemy);

        if (!Enemy.IsDead)
        {
            Enemy.Attack(Player);
        }
    }
}