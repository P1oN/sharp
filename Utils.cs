namespace CardGame
{
  public static class Utils
  {
    public static bool SearchInDictionaryByUserInput<T>(Dictionary<string, T> dictionary, string search, out T? item)
    {
      //TODO: Continue here
      item = default(T);
      if (int.TryParse(search, out int itemNumber))
      {
        if (itemNumber > 0 && itemNumber <= dictionary.Count)
        {
          item = dictionary.Values.ToArray()[itemNumber];
        }
      }
      else if (search.Length > 0)
      {
        string searchKey = "";
        dictionary.Keys.ToList().ForEach(key =>
        {
          if (key.ToLower().Contains(search.ToLower())) { searchKey = key; }
        });

        if (searchKey != "" && dictionary.TryGetValue(searchKey, out T? _item) && _item != null)
        {
          item = _item;
        }
      }
      return item != null && item.GetType() == typeof(T);
    }
  }
}