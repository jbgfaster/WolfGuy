using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int money=0;

    public bool HasMoney(int _money)
    {
        if(money>=_money)
            return true;
        else
            return false;
    }

    public void AddMoney(int _money)
    {
        money+=_money;
        if(money<0)
        {
            money=0;
        }
    }
}
