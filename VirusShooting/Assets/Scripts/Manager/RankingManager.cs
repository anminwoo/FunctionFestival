using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public Text[] ranks;

    public void Start()
    {
        SortRanking();
    }

    public void SortRanking()
    {
        int i = 0;
        List<(string, int)> sList = GameManager.instance.userInfo.OrderByDescending(u => u.Item2).ToList();
        foreach (var e in sList)
        {
            ranks[i].text = $"{i + 1} {e.Item1}, {e.Item2}";
            i++;
        }
    }
    
}
