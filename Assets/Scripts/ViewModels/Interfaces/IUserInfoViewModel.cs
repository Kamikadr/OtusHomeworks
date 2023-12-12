using UniRx;
using UnityEngine;

namespace ViewModels
{
    public interface IUserInfoViewModel: IViewModel
    {
        public IReadOnlyReactiveProperty<string> Name { get; }
        public IReadOnlyReactiveProperty<Sprite> Icon { get;  }
        public IReadOnlyReactiveProperty<string> Description { get; }
        public IReadOnlyReactiveProperty<int> Level { get; }
    }
}