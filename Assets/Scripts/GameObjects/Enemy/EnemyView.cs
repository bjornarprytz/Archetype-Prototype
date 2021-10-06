using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameObjects.Enemy
{
    public interface IEnemyView
    {
        int Health { get; set; }
        void SetName(string name);
        void SetImage(byte[] imageBytesAsPNG);
    }
    
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _nameText;
        
        private int _health;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                _healthText.text = _health.ToString();
            }
        }

        public void SetName(string name)
        {
            _nameText.text = name;
        }

        public void SetImage(byte[] imageBytesAsPNG)
        {
            _image.sprite.texture.LoadImage(imageBytesAsPNG);
        }
    }
}