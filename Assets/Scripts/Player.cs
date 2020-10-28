///
/// INFORMATION
///
/// Project: Exercise04
/// Date: 28/10/2020
/// Author: Level Up
/// Website: https://www.game-levelup.com/
/// Programmers: David Cuenca, Pau Elias
/// Description: Player model.
///

using UnityEngine;

public class Player: MonoBehaviour
{
    /// Name of the player. 
    public string Name { get; private set; }

    /// Id of the player.
    public int Id { get; private set; }
}
