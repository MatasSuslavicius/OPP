import './Button.scss';

interface ButtonProps {
  onClick: () => void
}

export function Button(props: ButtonProps): JSX.Element {
  return (
    <div className='button'>
      <button onClick={props.onClick}/>
    </div>
  )
}
