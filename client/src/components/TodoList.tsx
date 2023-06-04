import React, {useEffect} from 'react';
import {useTypedSelector} from "../hooks/useTypedSelector";
import {Todo, TodoActionTypes} from "../types/todo";
import TodoItem from "./TodoItem";
import {fetchTodo} from "../store/action-creators/todo";
import {AppDispatch} from "../store";

const TodoList = () => {

    const todoState = useTypedSelector(state=>state.todos);

    const dispatch = AppDispatch;

    useEffect(()=>{
        dispatch(fetchTodo());
    },[])

    return (
        <div className="todo-container">
            {todoState.todos.sort(a=>a.isCompleted?1:-1).map((todo:Todo)=> {
                        return <TodoItem key={todo.id} id={todo.id} expirationDate={todo.expirationDate}
                                            categoryName={todo.id.toString()} title={todo.title}
                                            isCompleted={todo.isCompleted}/>
                }
                )}
            <div>{todoState.error?"fail":"OK"}</div>
        </div>
    );
};

export default TodoList;
