import "./Button.css";

interface ButtonProps {
  onClick?: () => void;
}

export const BuyButton = (props: ButtonProps) => {
  return (
    <div>
      <button className="button" onClick={props.onClick}>
        Buy Unit1
      </button>
    </div>
  );
};
