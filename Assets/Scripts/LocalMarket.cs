using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMarket : MonoBehaviour
{
    struct Goods
    {
        private int _id;

        public float Price;

        public string GetName()
        {
            return ContentManager.Instance.GetGoodsById(_id).Name;
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }

    private HashSet<Goods> _goodsStockpile = new HashSet<Goods>();

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
