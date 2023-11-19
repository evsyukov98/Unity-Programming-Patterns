using Unity.VisualScripting;
using UnityEngine;

namespace Patterns.FactoryMethod
{
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        // Несмотря на название, важно понимать,
        // что создание продуктов не является единственной функцией создателя.
        // Обычно он содержит и другой полезный код работы с продуктом.
        public string GetHexCode()
        {
            IProduct product = FactoryMethod();
            string result = product.OperationGetColor().ToHexString();

            return result;
        }
    }
    
    // Конкретные Создатели переопределяют фабричный метод для того, чтобы
    // изменить тип результирующего продукта.
    public class ConcreteCreator1 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    public class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }
}
