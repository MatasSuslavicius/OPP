import './App.css';

function App(): JSX.Element {
  const myStyle = {
    backgroundImage: 'url(/background.JPG)',
    height: '80vh',
    backgroundSize: 'cover',
    backgroundRepeat: 'no-repeat'
  }

  return (
    <div style={myStyle}>
      zzz
    </div>
  )
}

export default App;