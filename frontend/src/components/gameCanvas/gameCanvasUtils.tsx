import { Unit, Vector2} from "../../contracts/contracts";

export const drawUnits = (
  ctx: CanvasRenderingContext2D,
  units: Unit[],
  isRightPlayer: boolean
) => {
  units.forEach((unit) => {
    drawUnit(ctx, unit, isRightPlayer);
  });
};

export const drawUnit = (
  ctx: CanvasRenderingContext2D,
  units: Unit,
  isRightPlayer: boolean
) => {
  ctx.beginPath();
  ctx.fillStyle = isRightPlayer ? "red" : "blue";
  const position = worldToScreenCoordinates(units.position);
  const scale = worldToScreenScale(units.scale);

  ctx.fillRect(position.x - scale.x / 2, position.y, scale.x, scale.y);
};

export const clearCanvas = (ctx: CanvasRenderingContext2D) => {
  ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);
};

export const worldToScreenScale = (worldScale: Vector2) => {
  return {
    x: worldScale.x * 50,
    y: worldScale.y * 50,
  };
};

export const worldToScreenCoordinates = (worldPosition: Vector2) => {
  /* World coordinates are from -10 to 10, where 0 is the center of the screen,
   -10 is the left spawm point and 10 is the right spawn point.
   The y position in world coordinates is always 0. Assuming Canvas is always 1024 by 575 */
  return {
    x: ((worldPosition.x + 10) * (1024 - 150)) / 20 + 75,
    y: 490,
  };
};
