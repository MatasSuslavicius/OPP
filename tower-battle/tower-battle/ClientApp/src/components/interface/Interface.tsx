import './Interface.css'

type InterfaceProps = {
  children?: React.ReactNode;
}

export function Interface(props: InterfaceProps): JSX.Element {
  return (
    <div className='Background'>
      {props.children}
    </div>
  )
}