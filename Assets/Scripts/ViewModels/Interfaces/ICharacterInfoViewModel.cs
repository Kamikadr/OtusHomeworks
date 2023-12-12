using UniRx;

namespace ViewModels
{
    public interface ICharacterInfoViewModel: IViewModel
    {
        IReadOnlyReactiveCollection<CharacterStatViewModel> CharacterStatViewModels { get; }
    }
}