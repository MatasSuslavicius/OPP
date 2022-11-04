import React, { useEffect, useRef } from "react";
import { GameState } from "../../contracts/contracts";
import "./GameCanvas.css";
import { clearCanvas, drawTurret, drawUnits } from "./gameCanvasUtils";

const GameCanvas = (gameState: GameState) => {
  const canvasRef = useRef<HTMLCanvasElement>(null);

  if (canvasRef.current) {
    const context = canvasRef.current.getContext("2d");
    clearCanvas(context!);
    drawUnits(context!, gameState.rightPlayerState.units, true);
    drawUnits(context!, gameState.leftPlayerState.units, false);
    drawTurret(context!, gameState.rightPlayerState.turret, true);
    drawTurret(context!, gameState.leftPlayerState.turret, false);
  }

  return (
    <div>{gameState.leftPlayerState.level === 1 && gameState.rightPlayerState.level === 1
      ? <img
        src="images/bokstai.jpg"
        className="background"
        alt="Backgound with trees"
      />
      : <img
        src="images/bokstai2.png"
        className="background"
        alt="Backgound with trees"
      />
    }
      <canvas ref={canvasRef} width={1024} height={575} className="canvas" />
    </div>
  );
};

export default GameCanvas;
