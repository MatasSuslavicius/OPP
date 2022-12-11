 import axios from "axios";
import { useState } from "react";
import { GameState, PlayerType } from "../../contracts/contracts";
import { UrlManager } from "../../Utils/UrlManager";
import ArmyView from "../armyView/ArmyView";
import IconButton from "../buttons/IconButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

interface InterfaceProps {
  gameState: GameState;
  playerType: PlayerType;
  onBuyUnitClick: (unitType: string) => void;
  onBuyTurretClick: () => void;
  onBuyTurretUpgradeClick: (turretType: string) => void;
  onUndoTurretUpgradeClick: () => void;
  onSellTurretClick: () => void;
}

const Interface = ({
  gameState,
  playerType,
  onBuyUnitClick,
  onBuyTurretClick,
  onBuyTurretUpgradeClick,
  onUndoTurretUpgradeClick,
  onSellTurretClick,
}: InterfaceProps) => {
  const [isGamePaused, setIsGamePaused] = useState<boolean>(false);
  const handleLevelUpClick = () => {
    axios({
      method: "post",
      url: UrlManager.getLevelUpEndpoint(),
      params: {
        isRightPlayer: playerType === PlayerType.Right,
      },
    });
  };
  const resetButtonAction = () => {
    axios.post(UrlManager.getResetLevelEndpoint());
  };
  return (
    <div className={`interface-container player-type-${playerType}`}>
      <div className="interface">
        {(playerType === PlayerType.Spectator && <h2>Spectating</h2>) || (
          <div className="army-control-container">
            {playerType !== PlayerType.Spectator && (
              <ArmyView
                level={
                  playerType === PlayerType.Right
                    ? gameState.rightPlayerState.level
                    : gameState.leftPlayerState.level
                }
                onBuyUnitClick={onBuyUnitClick}
                onLevelUpClick={handleLevelUpClick}
                army={
                  playerType === PlayerType.Right
                    ? gameState.rightPlayerState.army
                    : gameState.leftPlayerState.army
                }
              />
            )}
          </div>
        )}

        <div className="game-views-conatainer">
          <GameCanvas {...gameState} />
          <div className="turret-control-container">
            <IconButton
              image=""
              label="Buy Turret"
              onClick={() => onBuyTurretClick()}
            />
            <IconButton
              image=""
              label="Sell Turret"
              onClick={() => onSellTurretClick()}
            />
            <IconButton
              image=""
              label="Upg. Turret Damage"
              onClick={() => onBuyTurretUpgradeClick("damage")}
            />
            <IconButton
              image=""
              label="Upg. Turret Range"
              onClick={() => onBuyTurretUpgradeClick("range")}
            />
            <IconButton
              image=""
              label="Upg. Turret Speed"
              onClick={() => onBuyTurretUpgradeClick("speed")}
            />
            <IconButton
              image=""
              label="Undo Upgrade"
              onClick={() => onUndoTurretUpgradeClick()}
            />
            <IconButton
              image=""
              label={isGamePaused ? `Unpause` : `Pause`}
              onClick={() => {
                axios.post(UrlManager.getPauseEndpoint(!isGamePaused));
                setIsGamePaused(!isGamePaused);
              }}
            />
          </div>
        </div>
        {(playerType === PlayerType.Left && (
          <div className="control-container">
            <h3>Money: {gameState.leftPlayerState.money}</h3>
            <h3>Experience: {gameState.leftPlayerState.experience}</h3>
          </div>
        )) ||
          (playerType === PlayerType.Right && (
            <div className="control-container">
              <h3> Money</h3>{" "}
              <h3>
                {":  "}
                {gameState.rightPlayerState.money}
              </h3>
              <h3> Experience</h3>
              <h3>
                {":  "}
                {gameState.rightPlayerState.experience}
              </h3>
            </div>
          ))}
        <button onClick={resetButtonAction}>Reset Level</button>
      </div>
    </div>
  );
};

export default Interface;
