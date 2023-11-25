using Devotion.Scripts.Game.Boosters;
using System.Diagnostics;

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

    private bool _noOvercooked;

    public Food(string name, FoodStatus status = FoodStatus.Raw)
    {
        UnityEngine.Debug.Log("Created new food: " + name);

        FoodName = name;
        CurrentStatus = status;

        if (BoostersManager.Instance.GetBooster(Booster.BoosterType.NoOvercooked))
            OnNoOvercooked();
    }

    public void OnNoOvercooked()
    {
        _noOvercooked = true;
    }

    public void NextStep()
    {
        UnityEngine.Debug.Log("Changing status of food: " + FoodName);

        switch (CurrentStatus)
        {
            case FoodStatus.Raw:
                CurrentStatus = FoodStatus.Cooked;
                break;
            case FoodStatus.Cooked:
                if (_noOvercooked)
                    break;

                CurrentStatus = FoodStatus.Overcooked;
                GameIniter.Instance.InvokeAction(false);
                break;
            default:
                break;
        }
    }
}
