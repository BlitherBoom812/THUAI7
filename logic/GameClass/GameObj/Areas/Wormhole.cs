﻿using Preparation.Interface;
using Preparation.Utility;
using System.Collections.Generic;

namespace GameClass.GameObj.Areas;

public class Wormhole(List<WormholeCell> cells)
{
    public InVariableRange<long> HP = new(GameData.WormholeHP);
    private readonly List<WormholeCell> cells = cells;
    public List<WormholeCell> Cells => cells;
    public AtomicInt RepairNum { get; } = new AtomicInt(0);
    public bool Repair(int constructSpeed, Ship ship)
    {
        var addHP = HP.GetMaxV() - HP > constructSpeed ? constructSpeed : HP.GetMaxV() - HP;
        if (ship.MoneyPool.Money < addHP / 10)
        {
            return false;
        }
        return ship.MoneyPool.SubMoney(HP.AddRChange(addHP) / 10) > 0;
    }
    public void BeAttacked(Bullet bullet)
    {
        long subHP = bullet.AP;
        HP.SubPositiveV(subHP);
    }
    public void AddRepairNum(int add = 1)
    {
        RepairNum.Add(add);
    }
    public void SubRepairNum(int sub = 1)
    {
        RepairNum.Sub(sub);
    }
}