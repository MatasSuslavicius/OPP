import "./PlayButton.css";

interface ButtonProps {
  text: string;
  onClick: () => void;
}

export const PlayButton = (props: ButtonProps) => {
  return (
    <div>
      <button className="btn-slice" onClick={props.onClick}>
        {props.text}
      </button>
    </div>
  );
};