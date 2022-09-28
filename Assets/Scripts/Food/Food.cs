public sealed class Food
{
    public enum FoodStatus
    {
        Raw,
        Cooked,
        Overcooked
    }

    public string FoodName { get; }
    public FoodStatus CurrentStatus { get; private set; }

    public Food(string name, FoodStatus status = FoodStatus.Raw)
    {
        UnityEngine.Debug.Log("Created new food: " + name);

        FoodName = name;
        CurrentStatus = status;
    }

    public void NextStep()
    {
        UnityEngine.Debug.Log("Changing status of food: " + FoodName);

        switch (CurrentStatus)
        {
            case FoodStatus.Raw:
                {
                    CurrentStatus = FoodStatus.Cooked;
                    return;
                }
            case FoodStatus.Cooked:
                {
                    CurrentStatus = FoodStatus.Overcooked;
                    return;
                }
            default:
                {
                    return;
                }
        }
    }
}
