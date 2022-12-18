import axios from "axios";
import { GameState, PlayerType } from "../../contracts/contracts";
import { UrlManager } from "../../Utils/UrlManager";
import { ArmyUpgradeControls } from "../ArmyUpgradeControls";
import ArmyView from "../armyView/ArmyView";
import GameCanvas from "../gameCanvas/GameCanvas";
import { PlayerStatsDisplay } from "../PlayerStatsDisplay";
import { TurretUpgradeControls } from "../TurretUpgradeControls";
import "./Interface.css";

export interface InterfaceMediatorProps {
  gameState: GameState;
  playerType: PlayerType;
  onBuyUnitClick: (unitType: string) => void;
  onBuyTurretClick: () => void;
  onBuyTurretUpgradeClick: (turretType: string) => void;
  onUndoTurretUpgradeClick: () => void;
  onSellTurretClick: () => void;
  onBuyArmyUpgradeClick: (unitUpgradeType: string) => void;
}

const InterfaceMediator = (props: InterfaceMediatorProps) => {
  const handleLevelUpClick = () => {
    axios({
      method: "post",
      url: UrlManager.getLevelUpEndpoint(),
      params: {
        isRightPlayer: props.playerType === PlayerType.Right,
      },
    });
  };
  const resetButtonAction = () => {
    axios.post(UrlManager.getResetLevelEndpoint());
  };
  return (
    <div className={`interface-container player-type-${props.playerType}`}>
      <div className="interface">
        {(props.playerType === PlayerType.Spectator && <h2>Spectating</h2>) || (
          <div className="army-control-container">
            {props.playerType !== PlayerType.Spectator && (
              <ArmyView
                interfaceMediator={props}
                onLevelUpClick={handleLevelUpClick}
              />
            )}
          </div>
        )}

        <div className="game-views-conatainer">
          <GameCanvas {...props.gameState} />
          <TurretUpgradeControls interfaceMediator={props} />
          <ArmyUpgradeControls interfaceMediator={props} />
        </div>
        <PlayerStatsDisplay interfaceMediator={props} />
        <button onClick={resetButtonAction}>Reset Level</button>
      </div>
    </div>
  );
};

export default InterfaceMediator;
