using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler 
{
    private Transform prefabClone;
    
    private bool _isSpawning;
    
    private LayerMask _layerLocalMoveBuild;

    private Tower _selectTower;

   public void UpdateHandler()
   {
      if (Input.GetMouseButtonDown(0) && !prefabClone)
      {
      
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
          
          if (Physics.Raycast(ray, out RaycastHit hit))
          {
              if (hit.collider.CompareTag("Building"))
              {
                  if (_selectTower)
                  {
                      _selectTower.HideUiTower();
                  }
                  Tower tower =  hit.collider.GetComponent<Tower>();
                  tower.ShowUiTower();
                  _selectTower = tower;
              }
          }
      }
      
      if (Input.GetMouseButton(0) && prefabClone)
      {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerLocalMoveBuild);
          prefabClone.transform.position = hit.point + new Vector3(0, 0.4f, 0);
      }

      if (Input.GetMouseButtonUp(0))
      {
          if (_isSpawning)
          {
              _isSpawning = false;
          }
          else
          {
              prefabClone = null;

          }
      }

   
   }
   public void SpawnBuilding(Transform _prefabClone, LayerMask _layerMoveBuild, Tower.BuildStateType BuildStateType)
   {
       prefabClone = _prefabClone;
      
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       Physics.Raycast(ray, out RaycastHit hit);
       prefabClone.transform.position =  Vector3.zero + new Vector3(0, 0.4f, 0);
       prefabClone.GetComponent<Tower>().InitialTower(BuildStateType);
       _isSpawning = true;
       _layerLocalMoveBuild = _layerMoveBuild;
   }
}
