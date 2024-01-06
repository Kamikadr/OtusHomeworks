namespace SaveSystem
{
    public class GameSaver  
    {
        private readonly IGameRepository _gameRepository;

        public GameSaver(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void SaveStates()
        {
            _gameRepository.SaveState();
        }
    }
}