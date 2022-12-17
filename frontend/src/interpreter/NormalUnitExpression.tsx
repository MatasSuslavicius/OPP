import React from "react";
import { AbstractExpression } from "./AbstractExpression";
import { GameContext } from "./GameContext";

export class NormalUnitExpression extends AbstractExpression {
  public Interpret(ctx: GameContext): void {
    console.log("Interpreter normal.");
    ctx.CreateNormal();
  }
}
