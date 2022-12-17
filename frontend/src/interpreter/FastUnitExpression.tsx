import React from "react";
import { AbstractExpression } from "./AbstractExpression";
import { GameContext } from "./GameContext";

export class FastUnitExpression extends AbstractExpression {
  public Interpret(ctx: GameContext): void {
    console.log("Interpreter slow.");
    ctx.CreateFast();
  }
}
