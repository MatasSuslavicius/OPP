import { useState } from "react";
import { BuyButton } from "../buttons/BuyButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

const Interface = () => {
  const [test, setTest] = useState(0);

  return (
    <div>
      <div className="interface">
        <div className="control-container">
          <BuyButton onClick={() => setTest(Math.random())} />
        </div>
        <div>
          <GameCanvas
            unitPositions={[{ position: { x: test, y: 50 }, isEnemy: false }]}
          />
        </div>
      </div>
    </div>
  );
};

export default Interface;
