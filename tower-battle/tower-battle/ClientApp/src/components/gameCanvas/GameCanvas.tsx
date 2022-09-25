import React, { useRef } from "react";
import "./GameCanvas.css";
import { drawUnits, Unit } from "./gameCanvasUtils";

interface GameCanvasProps {
  unitPositions: Unit[];
}

const GameCanvas = ({ unitPositions }: GameCanvasProps) => {
  const canvasRef = useRef<HTMLCanvasElement>(null);

  if (canvasRef.current) {
    const context = canvasRef.current.getContext("2d");
    drawUnits(context!, unitPositions);
  }

  return (
    <div>
      <img src="images/bokstai.jpg" className="background" />
      <canvas ref={canvasRef} width={1024} height={575} />
    </div>
  );
};

export default GameCanvas;
