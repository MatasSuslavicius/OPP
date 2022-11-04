export enum PlayerType {
  Default,
  Left = 1,
  Right = 2,
  Spectator = 3,
}

export const INITIAL_GAME_STATE: GameState = {
  rightPlayerState: { units: [], money: 500, experience: 0, turret: null, level: 1 },
  leftPlayerState: { units: [], money: 500, experience: 0, turret: null, level: 1 },
  isLeveledUp: false
};

export interface GameState {
  rightPlayerState: PlayerState;
  leftPlayerState: PlayerState;
  isLeveledUp: boolean;
}

export interface PlayerState {
  units: Unit[];
  money: number;
  experience: number;
  turret: Turret | null;
  level: number;
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
  type: string;
}

export interface Vector2 {
  x: number;
  y: number;
}

export interface LobbyState {
  firstPlayerOnline: boolean;
  secondPlayerOnline: boolean;
  visitorCount: Number;
}

export const INITIAL_LOBBY_STATE: LobbyState = {
  firstPlayerOnline: false,
  secondPlayerOnline: false,
  visitorCount: 0,
}