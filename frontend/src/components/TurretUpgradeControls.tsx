import IconButton from "./buttons/IconButton";
import { InterfaceMediatorProps } from "./interface/Interface";

interface TurretUpgradeControlsProps {
  interfaceMediator: InterfaceMediatorProps;
}

export const TurretUpgradeControls = ({
  interfaceMediator,
}: TurretUpgradeControlsProps) => {
  return (
    <div className="turret-control-container">
      <IconButton
        image=""
        label="Buy Turret"
        onClick={() => interfaceMediator.onBuyTurretClick()}
      />
      <IconButton
        image=""
        label="Sell Turret"
        onClick={() => interfaceMediator.onSellTurretClick()}
      />
      <IconButton
        image=""
        label="Upg. Turret Damage"
        onClick={() => interfaceMediator.onBuyTurretUpgradeClick("damage")}
      />
      <IconButton
        image=""
        label="Upg. Turret Range"
        onClick={() => interfaceMediator.onBuyTurretUpgradeClick("range")}
      />
      <IconButton
        image=""
        label="Upg. Turret Speed"
        onClick={() => interfaceMediator.onBuyTurretUpgradeClick("speed")}
      />
    </div>
  );
};
