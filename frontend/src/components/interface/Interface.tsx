import axios from "axios";
import { GameState, PlayerType } from "../../contracts/contracts";
import { UrlManager } from "../../Utils/UrlManager";
import { Button } from "../buttons/BuyButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

interface InterfaceProps {
  gameState: GameState;
  playerType: PlayerType;
  onBuyUnitClick: (unitType: string) => void;
  onBuyTurretClick: () => void;
  onBuyTurretUpgradeClick: (turretType: string) => void;
  onSellTurretClick: () => void;
}

const Interface = ({
  gameState,
  playerType,
  onBuyUnitClick,
  onBuyTurretClick,
  onBuyTurretUpgradeClick,
  onSellTurretClick,
}: InterfaceProps) => {
  const levelButtonAction = () => {
    axios({
      method: "post",
      url: UrlManager.getLevelUpEndpoint(),
      data: {
        isRightPlayer: playerType === PlayerType.Right,
      },
    });
  };
  const clearButtonAction = () => {
    axios.post(UrlManager.getClearUnitsEndpoint());
  };
  const resetButtonAction = () => {
    axios.post(UrlManager.getResetLevelEndpoint());
  };
  return (
    <div className={`interface-container player-type-${playerType}`}>
      <div className="interface">
        {(playerType === PlayerType.Spectator && <h2>Spectating</h2>) || (
          <div className="control-container">
            <Button
              text="Buy Normal Unit"
              onClick={() => onBuyUnitClick("Soldier")}
            />
            <Button
              text="Buy Fast Unit"
              onClick={() => onBuyUnitClick("Scout")}
            />
            <Button
              text="Buy Slow Unit"
              onClick={() => onBuyUnitClick("Tank")}
            />
            <Button text="Level Up" onClick={levelButtonAction} />
            <Button text="Clear Units" onClick={clearButtonAction} />
            <Button text="Reset Level" onClick={resetButtonAction} />
            <Button text="Buy Turret" onClick={() => onBuyTurretClick()} />
            <Button text="Sell Turret" onClick={() => onSellTurretClick()} />
            <Button
              text="Upg. Turret Damage"
              onClick={() => onBuyTurretUpgradeClick("damage")}
            />
            <Button
              text="Upg. Turret Range"
              onClick={() => onBuyTurretUpgradeClick("range")}
            />
            <Button
              text="Upg. Turret Speed"
              onClick={() => onBuyTurretUpgradeClick("speed")}
            />
          </div>
        )}

        <div>
          <GameCanvas {...gameState} />
        </div>
        {(playerType === PlayerType.Left && (
          <div className="control-container">
            <h3> Money</h3>{" "}
            <h3>
              {":  "}
              {gameState.leftPlayerState.money}
            </h3>
            <h3> Experience</h3>
            <h3>
              {":  "}
              {gameState.leftPlayerState.experience}
            </h3>
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
      </div>
    </div>
  );
};

export default Interface;
