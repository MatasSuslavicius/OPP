import "./Button.css";

interface ButtonProps {
  text: string;
  onClick: () => void;
}

export const Button = (props: ButtonProps) => {
  return (
    <div>
      <button className="button" onClick={props.onClick}>
        {props.text}
      </button>
    </div>
  );
};
