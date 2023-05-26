import { useState } from 'react';
import './App.css';

function App() {

  const [count, setCount] = useState(0)
  const [showText, setSowText] = useState(false)
  const [write, setWrite] = useState('Pesho')

  return (
    <div className="App">
      <p>{count}</p>
      <button
        onClick={() => { setCount(count + 1); setSowText(!showText) }}
      >INCREMENT</button>
      <p>{showText ? <p>odd</p> : <p>even</p>}</p>
      <input placeholder='write a text '
        onChange={(e) => setWrite(e.target.value)}
      ></input>
      <p>{write}</p>
    </div>
  );
}

export default App;
