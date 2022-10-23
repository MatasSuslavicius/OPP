import { Component, useEffect, useState } from "react";
import { PlayerType } from "../../contracts/contracts";
import { PlayButton } from "../buttons/PlayButton";
import "./Lobby.css";
import { LobbyInfo } from "./lobbyInfo/LobbyInfo";
import Cookies from 'universal-cookie';
import axios from "axios";
import { UrlManager } from "../../Utils/UrlManager";

interface LobbyProps {
    startGameCallback: (value: boolean) => void;
}

export function Lobby(props: LobbyProps): JSX.Element {
    const cookies = new Cookies();
    const [userId, setUserId] = useState<String>(cookies.get('UserId'));
    const [loading, setLoading] = useState<boolean>(false);

    const getUserId = (): String => {
        if (!userId || userId.length === 0) {
            let tempId = crypto.randomUUID();
            setUserId(tempId);
            cookies.set('UserId', tempId, { path: '/' });
            return tempId;
        }

        return userId;
    };

    const setPlayerToSpectator = async () => {
        await axios.post(UrlManager.getSetPlayerTypeEndpoint(getUserId(), PlayerType.Spectator));
    };

    useEffect(() => {
        async function join() {
            setLoading(true);
            await axios.post(UrlManager.getJoinGameEndpoint(userId));
            setLoading(false);
        };

        join();
    }, []);

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
                        loading={loading}
                    />
                    <PlayButton
                        onClick={setPlayerToSpectator}
                        text={"Join As Spectator"}
                        loading={loading}
                    />
                </div>
            </div>
            <div className="connectionInfo">
                <LobbyInfo />
            </div>
        </div>
    );
}