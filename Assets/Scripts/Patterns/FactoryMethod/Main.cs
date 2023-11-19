using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.FactoryMethod
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Button chooseCreatorA;
        [SerializeField] private Button chooseCreatorB;
        [Space] 
        [SerializeField] private Button getHexCode;
        [Space] 
        [SerializeField] private TextMeshProUGUI hexText;
        [SerializeField] private Renderer materialRenderer;
        
        private ConcreteCreator1 _creator1 = new ConcreteCreator1();
        private ConcreteCreator2 _creator2 = new ConcreteCreator2();
        
        private Creator _currentCreator;
        private IProduct _product;
        
        private void Start()
        {
            chooseCreatorA.onClick.AddListener(() =>
            {
                _currentCreator = _creator1;
                CreateProduct();
            });
            
            chooseCreatorB.onClick.AddListener(() =>
            {
                _currentCreator = _creator2;
                CreateProduct();
            });

            getHexCode.onClick.AddListener(GetHexCode);
        }

        private void CreateProduct()
        {
            if (_currentCreator == null) return;

            _product = _currentCreator.FactoryMethod();
            materialRenderer.material.color = _product.OperationGetColor();

        }

        private void GetHexCode()
        {
            hexText.text = _currentCreator.GetHexCode();
        }
    }
}