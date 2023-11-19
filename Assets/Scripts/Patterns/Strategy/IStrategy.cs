using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.Strategy
{
    public interface IStrategy
    {
        List<int> DoAlgorithm(List<int> data);
    }
    
    class ConcreteStrategyA : IStrategy
    {
        public List<int> DoAlgorithm(List<int> data)
        {
            List<int> list = data;
            list.Sort();

            return list;
        }
    }
    
    class ConcreteStrategyB : IStrategy
    {
        public List<int> DoAlgorithm(List<int> data)
        {
            List<int> list = data;
            list.Sort();
            list.Reverse();

            return list;
        }
    }
    
    class ConcreteStrategyC : IStrategy
    {
        public List<int> DoAlgorithm(List<int> data)
        {
            List<int> list = data;
            list = list.OrderBy(a => Guid.NewGuid()).ToList();            

            return list;
        }
    }
}