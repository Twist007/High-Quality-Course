namespace WinterIsComing.Core
{
    using WinterIsComing.Core.Commands;

    internal class ExtendedCommandDispacher : CommandDispatcher
    {
        public override void SeedCommands()
        {
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
            base.SeedCommands();
        }
    }
}