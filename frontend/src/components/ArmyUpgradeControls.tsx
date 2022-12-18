import IconButton from "./buttons/IconButton";
import { InterfaceMediatorProps } from "./interface/Interface";

interface ArmyUpgradeControlsProps {
  interfaceMediator: InterfaceMediatorProps;
}

export const ArmyUpgradeControls = ({
  interfaceMediator,
}: ArmyUpgradeControlsProps) => {
  return (
    <div className="turret-control-container">
      <IconButton
        image=""
        label="Undo Upgrade"
        onClick={() => interfaceMediator.onUndoTurretUpgradeClick()}
      />
      <IconButton
        image=""
        label="Upg. Army Damage"
        onClick={() => interfaceMediator.onBuyArmyUpgradeClick("armyDamage")}
      />
      <IconButton
        image=""
        label="Upg. Army Health"
        onClick={() => interfaceMediator.onBuyArmyUpgradeClick("armyHealth")}
      />
    </div>
  );
};
