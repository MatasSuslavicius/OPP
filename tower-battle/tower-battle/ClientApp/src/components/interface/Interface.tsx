import { BuyButton } from "../buttons/BuyButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

const Interface = () => {
  return (
    <div>
      <div className="interface">
        <div className="control-container">
          <BuyButton />
        </div>
        <div>
          <GameCanvas />
        </div>
      </div>
    </div>
  );
};

export default Interface;
