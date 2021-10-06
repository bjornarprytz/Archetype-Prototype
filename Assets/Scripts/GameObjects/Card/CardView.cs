
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace GameObjects
{
    public interface ICardView
    {
        Collider Collider { get; }
        void SetTitle(string title);
        void SetCost(int cost);
        void SetRulesText(string text);
        void SetImage(byte[] imageBytesAsPNG);
        void SetColor(Color color);
    }
    
    public class CardView : MonoBehaviour, ICardView
    {
        [SerializeField] private Collider _collider;

        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _costText;
        [SerializeField] private TMP_Text _rulesText;

        [SerializeField] private Image _frame;
        
        [SerializeField] private Image _image;

        public Collider Collider => _collider;

        private CompositeDisposable _disposable = new CompositeDisposable();

        private void Awake()
        {
            Collider.OnMouseDownAsObservable()
                .Select(_ => Input.mousePosition)
                .Subscribe(OnClick)
                .AddTo(_disposable);
            
            Collider.OnMouseDragAsObservable()
                .Select(_ => Input.mousePosition)
                .Subscribe(MoveCard)
                .AddTo(_disposable);
        }

        private void OnClick(Vector3 pos)
        {
            
        }
        
        private void MoveCard(Vector3 pos)
        {
            gameObject.transform.position = pos;
        }


        public void SetTitle(string title)
        {
            _titleText.text = title;
        }

        public void SetCost(int cost)
        {
            _costText.text = $"{cost}";
        }

        public void SetRulesText(string text)
        {
            _rulesText.text = text;
        }

        public void SetImage(byte[] imageBytesAsPNG)
        {
            _image.sprite.texture.LoadImage(imageBytesAsPNG);
        }

        public void SetColor(Color color)
        {
            _frame.color = color;
        }
    }
}