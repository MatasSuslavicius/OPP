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
}

const Interface = ({
  gameState,
  playerType,
  onBuyUnitClick,
  onBuyTurretClick,
  onBuyTurretUpgradeClick,
}: InterfaceProps) => {
  const levelButtonAction = () => {
    axios.post(UrlManager.getLevelUpEndpoint());
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
              onClick={() => onBuyUnitClick("normal")}
            />
            <Button
              text="Buy Fast Unit"
              onClick={() => onBuyUnitClick("fast")}
            />
            <Button
              text="Buy Slow Unit"
              onClick={() => onBuyUnitClick("slow")}
            />
            <Button text="Level Up" onClick={levelButtonAction} />
            <Button text="Clear Units" onClick={clearButtonAction} />
            <Button text="Reset Level" onClick={resetButtonAction} />
            <Button 
              text="Buy Turret" 
              onClick={() => onBuyTurretClick()} 
            />
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
      </div>
    </div>
  );
};

export default Interface;
