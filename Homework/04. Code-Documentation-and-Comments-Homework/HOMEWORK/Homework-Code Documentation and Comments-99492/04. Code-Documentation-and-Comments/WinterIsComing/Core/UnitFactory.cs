namespace WinterIsComing.Core
{
    using WinterIsComing.Contracts;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models;
    using WinterIsComing.Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case UnitType.Mage:
                    return new Mage(x, y, name);
                case UnitType.Warrior:
                    return new Warrior(x, y, name);
                case UnitType.IceGiant:
                    return new IceGiant(x, y, name);
                default:
                    throw new GameException("Invalid creature type!");
            }
        }
    }
}