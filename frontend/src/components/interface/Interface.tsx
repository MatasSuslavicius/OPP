import axios from "axios";
import { GameState, PlayerType } from "../../contracts/contracts";
import { Button } from "../buttons/BuyButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

interface InterfaceProps {
  gameState: GameState;
  playerType: PlayerType;
}

const Interface = ({ gameState, playerType }: InterfaceProps) => {
  const normalUnitButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/Normal`);
  };
  const fastUnitButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/Fast`);
  };
  const slowUnitButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/Slow`);
  };
  const levelButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/LevelUp`);
  };
  const clearButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/ClearUnits`);
  };
  const resetButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/ResetLevel`);
  };
  return (
    <div className={`interface-container player-type-${playerType}`}>
      <div className="interface">
        {(playerType === PlayerType.Spectator && <h2>Spectating</h2>) || (
          <div className="control-container">
            <Button text="Buy Normal Unit" onClick={normalUnitButtonAction} />
            <Button text="Buy Fast Unit" onClick={fastUnitButtonAction} />
            <Button text="Buy Slow Unit" onClick={slowUnitButtonAction} />
            <Button text="Level Up" onClick={levelButtonAction} />
            <Button text="Clear Units" onClick={clearButtonAction} />
            <Button text="Reset Level" onClick={resetButtonAction} />
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
