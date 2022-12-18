import { PlayerType } from "../contracts/contracts";
import { InterfaceMediatorProps } from "./interface/Interface";

interface PlayerStatsDisplayProps {
  interfaceMediator: InterfaceMediatorProps;
}

export const PlayerStatsDisplay = ({
  interfaceMediator,
}: PlayerStatsDisplayProps) => {
  return (
    <>
      {(interfaceMediator.playerType === PlayerType.Left && (
        <div className="control-container">
          <h3>Money: {interfaceMediator.gameState.leftPlayerState.money}</h3>
          <h3>
            Experience: {interfaceMediator.gameState.leftPlayerState.experience}
          </h3>
        </div>
      )) ||
        (interfaceMediator.playerType === PlayerType.Right && (
          <div className="control-container">
            <h3> Money</h3>{" "}
            <h3>
              {":  "}
              {interfaceMediator.gameState.rightPlayerState.money}
            </h3>
            <h3> Experience</h3>
            <h3>
              {":  "}
              {interfaceMediator.gameState.rightPlayerState.experience}
            </h3>
          </div>
        ))}
    </>
  );
};
