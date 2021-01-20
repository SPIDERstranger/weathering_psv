﻿
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{
    public interface ISavable
    {
        IValues Values { get; }
        IRefs Refs { get; }
        IInventory Inventory { get; }
    }

    public interface ISavableDefinition : ISavable
    {
        void SetValues(IValues values);
        void SetRefs(IRefs refs);
        void SetInventory(IInventory inventory);
    }

    public interface IMap : ISavable
    {
        int Width { get; }

        int Height { get; }

        ITile Get(int i, int j);
        ITile Get(Vector2Int pos);
        bool UpdateAt<T>(int i, int j) where T : ITile;
        bool UpdateAt<T>(Vector2Int pos) where T : ITile;

        Type Generate(Vector2Int pos);

    }

    public interface IMapDefinition : IMap, ISavableDefinition
    {
        void SetTile(Vector2Int pos, ITileDefinition tile);
        void OnEnable();
        void OnDisable();
        void OnConstruct();
    }
}

