using ShootEmUp.GameInput;

namespace VContainer
{
    public class InputInstaller: Installer
    {
        public override void Configure(IContainerBuilder builder)
        {
            builder.Register<KeyboardInput>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}