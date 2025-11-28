using UnityEngine;

public class Wallet : MonoBehaviour
{
    private const int MoneyPrise = 1;
    private int _money;

    public void AddMoney()
    {
        _money += MoneyPrise;
    }
}
