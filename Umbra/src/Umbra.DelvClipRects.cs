﻿using System;
using System.Collections.Generic;
using System.Numerics;
using Umbra.Common;

namespace Umbra;

/// <summary>
/// Manages a shared clip region collection for DelvUI that ensures that DelvUI
/// does not capture input events inside the managed regions.
/// </summary>
[Service]
internal sealed class UmbraDelvClipRects : IDisposable
{
    private readonly HashSet<string> _managedRects = [];

    private readonly Dictionary<string, Vector4> _clipRects =
        Framework.DalamudPlugin.GetOrCreateData<Dictionary<string, Vector4>>("DelvUI.ClipRects", () => new());

    public void Dispose()
    {
        foreach (var key in _managedRects) {
            _clipRects.Remove(key);
        }

        Framework.DalamudPlugin.RelinquishData("DelvUI.ClipRects");
    }

    /// <summary>
    /// Stores a clip rect with the given bounds (left, top, right, bottom).
    /// </summary>
    public void SetClipRect(string name, Vector4 rect)
    {
        _clipRects[name] = rect;
        _managedRects.Add(name);
    }

    /// <summary>
    /// Removes a clip rect by name.
    /// </summary>
    public void RemoveClipRect(string name)
    {
        _clipRects.Remove(name);
        _managedRects.Remove(name);
    }

    /// <summary>
    /// Sets a clip rect by name with the given position and size.
    /// </summary>
    public void SetClipRect(string name, Vector2 position, Vector2 size)
    {
        SetClipRect(name, new(position.X, position.Y, position.X + size.X, position.Y + size.Y));
    }
}