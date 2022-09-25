import { Ref } from "react";
import { Unit } from "../../contracts/contracts";

export const drawUnits = (
  ctx: CanvasRenderingContext2D,
  units: Unit[],
  isRightPlayer: boolean
) => {
  units.forEach((unit) => {
    ctx.beginPath();
    ctx.fillStyle = isRightPlayer ? "red" : "blue";
    ctx.fillRect(unit.position.x, unit.position.y, 50, 50);
  });
};

export const clearCanvas = (ctx: CanvasRenderingContext2D) => {
  ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
};
