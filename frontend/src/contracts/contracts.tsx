export enum PlayerType {
  Default,
  Left = 1,
  Right = 2,
  Spectator = 3,
}

export enum Level {
  StoneAge = 1,
  BronzeAge = 2,
}

export interface ArmyUnit {
  unitCount: number;
  children: ArmyUnit[];
}

export const INITIAL_PLAYER_STATE: PlayerState = {
  units: [],
  money: 500,
  experience: 0,
  turret: null,
  level: 1,
  army: {
    unitCount: 0,
    children: [
      { unitCount: 0, children: [] },
      { unitCount: 0, children: [] },
      { unitCount: 0, children: [] },
    ],
  },
};

export const INITIAL_GAME_STATE: GameState = {
  rightPlayerState: INITIAL_PLAYER_STATE,
  leftPlayerState: INITIAL_PLAYER_STATE,
  isLeveledUp: false,
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
  army: ArmyUnit;
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
};
