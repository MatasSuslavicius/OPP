export enum PlayerType {
  Default,
  Left = 1,
  Right = 2,
  Spectator = 3,
}

export const INITIAL_GAME_STATE: GameState = {
  rightPlayerState: { units: [] , money: 500, experience: 0},
  leftPlayerState: { units: [] , money: 500, experience: 0},
};

export interface GameState {
  rightPlayerState: PlayerState;
  leftPlayerState: PlayerState;
}

export interface PlayerState {
  units: Unit[];
  money: number;
  experience: number;
}

export interface Unit {
  position: Vector2;
  scale: Vector2;
}

export interface Vector2 {
  x: number;
  y: number;
}
