using System.Collections.Generic;

namespace SaveSystem
{
    public class SaveLoadManager
    {
        private IEnumerable<ISaveLoader> _saveLoaders;
        private void Construct(IEnumerable<ISaveLoader> saveLoaders)
        {
            _saveLoaders = saveLoaders;
        }
        public void LoadGame()
        {
            
        }

        public void SaveGame()
        {
            
        }
    }
}