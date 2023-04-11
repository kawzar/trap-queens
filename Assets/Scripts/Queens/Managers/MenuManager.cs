using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Queens.Global.Constants;
using Queens.Managers;
using Queens.Models;
using Queens.Services;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; set; }
    [SerializeField] private HistoricDataFactory _historicDataFactory;

    [SerializeField] private GameObject _historicPrefab;
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
            instantiated.GetComponentInChildren<TextMeshProUGUI>().SetText($"{model.name} - {model.career}");
        }
    }
    
    public void OnPlay()
    {
        _ = SceneManager.Instance.LoadScene(SceneConstants.PLAY);
    }
}
