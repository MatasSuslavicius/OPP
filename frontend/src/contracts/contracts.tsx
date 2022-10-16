export enum PlayerType {
  Left = 1,
  Right = 2,
  Spectator = 3,
}

export const INITIAL_GAME_STATE: GameState = {
  rightPlayerState: { units: [] },
  leftPlayerState: { units: [] },
};

export interface GameState {
  rightPlayerState: PlayerState;
  leftPlayerState: PlayerState;
}

export interface PlayerState {
  units: Unit[];
}

export interface Unit {
  position: Vector2;
  scale: Vector2;
}

export interface Vector2 {
  x: number;
  y: number;
}
