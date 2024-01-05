namespace SaveSystem
{
    public class GameSaver  
    {
        private readonly GameRepository _gameRepository;

        public GameSaver(GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void SaveStates()
        {
            _gameRepository.SaveState();
        }
    }
}