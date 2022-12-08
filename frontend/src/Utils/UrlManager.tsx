import { PlayerType } from "../contracts/contracts";

export abstract class UrlManager {
    private static _serverUrl: string = "https://localhost:7125";

    /** Game controller endpoints */
    private static _GameController: string = `${ UrlManager._serverUrl }/api/Game/`;

    public static getGameStreamEndpoint(){
        return `${ UrlManager._serverUrl }/game`;
    }

    public static getJoinGameEndpoint(userId: String){
        return `${UrlManager._GameController}Join?userId=${ userId }`;
    }

    public static getPlayerTypeEndpoint(userId: String){
        return `${UrlManager._GameController}PlayerType?userId=${ userId }`;
    }

    public static getSetPlayerTypeEndpoint(userId: String, playerType: PlayerType) {
        return `${UrlManager._GameController}PlayerType?userId=${ userId }&type=${ playerType }`;
    }

    public static getPauseEndpoint(isPaused: Boolean) {
        return `${UrlManager._GameController}Pause?paused=${ isPaused }`;
    }

    /** Unit controller endpoints. */
    private static _UnitController: string = `${ UrlManager._serverUrl }/api/Unit/`;

    public static getLevelUpEndpoint(){
        return `${UrlManager._UnitController}LevelUp`;
    }

    public static getClearUnitsEndpoint(){
        return `${UrlManager._UnitController}ClearUnits`;
    }

    public static getResetLevelEndpoint(){
        return `${UrlManager._UnitController}ResetLevel`;
    }
}