using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class DefinitionsContainer : MonoBehaviour
{
    [System.Serializable]
    public struct Goods
    {
        public Goods(string name, string description) 
        {
            Name = name;
            Description = description;
        }

        [SerializeField] public string Name { get; private set; }
        [SerializeField] public string Description { get; private set; }
    }

    [System.Serializable]
    public struct ProductionMethod 
    {


        public string Name { get; private set; }
        public List<string> RequiredGoods { get; private set; }
    }


    public static DefinitionsContainer Instance { get; private set; }

    [SerializeField, SerializedDictionary("Goods ID", "Goods Data")] 
    private SerializedDictionary<string, Goods> _goodsDefinition = new();

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }


    public Goods GetGoods(string id)
    {
        Goods goods;

        if (_goodsDefinition.TryGetValue(id, out goods)) 
            return goods;

        Debug.LogError("Requested undefined goods");

        return new Goods("Undefined", "Undefined goods, probably an error");
    }


}
