using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Utilities
    {
        public enum Dice { D4, D6, D8, D10, D12, D20, D100 };
        public static Dictionary<Dice, GameObject> DiceObjects = new Dictionary<Dice, GameObject>()
        {
            {Dice.D4,   (GameObject)Resources.Load("Prefabs/D4", typeof(GameObject))},
            {Dice.D6,   (GameObject)Resources.Load("Prefabs/D6", typeof(GameObject))},
            {Dice.D8,   (GameObject)Resources.Load("Prefabs/D8", typeof(GameObject))},
            {Dice.D10,  (GameObject)Resources.Load("Prefabs/D10", typeof(GameObject))},
            {Dice.D12,  (GameObject)Resources.Load("Prefabs/D12", typeof(GameObject))},
            {Dice.D20,  (GameObject)Resources.Load("Prefabs/D20", typeof(GameObject))},
            {Dice.D100, (GameObject)Resources.Load("Prefabs/D100", typeof(GameObject))},
        };
    }
}
