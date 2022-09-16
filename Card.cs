namespace CardGame
{
  public static class CardTypes
  {
    public const string Warrior = "Warrior";
    public const string Mage = "Mage";
    public const string Rogue = "Rogue";
    public const string Healer = "Healer";
  }

  public struct MageCharacteristics
  {

  }

  public abstract class Card
  {
    public int ManaCost { get; protected set; }
    public int Health { get; protected set; }
    public int ActionPoints { get; protected set; }
    public string Name { get; protected set; }

    public Card(int manaCost = 1, int health = 1, int actionPoints = 1, string name = "Card")
    {
      ManaCost = manaCost;
      Health = health;
      ActionPoints = actionPoints;
      Name = name;
    }

    public void GetHit(int damage)
    {
      Health -= damage;
      Console.WriteLine($"{Name} damaged by {damage}.");
    }

    public void GetHeal(int healAmount)
    {
      Health += healAmount;
      Console.WriteLine($"{Name} healed on {healAmount}.");
    }

    public void Death()
    {
      Console.WriteLine($"{Name} is dying.");
    }

    public override string ToString()
    {
      return $"{Name}:\nAP:{ActionPoints}, HP:{Health}";
    }
  }

  public abstract class AttackingCard : Card
  {
    protected List<Type> TargetCardTypes;

    public AttackingCard(int manaCost = 1, int health = 1, int actionPoints = 1, string name = "AttackingCard") : base(manaCost, health, actionPoints, name)
    {
      TargetCardTypes = new List<Type>();
    }

    public virtual void Hit(Card targetCard)
    {
      if (TargetCardTypes.Contains(targetCard.GetType()))
      {
        targetCard.GetHit(ActionPoints);
      }
      else
      {
        Console.WriteLine($"{Name}: I cant hit {targetCard.Name}.");
      }
    }
  }

  public abstract class HealingCard : Card
  {
    private List<Card> _allyCards;

    public HealingCard(List<Card> allyCards, int manaCost = 1, int health = 1, int actionPoints = 1, string name = "HealingCard") : base(manaCost, health, actionPoints, name)
    {
      _allyCards = allyCards;
    }

    public virtual void Heal(Card targetCard)
    {
      _allyCards.ForEach(card => card.GetHeal(ActionPoints));
    }
  }

  //  Must kill Rogue
  public class Warrior : AttackingCard
  {
    public Warrior() : base(health: 3, name: "Warrior")
    {
      TargetCardTypes.Add(typeof(Rogue));
    }
  }

  //  Must kill Mage and Healer
  public class Rogue : AttackingCard
  {
    public Rogue() : base(actionPoints: 3, name: "Rogue")
    {
      TargetCardTypes.Add(typeof(Mage));
      TargetCardTypes.Add(typeof(Healer));
    }
  }

  //  Must kill Warrior
  public class Mage : AttackingCard
  {
    public Mage() : base(name: "Mage")
    {
      TargetCardTypes.Add(typeof(Warrior));
    }
  }

  // Must heal all cards on user desk
  public class Healer : HealingCard
  {
    public Healer(List<Card> allyCards) : base(allyCards: allyCards, manaCost: 2, name: "Healer")
    {
    }
  }
}
