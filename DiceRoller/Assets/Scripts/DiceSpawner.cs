using Boo.Lang;
using System.Collections;
using UnityEngine;



public class DiceSpawner : MonoBehaviour {

    private void Start()
    {
        List<Assets.Scripts.Utilities.Dice> diceToSpawn = new List<Assets.Scripts.Utilities.Dice>()
        {
            Assets.Scripts.Utilities.Dice.D4,
            Assets.Scripts.Utilities.Dice.D6,
            Assets.Scripts.Utilities.Dice.D8,
            Assets.Scripts.Utilities.Dice.D10,
            Assets.Scripts.Utilities.Dice.D12,
            Assets.Scripts.Utilities.Dice.D20,
            Assets.Scripts.Utilities.Dice.D100
        };
        StartCoroutine(SpawnDice(diceToSpawn));
    }

    IEnumerator SpawnDice (List<Assets.Scripts.Utilities.Dice> dice)
    {
        foreach (Assets.Scripts.Utilities.Dice die in dice)
        {
            SpawnDie(die);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnDie (Assets.Scripts.Utilities.Dice die)
    {
        GameObject dieToSpawn = Assets.Scripts.Utilities.DiceObjects[die];
        dieToSpawn = Instantiate(dieToSpawn);

        dieToSpawn.transform.rotation = Random.rotation;

        Vector3 spawnPosition = dieToSpawn.transform.position;
        spawnPosition.y = 10;
        dieToSpawn.transform.position = spawnPosition;

        Vector3 spawnForce = new Vector3(100, 100, 200);
        Vector3 spawnTorque = new Vector3(100, 0, 0);
        dieToSpawn.GetComponent<Rigidbody>().AddForce(spawnForce);
        dieToSpawn.GetComponent<Rigidbody>().AddTorque(spawnTorque);
    }
}
