import { PlayButton } from "../buttons/PlayButton";
import "./Lobby.css";
import { LobbyInfo } from "./lobbyInfo/LobbyInfo";

interface LobbyProps {
    startGameCallback: (value: boolean) => void;
}

export function Lobby(props: LobbyProps): JSX.Element {
    return (
        <div className="LobbyWrapper">
            <div className="title">
            🎆Battle Towers
            </div>
            <div className="buttonsWrapper">
                <div className="buttons">
                    <PlayButton
                        onClick={() => props.startGameCallback(true)}
                        text={"Play"}
                    />
                    <PlayButton
                        onClick={() => { }} //TODO: Add functionality.
                        text={"Join As Spectator"}
                    />
                </div>
            </div>
            <div className="connectionInfo">
                <LobbyInfo />
            </div>
        </div>
    );
}