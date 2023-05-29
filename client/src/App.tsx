import React from 'react';
import TodoList from "./components/TodoList";
import TodoInput from "./components/TodoInput";


function App() {

    return (
    <div style={{display:"flex",justifyContent:"center",flexDirection:"column"}}>
        <TodoList />
        <TodoInput />
    </div>
  );
}

export default App;
