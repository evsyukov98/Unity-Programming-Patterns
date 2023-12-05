using System;
using System.Collections.Generic;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Decorator
{
    
    /// <summary>
    /// Декоратор — это структурный паттерн проектирования, который позволяет динамически добавлять объектам новую функциональность, оборачивая их в полезные «обёртки».
    /// ****************************************************************
    /// Любая одежда — это аналог Декоратора. Применяя Декоратор, вы не меняете первоначальный класс и не создаёте дочерних классов.
    /// Так и с одеждой — надевая свитер, вы не перестаёте быть собой, но получаете новое свойство — защиту от холода.
    /// Вы можете пойти дальше и надеть сверху ещё один декоратор — плащ, чтобы защититься и от дождя.
    /// </summary>
    public class Main : MonoBehaviour
    {
        [Header("UI: ")]
        [SerializeField] private TextMeshProUGUI statsText;
        [SerializeField] private DropdownExtension dropdownRace;
        [SerializeField] private DropdownExtension dropdownSpec;
        [SerializeField] private Button cursedEffectButton;
        [Space, Header("Player: ")]
        [SerializeField] private RaceType race;
        [SerializeField] private SpecializationType spec;

        private Player _player;
        
        private void Start()
        {
            dropdownRace.SetEnumOptions(typeof(RaceType));
            dropdownSpec.SetEnumOptions(typeof(SpecializationType));
            
            dropdownRace.Dropdown.onValueChanged.AddListener(OnRaceChanged);
            dropdownSpec.Dropdown.onValueChanged.AddListener(OnSpecChanged);
            cursedEffectButton.onClick.AddListener(OnCursedEffect);

            InitPlayer();
        }

        private void InitPlayer()
        {
            _player = new Player(race, spec);
            UpdateStatsText();
        }

        private void OnRaceChanged(int value)
        {
            string enumElementName = dropdownRace.Dropdown.options[value].text;
            if (Enum.TryParse(enumElementName, out RaceType type)) 
                race = type;

            InitPlayer();
        }

        private void OnSpecChanged(int value)
        {
            string enumElementName = dropdownSpec.Dropdown.options[value].text;
            if (Enum.TryParse(enumElementName, out SpecializationType type)) 
                spec = type;

            InitPlayer();
        }

        private void OnCursedEffect()
        {
           _player.SetEffect(EffectType.Cursed);
           UpdateStatsText();
        }

        private void UpdateStatsText()
        {
            PlayerStats stats = _player.GetStats();
            string playerStatsString = $"<color=#FFB18A>Strength {stats.Strength}</color>\n<color=#7B5A6D>StrengthAgility {stats.Agility}</color>\n<color=#8FAABB>Intelligence {stats.Intelligence}</color>\n<color=#3D5D6B>Stamina {stats.Stamina}</color>";
            statsText.text = playerStatsString;
        }
    }

    public class Player
    {
        private RaceType _race;
        private SpecializationType _spec;
        private List<string> _items;
        private EffectType _effect;

        private IStatsProvider _provider;

        public Player()
        {
            _items = new List<string>();
            _effect = EffectType.None;
        }

        public Player(RaceType race, SpecializationType spec) : this()
        {
            _race = race;
            _spec = spec;
            
            UpdateStats();
        }

        public PlayerStats GetStats()
        { 
            return _provider.GetStats();
        }

        public void SetEffect(EffectType effect)
        {
            _effect = effect;
            UpdateStats();
        }

        private void UpdateStats()
        {
            _provider = new RaceStats(_race);
            _provider = new SpecializationStats(_provider, _spec);
            if(_items.Count != 0) _provider = new ItemsStatsProvider(_provider, _items);
            _provider = new EffectsStats(_provider, _effect);
        }
    }
}
