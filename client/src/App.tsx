import React from 'react';
import TodoList from "./components/TodoList";
import TodoInput from "./components/TodoInput";
import ChangeStore from "./components/ChangeStore";


function App() {

    return (
    <div style={{display:"flex",justifyContent:"center",flexDirection:"column"}}>
        <ChangeStore />
        <TodoList />
    </div>
  );
}

export default App;
