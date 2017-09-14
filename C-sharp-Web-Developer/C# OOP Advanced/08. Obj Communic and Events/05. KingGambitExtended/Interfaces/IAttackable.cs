using System;

public interface IAttackable
{
    void OnKingUnderAttack(Object sender, EventArgs arg);
    int HitCount { get; }
    string Name { get; }
}