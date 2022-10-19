export abstract class UrlManager {
    private static _serverUrl: string = "https://localhost:7125";

    /** Game controller endpoints */
    private static _GameController: string = `${ UrlManager._serverUrl }/game`;

    public static getGameStreamEndpoint(){
        return `${UrlManager._GameController}`;
    }

    public static getPlayerTypeEndpoint(){
        return `${UrlManager._serverUrl}/api/game/player-type`;
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