import React from "react";
import { GameState } from "../contracts/contracts";
import { GameContext } from "./GameContext";

export abstract class AbstractExpression {
  public abstract Interpret(ctx: GameContext): void;
}

// AbstractExpression x = new AbstractExpression(event, ctx);
// const result = x.interpret();
