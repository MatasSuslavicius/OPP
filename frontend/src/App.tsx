import { useState } from "react";
import "./App.css";
import ConnectedInterface from "./components/connectedInterface/ConnectedInterface";
import { Lobby } from "./components/lobby/Lobby";

function App(): JSX.Element {
  const [gameStarted, setGameStarted] = useState<boolean>();

  if (!gameStarted)
    return (
      <Lobby
        startGameCallback={setGameStarted}
      />);

  return <ConnectedInterface />;
}

export default App;
