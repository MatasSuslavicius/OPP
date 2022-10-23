import "./LobbyInfo.css";
import { PlayerInfo, PlayerStatus } from "./PlayerInfo/PlayerInfo";

export function LobbyInfo(): JSX.Element {
    return (
        <div className="lobbyInfo">
            <PlayerInfo
                playerName="First player" 
                playerStatus={PlayerStatus.Online} 
            />
            <PlayerInfo
                playerName="Second player" 
                playerStatus={PlayerStatus.Offline} 
            />
            <PlayerInfo
                playerName="Spectators" 
                playerStatus={0}
                isForVisitors={true}
            />
        </div>
    );
}