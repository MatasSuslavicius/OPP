import { useState } from "react";
import { GameState } from "../../contracts/contracts";
import { BuyButton } from "../buttons/BuyButton";
import GameCanvas from "../gameCanvas/GameCanvas";
import "./Interface.css";

const Interface = (gameState: GameState) => {
  return (
    <div>
      <div className="interface">
        <div className="control-container">
          <BuyButton />
        </div>
        <div>
          <GameCanvas {...gameState} />
        </div>
      </div>
    </div>
  );
};

export default Interface;
