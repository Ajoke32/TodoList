import React from 'react';
import {useTypedSelector} from "../hooks/useTypedSelector";
import {Todo} from "../types/todo";
import TodoItem from "./TodoItem";

const TodoList = () => {

    const todoState = useTypedSelector(state=>state.todos);


    return (
        <div className="todo-container">
            {todoState.todos.sort(a=>a.isCompleted?1:-1).map((todo:Todo, index)=> {
                        return <TodoItem key={index} id={todo.id} expirationDate={todo.expirationDate}
                                            categoryName={todo.categoryName} title={todo.title}
                                            isCompleted={todo.isCompleted}/>
                }
                )}
        </div>
    );
};

export default TodoList;
