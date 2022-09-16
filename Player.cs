namespace CardGame
{
  class Player
  {
    public string Name { get; private set; }
    private Dictionary<string, Card> CardsInArm;
    public Dictionary<string, Card> CardsOnTable { get; private set; }

    public Player(string name = "Player")
    {
      Name = name;
      CardsInArm = new Dictionary<string, Card>(){
        {"Warrior", new Warrior()},
        {"Rogue", new Rogue()},
        {"Mage", new Mage()},
      };
      CardsInArm.Add("Healer", new Healer(CardsInArm.Values.ToList()));
      CardsOnTable = new Dictionary<string, Card>();
    }

    public void PlaceCard()
    {
      ShowCards(CardsInArm);
      Console.WriteLine("Choose your card:");
      string? userInput = Console.ReadLine();
      if (userInput != null)
      {
        if (userInput.Length == 0)
        {
          Console.WriteLine("Put some number or Card name, pls...\nOr just press Esc");
        }
        else
        {
          if (Utils.SearchInDictionaryByUserInput(CardsInArm, userInput, out Card? card) && card != null)
          {
            CardsOnTable.Add(card.Name, card);
          }
          else
          {
            Console.WriteLine($"Cant find {userInput} card");
          }
        }
      }
    }

    private void ShowCards(Dictionary<string, Card> cards)
    {
      foreach (KeyValuePair<string, Card> item in cards)
      {
        Console.WriteLine($"{item.Key}: {item.Value}");
      }
    }
  }
}