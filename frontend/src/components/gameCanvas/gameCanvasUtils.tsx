import { Turret, Unit, Vector2 } from "../../contracts/contracts";

export const drawUnits = (
  ctx: CanvasRenderingContext2D,
  units: Unit[],
  isRightPlayer: boolean
) => {
  units.forEach((unit) => {
    drawUnit(ctx, unit, isRightPlayer);
  });
};

export const drawTurret = (
  ctx: CanvasRenderingContext2D,
  turret: Turret | null,
  isRightPlayer: boolean
) => {
  if (turret) {
    ctx.fillStyle = isRightPlayer ? "red" : "blue";
    const turretPosition = worldToScreenCoordinates(turret.position);
    const turretScale: Vector2 = { x: 50, y: 50 };
    ctx.fillRect(turretPosition.x, 210, turretScale.x, turretScale.y);
  }
};

export const drawUnit = (
  ctx: CanvasRenderingContext2D,
  unit: Unit,
  isRightPlayer: boolean
) => {
  ctx.beginPath();
  ctx.fillStyle = isRightPlayer ? "red" : "blue";
  const position = worldToScreenCoordinates(unit.position);
  const scale = worldToScreenScale(unit.scale);

  const image = new Image();
  image.src = getImageSource(unit.type, isRightPlayer);

  ctx.drawImage(
    image,
    position.x - scale.x / 2,
    unit.type === "fast" ? position.y - 23 : position.y,
    scale.x,
    scale.y
  );

  drawHealthBar(ctx, unit);
};

const getImageSource = (unitType: string, isRightPlayer: boolean): string => {
  if (!isRightPlayer) {
    switch (unitType) {
      case "StoneAgeTank":
        return "images/Level1Units/SlowUnit.svg";
      case "StoneAgeSoldier":
        return "images/Level1Units/NormalUnit.svg";
      case "StoneAgeScout":
        return "images/Level1Units/FastUnit.svg";
      case "BronzeAgeTank":
        return "images/Level2Units/SlowUnit.svg";
      case "BronzeAgeSoldier":
        return "images/Level2Units/NormalUnit.svg";
      case "BronzeAgeScout":
        return "images/Level2Units/FastUnit.svg";
      case "LevelUpUnit":
        return "images/LevelUpUnit.svg";
    }
  } else {
    switch (unitType) {
      case "StoneAgeTank":
        return "images/Level1Units/SlowUnit2.svg";
      case "StoneAgeSoldier":
        return "images/Level1Units/NormalUnit2.svg";
      case "StoneAgeScout":
        return "images/Level1Units/FastUnit2.svg";
      case "BronzeAgeTank":
        return "images/Level2Units/SlowUnit2.svg";
      case "BronzeAgeSoldier":
        return "images/Level2Units/NormalUnit2.svg";
      case "BronzeAgeScout":
        return "images/Level2Units/FastUnit2.svg";
      case "LevelUpUnit":
        return "images/LevelUpUnit.svg";
    }
  }
  return "";
};

const drawHealthBar = (ctx: CanvasRenderingContext2D, unit: Unit) => {
  ctx.beginPath();
  const unitPosition = worldToScreenCoordinates(unit.position);
  const unitScale = worldToScreenScale(unit.scale);
  const healtBarPosition: Vector2 = {
    x: unitPosition.x,
    y: unitPosition.y - unit.scale.y - 20,
  };
  const healthBarScale = { x: unitScale.x, y: 10 };

  // ctx.fillStyle = "red";
  // ctx.fillRect(
  //   healtBarPosition.x - unitScale.x / 2,
  //   healtBarPosition.y,
  //   healthBarScale.x,
  //   healthBarScale.y
  // );

  ctx.fillStyle = "green";
  ctx.fillRect(
    healtBarPosition.x - unitScale.x / 2,
    healtBarPosition.y,
    healthBarScale.x * (unit.health / unit.initialHealth),
    healthBarScale.y
  );
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
    Assuming Canvas is always 1024 by 575 */
  return {
    x: ((worldPosition.x + 10) * (1024 - 150)) / 20 + 75,
    y: 490 + worldPosition.y * 0.1,
  };
};
