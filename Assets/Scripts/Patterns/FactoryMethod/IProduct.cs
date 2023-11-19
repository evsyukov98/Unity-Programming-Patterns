using UnityEngine;

namespace Patterns.FactoryMethod
{
    public interface IProduct
    {
        public Color OperationGetColor();
    }
    
    class ConcreteProduct1 : IProduct
    {
        public Color OperationGetColor()
        {
            return Color.red;
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public Color OperationGetColor()
        {
            return Color.green;
        }
    }
}