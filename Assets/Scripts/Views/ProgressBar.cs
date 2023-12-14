using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using ViewModels;
using Sequence = DG.Tweening.Sequence;

namespace Views
{
    public class ProgressBar: BaseView<IProgressBarViewModel>
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private TMP_Text currentXpText;
        [SerializeField] private TMP_Text requiredXpText;
        
        [Header("Animation Settings")]
        [SerializeField] private ScaleTweenArgs startScaleTweenArgs;
        [SerializeField] private ScaleTweenArgs endScaleTweenArgs;
        [SerializeField] private float countingDuration;
        
        private int _currentXp;
        private int _requiredXp;
        private Sequence _animation;
        protected override void OnInitialize()
        {
            BindToViewModel();

            SetCurrentXpWithoutAnimation(Model.CurrentXp.Value);
        }

        private void BindToViewModel()
        {
            Model.RequiredXp.Subscribe(OnRequiredXpChange).AddTo(Disposables);
            Model.CurrentXp.SkipLatestValueOnSubscribe().Subscribe(OnCurrentXpChange).AddTo(Disposables);
        }

        private void OnCurrentXpChange(int newValue)
        {
            Animate(_currentXp, newValue);
            _currentXp = newValue;
        }
        private void OnRequiredXpChange(int newValue)
        {
            _requiredXp = newValue;
            requiredXpText.text = _requiredXp.ToString();
        }

        private void Animate(int oldValue, int newValue)
        {
            _animation?.Kill();

            _animation = DOTween.Sequence();
            _animation.Append(currentXpText.transform.DOScale(endScaleTweenArgs.Scale, endScaleTweenArgs.Duration));
            var tweenCounting = DOTween.To(() => oldValue, SetCurrentXpWithoutAnimation, newValue, countingDuration);
            _animation.Append(tweenCounting);
            _animation.Append(currentXpText.transform.DOScale(startScaleTweenArgs.Scale, startScaleTweenArgs.Duration));
            
        }
        private void SetCurrentXpWithoutAnimation(int newValue)
        {
            currentXpText.text = newValue.ToString();
            progressBar.value = (float) newValue / _requiredXp;
        }

        
    }
}