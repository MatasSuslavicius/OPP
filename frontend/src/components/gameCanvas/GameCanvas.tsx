import axios from "axios";
import React, { cloneElement, useRef, useState } from "react";
import { GameState } from "../../contracts/contracts";
import { UrlManager } from "../../Utils/UrlManager";
import "./GameCanvas.css";
import { clearCanvas, drawTurret, drawUnits } from "./gameCanvasUtils";

const GameCanvas = (gameState: GameState) => {
  const canvasRef = useRef<HTMLCanvasElement>(null);
  const [isGamePaused, setIsGamePaused] = useState<boolean>(false);

  if (canvasRef.current) {
    const context = canvasRef.current.getContext("2d");
    clearCanvas(context!);
    drawUnits(context!, gameState.rightPlayerState.units, true);
    drawUnits(context!, gameState.leftPlayerState.units, false);
    drawTurret(context!, gameState.rightPlayerState.turret, true);
    drawTurret(context!, gameState.leftPlayerState.turret, false);
  }

  const onPauseButtonClick = () => {
    axios.post(UrlManager.getPauseEndpoint(!isGamePaused));
    setIsGamePaused(!isGamePaused);
  };

  return (
    <>
      <div>
        <button className="playButton" onClick={onPauseButtonClick}>
          <img
            src={isGamePaused ? `images/play.svg` : `images/pause.svg`}
            alt="PauseButton"
          />
        </button>
      </div>
      <div className="container">
        {isGamePaused && (
          <div id="overlay">
            <div id="text">Game is paused</div>
          </div>
        )}
        {gameState.leftPlayerState.level === 1 &&
        gameState.rightPlayerState.level === 1 ? (
          <img
            src="images/bokstai.jpg"
            className="background"
            alt="Backgound with trees"
          />
        ) : (
          <img
            src="images/bokstai2.png"
            className="background"
            alt="Backgound with trees"
          />
        )}
        <canvas ref={canvasRef} width={1024} height={575} className="canvas" />
      </div>
    </>
  );
};

export default GameCanvas;
