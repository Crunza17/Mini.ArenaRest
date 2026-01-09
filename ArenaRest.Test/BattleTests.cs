using ArenaRest.Domain.Entities;
using Shouldly;
using Xunit;

namespace ArenaRest.Test;

public class BattleTests
{
    [Fact]
    public void Battle_Should_Initialize_With_Two_Fighters()
    {
        var player = new Fighter("Hero", 100, 10);
        var enemy = new Fighter("Monster", 100, 10);

        var battle = new Battle(player, enemy);

        battle.Id.ShouldNotBe(Guid.Empty); 
        battle.Player.ShouldBe(player);
        battle.Enemy.ShouldBe(enemy);
    }
    
    [Fact]
    public void ExecuteTurn_Should_Make_Player_Attack_Enemy()
    {
        var player = new Fighter("Hero", 100, 10);
        var enemy = new Fighter("Monster", 50, 5); 
        var battle = new Battle(player, enemy);

        battle.ExecuteTurn(); 

        battle.Enemy.CurrentHp.ShouldBe(40);
    }
    
    [Fact]
    public void ExecuteTurn_Should_Make_Enemy_CounterAttack_If_Alive()
    {
        // Arrange
        var player = new Fighter("Hero", 100, 10); 
        var enemy = new Fighter("Monster", 100, 5);
        var battle = new Battle(player, enemy);

        battle.ExecuteTurn();

        battle.Player.CurrentHp.ShouldBe(95); 
    }
}