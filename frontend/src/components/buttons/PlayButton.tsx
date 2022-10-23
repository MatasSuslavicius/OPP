import { useState } from "react";
import "./PlayButton.css";

interface ButtonProps {
  text: string;
  onClick: () => void;
  loading: boolean;
}

export const PlayButton = (props: ButtonProps) => {
  const [buttonClicked, setButtonClicked] = useState<boolean>(false);

  const onclick = () => {
    setButtonClicked(true);
    props.onClick();
  }

  return (
    <div>
      <button 
      className={`btn-slice ${ buttonClicked || props.loading ? `btn-disabled` : ""}`} 
      onClick={onclick} 
      disabled={buttonClicked || props.loading}>
        {props.text}
      </button>
    </div>
  );
};