import React, {useEffect} from 'react';
import {useTypedSelector} from "../hooks/useTypedSelector";
import {Todo} from "../types/todo";
import TodoItem from "./TodoItem";
import {fetchTodo} from "../store/action-creators/todo";
import {AppDispatch} from "../store";

const TodoList = () => {

    const state = useTypedSelector(state=>state);
    const todoState = state.todos;
    const categoryState = state.categories;

    const dispatch = AppDispatch;

    useEffect(()=>{
        dispatch(fetchTodo());
    },[])

    return (
        <div className="todo-container">
            {todoState.todos.sort(a=>a.isCompleted?1:-1).map((todo:Todo)=> {
                        return <TodoItem key={todo.id} id={todo.id} expirationDate={todo.expirationDate}
                                            categoryId={todo.categoryId} title={todo.title}
                                            isCompleted={todo.isCompleted}/>
                }
                )}
            <div>{
               todoState.error
            }</div>
        <div>{categoryState.error}</div>
        </div>
    );
};

export default TodoList;
