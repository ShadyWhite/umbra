﻿/* Umbra.Game | (c) 2024 by Una         ____ ___        ___.
 * Licensed under the terms of AGPL-3  |    |   \ _____ \_ |__ _______ _____
 *                                     |    |   //     \ | __ \\_  __ \\__  \
 * https://github.com/una-xiv/umbra    |    |  /|  Y Y  \| \_\ \|  | \/ / __ \_
 *                                     |______//__|_|  /____  /|__|   (____  /
 *     Umbra.Game is free software: you can          \/     \/             \/
 *     redistribute it and/or modify it under the terms of the GNU Affero
 *     General Public License as published by the Free Software Foundation,
 *     either version 3 of the License, or (at your option) any later version.
 *
 *     Umbra.Game is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU Affero General Public License for more details.
 */

using System.Numerics;

namespace Umbra.Game;

public interface IPlayer
{
        /// <summary>
    /// The player's current position in the world.
    /// </summary>
    public Vector3 Position { get; }

    /// <summary>
    /// The player's current rotation in radians.
    /// </summary>
    public float Rotation { get; }

    /// <summary>
    /// True if the player is currently moving.
    /// </summary>
    public bool IsMoving { get; }

    /// <summary>
    /// True if the player is currently mounted.
    /// </summary>
    public bool IsMounted { get; }

    /// <summary>
    /// True if the player is currently in combat.
    /// </summary>
    public bool IsInCombat { get; }

    /// <summary>
    /// True if the player is currently casting a spell or ability.
    /// </summary>
    public bool IsCasting { get; }

    /// <summary>
    /// True if the player is currently in an occupied state, meaning they
    /// can't perform any regular actions.
    /// </summary>
    public bool IsOccupied { get; }

    /// <summary>
    /// True if the player is currently watching a cutscene.
    /// </summary>
    public bool IsInCutscene { get; }

    /// <summary>
    /// True if the player is currently dead.
    /// </summary>
    public bool IsDead { get; }

    /// <summary>
    /// True if the player is currently jumping.
    /// </summary>
    public bool IsJumping { get; }

    /// <summary>
    /// True if the player is currently bound by duty, meaning they can't
    /// teleport or use the Duty Finder.
    /// </summary>
    public bool IsBoundByDuty { get; }

    /// <summary>
    /// True if the player can, and is allowed to, use the teleport action.
    /// </summary>
    public bool CanUseTeleportAction { get; }

    /// <summary>
    /// The name of the home world server the player originates from.
    /// </summary>
    public string HomeWorldName { get; }

    /// <summary>
    /// The name of the world server the player is currently in.
    /// </summary>
    public string CurrentWorldName { get; }

    public byte GrandCompanyId { get; }

    /// <summary>
    /// Get the job information by the specified job ID.
    /// </summary>
    public JobInfo GetJobInfo(byte jobId);

    /// <summary>
    /// Returns true if the player has the specified item in their inventory.
    /// </summary>
    public unsafe bool HasItemInInventory(uint itemId, uint minItemCount = 1);

    /// <summary>
    /// Get the count of the specified item in the player's inventory.
    /// </summary>
    public unsafe int GetItemCount(uint itemId);

    /// <summary>
    /// Use the specified inventory item by its item ID.
    /// </summary>
    public unsafe void UseInventoryItem(uint itemId);
}
