using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocalMarket : MonoBehaviour
{
    struct Goods
    {
        private string _id;

        public float Price;

        public string GetName()
        {
            return DefinitionsContainer.Instance.GetGoods(_id).Name;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
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
