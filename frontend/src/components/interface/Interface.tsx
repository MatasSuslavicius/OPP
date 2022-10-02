import axios from "axios";
import { GameState } from "../../contracts/contracts";
import { Button } from "../buttons/BuyButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

const Interface = (gameState: GameState) => {
  const unitButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit`);
  }
  const levelButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/LevelUp`);
  }
  const clearButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/ClearUnits`);
  }
  const resetButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit/ResetLevel`);
  }
  return (
    <div>
      <div className="interface">
        <div className="control-container">
          <Button text="Buy Units" onClick={unitButtonAction}/>
          <Button text="Level Up" onClick={levelButtonAction}/>
          <Button text="Clear Units" onClick={clearButtonAction}/>
          <Button text="Reset Level" onClick={resetButtonAction}/>
        </div>
        <div>
          <GameCanvas {...gameState} />
        </div>
      </div>
    </div>
  );
};

export default Interface;
