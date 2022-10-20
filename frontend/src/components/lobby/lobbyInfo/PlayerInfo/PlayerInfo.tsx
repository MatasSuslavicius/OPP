import "./PlayerInfo.css";

export enum PlayerStatus {
    Online,
    Offline
}

interface PlayerInfoProps {
    playerName: string;
    playerStatus: PlayerStatus | Number;
    isForVisitors?: boolean;
}

export function PlayerInfo(props: PlayerInfoProps): JSX.Element {

    return (
        <div className={`PlayerInfo ${ props.isForVisitors ? "isForVisitors" : "" }`}>
            {props.isForVisitors
                ? <>
                    <div className="PlayerName">{props.playerName}</div>
                    <div className="PlayerStatus">
                        {props.playerStatus.toString()}
                    </div>
                  </>
                : <>
                    <div className="PlayerName">{props.playerName}</div>
                    <div className={`PlayerStatus ${props.playerStatus === 0 ? "on" : "off"}`}>
                        {props.playerStatus === 0 ? "Online" : "Offline"}
                    </div>
                  </>
            }
        </div>
    );
}