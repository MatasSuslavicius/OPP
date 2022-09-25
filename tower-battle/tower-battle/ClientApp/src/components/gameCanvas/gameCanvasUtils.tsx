import { Ref } from "react";

export interface Unit {
  position: { x: number; y: number };
  isEnemy: boolean;
}

export const drawUnits = (ctx: CanvasRenderingContext2D, units: Unit[]) => {
  units.forEach((unit) => {
    ctx.beginPath();
    ctx.fillStyle = "red";
    ctx.fillRect(unit.position.x, unit.position.y, 50, 50);
  });
};

export const clearCanvas = (ctx: CanvasRenderingContext2D) => {
  ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
};
