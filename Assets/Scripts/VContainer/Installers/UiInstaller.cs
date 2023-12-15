using App;
using UI;
using UnityEngine;

namespace VContainer
{
    public class UiInstaller: Installer
    {
        [SerializeField] private PauseResumeButtonStateController pauseResumeButtonStateController;
        [SerializeField] private PauseResumeButtonListener pauseResumeButtonListener;
        [SerializeField] private StartButtonListener startButtonListener;
        
        public override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(pauseResumeButtonStateController).AsImplementedInterfaces();
            builder.RegisterInstance(pauseResumeButtonListener).AsImplementedInterfaces();
            builder.RegisterInstance(startButtonListener).AsImplementedInterfaces();
        }
    }
}