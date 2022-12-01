using System.Collections.Generic;
using System.IO;
using Queens.Models;
using Queens.Services;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CardCreator : EditorWindow
{
    private MultiColumnListView cardGrid;
    private Button importButton, exportJson;
    private TextField csvTextField;
    private List<CardModel> items = new List<CardModel>();
    
    [MenuItem("Kawzar/Tools/CardCreator")]
    public static void ShowExample()
    {
        CardCreator wnd = GetWindow<CardCreator>();
        wnd.titleContent = new GUIContent("CardCreator");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;
        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/CardCreator/CardCreator.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        
        root.Add(labelFromUXML);

       importButton = root.Q<Button>("import-button");
       exportJson = root.Q<Button>("export-json");
       csvTextField = root.Q<TextField>("csv-input");
       cardGrid = root.Q<MultiColumnListView>();

       exportJson.clicked += () =>
       {
           if (items.Count > 0)
           {
               var json = JsonConvert.SerializeObject(items);
               using var streamWriter = new StreamWriter(Application.streamingAssetsPath + "/Cards/cards.json");
               streamWriter.Write(json);
           }
       };
       
       cardGrid.columns["id"].makeCell = () => new Label();
           cardGrid.columns["name"].makeCell = () => new Label();
           cardGrid.columns["bearer"].makeCell = () => new Label();
           cardGrid.columns["collection"].makeCell = () => new Label();
           cardGrid.columns["level_lock"].makeCell = () => new Label();
           cardGrid.columns["dialog"].makeCell = () => new Label();
           cardGrid.columns["yes_flow"].makeCell = () => new Label();
           cardGrid.columns["yes_money"].makeCell = () => new Label();
           cardGrid.columns["yes_health"].makeCell = () => new Label();
           cardGrid.columns["yes_popularity"].makeCell = () => new Label();
           cardGrid.columns["no_flow"].makeCell = () => new Label();
           cardGrid.columns["no_money"].makeCell = () => new Label();
           cardGrid.columns["no_health"].makeCell = () => new Label();
           cardGrid.columns["no_popularity"].makeCell = () => new Label();

           cardGrid.columns["id"].bindCell = (VisualElement element, int index) =>
               (element as Label).text = items[index].id.ToString();
           cardGrid.columns["name"].bindCell = (VisualElement element, int index) =>
               (element as Label).text = items[index].name;
           cardGrid.columns["bearer"].bindCell = (VisualElement element, int index) =>
               (element as Label).text = items[index].bearer;
           cardGrid.columns["collection"].bindCell = (VisualElement element, int index) =>
               (element as Label).text = items[index].collection;
           cardGrid.columns["level_lock"].bindCell = (VisualElement element, int index) =>
               (element as Label).text = items[index].level_lock.ToString();
           cardGrid.columns["dialog"].bindCell = (VisualElement element, int index) =>
               (element as Label).text = items[index].dialog;
            cardGrid.columns["yes_flow"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].yes_flow.ToString();
            cardGrid.columns["yes_money"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].yes_money.ToString();
            cardGrid.columns["yes_health"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].yes_health.ToString();
            cardGrid.columns["yes_popularity"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].yes_popularity.ToString();
            cardGrid.columns["no_flow"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].no_flow.ToString();
            cardGrid.columns["no_money"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].no_money.ToString();
            cardGrid.columns["no_health"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].no_health.ToString();
            cardGrid.columns["no_popularity"].bindCell = (VisualElement element, int index) =>
                (element as Label).text = items[index].no_popularity.ToString();
            
           cardGrid.selectionType = SelectionType.Multiple;
           cardGrid.style.flexGrow = 1.0f;
           cardGrid.itemsSource = items;
           
       importButton.clicked += () =>
       {
           items = CardParserService.ParseCsv(csvTextField.value);
           cardGrid.itemsSource = items;

           cardGrid.Rebuild();
       };
    }
}