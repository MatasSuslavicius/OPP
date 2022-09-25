import './Button.css';

interface ButtonProps {
  onClick?: () => void
}

export function Button(props: ButtonProps): JSX.Element {
  return (
    <div>
      <button className='button' onClick={props.onClick}>Buy Unit1</button>
    </div>
  )
}
