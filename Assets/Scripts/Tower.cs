using System;
using System.Collections.Generic;
using System.Linq;
using States;
using UnityEngine;
using UnityEngine.UI;


public class Tower : MonoBehaviour
{
    [SerializeField] private PriceBuildings _priceBuildings;
    [SerializeField] private Text textLevel;
    [SerializeField] private GameObject uiTower;
    [SerializeField] private BuildStateType _buildingStateType;
    
    [SerializeField] private int _level;
    
    [SerializeField] private GameObject[] buttonsAction;
    [SerializeField] private List<GameObject> buildings = new List<GameObject>();
    [SerializeField] private List<Text> textPriceStates = new List<Text>();
    public int Level { get => _level; }
    public BuildStateType BuildingStateType { get => _buildingStateType; }
    private BuildingState _buildingState;

     

    public enum BuildStateType
    {
        NotBuild,
        Active,
        Destroed
    }

    public void InitialTower(BuildStateType buildingStateType)
    {
        SetState(buildingStateType);
    }
    public void ShowUiTower()
    {
        uiTower.SetActive(true);
    }
    
   
    public void Active()
    {
        _buildingState.Active();
    }

    public void Upgrade()
    {
        _buildingState.Upgrade();
    }

    public void Sale()
    {
        _buildingState.Sale();
    }
    public void Repair()
    {
        _buildingState.Repair();
    }
    public void SetLevel(int level)
    {

        _level = level;
        textLevel.text ="LV "+  (_level+1);
        TryPurchase(1);
    }

    public void AddLevel()
    {
        
        Debug.Log("SetLevel");
        _level++;
        textLevel.text ="LV "+  (_level+1);
        
        TryPurchase(1);

    }

    public void HideUiTower()
    {
        uiTower.SetActive(false);
    }

    public void TryPurchase(int index)
    {
        
        if (index == 1)
        {
            textPriceStates[index].text = (_priceBuildings.prices[index] * (_level + 1)).ToString()+ "$";
            textPriceStates[2].text = (_priceBuildings.prices[2] * (_level + 1)).ToString()+ "$";
        }
        else
        {
            textPriceStates[index].text = _priceBuildings.prices[index]+ "$";

        }
    }
    public void SetState(BuildStateType buildStateType)
    {
        BuildingState newState = new NotBuildState(this);
        switch (buildStateType)
        {
            case BuildStateType.NotBuild:
                newState = new NotBuildState(this);
                
                buildings.ForEach(x=>x.gameObject.SetActive(false));
                buildings[0].SetActive(true);
                
                buttonsAction.ToList().ForEach(x => x.SetActive(false));
                buttonsAction[0].SetActive(true);
                TryPurchase(0);
                break;
            case BuildStateType.Active:
                newState = new ActiveState(this);
                
                buildings.ForEach(x=>x.gameObject.SetActive(false));
                buildings[1].SetActive(true);
                
                buttonsAction.ToList().ForEach(x => x.SetActive(false));
                buttonsAction[1].SetActive(true);
                buttonsAction[2].SetActive(true);
                TryPurchase(1);
                TryPurchase(2);
                break;
            case BuildStateType.Destroed:
                newState = new DestroedState(this);
                
                buildings.ForEach(x=>x.gameObject.SetActive(false));
                buildings[2].SetActive(true);
                
                buttonsAction.ToList().ForEach(x => x.SetActive(false));
                buttonsAction[2].SetActive(true);
                buttonsAction[3].SetActive(true);
                TryPurchase(2);
                TryPurchase(3);
                break;
        }

        //делаем покупку и обновления текста
        _buildingState = newState;
        
    }
    }
