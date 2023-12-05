using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class DropdownExtension : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;

        public TMP_Dropdown Dropdown => _dropdown;

        private void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
        }

        public void SetEnumOptions(Type type)
        {
            _dropdown.ClearOptions();
            
            var newOptions = new List<string>();
            
            foreach (var raceType in Enum.GetValues(type))
            {
                string enumString = raceType.ToString();
                newOptions.Add(enumString);
            }
            
            _dropdown.AddOptions(newOptions);
        }
    }
}
