///
/// INFORMATION
///
/// Project: Exercise04
/// Date: 21/10/2020
/// Author: Level Up
/// Website: https://www.game-levelup.com/
/// Programmers: David Cuenca, Pau Elias
/// Description: Player manager. Contains all methods for managing player objects: find, add, remove, etc.
///

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player manager.
/// Contains all methods for managing player objects: find, add, remove, etc.
/// </summary>
/// <seealso cref="Player"/>
public class Comments : MonoBehaviour
{
    
    /// Action invoked when a player is added to the list of players.
    public event Action<Player> PlayerAdded = delegate { };

    /// Action invoked when a player is removed from the list of players.
    public event Action<Player> PlayerRemoved = delegate { };

    /// List of players, instantiated on the Awake method.
    private List<Player> _players;

    /// <summary>
    /// Initializes the list of players.
    /// </summary>
    private void Awake()
    {
        _players = new List<Player>();
    }

    /// <summary>
    /// Searches for the player with the given id in the list of players.
    /// </summary>
    /// <param name="id">Id of the player.</param>
    /// <returns>The first player with the given id in the list of players or <c>null</c> otherwise.</returns>
    /// <seealso cref="Player.Id"/>
    public Player GetPlayerById(int id)
    {
        return _players.Find(player => player.Id == id);
    }

    /// <summary>
    /// Adds the player to the list of players and calls <c>OnPlayerAdded</c>.
    /// </summary> 
    /// <remarks>
    /// This method does not check if the player to add is already in the list of players and calls <c>OnPlayerAdded</c> anyway.
    /// </remarks>    
    /// <param name="player">The player to be added.</param>
    /// <seealso cref="Player"/>
    public void AddPlayer(Player player)
    {
        _players.Add(player);
        OnPlayerAdded(player);
    }

    /// <summary>
    /// Removes the player from the list of players (if exists) and calls <c>OnPlayerRemoved</c>.
    /// <remarks>
    /// This method does not check if the player to remove is in the list of players and calls <c>OnPlayerRemoved</c> anyway.
    /// </remarks>
    /// </summary>
    /// <param name="player">The player to be removed.</param>
    /// <seealso cref="Player"/>
    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
        OnPlayerRemoved(player);
    }

    /// <summary>
    /// Returns the position of the player's transform in the world.
    /// </summary>
    /// <param name="id">Id of the player.</param>
    /// <returns>A <c>Vector3</c> with the position of the player's transform in the world.</returns>
    /// <exception cref="System.NullReferenceException">If the player with the given id doesn't exists in the list of players.</exception>
    /// <seealso cref="Player.Id"/>
    public Vector3 GetPlayerPositionById(int id)
    {
        return GetPlayerById(id).transform.position;
    }

    /// <summary>
    /// Invokes <c>PlayerAdded</c> action.
    /// </summary>
    /// <param name="player">The added player.</param>
    /// <seealso cref="Player"/>    
    public void OnPlayerAdded(Player player)
    {
        if(PlayerAdded != null)
        {
            PlayerAdded.Invoke(player);
        }
    }

    /// <summary>
    /// Invokes <c>PlayerRemoved</c> action.
    /// </summary>
    /// <param name="player">The removed player.</param>
    /// <seealso cref="Player"/>    
    public void OnPlayerRemoved(Player player)
    {
        if (PlayerAdded != null)
        {
            PlayerRemoved.Invoke(player);
        }
    }

}
