using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Build Price", menuName = "Prices/Buildings")]
public class PriceBuildings : ScriptableObject
{
    public List<int> prices = new List<int>();
}
