using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    [System.Serializable]
    public struct Goods
    {
        public Goods(string name, string desciption) 
        {
            _name = name;
            _description = desciption;
        }

        public string Name { get { return _name; } }
        public string Desciption { get { return _description; } }

        [SerializeField] private string _name;
        [SerializeField] private string _description;
    }

    public static ContentManager Instance { get; private set; }

    [SerializeField] private List<Goods> _goodsDefenition = new List<Goods>();

    public Goods GetGoodsById(int id) 
    {
        if (id < 0 || id >= _goodsDefenition.Count)
            return new Goods();

        return _goodsDefenition[id];
    }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
}
