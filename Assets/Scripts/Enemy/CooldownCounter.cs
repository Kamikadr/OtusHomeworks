using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShootEmUp.Enemies
{
    public class CooldownCounter: IDisposable
    {
        private readonly float _countdown;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _needCount;

        public CooldownCounter(float enemyCooldown)
        {
            _countdown = enemyCooldown;
        }
        public event Action CountIsDownEvent;

        public void SetActive(bool value)
        {
            _needCount = value;
            if (value)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                CooldownTask(_cancellationTokenSource.Token);
            }
            else
            {
                _cancellationTokenSource?.Cancel();
            }
        }

        private async Task CooldownTask(CancellationToken token = default)
        {
            try
            {
                while (_needCount)
                {
                    await Task.Delay(TimeSpan.FromSeconds(_countdown), token);
                    CountIsDownEvent?.Invoke();
                }
            }
            finally
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}