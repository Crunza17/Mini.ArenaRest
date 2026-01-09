using ArenaRest.Domain.Entities;
using Shouldly;

namespace ArenaRest.Test;

public class FighterTests
{
    [Fact]
    public void Fighter_Should_Reduce_Hp_When_Taking_Damage()
    {
        var fighter = new Fighter("Hero", 100, 0); 

        fighter.TakeDamage(10);

        fighter.CurrentHp.ShouldBe(90);
    }
    
    [Fact]
    public void CurrentHp_Should_Not_Drop_Below_Zero()
    {
        var fighter = new Fighter("Weakling", 50, 0);

        fighter.TakeDamage(100);

        fighter.CurrentHp.ShouldBe(0);
    }
    
    [Fact]
    public void IsDead_Should_Be_True_When_Hp_Is_Zero()
    {
        var fighter = new Fighter("Zombie", 10, 0);

        fighter.TakeDamage(10);

        fighter.IsDead.ShouldBeTrue();
    }
    
    [Fact]
    public void Attack_Should_Reduce_Target_Hp_By_Attacker_Strength()
    {
        var attacker = new Fighter("Hero", 100, 10); 
        var target = new Fighter("Zombie", 50, 5);

        attacker.Attack(target);

        target.CurrentHp.ShouldBe(40);
    }
}