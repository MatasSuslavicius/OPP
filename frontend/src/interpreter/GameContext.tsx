import React from "react";
import { HubConnection } from "@microsoft/signalr";

export class GameContext {
  private connection: HubConnection | undefined;

  constructor(connection: HubConnection | undefined) {
    this.connection = connection;
  }

  public CreateSlow(): void {
    this.connection?.invoke("BuyUnit", "Tank");
  }
  public CreateNormal(): void {
    this.connection?.invoke("BuyUnit", "Soldier");
  }
  public CreateFast(): void {
    this.connection?.invoke("BuyUnit", "Tank");
  }
}

// AbstractExpression x = new AbstractExpression(event, ctx);
// const result = x.interpret();
