using System.Collections.Generic;

namespace Patterns.Strategy
{
    public interface IStrategy
    {
        List<int> DoAlgorithm(List<int> data);
    }
}