import { Unit } from "../../contracts/contracts";

export const drawUnits = (
  ctx: CanvasRenderingContext2D,
  units: Unit[],
  isRightPlayer: boolean
) => {
  units.forEach((unit) => {
    ctx.beginPath();
    ctx.fillStyle = isRightPlayer ? "red" : "blue";
    ctx.fillRect(unit.position.x, unit.position.y, unit.scale.x, unit.scale.y);
  });
};

export const clearCanvas = (ctx: CanvasRenderingContext2D) => {
  ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
};
