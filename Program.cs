namespace CardGame
{
  class Programm
  {
    public static void Main()
    {
      // Warrior warrior = new();
      // Rogue rogue = new();
      // Mage mage = new();
      // warrior.Hit(rogue);
      // warrior.Hit(mage);

      Player player = new();

      player.PlaceCard();

      player.CardsOnTable.Values.ToList().ForEach(card => Console.WriteLine(card));
      if (player.CardsOnTable.TryGetValue("Healer1", out Card card))
      {
        Console.WriteLine(card);
      }
    }
  }
}