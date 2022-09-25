import axios from "axios";
import { GameState } from "../../contracts/contracts";
import { BuyButton } from "../buttons/BuyButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

const Interface = (gameState: GameState) => {
  const unitButtonAction = () => {
    axios.post(`https://localhost:7125/api/Unit`);
  }
  return (
    <div>
      <div className="interface">
        <div className="control-container">
          <BuyButton onClick={unitButtonAction}/>
        </div>
        <div>
          <GameCanvas {...gameState} />
        </div>
      </div>
    </div>
  );
};

export default Interface;
