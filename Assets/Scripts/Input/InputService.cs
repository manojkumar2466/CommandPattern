using Command.Main;
using Command.Player;
using Command.Actions;

namespace Command.Input
{
    public class InputService
    {
        private MouseInputHandler mouseInputHandler;

        private InputState currentState;
        private CommandType selectedCommandType;
        private TargetType targetType;

        public InputService()
        {
            mouseInputHandler = new MouseInputHandler(this);
            SetInputState(InputState.INACTIVE);
            SubscribeToEvents();
        }

        public void SetInputState(InputState inputStateToSet) => currentState = inputStateToSet;

        private void SubscribeToEvents() => GameService.Instance.EventService.OnActionSelected.AddListener(OnActionSelected);

        public void UpdateInputService()
        {
            if(currentState == InputState.SELECTING_TARGET)
                mouseInputHandler.HandleTargetSelection(targetType);
        }

        public void OnActionSelected(CommandType selectedActionType)
        {
            this.selectedActionType = selectedActionType;
            SetInputState(InputState.SELECTING_TARGET);
            TargetType targetType = SetTargetType(selectedActionType);
            ShowTargetSelectionUI(targetType);
        }

        private void ShowTargetSelectionUI(TargetType selectedTargetType)
        {
            int playerID = GameService.Instance.PlayerService.ActivePlayerID;
            GameService.Instance.UIService.ShowTargetOverlay(playerID, selectedTargetType);
        }

        private TargetType SetTargetType(CommandType selectedActionType) => targetType = GameService.Instance.ActionService.GetTargetTypeForAction(selectedActionType);

        public void OnTargetSelected(UnitController targetUnit)
        {
            SetInputState(InputState.EXECUTING_INPUT);
            IUnitCommand unitCommand= CreateUnitCommand(targetUnit);

           //GameService.Instance.
        }

        private CommandData CreateCommandData(UnitController targetUnit)
        {
            CommandData commandData = new CommandData(GameService.Instance.PlayerService.ActiveUnitID,
                                                        targetUnit.UnitID,
                                                        GameService.Instance.PlayerService.ActivePlayerID,
                                                        targetUnit.Owner.PlayerID);
            return commandData;
        }

        private IUnitCommand CreateUnitCommand(UnitController targetUnit)
        {
            CommandData commandData = CreateCommandData(targetUnit);

            IUnitCommand unitCommand;
            switch (selectedCommandType)
            {
                case CommandType.Attack:
                    unitCommand = new AttackCommand(commandData);
                    break;
                case CommandType.AttackStance:
                    unitCommand = new AttackStanceCommand(commandData);
                    break;
                case CommandType.BerserkAttack:
                    unitCommand = new BeserkAttackCommand(commandData);
                    break;
                case CommandType.Cleanse:
                    unitCommand = new CleanseCommand(commandData);
                    break;
                case CommandType.Heal:
                    unitCommand = new HealCommand(commandData);
                    break;
                case CommandType.Meditate:
                    unitCommand = new MeditateCommand(commandData);
                    break;
                case CommandType.ThirdEye:
                    unitCommand = new ThirdEyeCommand(commandData);
                    break;
                default:
                    throw new System.Exception("unit command not found");

            }
            return unitCommand;

        }

    }
}