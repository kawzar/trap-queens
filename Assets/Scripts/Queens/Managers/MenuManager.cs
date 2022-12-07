using System.Collections.Generic;
using Queens.Managers;
using Queens.Models;
using Queens.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; set; }
    [SerializeField] private HistoricDataFactory _historicDataFactory;

    [SerializeField] private TextMeshProUGUI _historicPrefab;
    [SerializeField] private Transform _historicListParent;
    private List<HistoricPlayerModel> _historicPlayerModels;
    private void Awake()
    {
        _historicPlayerModels = _historicDataFactory.GetHistoricData();
    }

    private void Start()
    {
        foreach (var model in _historicPlayerModels)
        {
            var instantiated =Instantiate(_historicPrefab, _historicListParent);
            instantiated.SetText($"{model.name} - {model.career}");
        }
    }
    
    public void OnPlay()
    {
        SceneManager.LoadScene(0);
    }
}
