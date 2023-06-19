import React, {useEffect, useState} from 'react';
import {useTypedSelector} from "../hooks/useTypedSelector";
import {Todo} from "../types/todo";
import TodoItem from "./TodoItem";
import {fetchTodo} from "../store/action-creators/todo";
import {AppDispatch} from "../store";
import TodoInput from "./TodoInput";


enum storeType{
    XML,
    DB
}

const TodoList = () => {

    const state = useTypedSelector(state=>state);

    const todoState = state.todos;



    const dispatch = AppDispatch;

    useEffect(()=>{
        dispatch(fetchTodo());
    },[])


    return (
        <div className="todo-container">
            {todoState.todos.sort(a=>a.isCompleted?1:-1).map((todo:Todo)=> {
                        return <TodoItem key={todo.id} category={todo.category} id={todo.id} expirationDate={todo.expirationDate}
                                            categoryId={todo.categoryId} title={todo.title}
                                            isCompleted={todo.isCompleted}/>
                }
                )}
            <TodoInput />
        </div>
    );
};

export default TodoList;
