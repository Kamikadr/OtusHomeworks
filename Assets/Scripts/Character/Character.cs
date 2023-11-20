using ShootEmUp.Common;
using UnityEngine;

namespace ShootEmUp.Characters
{
    public class Character: Unit, ICharacter
    {
        public GameObject GameObject => gameObject;
    }
}