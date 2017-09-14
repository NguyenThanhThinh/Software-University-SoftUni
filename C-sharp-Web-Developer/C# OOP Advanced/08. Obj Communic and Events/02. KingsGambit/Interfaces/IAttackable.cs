using System;

public interface IAttackable
{
    void OnKingUnderAttack(Object sender, EventArgs arg);

    string Name { get; }
}