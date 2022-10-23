export enum PlayerType {
  Default,
  Left = 1,
  Right = 2,
  Spectator = 3,
}

export const INITIAL_GAME_STATE: GameState = {
  rightPlayerState: { units: [], money: 500, experience: 0, turret: null },
  leftPlayerState: { units: [], money: 500, experience: 0, turret: null },
};

export interface GameState {
  rightPlayerState: PlayerState;
  leftPlayerState: PlayerState;
}

export interface PlayerState {
  units: Unit[];
  money: number;
  experience: number;
  turret: Turret | null;
}

export interface Turret {
  damage: number;
  speed: number;
  range: number;
  position: Vector2;
}

export interface Unit {
  position: Vector2;
  scale: Vector2;
  initialHealth: number;
  health: number;
}

export interface Vector2 {
  x: number;
  y: number;
}
