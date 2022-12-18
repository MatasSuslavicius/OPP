import { Level, PlayerType } from "../../contracts/contracts";
import IconButton from "../buttons/IconButton";
import { InterfaceMediatorProps } from "../interface/Interface";
import "./ArmyView.css";

interface ArmyViewProps {
  interfaceMediator: InterfaceMediatorProps;
  onLevelUpClick: () => void;
}

const ArmyView = ({ interfaceMediator, onLevelUpClick }: ArmyViewProps) => {
  const level =
    interfaceMediator.playerType === PlayerType.Right
      ? interfaceMediator.gameState.rightPlayerState.level
      : interfaceMediator.gameState.leftPlayerState.level;

  const army =
    interfaceMediator.playerType === PlayerType.Right
      ? interfaceMediator.gameState.rightPlayerState.army
      : interfaceMediator.gameState.leftPlayerState.army;

  return (
    <div className="army-view-container">
      <div className="army-view-container-row">
        <IconButton
          onClick={onLevelUpClick}
          image="images/ArmyLogo.png"
          label="Your army"
        >
          Units: {army.unitCount}
        </IconButton>
      </div>
      <div className="army-view-container-row">
        <IconButton
          onClick={() => interfaceMediator.onBuyUnitClick("Soldier")}
          image={`images/${Level[level]}Soldier.svg`}
          label="Soldier Legion"
        >
          Units: {army.children[0].unitCount}
        </IconButton>
        <IconButton
          onClick={() => interfaceMediator.onBuyUnitClick("Scout")}
          image={`images/${Level[level]}Scout.svg`}
          label="Scout Legion"
        >
          Units: {army.children[1].unitCount}
        </IconButton>
        <IconButton
          onClick={() => interfaceMediator.onBuyUnitClick("Tank")}
          image={`images/${Level[level]}Tank.svg`}
          label="Tank Legion"
        >
          Units: {army.children[2].unitCount}
        </IconButton>
      </div>
      <div className="army-view-container-row"></div>
    </div>
  );
};

export default ArmyView;
