using Cysharp.Threading.Tasks;

namespace App.SaveSystem
{
    public sealed class GameSaver  
    {
        private readonly IGameRepository _gameRepository;

        public GameSaver(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async UniTask SaveStates()
        {
           await _gameRepository.SaveStateAsync();
        }
    }
}