using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private TextMeshProUGUI _message;
    
    public void ShowPanel()
    {
        _object.SetActive(true);
        _message.text = "Человеческая цивилизация закончила существование";
        Time.timeScale = 0;//Конец игры для тестов        
    }
}
