using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
  [SerializeField] private GameObject prefabBuilding;
  [SerializeField] private LayerMask layerMovebuilding;
  
  private InputHandler _inputHandler = new InputHandler();

  private List<Tower> _towers = new List<Tower>();
  private void Update()
  {
     _inputHandler.UpdateHandler();
  }

  public void SpawnBuilding(int index)
  {
      if (_towers.Count>=1)
      {
          _towers[_towers.Count-1].HideUiTower();
      }
      Tower.BuildStateType buildStateType = (Tower.BuildStateType)index;
      Transform prefabClone = Instantiate(prefabBuilding.transform);
      _inputHandler.SpawnBuilding(prefabClone, layerMovebuilding, buildStateType);
      
      _towers.Add(prefabClone.GetComponent<Tower>());
  }
}
