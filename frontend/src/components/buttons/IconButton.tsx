import "./IconButton.css";

interface IconButtonProps {
  onClick: () => void;
  label: string;
  image: string;
  alt?: string;
  children?: React.ReactNode;
}

const IconButton = ({
  onClick,
  label,
  image,
  alt,
  children,
}: IconButtonProps) => {
  return (
    <div className="icon-button-container" onClick={onClick}>
      <span className="icon-button-label">{label}</span>
      <img src={image} className="icon-button-image" alt={alt} />
      {children}
    </div>
  );
};

export default IconButton;
