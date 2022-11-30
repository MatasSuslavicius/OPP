import React from "react";
import { ArmyUnit, Level } from "../../contracts/contracts";
import IconButton from "../buttons/IconButton";
import "./ArmyView.css";

interface ArmyViewProps {
  level: Level;
  onBuyUnitClick: (unitType: string) => void;
  onLevelUpClick: () => void;
  army: ArmyUnit;
}

const ArmyView = ({
  level,
  onBuyUnitClick,
  onLevelUpClick,
  army,
}: ArmyViewProps) => {
  return (
    <div className="army-view-container">
      <div className="army-view-container-row">
        <IconButton
          onClick={onLevelUpClick}
          image="images/ArmyLogo.png"
          label="Your army"
        >
          Units: {army.unitCount}
        </IconButton>
      </div>
      <div className="army-view-container-row">
        <IconButton
          onClick={() => onBuyUnitClick("Soldier")}
          image={`images/${Level[level]}Soldier.svg`}
          label="Soldier Legion"
        >
          Units: {army.children[0].unitCount}
        </IconButton>
        <IconButton
          onClick={() => onBuyUnitClick("Scout")}
          image={`images/${Level[level]}Scout.svg`}
          label="Scout Legion"
        >
          Units: {army.children[1].unitCount}
        </IconButton>
        <IconButton
          onClick={() => onBuyUnitClick("Tank")}
          image={`images/${Level[level]}Tank.svg`}
          label="Tank Legion"
        >
          Units: {army.children[2].unitCount}
        </IconButton>
      </div>
      <div className="army-view-container-row"></div>
    </div>
  );
};

export default ArmyView;
