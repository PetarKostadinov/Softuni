import { useReducer } from 'react';
import './App.css';

const reducer = (state, action) => {
  switch (action.type) {
    case 'INCREMENT':
      return { count: state.count + 1, text: state.count % 2 !== 0 ? 'even' : 'odd' }

    default:
      return state;
  }
}

function App() {

  const [state, dispatch] = useReducer(reducer, { count: 0, text: 'neutral' })

  return (
    <div className="App">
      <p>{state.count}</p>
      <button
        onClick={() => dispatch({ type: 'INCREMENT' })}
      >Increment and change the text</button>
      {<p>{state.text}</p>}
    </div>
  );
}

export default App;
