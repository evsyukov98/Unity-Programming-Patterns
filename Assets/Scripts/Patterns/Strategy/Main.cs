using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resultText;
        
        [SerializeField] private Button firstStrategy;
        [SerializeField] private Button secondStrategy;
        [SerializeField] private Button thirdStrategy;

        private Context _context = new Context();

        private void Start()
        {
            firstStrategy.onClick.AddListener(FirstStrategy);
            secondStrategy.onClick.AddListener(SecondStrategy);
            thirdStrategy.onClick.AddListener(ThirdStrategy);
        }

        private void FirstStrategy()
        {
            _context.SetStrategy(new ConcreteStrategyA());
            UpdateText(_context.DoSomeBusinessLogic());
        }

        private void SecondStrategy()
        {
            _context.SetStrategy(new ConcreteStrategyB());
            UpdateText(_context.DoSomeBusinessLogic());
        }

        private void ThirdStrategy()
        {
            _context.SetStrategy(new ConcreteStrategyC());
            UpdateText(_context.DoSomeBusinessLogic());
        }

        private void UpdateText(List<int> result)
        {
            string resultStr = string.Empty;
            
            foreach (int element in result)
            {
                resultStr += element + ",";
            }

            resultText.text = resultStr;
        }
    }
    
    class Context
    {       
        private IStrategy _strategy;

        public Context() { }
        
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Обычно Контекст позволяет заменить объект Стратегии во время
        // выполнения.
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Вместо того, чтобы самостоятельно реализовывать множественные версии
        // алгоритма, Контекст делегирует некоторую работу объекту Стратегии.
        public List<int> DoSomeBusinessLogic()
        {
            return _strategy.DoAlgorithm(new List<int> { 1, 5, 23 ,2 , 3, 12, 37 });
        }
    }
}
