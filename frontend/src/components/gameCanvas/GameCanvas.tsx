import React, { useRef } from "react";
import { GameState } from "../../contracts/contracts";
import "./GameCanvas.css";
import { drawUnits } from "./gameCanvasUtils";

const GameCanvas = (gameState: GameState) => {
  const canvasRef = useRef<HTMLCanvasElement>(null);

  if (canvasRef.current) {
    const context = canvasRef.current.getContext("2d");
    drawUnits(context!, gameState.rightPlayerState.units, true);
    drawUnits(context!, gameState.leftPlayerState.units, false);
  }

  return (
    <div>
      <img
        src="images/bokstai.jpg"
        className="background"
        alt="Backgound with trees"
      />
      <canvas ref={canvasRef} width={1024} height={575} />
    </div>
  );
};

export default GameCanvas;
