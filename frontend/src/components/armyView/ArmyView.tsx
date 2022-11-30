import React from "react";
import { Level } from "../../contracts/contracts";
import IconButton from "../buttons/IconButton";
import "./ArmyView.css";

interface ArmyViewProps {
  level: Level;
  onBuyUnitClick: (unitType: string) => void;
  onLevelUpClick: () => void;
}

const ArmyView = ({ level, onBuyUnitClick, onLevelUpClick }: ArmyViewProps) => {
  return (
    <div className="army-view-container">
      <div className="army-view-container-row">
        <IconButton
          onClick={onLevelUpClick}
          image="images/ArmyLogo.png"
          label="Your army"
        />
      </div>
      <div className="army-view-container-row">
        <IconButton
          onClick={() => onBuyUnitClick("Soldier")}
          image={`images/${Level[level]}Soldier.svg`}
          label="Soldier Legion"
        />
        <IconButton
          onClick={() => onBuyUnitClick("Scout")}
          image={`images/${Level[level]}Scout.svg`}
          label="Scout Legion"
        />
        <IconButton
          onClick={() => onBuyUnitClick("Tank")}
          image={`images/${Level[level]}Tank.svg`}
          label="Tank Legion"
        />
      </div>
      <div className="army-view-container-row"></div>
    </div>
  );
};

export default ArmyView;
